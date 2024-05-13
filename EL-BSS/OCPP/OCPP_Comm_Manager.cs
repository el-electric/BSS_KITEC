
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EL_DC_Charger.ocpp.ver16.comm;
using System.Diagnostics;
using EL_BSS;

namespace BatteryChangeCharger.OCPP
{
    public class OCPP_Comm_Manager
    {
        private ClientWebSocket webSocket = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        Timer connectionCheckTimer;
        bool isStop = false;
        string url;
        public OCPP_Comm_Manager()
        {
            url = CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\web_socet_url.ini", "web_socet_url", "url", "wss://dev.wev-charger.com:12200/ws/NYJ-TEST0001");
            ConnectAsync(url);
            connectionCheckTimer = new Timer(CheckConnectionStatus, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }
        private async void CheckConnectionStatus(object state)
        {
            if (webSocket.State == WebSocketState.Closed || webSocket.State == WebSocketState.Aborted)
            {
                // 재접속 시도
                Console.WriteLine("재접속");
                //await Reconnect(url);
            }
            if (webSocket.State == WebSocketState.Open /*&& !Model.getInstance().is_offline*/)
            {
                for (int i = 0; i < Model.getInstance().oCPP_Comm_SendMgr.list_packet.Count; i++)
                {
                    await SendMessageAsync(Model.getInstance().oCPP_Comm_SendMgr.list_packet[i].mPacket.ToString());
                }
            }
        }
        async Task ReceiveData(ClientWebSocket webSocket)
        {
            var buffer = new byte[1024 * 4]; // 버퍼 크기 설정
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Model.getInstance().oCPP_Comm_SendMgr.ReceivedPacket(receivedMessage);
                    Console.WriteLine("Received: " + receivedMessage);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
            }
        }
        public async Task ConnectAsync(string uri)
        {
            webSocket = new ClientWebSocket();

            webSocket.Options.SetRequestHeader("Sec-WebSocket-Protocol", "ocpp1.6");
            webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(5);
            webSocket.Options.SetBuffer(5000, 5000);

            await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

            switch (webSocket.State)
            {
                case WebSocketState.Open:
                    ReceiveData(webSocket);
                    Console.WriteLine("연결 성공");
                    break;
                default:
                    Console.WriteLine("연결 에러");
                    break;
            }

        }

        public async Task SendMessageAsync(string message)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                message = message.Replace("\r\n  2", "2");
                message = message.Replace("\r\n  3", "3");
                var messageBuffer = System.Text.Encoding.UTF8.GetBytes(message);
                var segment = new ArraySegment<byte>(messageBuffer);

                await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);

                if (webSocket.State == WebSocketState.Open)
                    Logger.d("＠Send Success＠ " + ": " + message);
                else
                    Logger.d("＠Send Failed＠ " + ": " + message);
            }
        }

        public async Task<string> ReceiveMessageAsync()
        {
            var buffer = new byte[1024];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            return System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
        }

        public async Task CloseAsync()
        {
            if (webSocket != null && webSocket.State == WebSocketState.Open)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                Console.WriteLine("WebSocket closed!");
            }
        }

        //public async Task ListenForMessagesAsync(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        while (!cancellationToken.IsCancellationRequested && webSocket.State == WebSocketState.Open)
        //        {

        //            string message = await ReceiveMessageAsync();
        //            Console.WriteLine($"Received message: {message}");


        //        }
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        Console.WriteLine("Message listening canceled.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in message listening: {ex.Message}");
        //    }
        //}


        public async Task Reconnect(string url)
        {
            while (webSocket.State != WebSocketState.Open)
            {
                try
                {
                    webSocket = new ClientWebSocket();
                    await webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
                    await ReceiveData(webSocket); // 재연결 후 ReceiveData 다시 호출
                }
                catch (Exception ex)
                {
                    // 연결 실패 처리, 재시도 로직 등
                }
                await Task.Delay(1000); // 재시도 전 딜레이
            }
        }
    }
}
