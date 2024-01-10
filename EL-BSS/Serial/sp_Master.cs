using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Serial
{
    public class sp_Master
    {
        static SerialPort serial;
        private static List<byte> mReceive_Data = new List<byte>();

        public static bool Open(string PortName)
        {
            try
            {
                serial = new SerialPort();

                serial.PortName = PortName;
                serial.BaudRate = 38400;
                serial.Parity = Parity.None;
                serial.DataBits = 8;
                serial.StopBits = StopBits.One;
                serial.Handshake = Handshake.None;

                serial.DataReceived += Comport1_DataReceived;
                serial.Open();

                Model.isOpen_Master = true;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void Close()
        {
            serial.Close();
        }
        private static void Comport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("수신");
            int bytesToRead = serial.BytesToRead;
            byte[] receivedData = new byte[bytesToRead];
            serial.Read(receivedData, 0, bytesToRead);

            // processData 함수에 전체 바이트 배열을 한 번에 전달
            //await Task.Run(() => processData(receivedData));
            processData(receivedData);
        }
        private static void processData(byte[] data)
        {

            // 수신된 데이터를 버퍼에 추가
            mReceive_Data.AddRange(data);

            while (true)
            {
                int startIndex = mReceive_Data.IndexOf(0xfe); // STX
                int endIndex = mReceive_Data.IndexOf(0xff); // ETX

                int endIndexlast = mReceive_Data.LastIndexOf(0xff);

                // 완전한 패킷이 수신될 때까지 기다림
                if (startIndex != -1 && endIndex != -1)
                {
                    if (mReceive_Data.IndexOf(0x06) > 0)
                    {
                        Model.masterFirmWareisAck = true;

                        Console.WriteLine("ACK 수신 -> " + Model.binBufferCount);

                    }
                    else if (mReceive_Data.IndexOf(0x15) > 0)
                    {
                        Model.masterFirmWareisNck = true;
                        Console.WriteLine("NACK 수신 -> " + Model.binBufferCount);
                    }

                    mReceive_Data.RemoveRange(0, endIndex + 1);
                    //byte[] packet = mReceive_Data.GetRange(0, ).ToArray();
                }
                else
                {
                    // 유효한 패킷이 없으면 루프 탈출
                    break;
                }
            }
        }
        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
