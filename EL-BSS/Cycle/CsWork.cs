using BatteryChangeCharger.OCPP;
using DrakeUI.Framework;
using EL_BSS.Serial;
using EL_DC_Charger.ocpp.ver16.comm;
using EL_DC_Charger.ocpp.ver16.packet.cp2csms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static EL_BSS.Model;

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
                    NextStep();
                    break;
                case CsDefine.CYC_INIT + 1:
                    // Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_BootNotification();
                    //Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(Bootnotification);
                    JumpStep(CsDefine.CYC_MAIN);
                    break;

                case CsDefine.CYC_MAIN:
                    //반납 //status // 충전 
                    CurrentStep = CsDefine.CYC_MAIN;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    Model.getInstance().frmFrame.showNotiForm("인증중입니다." + Model.getInstance().Req_Authorize.batterySetName);
                    NextStep();                    
                    break;
                case CsDefine.CYC_MAIN + 2:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        if (sp_Slave.Check_100SOC_Battery())
                        {
                            NextStep();
                        }
                        else
                        {
                            Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_authorize(enumData.Fault.ToString(), 1, "유효 슬롯 없음");
                            NextStep();
                        }
                    }
                    break;
                case CsDefine.CYC_MAIN + 3:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        frmFrame.deleMenuClick(0);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = 0;
                    }
                    break;
                case CsDefine.CYC_MAIN + 4:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        mainFormLabelUpdate("1245");
                        NextStep();
                    }
                    break;
            }

            if (Model.getInstance().Send_Wakeup == null || Model.getInstance().Send_Wakeup != null && Model.getInstance().Send_Wakeup.Value.AddMinutes(5) <= DateTime.Now)
            {
                Model.getInstance().Send_Wakeup = DateTime.Now;
                CsWakeup.interverWakeUP();
            }

        }


        static DateTime nextHeartBeatTime = DateTime.Now.AddSeconds(Model.getInstance().HeartBeatInterval);
        static DateTime nextMeterValues = DateTime.Now.AddSeconds(Model.getInstance().MeterValuesInterval);
        static DateTime nextStationInfo = DateTime.Now.AddSeconds(Model.getInstance().StationInfoInterval);
        public static void OCPP_IntervalCycle()
        {            
            if (DateTime.Now >= nextHeartBeatTime)
            {
                //Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_HeartBeat();
                nextHeartBeatTime = DateTime.Now.AddSeconds(Model.getInstance().HeartBeatInterval);
            }
            if (DateTime.Now >= nextMeterValues)
            {
                nextMeterValues = DateTime.Now.AddSeconds(Model.getInstance().MeterValuesInterval);
            }
            if (DateTime.Now >= nextStationInfo)
            {
                nextStationInfo = DateTime.Now.AddSeconds(Model.getInstance().StationInfoInterval);
            }
        }

        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_RUN] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = ++CurrentStep;
        }

        private static void JumpStep(int step)
        {
            CurrentStep = step;
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = step;
        }

        private static void mainFormLabelUpdate(string context)
        {
            var observer = Model.getInstance().frmFrame.observers.FirstOrDefault(o => ReferenceEquals(o, Model.getInstance().frmFrame));
            observer?.UpdateForm(context);
        }

    }
}
