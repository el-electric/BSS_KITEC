using EL_DC_Charger.ocpp.ver16.datatype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.OCPP.packet.cp2csms
{
    public class SET_Batteries_Value
    {
        public string bateryId;
        public int chargingAmount;
        public string batteryType;

        public SET_Batteries_Value(int slotid)
        {
            this.bateryId = Model.getInstance().list_SlaveRecv[slotid - 1].Serial_Number.ToString();
            this.chargingAmount = Model.getInstance().list_SlaveRecv[slotid - 1].SOC;
            this.batteryType = Model.getInstance().list_SlaveRecv[slotid - 1].Check_BatteryVoltage_Type.ToString();
        }
    }
}

