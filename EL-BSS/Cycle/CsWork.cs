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

        public async static void Main_WorkCycle() //자동동작 시퀀스
        {
            if (Model.Dt_SendInterval.AddSeconds(Model.SendInterval) > DateTime.Now)
            {
                ///////////////////////////////////


                ///////////////////////////////////
                Model.Dt_SendInterval = DateTime.Now;
            }

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
                    getInstance().frmFrame.GetfrmMain().setting_button_visible(false);
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    string puttext = "사용자 이름 : " + getInstance().Authorize.userName + "\n" + "배터리 세트 : " + getInstance().Authorize.batterySetName + "\n" + "구독 여부 : " + getInstance().Authorize.ticketAvailable_value + "\n" + "잔여캐시 : " + getInstance().Authorize.cashBalance + "원";
                    getInstance().frmFrame.showNotiForm(puttext);
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 2:
                    /*CsWakeup.interverWakeUP();*/
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 3:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        if (sp_Slave.Check_able_battery_slot())  // 사용가능한 슬롯이 있을 경우 반납받을 슬롯과 대여할 슬롯을 결정해둔다
                        {
                            if (Model.getInstance().Authorize_Type == enumData.APP.ToString())
                            {
                                getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                                frmFrame.deleMenuClick(0);
                                mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                                NextStep();
                            }
                            else if (Model.getInstance().Authorize_Type == enumData.STATION.ToString())
                            {
                                getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                                frmFrame.deleMenuClick(0);
                                mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                                NextStep();

                            }
                        }
                        else  // 없을 경우
                        {
                            frmFrame.deleMenuClick(0);
                            getInstance().frmFrame.NotiShow("사용 가능한 슬롯이 없습니다.\n다른 스테이션을 이용해주세요", 1000);
                            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                        }
                    }
                    break;
                case CsDefine.CYC_MAIN + 4:
                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false &&  // 배터리가 들어있고 문이 닫혔다면
                        getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("배터리 통신중 입니다.");
                        NextStep();
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false)  // 문을 열었는데 배터리를 넣지않고 문을 닫으면
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)  // 문을 열었는데 배터리를 넣지않고 문을 닫으면
                    {
                        mainFormLabelUpdate("슬롯의 배터리를 넣고 문을 닫아주세요");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    }
                    break;
                case CsDefine.CYC_MAIN + 5:  // wakeup 시퀀스
                    /*if (_slot_Count == 2)
                    {
                        _slot_Count = 0;
                        NextStep();
                    }*/

                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_TEMP;


                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].WAKEUP_Signal && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].WAKEUP_Signal)
                    {
                        if ((getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString() &&  // 서버에서 받은 batteryid와 배터리에서 받은 serialnum이 일치할때
                        getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString())
                        ||
                        (getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString() &&
                         getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))
                        {
                            string response = await Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_DataTransfer_battery_exchange(Model.getInstance().Retreive_slot, Model.getInstance().Lent_slot);

                            switch (response)
                            {
                                case "00000":
                                    getInstance().frmFrame.showNotiForm("배터리 인증 성공");
                                    NextStep();
                                    break;
                                case "11101":
                                    getInstance().frmFrame.showNotiForm("배터리를 찾을 수 없습니다.");
                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                    break;
                                case "11102":
                                    getInstance().frmFrame.showNotiForm("배터리 세트를 찾을 수 없습니다.");
                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                    break;
                                case "10002":
                                    getInstance().frmFrame.showNotiForm("이용자가 없습니다.");
                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                    break;
                                case "12102":
                                    getInstance().frmFrame.showNotiForm("스테이션이 존재하지 않습니다");
                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                    break;
                                default:
                                    getInstance().frmFrame.showNotiForm("없는 애러코드");
                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                    break;
                            }
                        }
                        NextStep();
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 10000)
                    {

                    }
                    /*else
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_WAKEUP; // 반납받은 슬롯의 배터리를 확인한다
                    }*/
                    break;
                /*case CsDefine.CYC_WAKEUP:
                    bool wakeupflag = CsWakeup.isWakeUP(getInstance().Lent_slot[_slot_Count]);

                    if (wakeupflag) { _slot_Count++; }  // 슬롯의 배터리를 받아서 Wakeup을 받으면
                    else // wake up을 받지 못한다면
                    {
                        getInstance().list_SlaveSend[getInstance().Lent_slot[_slot_Count] - 1].doorOpen = true;
                        mainFormLabelUpdate("문이 열린 슬롯의 배터리를 다시 장착해주세요.");
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 4;
                    }

                    if (_slot_Count == 2)
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN + 5;
                    }
                    break;*/
                case CsDefine.CYC_MAIN + 6:  // feton 시퀀스
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
                case CsDefine.CYC_MAIN + 7:
                    if ((getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString() &&  // 서버에서 받은 batteryid와 배터리에서 받은 serialnum이 일치할때
                        getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString())
                        ||
                        (getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString() &&
                         getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))
                    {
                        string response = await Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_DataTransfer_battery_exchange(Model.getInstance().Retreive_slot, Model.getInstance().Lent_slot);

                        switch (response)
                        {
                            case "00000":
                                getInstance().frmFrame.showNotiForm("배터리 인증 성공");
                                NextStep();
                                break;
                            case "11101":
                                getInstance().frmFrame.showNotiForm("배터리를 찾을 수 없습니다.");
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "11102":
                                getInstance().frmFrame.showNotiForm("배터리 세트를 찾을 수 없습니다.");
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "10002":
                                getInstance().frmFrame.showNotiForm("이용자가 없습니다.");
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "12102":
                                getInstance().frmFrame.showNotiForm("스테이션이 존재하지 않습니다");
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            default:
                                getInstance().frmFrame.showNotiForm("없는 애러코드");
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                        }
                    }
                    else
                    {
                        getInstance().frmFrame.NotiShow("배터리의 ID가 일치하지 않습니다.\n고객센터에 문의해주세요.", 1000);
                        frmFrame.deleMenuClick(0);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    break;
                case CsDefine.CYC_MAIN + 8:
                    if (CsCharging.isCharging(getInstance().Lent_slot[0]) && CsCharging.isCharging(getInstance().Lent_slot[1]))
                    {
                        /*Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StartTrnasaction(getInstance().Lent_slot[0] - 1);
                        Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StartTrnasaction(getInstance().Lent_slot[1] - 1);*/
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

                case CsDefine.CYC_TEMP:
                    break;

            }

            //for (int c = 1; c < 9; c++)
            //{
            //    if (Model.getInstance().list_SlaveSend[c - 1].BatteryOutput == true && Model.getInstance().list_SlaveRecv[c - 1].ChargingStatus == 100)
            //    {
            //        CsCharging.Main_WorkCycle(c);
            //    }
            //}


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
