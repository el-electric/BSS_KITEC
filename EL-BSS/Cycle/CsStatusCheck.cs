using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public class CsStatusCheck
    {

        public static int CurrentStep = 0;
        public static void CYC_STATUSCHECK(int slotId)
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_STATUSCHECK])
            {
                case CsDefine.CYC_MAIN:
                    CurrentStep = CsDefine.CYC_MAIN;
                    NextStep();
                    break;

                case CsDefine.CYC_MAIN + 1:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].SOC < 97 && Model.getInstance().list_SlaveRecv[slotId - 1].SOH > 60) // SOC의 값이 너무 높지 않고 SOC의 수명이 너무 적지 않은 배터리
                    {
                        NextStep();
                    }
                    else
                    {
                        // SOC의 값과 SOH의 값에 문제가 있음
                    }
                    break;

                    case CsDefine.CYC_MAIN + 2:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].BatteryMaxTemper < 60 && Model.getInstance().list_SlaveRecv[slotId - 1].BatteryMinTemper > 10) // 배터리의 온도도 기준에 맞아야 함
                    {
                        NextStep();
                    }
                    else
                    {
                        // 배터리 온도가 기준에 맞지 않음
                    }
                    break;

                    case CsDefine.CYC_MAIN + 3:
                    if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == 48)  // 배터리의 종류에 따라 전류값을 변경 , 전압값은 변경불가
                    {
                        Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 15;
                    }
                    else if (Model.getInstance().list_SlaveRecv[slotId - 1].Check_BatteryVoltage_Type == 72)
                    {
                        Model.getInstance().list_SlaveSend[slotId - 1].request_Wattage = 10;
                    }

                    Model.getInstance().list_SlaveSend[slotId - 1].BatteryOutput = true;  // 충전 명령
                    break;
            }

            
        }

        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_STATUSCHECK] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_STATUSCHECK] = ++CurrentStep;
        }

        private static void JumpStep(int step)
        {
            CsDefine.Delayed[CsDefine.CYC_STATUSCHECK] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_STATUSCHECK] = step;
        }
    }
}
