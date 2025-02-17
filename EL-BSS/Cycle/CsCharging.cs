using BatteryChangeCharger.OCPP;
using EL_BSS.Serial;
using EL_DC_Charger.ocpp.ver16.comm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Ink;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public class CsCharging
    {
        public static int CurrentStep = 0;
        private static bool firstboot = false;
        private static Stopwatch sw_first = new Stopwatch();

        public static bool isCharging(int slotid)
        {
            Model.getInstance().list_SlaveSend[slotid - 1].BatteryOutput = true;

            if (Model.getInstance().list_SlaveRecv[slotid - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
            {
                Model.getInstance().list_SlaveSend[slotid - 1].request_Wattage = 150;
            }
            else if (Model.getInstance().list_SlaveRecv[slotid - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
            {
                Model.getInstance().list_SlaveSend[slotid - 1].request_Wattage = 100;
            }

            CsDefine.Delayed[CsDefine.CYC_CHARGING] = 0;

            while (true)
            {
                if (Model.getInstance().list_SlaveRecv[slotid - 1].ProcessStatus == 100)
                {
                    break;

                }
                else if (CsDefine.Delayed[CsDefine.CYC_CHARGING] >= 3000)
                {
                    return false;
                }

                Thread.Sleep(10);
            }
            return true;
        }

        public static void isCharging_Two_Slot(int[] slot)
        {
            Model.getInstance().list_SlaveSend[slot[0] - 1].BatteryOutput = true;
            Model.getInstance().list_SlaveSend[slot[1] - 1].BatteryOutput = true;

            if (Model.getInstance().list_SlaveRecv[slot[0] - 1].Check_BatteryVoltage_Type == (int)enumData.Type48 &&
                Model.getInstance().list_SlaveRecv[slot[1] - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
            {
                Model.getInstance().list_SlaveSend[slot[0] - 1].request_Wattage = 150;
                Model.getInstance().list_SlaveSend[slot[1] - 1].request_Wattage = 150;
            }
            else if (Model.getInstance().list_SlaveRecv[slot[0] - 1].Check_BatteryVoltage_Type == (int)enumData.Type72 &&
                    Model.getInstance().list_SlaveRecv[slot[1] - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
            {
                Model.getInstance().list_SlaveSend[slot[0] - 1].request_Wattage = 100;
                Model.getInstance().list_SlaveSend[slot[1] - 1].request_Wattage = 100;
            }
        }

        public static bool is_first = false;

        public static void Slot_Charging_Control(int slotid)
        {
            var model = Model.getInstance();

            if (!is_first)
            {
                sw_first.Start();
                is_first = true;
            }

            if (!firstboot)
            {
                if (sw_first.ElapsedMilliseconds <= 5000)
                { return; }
                else
                {
                    sw_first.Stop();
                    firstboot = true;
                }
            }

            if (Model.getInstance().list_SlaveRecv[slotid - 1].Check_BatteryVoltage_Type == 48)
            {
                Model.getInstance().list_SlaveSend[slotid - 1].request_Wattage = 150;
            }
            else if(Model.getInstance().list_SlaveRecv[slotid - 1].Check_BatteryVoltage_Type == 72)
            {
                Model.getInstance().list_SlaveSend[slotid - 1].request_Wattage = 100;
            }


            if (model.list_MasterRecv[0].Error_Occured || model.list_MasterRecv[1].Error_Occured)
            {
                sp_Slave.Stop_Charging_all_Slot();
            }
            else
            {
                if (!model.list_SlaveRecv[slotid - 1].Error_Occured) // 에러가 아니라면
                {
                    if (is_charging(slotid))
                    {
                        if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper >= 75 || Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp >= 75)
                        {
                            model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper >= 45 || Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp >= 45)
                        {
                            setHighTemp_Current(true, slotid);
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_Temper < 40 || Model.getInstance().list_SlaveRecv[slotid - 1].Battery_Slot_Temp < 40)
                        {
                            setHighTemp_Current(false, slotid);
                        }
                    }

                    if (model.list_SlaveRecv[slotid - 1].WAKEUP_Signal && // SOC가 반납을 할정도로 존재하지 못할때 충전 시켜줌
                    model.list_SlaveRecv[slotid - 1].SOC < 100 &&
                    !model.list_SlaveRecv[slotid - 1].isSequence)
                    {
                        if (model.list_SlaveRecv[slotid - 1].DischargingMode)
                        {
                            model.list_SlaveSend[slotid - 1].BatteryFETON = true;
                        }
                        else 
                        {
                            model.list_SlaveSend[slotid - 1].BatteryFETON = true;
                            model.list_SlaveSend[slotid - 1].BatteryOutput = true;
                        }
                    }
                }
                else  // 에러라면
                {
                    if (!model.list_SlaveRecv[slotid - 1].isSequence)
                    {
                        model.list_SlaveSend[slotid - 1].BatteryFETON = false;
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                    }
                    else
                    {
                        model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                    }
                }

                if (model.list_SlaveRecv[slotid - 1].SOC == 100 || model.list_SlaveRecv[slotid - 1].isDoor)
                {
                    model.list_SlaveSend[slotid - 1].BatteryFETON = false;
                    model.list_SlaveSend[slotid - 1].BatteryOutput = false;
                }
            }
        }

        public static bool is_charging(int slot_num)
        {
            if (Model.getInstance().list_SlaveRecv[slot_num - 1].ProcessStatus == 100) return true;

            if (Model.getInstance().list_SlaveRecv[slot_num - 1].WAKEUP_Signal) return false;

            if (Model.getInstance().list_SlaveRecv[slot_num - 1].FET_ON_State) return false; 

            if(Model.getInstance().list_SlaveSend[slot_num - 1].BatteryOutput) return false;

            if (!Model.getInstance().list_SlaveSend[slot_num - 1].hmiManual) return false;

            if (Model.getInstance().list_SlaveRecv[slot_num - 1].FET_Temper != null) return false;

            if (!Model.getInstance().list_SlaveRecv[slot_num - 1].Error_Occured) return false;

            return true;
        }

        public static void Main_WorkCycle(int slotId) //자동동작 시퀀스
        {
            
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_CHARGING])
            {
                case CsDefine.CYC_MAIN:
                    CurrentStep = CsDefine.CYC_MAIN;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    break;
            }
        }
        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_CHARGING] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_CHARGING] = ++CurrentStep;
        }

        private static void JumpStep(int step)
        {
            CsDefine.Delayed[CsDefine.CYC_CHARGING] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_CHARGING] = step;
        }

        private static void setHighTemp_Current(bool high_temp, int slotId)
        {
            if (high_temp)
            {
                if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == 48)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 70;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == 72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 50;
                }
            }
            else
            {
                if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 150;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 100;
                }
            }
        }
    }
}
