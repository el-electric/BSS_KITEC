using BatteryChangeCharger.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EL_DC_Charger.ocpp.ver16.packet.cp2csms
{
    public class Req_Battery_Info
    {
        public bool Battery_Setting;
        public double PowerPackVoltage;
        public double PowerPackCurrent;
        public double Battery_Temp;
        public int SOC;
        public int SOH;
        public bool Charging_or_Not;
        public double Charger_Temp;
        public int Remain_Time;
        public void setRequiredValue(int slotnum)
        {
            this.Battery_Setting = MyApplication.getInstance().SerialPort_IOBoard.getManager_Send().mManager_Packet.mPacket_a1_Receive.Check_Slot_battery_In(slotnum);
            this.PowerPackVoltage = (MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.PowerPackVoltage / 100);
            this.PowerPackCurrent = (MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.PowerPackcurrent / 100);
            this.Battery_Temp = MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.BatteryMaxTemper;
            this.SOC = MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.SOC;
            this.SOH = MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.SOH;
            if (MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.ChargingStatus == 100)
            { this.Charging_or_Not = true; }
            else
            {this.Charging_or_Not = false;}
            this.Charger_Temp = MyApplication.getInstance().SerialPort_IOBoard.getManager_Send().mManager_Packet.mPacket_z1_Receive.Charger_Up_Temp;
            this.Remain_Time = MyApplication.getInstance().SerialPort_NFCBoard.getManager_Send().mPackets[slotnum].mPacket_c1_Receive.RemainTime;
        }
    }
}

