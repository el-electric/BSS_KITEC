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
        private static void Comport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serial.BytesToRead;
            byte[] receivedData = new byte[bytesToRead];
            serial.Read(receivedData, 0, bytesToRead);

            foreach (byte data in receivedData)
            {
                processData(data);
            }
        }

        private static void processData(byte data)
        {
            // 데이터를 리스트에 추가
            mReceive_Data.Add(data);

            // 패킷의 시작과 끝을 찾습니다.
            int startIndex = mReceive_Data.IndexOf(0xfe);
            int endIndex = mReceive_Data.IndexOf(0xff);

            // 시작과 끝 바이트가 모두 있는 경우
            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {
                // 패킷 추출
                byte[] packet = mReceive_Data.GetRange(startIndex, endIndex - startIndex + 1).ToArray();

                // 패킷 처리
                HandlePacket(packet);

                // 처리된 데이터 제거
                mReceive_Data.RemoveRange(0, endIndex + 1);
            }
        }

        static int slaveId = 0;
        static int masterId = 0;
        static int idx = 0;
        static byte[] temp = new byte[2];
        private static void HandlePacket(byte[] packet)
        {
            Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);

            //z1
            if (packet.Length == 71)
            {

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
                Model.list_SlaveRecv[idx - 1].BatteryMinTemper = EL_Manager_Conversion.getInt_2Byte(packet[34], packet[35]);
                Model.list_SlaveRecv[idx - 1].ProcessStatus = EL_Manager_Conversion.getInt(packet[37]);
                Model.list_SlaveRecv[idx - 1].ErrorCode = EL_Manager_Conversion.getInt_2Byte(packet[38], packet[39]);
                Model.list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]);
                Model.list_SlaveRecv[idx - 1].SOH = EL_Manager_Conversion.getInt(packet[41]);

                temp[0] = packet[50];
                temp[1] = packet[51];
                Model.list_SlaveRecv[idx - 1].BatteryType = EL_Manager_Conversion.ByteArrayToString(temp);





            }

        }

        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
