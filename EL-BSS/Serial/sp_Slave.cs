using DrakeUI.Framework;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS.Serial
{
    public class sp_Slave
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

                Model.isOpen_Slave = true;
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public static void Close()
        {
            serial.Close();
        }
        private static async void Comport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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
                if (startIndex != -1 && endIndex != -1 && endIndex - startIndex == 70)
                {
                    byte[] packet = mReceive_Data.GetRange(startIndex, 71).ToArray();

                    // 패킷 처리
                    HandlePacket(packet);

                    // 처리된 데이터 제거
                    mReceive_Data.RemoveRange(0, endIndex + 1);

                    // 버퍼에 더 이상 데이터가 없으면 반복 중단
                    if (mReceive_Data.Count == 0)
                    {
                        break;
                    }
                }
                else if (startIndex != -1 && endIndex != -1 && endIndex - startIndex != 70)
                {
                    // 처리된 데이터 제거
                    mReceive_Data.RemoveRange(0, endIndex + 1);

                    // 버퍼에 더 이상 데이터가 없으면 반복 중단
                    if (mReceive_Data.Count == 0)
                    {
                        break;
                    }
                }
                else if (startIndex != -1 && (endIndex < startIndex || endIndex == -1))
                {
                    // 완전한 패킷이 아직 도착하지 않았으면, 루프 탈출
                    break;
                }
                else if (startIndex == -1 && endIndex != -1)
                {
                    // 유효하지 않은 데이터 제거
                    mReceive_Data.RemoveRange(0, endIndexlast + 1);
                    if (mReceive_Data.Count == 0)
                    {
                        break;
                    }
                }
                else if (startIndex == -1 && endIndex == -1)
                {
                    // 유효하지 않은 데이터 제거
                    mReceive_Data.RemoveRange(0, mReceive_Data.Count);
                    if (mReceive_Data.Count == 0)
                    {
                        break;
                    }
                }
                else
                {
                    // 유효한 패킷이 없으면 루프 탈출
                    break;
                }
            }
        }

        static int slaveId = 0;
        static int masterId = 0;
        static int idx = 0;
        static byte[] temp = new byte[2];
        private static void HandlePacket(byte[] packet)
        {
            Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);



            masterId = packet[4];
            slaveId = packet[5];

            if (masterId == 2)
                idx = slaveId + 4;
            else
                idx = slaveId;

            Model.list_SlaveRecv[idx - 1].BatterArrive = EL_Manager_Conversion.getFlagByByteArray(packet[17], 7);
            Model.list_SlaveRecv[idx - 1].isDoor = EL_Manager_Conversion.getFlagByByteArray(packet[18], 6);

            if (Model.list_SlaveRecv[idx - 1].isDoor)
                Model.list_SlaveSend[idx - 1].doorOpen = false;

            Model.list_SlaveRecv[idx - 1].SeqNum = packet[19];
            Model.list_SlaveRecv[idx - 1].PowerPackStatus = EL_Manager_Conversion.getFlagByByteArray(packet[20], 7);
            Model.list_SlaveRecv[idx - 1].PowerPackVoltage = EL_Manager_Conversion.getInt_2Byte(packet[21], packet[22]);
            Model.list_SlaveRecv[idx - 1].PowerPackWattage = EL_Manager_Conversion.getInt_2Byte(packet[23], packet[24]);
            Model.list_SlaveRecv[idx - 1].BatteryCurrentVoltage = EL_Manager_Conversion.getInt_2Byte(packet[25], packet[26]);
            Model.list_SlaveRecv[idx - 1].BatteryCurrentWattage = EL_Manager_Conversion.getInt_2Byte(packet[27], packet[28]);
            Model.list_SlaveRecv[idx - 1].BatteryRequestVoltage = EL_Manager_Conversion.getInt_2Byte(packet[29], packet[30]);
            Model.list_SlaveRecv[idx - 1].BatteryRequestWattage = EL_Manager_Conversion.getInt_2Byte(packet[31], packet[32]);
            Model.list_SlaveRecv[idx - 1].BatteryMaxTemper = EL_Manager_Conversion.getInt_2Byte(packet[33], packet[34]);
            Model.list_SlaveRecv[idx - 1].BatteryMinTemper = EL_Manager_Conversion.getInt_2Byte(packet[35], packet[3]);
            Model.list_SlaveRecv[idx - 1].ProcessStatus = EL_Manager_Conversion.getInt(packet[37]);
            Model.list_SlaveRecv[idx - 1].ErrorCode = EL_Manager_Conversion.getInt_2Byte(packet[38], packet[39]);
            Model.list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]);
            Model.list_SlaveRecv[idx - 1].SOH = EL_Manager_Conversion.getInt(packet[41]);

            temp[0] = packet[50];
            temp[1] = packet[51];
            Model.list_SlaveRecv[idx - 1].BatteryType = EL_Manager_Conversion.ByteArrayToString(temp);


        }

        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
