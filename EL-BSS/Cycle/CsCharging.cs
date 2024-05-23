using BatteryChangeCharger.OCPP;
using EL_DC_Charger.ocpp.ver16.comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public class CsCharging
    {
        public static int CurrentStep = 0;

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
                    // Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = true;
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

        public static void Main_WorkCycle(int slotId) //자동동작 시퀀스
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_CHARGING])
            {
                case CsDefine.CYC_MAIN:
                    CurrentStep = 0;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper != null)
                    {
                        if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper >= 92)
                        {
                            Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 0;
                            NextStep();
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper >= 82)
                        {
                            setHighTemp_Current(true, slotId);
                        }
                        else if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper < 82)
                        {
                            setHighTemp_Current(false, slotId);
                        }
                    }
                    break;
                case CsDefine.CYC_MAIN + 2:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].FET_Temper <= 60)
                    {
                        setHighTemp_Current(false, slotId);
                        JumpStep(CsDefine.CYC_MAIN + 1);
                    }
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
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 7;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == 72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 5;
                }
            }
            else
            {
                if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type48)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 15;
                }
                else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == (int)enumData.Type72)
                {
                    Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 10;
                }
            }
        }
    }
}
