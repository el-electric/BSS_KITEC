using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace EL_BSS.Cycle
{
    public class CsWakeup
    {
        public static int CurrentStep = 0;

        int timeout = 3000;
        //웨이크업(FETON) CsWakeUp

        //상태체크 CsStatusCheck

        //충전     CsCharging

        public static bool isWakeUP(int slotid)
        {
            Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = true;
            CsDefine.Delayed[CsDefine.CYC_R_WAKEUP] = 0;

            while (true)
            {
                if (Model.getInstance().list_SlaveRecv[slotid - 1].WAKEUP_Signal)
                {
                    // Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = true;
                    break;
                }
                else if (CsDefine.Delayed[CsDefine.CYC_R_WAKEUP] >= 10000)
                {
                    return false;
                }

                Thread.Sleep(10);
            }
            return true;
        }

        public static bool isFETon(int slotid)
        {
            Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = true;
            CsDefine.Delayed[CsDefine.CYC_FETON] = 0;

            while (true)
            {
                if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_ON_State)
                {
                    break;
                }
                else if (CsDefine.Delayed[CsDefine.CYC_FETON] >= 10000)
                {
                    return false;
                }

                Thread.Sleep(10);
            }
            return true;
        }

        public static void CYC_WAKEUP(int slotid)
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_WAKEUP])
            {
                case CsDefine.CYC_MAIN:
                    CurrentStep = CsDefine.CYC_MAIN;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = true;  // 배터리 wakeup을 줌
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 2:
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].WAKEUP_Signal)  // 배터리 wakeup을 성공
                    {
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = false;
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = true;  // FET ON 명령
                        NextStep();
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_WAKEUP] >= 3000) // 3초동안 wakeup의 성공을 받지 못함
                    {
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = false;
                        // wakeup이 안됨 문제 있음
                    }
                    break;
                case CsDefine.CYC_MAIN + 3:
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_ON_State)  // FETON 성공
                    {
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = false;
                        //CsStatusCheck으로 넘어갈수 있음 
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_WAKEUP] >= 3000) // 3초동안 FETON의 성공을 받지 못함
                    {
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = false;
                        // FWTON이 안됨 문제 있음
                    }

                    break;
            }
        }

        public async static void interverWakeUP()
        {
            for (int i = 1; i <= 8; i++)
            {
                if (Model.getInstance().list_SlaveRecv[i - 1].BatterArrive && Model.getInstance().list_SlaveRecv[i - 1].WAKEUP_Signal == false)
                {
                    bool isWakeup = await Task.Run(() => isWakeUP(i));
                }
            }
        }

        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_WAKEUP] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_WAKEUP] = ++CurrentStep;
        }

        private static void JumpStep(int step)
        {
            CsDefine.Delayed[CsDefine.CYC_WAKEUP] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_WAKEUP] = step;
        }
    }
}
