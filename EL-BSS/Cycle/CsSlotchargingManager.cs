using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool soc_Low_High;
        private Stopwatch sw_first = new Stopwatch();

        public CsSlotchargingManager(int slotid)
        {
            this.slotid = slotid;

            if (Model.getInstance().list_SlaveRecv[slotid - 1].SOC == 100) this.soc_Low_High = true;
            else this.soc_Low_High = false;

            sw_first.Start();
        }
        public void Slot_Charging_Manage() //슬롯마다 온도에 따라 충전 전류를 바꿈
        {

            if (sw_first.ElapsedMilliseconds <= 5000)
                return;
            else
                sw_first.Stop();

            var model = Model.getInstance();


            if (model.list_MasterRecv[0].Error_Occured || model.list_MasterRecv[1].Error_Occured)
            {
                sp_Slave.Stop_Charging_all_Slot();
            }
            else
            {
                if (model.list_SlaveRecv[slotid - 1].ProcessStatus == 100 &&
                model.list_SlaveRecv[slotid - 1].WAKEUP_Signal &&
                model.list_SlaveRecv[slotid - 1].FET_ON_State &&
                model.list_SlaveSend[slotid - 1].BatteryOutput &&
                !model.list_SlaveSend[slotid - 1].hmiManual &&
                model.list_SlaveRecv[slotid - 1].FET_Temper != null)
                {
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper >= 50)
                    {
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                        Model.getInstance().csErrorControl.Is_Slot_Error(slotid - 1, Battery_Error.Slot_Temperature_Error, true);
                    }
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp >= 60)
                    {
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                        Model.getInstance().csErrorControl.Is_Slot_Error(slotid - 1, Battery_Error.Slot_Temperature_Error, true);
                    }
                    else if (Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp >= 50)
                    {
                        setHighTemp_Current(true, slotid);
                    }
                    else if (Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp < 50)
                    {
                        setHighTemp_Current(false, slotid);
                    }
                }
                else if (Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp < 60 && Model.getInstance().Battery_Error_Code[slotid - 1][Battery_Error.Slot_Temperature_Error])
                {
                    Model.getInstance().csErrorControl.Is_Slot_Error(slotid - 1, Battery_Error.Slot_Temperature_Error, false);
                }

                if (model.list_SlaveRecv[slotid - 1].Error_Occured || model.list_SlaveRecv[slotid - 1].SOC == 100 || model.list_SlaveRecv[slotid - 1].isDoor) //에러 발생시 그리고 완속 
                {
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].DischargingMode)
                    { model.list_SlaveSend[slotid - 1].BatteryOutput = false; }
                    else 
                    {
                        model.list_SlaveSend[slotid - 1].BatteryFETON = false;
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                    }
                }
                else if (model.list_SlaveRecv[slotid - 1].WAKEUP_Signal && // SOC가 반납을 할정도로 존재하지 못할때 충전 시켜줌
                    !model.list_SlaveRecv[slotid - 1].Error_Occured &&
                    model.list_SlaveRecv[slotid - 1].SOC < 100 &&
                      (!model.list_MasterRecv[0].Error_Occured || !model.list_MasterRecv[1].Error_Occured) &&
                    Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper <= 40 &&
                    Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp <= 40 &&
                    !Model.getInstance().list_SlaveRecv[slotid - 1].isSequence &&
                    !Model.getInstance().list_SlaveRecv[slotid -1].DischargingMode)
                {
                    
                    model.list_SlaveSend[slotid - 1].BatteryFETON = true;
                    model.list_SlaveSend[slotid - 1].BatteryOutput = true;
                }
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
