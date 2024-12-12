
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EL_DC_Charger.ocpp.ver16.comm;
using System.Diagnostics;
using EL_BSS;
using System.Timers;
using System.Collections.Concurrent;
using static EL_BSS.Model;
using System.Speech.Synthesis.TtsEngine;
using System.Windows.Shapes;
using WebSocket4Net;
using SuperSocket.ClientEngine;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Interop;
using System.Windows.Forms;
using System.Net.WebSockets;
using WebSocket = WebSocket4Net.WebSocket;
using WebSocketState = WebSocket4Net.WebSocketState;

namespace BatteryChangeCharger.OCPP
{
    public class OCPP_Comm_Manager
    {

        private static WebSocket websocket;
        //CancellationTokenSource cts = new CancellationTokenSource();
        //public System.Timers.Timer connectionCheckTimer;
        //bool isStop = false;
        private static ConcurrentDictionary<string, TaskCompletionSource<string>> responseTasks = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public Nullable<DateTime> Server_Disconnect_Time = null;


        string url;
        public OCPP_Comm_Manager()
        {
            url = CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\web_socet_url.ini", "web_socet_url", "url", "ws://192.168.0.59:8181");
            websocket = new WebSocket(url);
            websocket.EnableAutoSendPing = true;
            websocket.AutoSendPingInterval = 300;
            websocket.Opened += WebSocket_Opened;
            websocket.Closed += Websocket_Closed;
            websocket.MessageReceived += WebSocket_MessageReceived;
            websocket.Error += Websocket_Error;

            //while (websocket.State != WebSocketState.Open)
            //{
            //    await Task.Delay(100);
            //}
        }

        private void Websocket_Closed(object sender, EventArgs e)
        {
            websocket.Open();
        }

        private void Websocket_Error(object sender, ErrorEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("error " + e.Exception.Message);
            Console.WriteLine("WebSocket error: " + e.Exception.Message);
            CsUtil.WriteLog("WEBSOCKET_ERROR", "WSS");
            Model.getInstance().frmFrame.lamp_ems.On = false;
        }

        public void WebSocketOpen()
        {
            websocket.Open();
        }
        public void WebSocketClose()
        {
            //var args = e as ClosedEventArgs;
            //if (args != null)
            //{
            //    CsUtil.WriteLog("WebSocket connection closed. Reason:" + args.Reason, "WSS");
            //    CsUtil.WriteLog("WebSocket connection closed. Reason:" + args.ToString(), "WSS");
            //}
            //else
            //{
            //    CsUtil.WriteLog("WEBSOCKET_CLOSE", "WSS");
            //}
            System.Windows.Forms.MessageBox.Show("WebSocket connection closed.");
            Console.WriteLine("WebSocket connection closed.");
            Model.getInstance().frmFrame.lamp_ems.On = false;
            Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time = DateTime.Now;
        }


        public List<string> buffer = new List<string>();
        public void Send_Packet_Buffer(List<string> buffer)
        {
            if (buffer != null)
            {
                foreach (string packet in buffer)
                {
                    SendMessagePacket(packet);
                }
            }
        }





        private async void WebSocket_Opened(object sender, EventArgs e)
        {
            CsUtil.WriteLog("WEBSOCKET_OPEN", "WSS");
            Console.WriteLine("WebSocket connection opened.");
            Model.getInstance().frmFrame.lamp_ems.On = true;
            string response = await Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_BootNotification();
            Model.getInstance().set_test_csms_buffer(response);
            JArray jsonArray = JArray.Parse(response);
            if (jsonArray[2]["status"].ToString() == enumData.Accepted.ToString())
            {
                Model.getInstance().StationInfoInterval = (int)jsonArray[2]["interval"];

                Model.getInstance().frmFrame.viewForm(0);

                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInforBootNotification();
            }
        }

        public bool get_WebSocket_State()
        {
            if (websocket.State == WebSocketState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> SendMessageAndWaitForResponseAsync(string message)
        {
            if (websocket.State != WebSocketState.Open)
                return null;

            // 메시지에서 UId 추출 및 멤버 변수에 대입
            string currentRequestId = JsonConvert.DeserializeObject<JArray>(message)?[1]?.ToString();

            Console.WriteLine("Message SEND : " + message);
            var tcs = new TaskCompletionSource<string>();
            responseTasks[currentRequestId] = tcs;

            // 메시지 전송
            websocket.Send(message);
            Model.getInstance().set_test_csms_buffer(message); // 프리테스트용
            try
            {
                var timeoutTask = Task.Delay(5000); //타임아웃 설정
                var completedTask = await Task.WhenAny(tcs.Task, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    return "TIMEOUT";
                }
                else
                {
                    string response = await tcs.Task;
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("메시지 전송 에러 : " + ex.Message);
                return null;
            }
            finally
            {
                responseTasks.TryRemove(currentRequestId, out _);
            }
        }
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message received: " + e.Message + " TIMESTAMP " + DateTime.Now.ToString("hh mm ss"));
            string responseUid = JsonConvert.DeserializeObject<JArray>(e.Message)?[1]?.ToString();
            try
            {
                Model.getInstance().oCPP_Comm_SendMgr.ReceivedPacket(e.Message);

                if (responseUid != null && responseTasks.TryRemove(responseUid, out var tcs))
                {
                    tcs.SetResult(e.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message received Error: " + ex.Message);
            }
        }
        public void SendMessagePacket(string message)
        {
            if (websocket.State == WebSocketState.Open)
            {
                Logger.d("☆Send☆ OCPP CP->CSMS Call => " + message);
                // Console.WriteLine("Send to Server > " + message);
                Model.getInstance().set_test_csms_buffer(message);  // 프리테스트용
                websocket.Send(message);
            }

        }

        public async Task SendMessagePacket_without_log(string message)
        {
            if (websocket.State == WebSocketState.Open)
            {
                Model.getInstance().set_test_csms_buffer(message);  // 프리테스트용
                websocket.Send(message);
            }
        }
    }
}
