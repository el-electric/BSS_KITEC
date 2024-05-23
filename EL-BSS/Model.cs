
using BatteryChangeCharger.OCPP;
using EL_BSS.Serial;
using EL_DC_Charger.ocpp.ver16.comm;
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
using System.Data.SQLite;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace EL_BSS
{
    public class Model
    {
        private static Model instance;

        public static Model getInstance()
        {
            if (instance == null)
            {
                instance = new Model();
                mJsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                mJsonSerializerSettings.Formatting = Formatting.None;
                mJsonSerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;

                Model.getInstance().oCPP_Comm_Manager = new OCPP_Comm_Manager();
                Model.getInstance().oCPP_Comm_SendMgr = new OCPP_Comm_SendMgr();
            }
            return instance;
        }

        public frmFrame frmFrame;

        public int Charging_Step;
        public bool isOpen_Master;
        public bool isOpen_Slave;

        public byte[] binFile;
        public List<byte[]> binFileBuffer = new List<byte[]>();
        public int binBufferCount = 0;

        public int Jump_APP = 0;
        public int Read_Version = 1;
        public int PWUpdate_Send_Flag;
        public int PWUpdate_Jump_Flag;
        public int Binary_Data_Seq;
        public int PWUpdate_New_Version_Major = 1;
        public int PWUpdate_New_Version_Minor = 1;
        public int PWUpdate_New_Version_Patch = 1;
        public bool Auto_Update = false;

        public int boot_Version_Major;
        public int boot_Version_Minor;
        public int boot_Version_Patch;
        public int app1_Version_Major;
        public int app1_Version_Minor;
        public int app1_Version_Patch;
        public int app2_Version_Major;
        public int app2_Version_Minor;
        public int app2_Version_Patch;



        public bool FirmwareUpdate;
        public int f0_OR_f1Update_OR_f1Jump = 0; // 1 = f0 , 2 = f1 업데이트 패킷  3 = f1 점프용 패킷
        public int FirmwareUpdate_step = 0;
        public bool FirmWareisAck;
        public bool FirmWareisNak;
        public int FirmWareisNck_Count = 0;
        public int PWUpdate_MasterID;
        public int PWUpdate_Receive_MasterID = 1;


        /*public bool slaveFirmwareUpdate;
        public int slaveFirmwareUpdate_step = 0;
        public bool slaveFirmWareisAck;
        public bool slaveFirmWareisNck;*/
        public int PWUpdate_SlaveID;
        public int PWUpdate_Receive_SlaveID = 1;


        public int masterCount = 2;
        public int slaveCount = 8;

        public string DefaultPath = "Application.StartupPath + @\"\\Config.ini\"";

        // 처음으로 사용자가 반납하기 버튼을 누른 시간
        public Nullable<DateTime> dt_First_ClickStartButton_Time = null;
        public Nullable<DateTime> Send_FWUpdate_Packet_Time = null;

        public List<MasterSend> list_MasterSend = new List<MasterSend>();
        public List<MasterRecv> list_MasterRecv = new List<MasterRecv>();

        public List<SlaveSend> list_SlaveSend = new List<SlaveSend>();
        public List<SlaveRecv> list_SlaveRecv = new List<SlaveRecv>();

        //데이터 받는지 표시
        public List<DateTime> list_SlaveDataRecvDatetime = new List<DateTime>();
        public List<DateTime> list_MasterDataRecvDatetime = new List<DateTime>();

        public string Master_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "MASTER", "COM1");
        public string Slave_PortName = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "COMPORT", "SLAVE", "COM2");
        public string StationId = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID", "");

        public bool Start_Return_Button = false;


        public SQLiteConnection connection;
        public OCPP_Comm_Manager oCPP_Comm_Manager;
        public OCPP_Comm_SendMgr oCPP_Comm_SendMgr;
        public static JsonSerializerSettings mJsonSerializerSettings = new JsonSerializerSettings();
        public string[] Check_statusnotification = new string[8];
        public bool Send_bootnotification = false;

        public int HeartBeatInterval = 10;
        public int StationInfoInterval = 10;
        public int MeterValuesInterval = 10;


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

            public bool BatteryFETON;
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
            public int Check_BatteryVoltage_Type;

            ////////////

            /////C1/////
            public int FET_Temper;
            public bool WAKEUP_Signal = false;
            public bool FET_ON_State = false;
            public int Serial_Number;
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
            if (list_SlaveSend[idx - 1].BatteryFETON)
                bytes[20] |= 0x20;
            if (list_SlaveSend[idx - 1].BatteryWakeup)
                bytes[20] |= 0x10;
            if (list_SlaveSend[idx - 1].BatteryOutput)
                bytes[20] |= 0x04;
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

            // CsUtil.IniWriteValue(System.Windows.Forms.Application.StartupPath + @"\Byte_Test", "packet", Model.binBufferCount.ToString(), );


            if (slaveid == 0)
            { sp_Master.Write(bytes); }
            else
            { sp_Slave.Write(bytes); }
        }
        public static byte[] make_f1()
        {
            byte[] bytes = new byte[12 + getInstance().binFileBuffer[getInstance().binBufferCount].Length + 1];

            bytes[0] = (byte)getInstance().PWUpdate_New_Version_Major;    // 9
            bytes[1] = (byte)getInstance().PWUpdate_New_Version_Minor;    // 10
            bytes[2] = (byte)getInstance().PWUpdate_New_Version_Patch;    // 11
            if (getInstance().binFileBuffer[getInstance().binBufferCount++].Length < 200)  // 12            
                bytes[3] = 2;
            else
                bytes[3] = 1;

            bytes[4] = (byte)getInstance().Jump_APP;    //13
            bytes[5] = (byte)getInstance().Jump_APP;   // 14
            bytes[6] = 0;    //15

            bytes[7] = (byte)((getInstance().binBufferCount >> 8) & 0x000000ff); //시퀀스    //16
            bytes[8] = (byte)((getInstance().binBufferCount) & 0x000000ff);    // 17

            byte[] temp;

            temp = CsUtil.getCRC16_CCITT(Model.getInstance().binFile, 0, Model.getInstance().binFile.Length + 3);

            /*bytes[9] = temp[0];     // 18
            bytes[10] = temp[1];    // 19*/

            bytes[9] = temp[1];     // 18 비정상 패킷
            bytes[10] = temp[0];


            bytes[11] = (byte)((getInstance().binFileBuffer[getInstance().binBufferCount - 1].Length >> 8) & 0x000000ff); //길이     //20
            bytes[12] = (byte)((getInstance().binFileBuffer[getInstance().binBufferCount - 1].Length) & 0x000000ff);      // 21

            Array.Copy(getInstance().binFileBuffer[getInstance().binBufferCount - 1], 0, bytes, 13, getInstance().binFileBuffer[getInstance().binBufferCount - 1].Length);  // 바이트를 쪼갠 파일, 쪼갠 파일의 시작 인덱스 , 붙일 파일 , 붙일 파일의 마지막 인덱스 , 바이트를 쪼갠 파일의 길이

            return bytes;

        }

        public static void makeFirmwaref1_without_Binary(int masterid, int slaveid, int jumpId)
        {
            byte[] bytes = new byte[25];
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

            bytes[7] = 0;
            bytes[8] = 13;
            ////////////////////////            
            bytes[13] = 0;
            bytes[14] = (byte)jumpId;

            byte[] temp;
            temp = CsUtil.getCRC16_CCITT(bytes, 0, bytes.Length);

            bytes[22] = temp[0];
            bytes[23] = temp[1];
            bytes[24] = 0xff;

            if (slaveid == 0)
            { sp_Master.Write(bytes); }
            else
            { sp_Slave.Write(bytes); }
        }

        public static void makeFirmwareF0(int masterid, int slaveid)
        {
            byte[] bytes = new byte[13];
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

            bytes[9] = (byte)getInstance().Read_Version;

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

        private bool Check_100SOC_Battery()
        {
            int Check_Slot_Count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Model.getInstance().list_SlaveRecv[i].SOC == 0 &&
                    Model.getInstance().list_SlaveRecv[i].dt_First_BatterArrive_Time != null &&
                    Model.getInstance().list_SlaveRecv[i].dt_First_BatterArrive_Time.Value.AddMinutes(5) <= DateTime.Now)
                {
                    Check_Slot_Count++;
                }
            }
            if (Check_Slot_Count < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public enum enumData
        {
            BootNotification,
            StatusNotification,
            Heartbeat,
            MeterValues,
            StationInfo,
            Authorize,
            StartTransaction,
            StopTransaction,
            Accepted,
            Type48 = 48,
            Type72 = 72
        }
    }
}
