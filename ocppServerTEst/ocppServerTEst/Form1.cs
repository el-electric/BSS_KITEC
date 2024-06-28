using Fleck;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ocppServerTEst
{
    public partial class Form1 : Form
    {
        private List<IWebSocketConnection> allSockets;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allSockets = new List<IWebSocketConnection>();
            var server = new WebSocketServer("ws://0.0.0.0:8181");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    textBox1.Text += (DateTime.Now.ToString("HH:mm:ss : " + message)) + Environment.NewLine;
                    Console.WriteLine("Message: " + message);
                    //allSockets.ForEach(s => s.Send("Echo: " + message));


                    if (message.IndexOf("HeartBeat") > 0)
                    {
                        JArray jsonArray = JArray.Parse(message);
                        string uid = jsonArray[1].ToString();

                        var data = new object[]
                       {
                            3,
                            uid,
                                new
                                {
                                    currentTime = DateTime.Now.ToString(),
                                }
                       };
                        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                        allSockets.ForEach(s => s.Send(json));
                    }
                    else if (message.IndexOf("BootNotification") > 0)
                    {
                        JArray jsonArray = JArray.Parse(message);
                        string uid = jsonArray[1].ToString();


                        var data = new object[]
                        {
                            3,
                            uid,
                                new
                                {
                                    currentTime = DateTime.Now.ToString(),
                                    interval = 3600,
                                    status = "Accepted"
                                }
                        };
                        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                        allSockets.ForEach(s => s.Send(json));
                    }
                    else if (message.IndexOf("Authorize") > 0)
                    {
                        JArray jsonArray = JArray.Parse(message);
                        string uid = jsonArray[1].ToString();
                        string status = "Accepted";

                        List<string> returnBatteryId = new List<string>();

                        returnBatteryId.Add("BT-001");
                        returnBatteryId.Add("BT-002");

                        var data = new object[]
                        {
                            3,
                            uid,
                                new
                                {
                                    status = status,
                                    staionId= "elstation01",
                                    userNo= 1,
                                    userName= "홍길동",
                                    batterySetNo= 1,
                                    batterySetName= "홍길동 배터리 모음",
                                    returnBatteryIds = returnBatteryId,
                                    ticketAvailable= true,
                                    cashBalance= 100,
                                    

                                }
                        };
                        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                        allSockets.ForEach(s => s.Send(json));
                    }

                };
            });

            Console.WriteLine("Server started on ws://0.0.0.0:8181");
            Console.ReadLine(); // Keep the server running until the user presses Enter
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = "윤석진";

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            allSockets.ForEach(s => s.Send(json));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string uid = "e22f11a5-590e-461e-8550-cfc8bf79efec";

             List<string> returnBatteryId = new List<string>();

            returnBatteryId.Add("BT-001");
            returnBatteryId.Add("BT-002");

            var data = new Object[]
            {
                2,
                uid,
                "Authorize",
                    new
                    {
                    staionId= "elstation01",
                    userNo= 1,
                    userName= "홍길동",
                    batterySetNo= 1,
                    batterySetName= "홍길동 배터리 모음",
                    returnBatteryIds = returnBatteryId,
                    ticketAvailable= true,
                    cashBalance= 100,
                    type ="72"
                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            allSockets.ForEach(s => s.Send(json));
        }

    }
}