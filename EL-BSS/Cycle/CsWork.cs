using BatteryChangeCharger.OCPP;
using DrakeUI.Framework;
using EL_DC_Charger.ocpp.ver16.comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public static class CsWork
    {
        public static int CurrentStep = 0;

        public static void Main_WorkCycle() //자동동작 시퀀스
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_RUN])
            {
                case CsDefine.CYC_INIT:
                    CurrentStep = CsDefine.CYC_INIT;
                    Model.getInstance().oCPP_Comm_Manager = new OCPP_Comm_Manager();
                    Model.getInstance().oCPP_Comm_SendMgr = new OCPP_Comm_SendMgr();
                    NextStep();
                    break;
                case CsDefine.CYC_INIT + 1:
                    // Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_BootNotification();
                    //Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(Bootnotification);
                    JumpStep(CsDefine.CYC_MAIN);
                    break;

                case CsDefine.CYC_MAIN:
                    mainFormLabelUpdate("start");
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        mainFormLabelUpdate("1245");
                        NextStep();
                    }
                    break;

                case CsDefine.CYC_MAIN + 2:
                    mainFormLabelUpdate("6666");
                    break;
                case CsDefine.CYC_AUTHORIZE:
                    break;
                case CsDefine.CYC_INSERT_BATTERY_FIRST:
                    break;
                case CsDefine.CYC_INSERT_BATTERY_SECOND:
                    break;
                case CsDefine.CYC_CHARGING:
                    CsWakeup.CYC_WAKEUP();
                    break;
                case CsDefine.CYC_RETRIEVE_BATTERY_FIRST:
                    break;
                case CsDefine.CYC_RETRIEVE_BATTERY_SECOND:
                    break;
                case CsDefine.CYC_COMPLETE:
                    break;

            }

        }
        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_RUN] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = ++CurrentStep;
        }

        private static void JumpStep(int step)
        {
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = step;
        }

        private static void mainFormLabelUpdate(string context)
        {
            var observer = Model.getInstance().frmFrame.observers.FirstOrDefault(o => ReferenceEquals(o, Model.getInstance().frmFrame));
            observer?.UpdateForm(context);
        }

    }
}
