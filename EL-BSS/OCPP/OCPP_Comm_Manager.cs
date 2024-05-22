
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
using System.Timers;
using System.Collections.Concurrent;

namespace BatteryChangeCharger.OCPP
{
    public class OCPP_Comm_Manager
    {
        private ClientWebSocket webSocket = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        private System.Timers.Timer connectionCheckTimer;
        bool isStop = false;
        private TaskCompletionSource<string> responseCompletionSource;
        string url;
        public OCPP_Comm_Manager()
        {
            url = CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\web_socet_url.ini", "web_socet_url", "url", "ws://192.168.0.90:8181");
            //url = "ws://192.168.0.90:8181";
            ConnectAsync(url);
            connectionCheckTimer = new System.Timers.Timer(5000); // 5초마다 실행
            connectionCheckTimer.Elapsed += CheckConnectionStatus;
            connectionCheckTimer.AutoReset = true;
            connectionCheckTimer.Enabled = true;
        }

        private async void CheckConnectionStatus(object sender, ElapsedEventArgs e)
        {
            if (webSocket.State == WebSocketState.Closed || webSocket.State == WebSocketState.Aborted)
            {
                Model.getInstance().frmFrame.lamp_ems.On = false;
                connectionCheckTimer.Stop(); // 타이머 정지
                await Reconnect(url);
                connectionCheckTimer.Start(); // 타이머 재시작                
            }
            if (webSocket.State == WebSocketState.Open /*&& !Model.getInstance().is_offline*/)
            {
                Model.getInstance().frmFrame.lamp_ems.On = true;
                //for (int i = 0; i < Model.getInstance().oCPP_Comm_SendMgr.list_packet.Count; i++)
                //{
                //    await SendMessageAsync(Model.getInstance().oCPP_Comm_SendMgr.list_packet[i].mPacket.ToString());
                //}
            }
        }


        public async Task Reconnect(string url)
        {
            try
            {
                Console.WriteLine("재접속 시도 중...");
                await ConnectAsync(url); // 비동기 호출 대기
            }
            catch (Exception ex)
            {
                Console.WriteLine($"재접속 실패: {ex.Message}");
                // 연결 실패 처리, 재시도 로직 등
            }
            await Task.Delay(1000); // 재시도 전 딜레이

        }


        public async Task ConnectAsync(string uri)
        {
            webSocket = new ClientWebSocket();

            webSocket.Options.SetRequestHeader("Sec-WebSocket-Protocol", "ocpp1.6");
            webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(60);
            webSocket.Options.SetBuffer(5000, 5000);

            await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

            switch (webSocket.State)
            {
                case WebSocketState.Open:
                    Model.getInstance().frmFrame.lamp_ems.On = true;
                    Console.WriteLine("연결 성공");
                    _ = Task.Run(ReceiveMessagesAsync);
                    string a = await Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_BootNotification();

                    break;
                default:
                    if (Model.getInstance().frmFrame != null)
                        Model.getInstance().frmFrame.lamp_ems.On = false;
                    Console.WriteLine("연결 에러");
                    break;
            }

        }

        private async Task ReceiveMessagesAsync()
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        Console.WriteLine("WebSocket connection closed");
                    }
                    else
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                        Console.WriteLine("Received from server: " + receivedMessage);

                        // 응답 메시지를 기다리는 요청이 있는 경우
                        if (responseCompletionSource != null && !responseCompletionSource.Task.IsCompleted)
                        {
                            responseCompletionSource.SetResult(receivedMessage);
                        }
                        else
                        {
                            // 일반적인 메시지 처리 로직
                            // HandleGeneralMessage(receivedMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        string currentRequestId;
        public async Task<string> SendMessageAndWaitForResponse(string message)
        {
            // 메시지에서 UId 추출 및 멤버 변수에 대입
            currentRequestId = JsonConvert.DeserializeObject<JArray>(message)?[1]?.ToString();

            // 기존 TaskCompletionSource가 이미 완료된 경우를 대비해 새로 생성
            var tcs = new TaskCompletionSource<string>();
            Interlocked.Exchange(ref responseCompletionSource, tcs);

            // 메시지 보내기
            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await webSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);

            // 응답 기다리기            
            using (var cts = new CancellationTokenSource())
            {
                var delayTask = Task.Delay(5000, cts.Token);

                while (true)
                {
                    var responseTask = responseCompletionSource.Task;
                    var completedTask = await Task.WhenAny(responseTask, delayTask);

                    if (completedTask == delayTask)
                    {
                        // 타임아웃 발생
                        responseCompletionSource.TrySetResult(null);  // 타임아웃 시 null 반환
                        return null;
                    }
                    else
                    {
                        // 응답 받음
                        var response = await responseTask;
                        JArray responseObject = null;

                        try
                        {
                            responseObject = JsonConvert.DeserializeObject<JArray>(response);
                        }
                        catch (JsonException)
                        {
                            Console.WriteLine("Invalid JSON format in response: " + response);
                            // continue로 루프를 계속해서 다음 응답을 기다림
                            responseCompletionSource = new TaskCompletionSource<string>();
                            continue;
                        }

                        string responseUid = responseObject?[1]?.ToString();

                        if (responseUid == currentRequestId)
                        {
                            // UID가 일치하면 타임아웃 작업 취소
                            cts.Cancel();
                            return response;
                        }
                        else
                        {
                            // UId가 일치하지 않으면 다시 대기
                            Console.WriteLine("UID 일치 하지 않아 재대기" + responseUid);
                            responseCompletionSource = new TaskCompletionSource<string>();
                        }
                    }
                }
            }
        }


        public async Task CloseAsync()
        {
            if (webSocket != null && webSocket.State == WebSocketState.Open)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                Console.WriteLine("WebSocket closed!");
            }
        }
    }
}
