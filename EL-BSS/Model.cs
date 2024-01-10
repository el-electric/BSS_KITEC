using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace EL_BSS
{
    public class Model
    {

        public frmFrame frmFrame;

        public int Charging_Step;
        public static bool isOpen_Master;
        public static bool isOpen_Slave;

        public static byte[] binFile;
        public static List<byte[]> binFileBuffer = new List<byte[]>();
        public static int binBufferCount = 0;


        public static bool masterFirmwareUpdate;
        public static int masterFirmwareUpdate_step = 0;
        public static bool masterFirmWareisAck;
        public static bool masterFirmWareisNck;
        public static int slaveFirmwareUpdate_step = 0;


        public static bool slaveFirmwareUpdate;

        public int masterCount = 2;
        public int slaveCount = 8;

        public string DefaultPath = "Application.StartupPath + @\"\\Config.ini\"";

        public static List<SlaveSend> list_SlaveSend = new List<SlaveSend>();
        public static List<SlaveRecv> list_SlaveRecv = new List<SlaveRecv>();

        //데이터 받는지 표시
        public static List<DateTime> list_DataRecvDatetime = new List<DateTime>();

        public static string Master_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "MASTER", "");
        public static string Slave_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "SLAVE", "");

        public class MasterSend
        {
            bool hmiManual;
        }
        public class MasterRecv
        {
            //진동경고
            bool vibrationWarning;
            //침수 위험
            bool floodingDanger;
            //침수 경고
            bool floodingWarning;
        }
        public class SlaveSend
        {
            public bool boardReset;
            public bool isFan;
            public bool hmiManual;
            public bool z1CommandDisregard;
            public bool doorOpen;
            public bool LED_Blue;
            public bool LED_Green;
            public bool LED_Red;

            public bool BatteryWakeup;
            public bool BatteryOutput;
            public bool Output;

            public int request_Voltage;
            public int request_Wattage;


            public SlaveSend(int request_Voltage, int request_Wattage)
            {
                this.request_Voltage = request_Voltage;
                this.request_Wattage = request_Wattage;
            }
        }
        public class SlaveRecv
        {
            //배터리안착
            public bool BatterArrive;
            public bool isDoor;
            public int SeqNum;

            /////Z1/////            
            public bool PowerPackStatus;
            public int PowerPackVoltage;
            public int PowerPackWattage;
            public int BatteryCurrentVoltage;
            public int BatteryCurrentWattage;
            public int BatteryRequestVoltage;
            public int BatteryRequestWattage;
            public int BatteryMaxTemper;
            public int BatteryMinTemper;
            public int ChargingStatus;
            public int ErrorCode;
            public int ProcessStatus;
            public int SOC;
            public int SOH;
            public int RemainTime;
            public int firmWareVersion_Major;
            public int firmWareVersion_Minor;
            public int protocolVersion_Major;
            public int protocolVersion_Minor;
            public int protocolVersion_Patch;
            public string BatteryType = "";

            //51
            public bool overCharging;
            public bool overDischarge;
            public bool packOverCharging;
            public bool cellOverCharging;
            public bool packHighVoltage;
            public bool packLowVoltage;
            public bool highVoltage;
            public bool rowVoltage;

            //52
            public bool FET_HighTemp;
            public bool FET_LowTemp;
            public bool cell_HighTemp;
            public bool cell_LowTemp;
            public bool reCycleOverCharging;

            //53
            public bool overChargingProtection;
            public bool overDischargeProtection;
            public bool packRecycleOverChargingProtection;
            public bool cellRecycleOverChargingProtection;
            public bool packHighVoltageProtection;
            public bool packLowVoltageProtection;
            public bool highVoltageProtection;
            public bool lowVoltageProtection;

            ////////////

            /////C1/////

            ////////////
        }


        public void makeMaserPacket(int idx)
        {



        }
        public byte[] makeSlavePacket(int idx)
        {
            byte[] bytes = new byte[28];

            bytes[0] = 0xfe;

            bytes[1] = 0;
            bytes[2] = 0;
            bytes[3] = 0;

            //bytes[4] = 1;
            ////slave
            //bytes[5] = 1;

            if (idx > 4)
            {
                //master 
                bytes[4] = 2;
                //slave
                bytes[5] = (byte)(idx - 4);
            }
            else
            {
                //master 
                bytes[4] = 1;
                //slave
                bytes[5] = (byte)idx;
            }

            bytes[6] = (byte)'M';
            bytes[7] = (byte)'S';

            bytes[8] = (byte)'z';
            bytes[9] = (byte)'1';

            bytes[10] = 0;
            //데이터길이
            bytes[11] = 13;

            bytes[12] = 0;
            bytes[13] = 1;

            bytes[14] = 0;

            if (list_SlaveSend[idx - 1].boardReset)
                bytes[14] |= 0x80;
            if (list_SlaveSend[idx - 1].isFan)
                bytes[14] |= 0x08;
            if (list_SlaveSend[idx - 1].hmiManual)
                bytes[14] |= 0x04;

            bytes[15] = 0;
            bytes[16] = 1;

            bytes[17] = 0;

            if (list_SlaveSend[idx - 1].z1CommandDisregard)
                bytes[17] |= 0x04;
            if (list_SlaveSend[idx - 1].doorOpen)
                bytes[17] |= 0x02;

            bytes[18] = 0;
            bytes[19] = 0;
            if (list_SlaveSend[idx - 1].LED_Blue)
                bytes[19] |= 0x04;
            if (list_SlaveSend[idx - 1].LED_Green)
                bytes[19] |= 0x02;
            if (list_SlaveSend[idx - 1].LED_Red)
                bytes[19] |= 0x01;

            bytes[20] = 0;
            if (list_SlaveSend[idx - 1].BatteryWakeup)
                bytes[20] |= 0x10;
            if (list_SlaveSend[idx - 1].BatteryOutput)
                bytes[20] |= 0x01;
            if (list_SlaveSend[idx - 1].Output)
                bytes[20] |= 0x02;



            bytes[21] = (byte)((list_SlaveSend[idx - 1].request_Voltage >> 8) & 0x000000ff);
            bytes[22] = (byte)((list_SlaveSend[idx - 1].request_Voltage) & 0x000000ff);

            bytes[23] = (byte)((list_SlaveSend[idx - 1].request_Wattage >> 8) & 0x000000ff);
            bytes[24] = (byte)((list_SlaveSend[idx - 1].request_Wattage) & 0x000000ff);

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);
            bytes[25] = temp[0];
            bytes[26] = temp[1];
            bytes[27] = 0xff;

            return bytes;
        }

        public static void makeFirmwareupdate()
        {

            byte[] f1 = make_f1();

            byte[] bytes = new byte[9 + f1.Length + 3];
            bytes[0] = 0xfe;

            bytes[1] = 1; //가변
            bytes[2] = 1; //가변            
            bytes[3] = (byte)'M';
            bytes[4] = (byte)'S';
            bytes[5] = (byte)'f';
            bytes[6] = (byte)'1';

            bytes[7] = (byte)((f1.Length >> 8) & 0x000000ff); //시퀀스
            bytes[8] = (byte)((f1.Length) & 0x000000ff);
            ////////////////////////            

            Array.Copy(f1, 0, bytes, 9, f1.Length);

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);

            bytes[9 + f1.Length] = temp[0];
            bytes[9 + f1.Length + 1] = temp[1];
            bytes[bytes.Length - 1] = 0xff;

            sp_Master.Write(bytes);
        }
        public static byte[] make_f1()
        {


            byte[] bytes = new byte[12 + binFileBuffer[binBufferCount].Length + 1];

            bytes[0] = 1;
            bytes[1] = 1;
            bytes[2] = 1;
            if (binFileBuffer[binBufferCount++].Length < 200)
            {
                bytes[3] = 0;
                masterFirmwareUpdate = false;
            }
            else
                bytes[3] = 1;

            bytes[4] = 0;
            bytes[5] = 0;
            bytes[6] = 0;

            bytes[7] = (byte)((binBufferCount >> 8) & 0x000000ff); //시퀀스
            bytes[8] = (byte)((binBufferCount) & 0x000000ff);

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(binFileBuffer[binBufferCount - 1], 0, binFileBuffer[binBufferCount - 1].Length);

            bytes[9] = temp[0];
            bytes[10] = temp[1];

            bytes[11] = (byte)((binFileBuffer[binBufferCount - 1].Length >> 8) & 0x000000ff); //길이
            bytes[12] = (byte)((binFileBuffer[binBufferCount - 1].Length) & 0x000000ff);

            Array.Copy(binFileBuffer[binBufferCount - 1], 0, bytes, 13, binFileBuffer[binBufferCount - 1].Length);

            return bytes;

        }
    }
}
