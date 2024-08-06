using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public class CsSlotchargingManager
    {
        public int slotid;
        public int OverCurrent_Count;
        public int OverVoltage_Count;
        public int LowVoltage_Count;
        public bool Flooding_Stop;

        public CsSlotchargingManager(int slotid)
        {
            this.slotid = slotid;   
        }
        protected int charger_step = 0;
        public void Slot_Charging_Manage() //슬롯마다 온도에 따라 충전 전류를 바꿈
        {

            if (Model.getInstance().list_MasterRecv[0].floodingWarning || Model.getInstance().list_MasterRecv[0].floodingDanger)
            {
                Flooding_Stop = true;
            }
            switch (charger_step)
            {
                case 0:
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper != null)
                    {
                        if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper >= 92)
                        {
                            Model.getInstance().list_SlaveSend[slotid - 1].request_Wattage = 0;
                            charger_step = 1;
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper >= 72)
                        {
                            setHighTemp_Current(true, slotid);
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper < 82)
                        {
                            setHighTemp_Current(false, slotid);
                        }
                    }
                    break;
                case 1:
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper <= 60)
                    {
                        setHighTemp_Current(false, slotid);
                        charger_step = 0;
                    }
                    break;
            }

            /*if (Model.getInstance().list_SlaveRecv[slotid - 1].BatteryCurrentWattage >= 160)
            {
                OverCurrent_Count++;
            }*/
            //과전류
            //과전압
            //저전압
            //침수
        }

        private void setHighTemp_Current(bool high_temp, int slotId)
        {
            if (high_temp)
            {
                if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 7 * 10;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 5 * 10;
                }
            }
            else
            {
                if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 15 * 10;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 10 * 10;
                }
            }
        }
    }
}
