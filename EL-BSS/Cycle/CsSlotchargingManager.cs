﻿using EL_BSS.Serial;
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
        private Stopwatch sw_first = new Stopwatch();

        public CsSlotchargingManager(int slotid)
        {
            this.slotid = slotid;

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
                    }

                    if (Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp >= 60)
                    {
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
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

                if (model.list_SlaveRecv[slotid - 1].Error_Occured || model.list_SlaveRecv[slotid - 1].SOC == 100 || model.list_SlaveRecv[slotid - 1].isDoor) //에러 발생시
                {
                    model.list_SlaveSend[slotid - 1].BatteryFETON = false;
                    model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                }

                if (model.list_SlaveRecv[slotid - 1].WAKEUP_Signal && // SOC가 반납을 할정도로 존재하지 못할때 충전 시켜줌
                    model.list_SlaveRecv[slotid - 1].SOC < 100 &&
                    !model.list_SlaveRecv[slotid - 1].Error_Occured &&
                      (!model.list_MasterRecv[0].Error_Occured || !model.list_MasterRecv[1].Error_Occured) &&
                    Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper <= 40 &&
                    Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp <= 40 &&
                    !Model.getInstance().list_SlaveRecv[slotid - 1].isSequence
                    )
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
