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
        protected int charger_step = 0;
        public void Slot_Charging_Manage(int slotId) //슬롯마다 온도에 따라 충전 전류를 바꿈
        {
            switch (charger_step)
            {
                case 0:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper != null)
                    {
                        if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper >= 92)
                        {
                            Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 0;
                            charger_step = 1;
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper >= 72)
                        {
                            setHighTemp_Current(true, slotId);
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper < 82)
                        {
                            setHighTemp_Current(false, slotId);
                        }
                    }
                    break;
                case 1:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper <= 60)
                    {
                        setHighTemp_Current(false, slotId);
                        charger_step = 0;
                    }
                    break;
            }

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
