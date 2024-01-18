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
                if (!Model.masterFirmwareUpdate_Check_Finish)
                {
                    int packetLength = 71; // 패킷의 길이

                    // STX가 있고, 충분한 길이의 데이터가 있는지 확인
                    if (startIndex != -1 && mReceive_Data.Count >= startIndex + packetLength)
                    {
                        if (mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            byte[] packet = mReceive_Data.GetRange(startIndex, packetLength).ToArray();

                            // 패킷 처리
                            HandlePacket(packet);

                            // 처리된 데이터 제거
                            mReceive_Data.RemoveRange(0, startIndex + packetLength);


                            // 버퍼에 더 이상 데이터가 없으면 반복 중단
                            if (mReceive_Data.Count == 0)
                            {
                                break;
                            }
                        }
                        else if (!mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            mReceive_Data.RemoveRange(0, startIndex + packetLength);
                        }
                    }
                    else
                    {
                        // 완전한 패킷이 아직 도착하지 않았으면, 루프 탈출
                        break;
                    }
                }
                else if (Model.masterFirmwareUpdate_Check_Finish)
                {
                    int packetLength = 20; // 패킷의 길이

                    // STX가 있고, 충분한 길이의 데이터가 있는지 확인
                    if (startIndex != -1 && mReceive_Data.Count >= startIndex + packetLength)
                    {
                        if (mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            byte[] packet = mReceive_Data.GetRange(startIndex, packetLength).ToArray();

                            // 패킷 처리
                            HandlePacket_f1(packet);

                            // 처리된 데이터 제거
                            mReceive_Data.RemoveRange(0, startIndex + packetLength);

                            // 버퍼에 더 이상 데이터가 없으면 반복 중단
                            if (mReceive_Data.Count == 0)
                            {
                                break;
                            }
                        }
                        else if (!mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            mReceive_Data.RemoveRange(0, startIndex + packetLength);
                        }
                    }
                    else
                    {
                        // 완전한 패킷이 아직 도착하지 않았으면, 루프 탈출
                        break;
                    }
                }
            }
        }

        static int slaveId = 0;
        static int masterId = 0;
        static int idx = 0;
        static byte[] temp = new byte[2];
        private static void HandlePacket(byte[] packet)
        {
            //Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);



            masterId = packet[4];
            slaveId = packet[5];


            if (masterId == 2)
                idx = slaveId + 4;
            else
                idx = slaveId;

            Model.list_SlaveDataRecvDatetime[idx - 1] = DateTime.Now;

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
            if (Model.list_SlaveRecv[idx - 1].BatteryRequestVoltage == 0)
            { }
            else if ((Model.list_SlaveRecv[idx - 1].BatteryRequestVoltage / 10) > 65)
            {
                Model.list_SlaveRecv[idx - 1].Check_BatteryVoltage_Type = " 72V";
            }
            else if ((Model.list_SlaveRecv[idx - 1].BatteryRequestVoltage / 10) < 65)
            {
                Model.list_SlaveRecv[idx - 1].Check_BatteryVoltage_Type = " 48V";
            }
            Model.list_SlaveRecv[idx - 1].BatteryRequestWattage = EL_Manager_Conversion.getInt_2Byte(packet[31], packet[32]);
            Model.list_SlaveRecv[idx - 1].BatteryMaxTemper = EL_Manager_Conversion.getInt_2Byte(packet[33], packet[34]);
            Model.list_SlaveRecv[idx - 1].BatteryMinTemper = EL_Manager_Conversion.getInt_2Byte(packet[35], packet[36]);
            Model.list_SlaveRecv[idx - 1].ProcessStatus = EL_Manager_Conversion.getInt(packet[37]);
            Model.list_SlaveRecv[idx - 1].ErrorCode = EL_Manager_Conversion.getInt_2Byte(packet[38], packet[39]);
            Model.list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]);
            Model.list_SlaveRecv[idx - 1].SOH = EL_Manager_Conversion.getInt(packet[41]);

            temp[0] = packet[50];
            temp[1] = packet[51];
            Model.list_SlaveRecv[idx - 1].BatteryType = EL_Manager_Conversion.ByteArrayToString(temp);


        }

        private static void HandlePacket_f1(byte[] packet)
        {
            int JMT = 0;
            /*Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);*/

            Model.PWUpdate_Send_Flag = packet[9];

            if (Model.PWUpdate_Send_Flag == 2)
            {
                JMT = 2;
                Console.WriteLine("JMT is 2");
                Model.masterFirmwareUpdate_Check_Finish = false;
            }
            else if (Model.PWUpdate_Send_Flag == 1)
            {
                JMT = 1;
                Console.WriteLine("JMT is 1");
            }
            Model.Binary_Data_Seq = EL_Manager_Conversion.getInt_2Byte(packet[14], packet[15]);
            if (packet[16] == 0x06)
            {
                Model.masterFirmWareisAck = true;
            }
            else if (packet[16] == 0x15)
            {
                Model.masterFirmWareisNck = true;
            }
        }

        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
