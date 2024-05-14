using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public class CsCharging
    {
        public static int CurrentStep = 0;


        //웨이크업(FETON) CsWakeUp

        //상태체크 CsStatusCheck

        //충전     CsCharging



        public void CYC_WAKEUP(int slotid)
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_WAKEUP])
            {
                case CsDefine.CYC_MAIN:
                    break;
                case CsDefine.CYC_MAIN + 1:
                    CurrentStep = CsDefine.CYC_MAIN + 1;
                    Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = true;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 2:
                    CurrentStep = CsDefine.CYC_MAIN + 1;
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].WAKEUP_Signal)
                    {
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryWakeup = false;
                        Model.getInstance().list_SlaveSend[slotid - 1].BatteryFETON = true;
                        NextStep();
                    }
                    if (CsDefine.Delayed[CsDefine.CYC_WAKEUP] >= 3000)
                    {
                        // wakeup이 안됨 문제가 있음
                    }
                    break;
                case CsDefine.CYC_MAIN + 3:
                    if (Model.getInstance().list_SlaveRecv[slotid - 1].FET_ON_State)
                    {
                         //CsStatusCheck으로 넘어갈수 있음 
                    }
                    break;
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
