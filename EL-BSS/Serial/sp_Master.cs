using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
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
                if (!Model.masterFirmwareUpdate_Check_Finish)
                {
                    int packetLength = 41; // 패킷의 길이

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
        private static void HandlePacket(byte[] packet)
        {
            // Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);

            masterId = packet[4];
            slaveId = packet[5];

            Model.list_MasterDataRecvDatetime[masterId - 1] = DateTime.Now;

            Model.list_MasterRecv[masterId - 1].vibrationWarning = EL_Manager_Conversion.getFlagByByteArray(packet[20], 0);
            Model.list_MasterRecv[masterId - 1].floodingWarning = EL_Manager_Conversion.getFlagByByteArray(packet[20], 6);
            Model.list_MasterRecv[masterId - 1].floodingDanger = EL_Manager_Conversion.getFlagByByteArray(packet[20], 6);

            Model.list_MasterRecv[masterId - 1].DIP_Switch_Chaeck = packet[22];
            Model.list_MasterRecv[masterId - 1].Charger_UpperTemper = EL_Manager_Conversion.getInt_2Byte(packet[23], packet[24]);
            Model.list_MasterRecv[masterId - 1].Charger_UpperTemper = EL_Manager_Conversion.getInt_2Byte(packet[25], packet[26]);
            Model.list_MasterRecv[masterId - 1].Charger_Humidity = packet[27];
            Model.list_MasterRecv[masterId - 1].Charger_WaveSensor = EL_Manager_Conversion.getInt_2Byte(packet[28], packet[29]);
            Model.list_MasterRecv[masterId - 1].Charger_LightSensor = EL_Manager_Conversion.getInt_2Byte(packet[30], packet[31]);
        }

        private static void HandlePacket_f1(byte[] packet)
        {
            // Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);

            int JMT = 0;
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

        private static void HandlePacket_f0(byte[] packet)
        {
            Model.boot_Version_Major = packet[9];
            Model.boot_Version_Minor = packet[10];
            Model.boot_Version_Patch = packet[11];
            Model.app1_Version_Major = packet[12];
            Model.app1_Version_Minor = packet[13];
            Model.app1_Version_Patch = packet[14];
            Model.app2_Version_Major = packet[15];
            Model.app2_Version_Minor = packet[16];
            Model.app2_Version_Patch = packet[17];
        }
        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
