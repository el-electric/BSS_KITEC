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

        public static int Download_APP = 1;
        public static int Jump_APP = 1;
        public static int Read_Version = 1;
        public static int PWUpdate_Send_Flag;
        public static int Binary_Data_Seq;
        public static int PWUpdate_New_Version_Major = 1;
        public static int PWUpdate_New_Version_Minor = 1;
        public static int PWUpdate_New_Version_Patch = 1;

        public static int boot_Version_Major;
        public static int boot_Version_Minor;
        public static int boot_Version_Patch;
        public static int app1_Version_Major;
        public static int app1_Version_Minor;
        public static int app1_Version_Patch;
        public static int app2_Version_Major;
        public static int app2_Version_Minor;
        public static int app2_Version_Patch;



        public static bool masterFirmwareUpdate;
        public static bool masterFirmwareUpdate_Check_Finish = false;
        public static bool masterFirmware_f0 = false;
        public static int masterFirmwareUpdate_step = 0;
        public static bool masterFirmWareisAck;
        public static bool masterFirmWareisNck;
        public static int PWUpdate_MasterID;


        public static bool slaveFirmwareUpdate;
        public static int slaveFirmwareUpdate_step = 0;
        public static bool slaveFirmWareisAck;
        public static bool slaveFirmWareisNck;
        public static int PWUpdate_SlaveID;


        public int masterCount = 2;
        public int slaveCount = 8;

        public string DefaultPath = "Application.StartupPath + @\"\\Config.ini\"";

        // 처음으로 사용자가 반납하기 버튼을 누른 시간
        public static Nullable<DateTime> dt_First_ClickStartButton_Time = null;

        public static List<MasterSend> list_MasterSend = new List<MasterSend>();
        public static List<MasterRecv> list_MasterRecv = new List<MasterRecv>();

        public static List<SlaveSend> list_SlaveSend = new List<SlaveSend>();
        public static List<SlaveRecv> list_SlaveRecv = new List<SlaveRecv>();

        //데이터 받는지 표시
        public static List<DateTime> list_SlaveDataRecvDatetime = new List<DateTime>();
        public static List<DateTime> list_MasterDataRecvDatetime = new List<DateTime>();

        public static string Master_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "MASTER", "");
        public static string Slave_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "SLAVE", "");

        public static bool Start_Return_Button = false;

        public class MasterSend
        {
            public bool boardReset;
            public bool isFan;
            public bool hmiManual;
        }
        public class MasterRecv
        {
            //진동 경고
            public bool vibrationWarning;
            //침수 위험
            public bool floodingDanger;
            //침수 경고
            public bool floodingWarning;

            public int DIP_Switch_Chaeck;
            public int Charger_UpperTemper;
            public int Charger_LowerTemper;
            public int Charger_Humidity;
            public int Charger_WaveSensor;
            public int Charger_LightSensor;

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

            // 최초 안착 신호 들어온 시간
            public Nullable<DateTime> dt_First_BatterArrive_Time = null;

            // 배터리 타입 구분
            public string Check_BatteryVoltage_Type = null;

            ////////////

            /////C1/////

            ////////////

        }


        public byte[] makeMaserPacket(int idx)
        {
            byte[] bytes = new byte[22];

            bytes[0] = 0xfe;

            bytes[1] = 0;
            bytes[2] = 0;
            bytes[3] = 0;

            if (idx == 1)
            {
                //master 
                bytes[4] = 1;
                //slave
                bytes[5] = 0;
            }
            else if (idx == 2)
            {
                //master 
                bytes[4] = 2;
                //slave
                bytes[5] = 0;
            }

            bytes[6] = (byte)'M';
            bytes[7] = (byte)'M';

            bytes[8] = (byte)'z';
            bytes[9] = (byte)'1';

            bytes[10] = 0;
            //데이터길이
            bytes[11] = 7;

            bytes[12] = 0;
            bytes[13] = 1;

            bytes[14] = 0;
            if (list_MasterSend[idx - 1].boardReset)
            {
                bytes[14] |= 0x80;
                list_MasterSend[idx - 1].boardReset = false;
            }
            if (list_MasterSend[idx - 1].isFan)
                bytes[14] |= 0x08;
            if (list_MasterSend[idx - 1].hmiManual)
                bytes[14] |= 0x04;

            bytes[15] = 0;
            bytes[16] = 1;

            bytes[17] = 0;

            bytes[18] = 0;

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);
            bytes[19] = temp[0];
            bytes[20] = temp[1];
            bytes[21] = 0xff;

            return bytes;
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
            {
                bytes[14] |= 0x80;
                list_SlaveSend[idx - 1].boardReset = false;
            }

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

        public static void makeFirmwareupdate(int masterid, int slaveid)
        {

            byte[] f1 = make_f1();

            byte[] bytes = new byte[9 + f1.Length + 3];
            bytes[0] = 0xfe;

            bytes[1] = (byte)masterid; //가변
            bytes[2] = (byte)slaveid; //가변

            bytes[3] = (byte)'M';
            if (slaveid == 0)
            { bytes[4] = (byte)'M'; }
            else
            { bytes[4] = (byte)'S'; }

            bytes[5] = (byte)'f';
            bytes[6] = (byte)'1';

            bytes[7] = (byte)((f1.Length >> 8) & 0x000000ff); //시퀀스
            bytes[8] = (byte)((f1.Length) & 0x000000ff);
            ////////////////////////            

            Array.Copy(f1, 0, bytes, 9, f1.Length); // make_f1()

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);

            bytes[9 + f1.Length] = temp[0];
            bytes[9 + f1.Length + 1] = temp[1];
            bytes[bytes.Length - 1] = 0xff;

            if (slaveid == 0)
            { sp_Master.Write(bytes); }
            else
            { sp_Slave.Write(bytes); }
        }
        public static byte[] make_f1()
        {
            byte[] bytes = new byte[12 + binFileBuffer[binBufferCount].Length + 1];

            bytes[0] = (byte)PWUpdate_New_Version_Major;    // 9
            bytes[1] = (byte)PWUpdate_New_Version_Minor;    // 10
            bytes[2] = (byte)PWUpdate_New_Version_Patch;    // 11
            if (binFileBuffer[binBufferCount++].Length < 200)  // 12
            {
                bytes[3] = 0;
                masterFirmwareUpdate = false;
            }
            else
                bytes[3] = 1;

            bytes[4] = (byte)Download_APP;    //13
            bytes[5] = (byte)Jump_APP;   // 14
            bytes[6] = 0;    //15

            bytes[7] = (byte)((binBufferCount >> 8) & 0x000000ff); //시퀀스    //16
            bytes[8] = (byte)((binBufferCount) & 0x000000ff);    // 17

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(binFileBuffer[binBufferCount - 1], 0, binFileBuffer[binBufferCount - 1].Length);

            bytes[9] = temp[0];     // 18
            bytes[10] = temp[1];    // 19

            bytes[11] = (byte)((binFileBuffer[binBufferCount - 1].Length >> 8) & 0x000000ff); //길이     //20
            bytes[12] = (byte)((binFileBuffer[binBufferCount - 1].Length) & 0x000000ff);      // 21

            Array.Copy(binFileBuffer[binBufferCount - 1], 0, bytes, 13, binFileBuffer[binBufferCount - 1].Length);  // 바이트를 쪼갠 파일, 쪼갠 파일의 시작 인덱스 , 붙일 파일 , 붙일 파일의 마지막 인덱스 , 바이트를 쪼갠 파일의 길이

            return bytes;

        }

        public static void makeFirmwareF0(int masterid, int slaveid)
        {
            byte[] bytes = new byte[12];
            bytes[0] = 0xfe;

            bytes[1] = (byte)masterid; //가변
            bytes[2] = (byte)slaveid; //가변            
            bytes[3] = (byte)'M';
            if (slaveid == 0)
            { bytes[4] = (byte)'M'; }
            else
            { bytes[4] = (byte)'S'; }
            bytes[5] = (byte)'f';
            bytes[6] = (byte)'0';

            bytes[7] = 0;
            bytes[8] = 1;

            bytes[9] = (byte)Read_Version;

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);
            bytes[10] = temp[0];
            bytes[11] = temp[1];

            bytes[12] = 0xff;

            if (slaveid == 0)
            { sp_Master.Write(bytes); }
            else
            { sp_Slave.Write(bytes); }
        }
    }
}
