
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
            websocket.Opened += new EventHandler(WebSocket_Opened);
            websocket.Closed += new EventHandler(WebSocket_Closed);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(WebSocket_MessageReceived);
            websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WebSocket_Error);

            //while (websocket.State != WebSocketState.Open)
            //{
            //    await Task.Delay(100);
            //}
        }

        public void WebSocketOpen()
        {
            websocket.Open();
        }
        private void WebSocket_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show("error " + e.Exception.Message);
            Console.WriteLine("WebSocket error: " + e.Exception.Message);
            CsUtil.WriteLog("WEBSOCKET_ERROR", "WSS");
            Model.getInstance().frmFrame.lamp_ems.On = false;
        }



        private void WebSocket_Closed(object sender, EventArgs e)
        {

            var args = e as ClosedEventArgs;
            if (args != null)
            {
                CsUtil.WriteLog("WebSocket connection closed. Reason:" + args.Reason, "WSS");
                CsUtil.WriteLog("WebSocket connection closed. Reason:" + args.ToString(), "WSS");
            }
            else
            {
                CsUtil.WriteLog("WEBSOCKET_CLOSE", "WSS");
            }
            MessageBox.Show("WebSocket connection closed.");
            Console.WriteLine("WebSocket connection closed.");
            Model.getInstance().frmFrame.lamp_ems.On = false;

            Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time = DateTime.Now;
            // WebSocketOpen();
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

            var tcs = new TaskCompletionSource<string>();
            responseTasks.TryAdd(currentRequestId, tcs);


            Console.WriteLine("Message SEND : " + message);
            // 메시지 전송
            websocket.Send(message);
            Model.getInstance().set_test_csms_buffer(message); // 프리테스트용

            // 응답 대기 (타임아웃을 설정할 수도 있음)
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                cts.Token.Register(() => tcs.TrySetCanceled());
                try
                {                    
                    return await tcs.Task;
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Timeout waiting for response.");
                    return null;
                }
            }
        }
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message received: " + e.Message);
            string messageId = null;
            try
            {
                messageId = JsonConvert.DeserializeObject<JArray>(e.Message)?[1]?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message received Error: " + ex.Message);
            }

            if (messageId != null && responseTasks.TryRemove(messageId, out var tcs))
            {
                tcs.SetResult(e.Message);
            }
            else
            {
                Model.getInstance().oCPP_Comm_SendMgr.ReceivedPacket(e.Message);
            }
        }
        public async Task SendMessagePacket(string message)
        {
            if (websocket.State == WebSocketState.Open)
            {
                Logger.d("☆Send☆ OCPP CP->CSMS Call => " + message);
                Console.WriteLine("Send to Server > " + message);
                Model.getInstance().set_test_csms_buffer(message);  // 프리테스트용
                websocket.Send(message);
            }

        }
    }
}
