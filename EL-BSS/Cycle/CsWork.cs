using BatteryChangeCharger.OCPP;
using DrakeUI.Framework;
using EL_BSS.Serial;
using EL_DC_Charger.ocpp.ver16.comm;
using EL_DC_Charger.ocpp.ver16.packet.cp2csms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static int _slot_Count = 0;

        public static void Main_WorkCycle() //자동동작 시퀀스
        {


            switch (CsDefine.Cyc_Rail[CsDefine.CYC_RUN])
            {
                case CsDefine.CYC_MAIN:
                    //반납 //status // 충전 
                    CurrentStep = CsDefine.CYC_MAIN;
                    mainFormLabelUpdate("");

                    getInstance().Retreive_slot[0] = 0;
                    getInstance().Retreive_slot[1] = 0;
                    getInstance().Lent_slot[0] = 0;
                    getInstance().Lent_slot[1] = 0;
                    _slot_Count = 0;
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    getInstance().frmFrame.showNotiForm("인증중입니다." + getInstance().Req_Authorize.batterySetName);
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
                            /*if (enumData.Accepted.ToString() == JsonConvert.DeserializeObject<JArray>(Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(Model.getInstance().Retreive_slot[0], enumData.Preparing.ToString()).ToString())?[2]?["status"]?.ToString() &&
                                enumData.Accepted.ToString() == JsonConvert.DeserializeObject<JArray>(Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(Model.getInstance().Retreive_slot[1], enumData.Preparing.ToString()).ToString())?[2]?["status"]?.ToString())
                            {
                                Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[Model.getInstance().Retreive_slot[1] - 1].doorOpen = true;

                                frmFrame.deleMenuClick(0);
                                mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                                NextStep();
                            }*/

                            getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[0], enumData.Preparing.ToString());
                            getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[1], enumData.Preparing.ToString());

                            getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                            getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                            frmFrame.deleMenuClick(0);
                            mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                            NextStep();


                        }
                        else
                        {
                            getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_authorize(enumData.Fault.ToString(), 1, "유효 슬롯 없음");
                            getInstance().frmFrame.NotiShow("사용 가능한 슬롯이 없습니다.\n다른 스테이션을 이용해주세요", 1000);
                            frmFrame.deleMenuClick(0);
                            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                        }
                    }
                    break;
                case CsDefine.CYC_MAIN + 4:
                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false &&
                        getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("배터리 인증중 입니다.");
                        NextStep();
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    }
                    break;
                case CsDefine.CYC_MAIN + 5:
                    if (_slot_Count == 2)
                    {
                        _slot_Count = 0;
                        NextStep();
                    }
                    else
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_WAKEUP;
                    }
                    break;
                case CsDefine.CYC_WAKEUP:
                    bool wakeupflag = CsWakeup.isWakeUP(getInstance().Lent_slot[_slot_Count]);

                    if (wakeupflag) { _slot_Count++; }
                    else 
                    {
                        getInstance().list_SlaveSend[getInstance().Lent_slot[_slot_Count] - 1].doorOpen = true;
                        mainFormLabelUpdate("문이 열린 슬롯의 배터리를 다시 장착해주세요.");
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 4;
                    }

                    if (_slot_Count == 2)
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 5;
                    }
                    break;
                case CsDefine.CYC_MAIN + 6:
                    if ((getInstance().Req_Authorize.batteryId1 == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString() &&  // 서버에서 받은 batteryid와 배터리에서 받은 serialnum이 일치할때
                        getInstance().Req_Authorize.batteryId2 == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString()) 
                        ||
                        (getInstance().Req_Authorize.batteryId1 == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString() &&
                         getInstance().Req_Authorize.batteryId2 == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))
                    {
                        NextStep();
                    }
                    else
                    {
                        getInstance().frmFrame.NotiShow("배터리의 ID가 일치하지 않습니다.\n고객센터에 문의해주세요.", 1000);
                        frmFrame.deleMenuClick(0);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    break;
                case CsDefine .CYC_MAIN + 7:
                    if (_slot_Count == 2)
                    {
                        _slot_Count = 0;
                        NextStep();
                    }
                    else
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_FETON;
                    }
                    break;
                case CsDefine.CYC_FETON:
                    bool FETonflag = CsWakeup.isFETon(getInstance().Lent_slot[_slot_Count]);
                    if (FETonflag) { _slot_Count++; }
                    else
                    {
                        getInstance().list_SlaveSend[getInstance().Lent_slot[_slot_Count] - 1].doorOpen = true;
                        mainFormLabelUpdate("문이 열린 슬롯의 배터리를 다시 장착해주세요.");
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 4;
                    }

                    if (_slot_Count == 2)
                    {
                        _slot_Count = 0;
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 8;
                    }

                    break;
                case CsDefine.CYC_MAIN + 8:
                    if (CsCharging.isCharging(getInstance().Lent_slot[0]) && CsCharging.isCharging(getInstance().Lent_slot[1]))
                    {
                        getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[0], enumData.Charging.ToString());
                        getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[1], enumData.Charging.ToString());
                        mainFormLabelUpdate("반납이 완료 되었습니다.");
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 9:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                        mainFormLabelUpdate("문이 열린 슬롯의 배터리를 가져가 주세요.");
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 10:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive &&
                        !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Retreive_slot[0], enumData.Empty.ToString());
                        getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Retreive_slot[1], enumData.Empty.ToString());
                        mainFormLabelUpdate("감사합니다. 안녕히가세요.");
                        NextStep();
                    }
                    else if (!Model.getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        mainFormLabelUpdate("배터리를 빼고 문을 닫아주세요");
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && Model.getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                        mainFormLabelUpdate("배터리를 빼고 문을 닫아주세요");
                    }
                    break;
                case CsDefine.CYC_MAIN + 11:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        JumpStep(0);
                    }
                    break;
                
            }


                CsWakeup.interverWakeUP();
        }


        static DateTime nextHeartBeatTime = DateTime.Now.AddSeconds(getInstance().HeartBeatInterval);
        static DateTime nextMeterValues = DateTime.Now.AddSeconds(getInstance().MeterValuesInterval);
        static DateTime nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);
        public static void OCPP_IntervalCycle()
        {            
            if (DateTime.Now >= nextHeartBeatTime)
            {
                //Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_HeartBeat();
                nextHeartBeatTime = DateTime.Now.AddSeconds(getInstance().HeartBeatInterval);
            }
            if (DateTime.Now >= nextMeterValues)
            {
                nextMeterValues = DateTime.Now.AddSeconds(getInstance().MeterValuesInterval);
            }
            if (DateTime.Now >= nextStationInfo)
            {
                nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);
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
            var observer = getInstance().frmFrame.observers.FirstOrDefault(o => ReferenceEquals(o, getInstance().frmFrame));
            observer?.UpdateForm(context);
        }

        private static void State_Error(string context)
        {
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
            getInstance().frmFrame.NotiShow("문제가 발생하였습니다. 관리자에게 문의해주세요\n" + context, 1000);
        }

    }
}
