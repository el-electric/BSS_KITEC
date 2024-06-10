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
                    mainFormLabelUpdate("");

                    Model.getInstance().Retreive_slot[0] = 0;
                    Model.getInstance().Retreive_slot[1] = 0;

                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = 0;
                    /*NextStep();*/
                    break;
                case CsDefine.CYC_INIT + 1:
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
                    CsWakeup.interverWakeUP();
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 3:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        if (sp_Slave.Check_able_battery_slot())
                        {
                            Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[0] - 1].doorOpen = true;
                            Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[1] - 1].doorOpen = true;
                            frmFrame.deleMenuClick(0);
                            mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                            NextStep();
                        }
                        else
                        {
                            Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_authorize(enumData.Fault.ToString(), 1, "유효 슬롯 없음");
                            Model.getInstance().frmFrame.NotiShow("사용 가능한 슬롯이 없습니다.\n다른 스테이션을 이용해주세요", 1000);
                            frmFrame.deleMenuClick(0);
                            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                        }
                    }
                    break;
                case CsDefine.CYC_MAIN + 4:
                    if (Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[0] - 1].BatterArrive && Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[0] - 1].isDoor == false &&
                        Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[1] - 1].BatterArrive && Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("배터리 인증중 입니다.");
                        NextStep();
                    }
                    else if (!Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[0] - 1].BatterArrive && Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[0] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[0] - 1].doorOpen = true;
                    }
                    else if (!Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[1] - 1].BatterArrive && Model.getInstance().list_SlaveRecv[Model.getInstance().Retreive_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[0] - 1].doorOpen = true;
                    }
                    break;
                    case CsDefine.CYC_MAIN + 5:

                    break;
                case CsDefine.CYC_MAIN + 6:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        mainFormLabelUpdate("1245");
                        NextStep();
                    }
                    break;
            }


                CsWakeup.interverWakeUP();
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
