using BatteryChangeCharger.OCPP;
using DrakeUI.Framework;
using EL_BSS.Serial;
using EL_DC_Charger.ocpp.ver16.comm;
using EL_DC_Charger.ocpp.ver16.packet.cp2csms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public static class CsWork
    {
        public static int CurrentStep = 0;

        private static Sound_Player sound_Player;

        private static Nullable<DateTime> dt_not_closed_time = null;

        public async static void Main_WorkCycle() //자동동작 시퀀스
        {
            if (CsDefine.Delayed[CsDefine.CYC_BAR_COLOR] >= 1000)
            {
                CsDefine.Delayed[CsDefine.CYC_BAR_COLOR] = 0;
                Model.getInstance().frmFrame.Set_Change_progress_Color();
            }

            if (Model.getInstance().bis_Click_Home_button)
            {
                Model.getInstance().bis_Click_Home_button = false;
                Model.getInstance().frmFrame.GetfrmMain().show_Door_Close_Popup(1, 2);
            }

            if (Model.Dt_SendInterval.AddSeconds(Model.SendInterval) < DateTime.Now && Model.getInstance().Send_bootnotification)
            {
                Model.Dt_SendInterval = DateTime.Now;
                ///////////////////////////////////
                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StaionInfo(0);
                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StaionInfo(1);

                for (int i = 0; i < 8; i++)
                {
                    Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(i);
                }

                ///////////////////////////////////
            }

            switch (CsDefine.Cyc_Rail[CsDefine.CYC_RUN])
            {

                case CsDefine.CYC_INIT:
                    mainFormLabelUpdate("");
                    for (int i = 1; i <= 8; i++)
                    {
                        Model.getInstance().list_SlaveRecv[i - 1].isSequence = false;
                    }
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_END;
                    break;
                case CsDefine.CYC_MAIN:
                    //반납 //status // 충전 
                    CurrentStep = CsDefine.CYC_MAIN;
                    mainFormLabelUpdate("");

                    getInstance().Retreive_slot[0] = 0;
                    getInstance().Retreive_slot[1] = 0;
                    getInstance().Lent_slot[0] = 0;
                    getInstance().Lent_slot[1] = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        getInstance().list_SlaveRecv[i].isSequence = false;
                    }
                    /*getInstance().Authorize = null;*/
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 1:
                    string puttext =
                        "사용자 이름 : " + getInstance().Authorize.userName + "\n" +
                        "배터리 세트 : " + getInstance().Authorize.batterySetName + "\n" +
                        "구독 여부 : " + getInstance().Authorize.ticketAvailable_value + "\n" +
                        "잔여캐시 : " + getInstance().Authorize.cashBalance + "원" + "\n" +
                        "배터리 종류 : " + getInstance().Authorize.batteryType + "V";
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
                                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Conf_Authorize(Model.getInstance().Authorize.uid, enumData.success.ToString());
                            }
                            else if (Model.getInstance().Authorize_Type == enumData.STATION.ToString())
                            {

                            }

                            getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                            getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                            frmFrame.deleMenuClick(0);
                            mainFormLabelUpdate("문이 열린 슬롯의 배터리를 넣고 문을 닫아주세요.");
                            NextStep();
                        }
                        else  // 없을 경우
                        {
                            if (Model.getInstance().Authorize_Type == enumData.APP.ToString())
                            {
                                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Conf_Authorize(Model.getInstance().Authorize.uid, enumData.fail.ToString());
                            }
                            else if (Model.getInstance().Authorize_Type == enumData.STATION.ToString())
                            {
                                // Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_battery_Excange_Finished(enumData.fail.ToString());
                            }


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

                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].WAKEUP_Signal && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].WAKEUP_Signal)
                    {
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].BatteryFETON = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].BatteryFETON = true;
                        NextStep();
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 10000)
                    {
                        mainFormLabelUpdate("배터리를 다시 장착해주세요.");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                        JumpStep(CsDefine.CYC_MAIN + 4);
                    }
                    break;
                case CsDefine.CYC_MAIN + 6:  // feton 시퀀스
                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].FET_ON_State && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].FET_ON_State)
                    {
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_TEMP;  // 함수실행중 또 함수가 실행되는 것을 막음
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 10000)
                    {
                        mainFormLabelUpdate("배터리를 다시 장착해주세요.");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                        JumpStep(CsDefine.CYC_MAIN + 4);
                    }
                    break;

                case CsDefine.CYC_MAIN + 7:
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 8:
                    if (CsCharging.isCharging(getInstance().Lent_slot[0]) && CsCharging.isCharging(getInstance().Lent_slot[1]))
                    {
                        ///////////////////////////////////////////////////
                        /*getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(getInstance().Lent_slot[0]);
                        getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(getInstance().Lent_slot[1]);*/

                        // getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[0], enumData.Charging.ToString());
                        // getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(getInstance().Lent_slot[1], enumData.Charging.ToString());
                        ///////////////////////////////////////////////////

                        mainFormLabelUpdate("반납이 완료 되었습니다.");
                        frmFrame.deleMenuClick(0);
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 9:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                        mainFormLabelUpdate("문이 열린 슬롯의 배터리를 가져가 주세요.");
                        dt_not_closed_time = DateTime.Now;
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 10:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive &&
                        !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        mainFormLabelUpdate("감사합니다. 안녕히가세요.");
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_battery_Excange_Finished(enumData.finished.ToString());
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

                    /*if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 3000 &&
                        (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive) ||
                        (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive))
                    {
                        JumpStep(CsDefine.CYC_DOOR_ERROR);
                    }*/

                    if (dt_not_closed_time != null && dt_not_closed_time.Value.AddSeconds(10) <= DateTime.Now &&
                        (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive) ||
                        (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive))
                    {
                        JumpStep(CsDefine.CYC_DOOR_ERROR);
                    }

                    break;
                case CsDefine.CYC_MAIN + 11:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        JumpStep(0);
                    }
                    break;

                case CsDefine.CYC_TEMP:

                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_TEMP + 1;

                    if ((getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString() &&  // 서버에서 받은 batteryid와 배터리에서 받은 serialnum이 일치할때
                        getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString())
                        ||
                        (getInstance().Authorize.returnbatteryId[1] == getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString() &&
                         getInstance().Authorize.returnbatteryId[0] == getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))
                    {
                        string response = await Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_DataTransfer_battery_exchange(Model.getInstance().Lent_slot, Model.getInstance().Retreive_slot);

                        switch (response)
                        {
                            case "00000":
                                getInstance().frmFrame.showNotiForm("배터리 인증 성공");
                                NextStep();
                                break;
                            case "11101":
                                getInstance().frmFrame.showNotiForm("배터리를 찾을 수 없습니다.");
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "11102":
                                getInstance().frmFrame.showNotiForm("배터리 세트를 찾을 수 없습니다.");
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "10002":
                                getInstance().frmFrame.showNotiForm("이용자가 없습니다.");
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "12102":
                                getInstance().frmFrame.showNotiForm("스테이션이 존재하지 않습니다");
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            default:
                                getInstance().frmFrame.showNotiForm("없는 애러코드");
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                        }
                    }
                    else
                    {
                        getInstance().frmFrame.NotiShow("배터리의 ID가 일치하지 않습니다.\n고객센터에 문의해주세요.", 10000);
                        Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                        Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                        frmFrame.deleMenuClick(0);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    break;

                case CsDefine.CYC_TEMP + 1:

                    break;

                case CsDefine.CYC_DOOR_ERROR:
                    sound_Player = new Sound_Player();
                    mainFormLabelUpdate("문을 닫아주세요");
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[0] - 1, Battery_Error.Door_Closing_Error, true);
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[1] - 1, Battery_Error.Door_Closing_Error, true);
                    // Model.getInstance().frmFrame.GetfrmMain().show_Door_Close_Popup(getInstance().Retreive_slot[0], getInstance().Retreive_slot[1]);
                    sound_Player.play_Sound(true);
                    NextStep();
                    break;
                case CsDefine.CYC_DOOR_ERROR + 1:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive &&
                        !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        sound_Player.Stop_play();
                        mainFormLabelUpdate("감사합니다. 안녕히가세요.");
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_battery_Excange_Finished(enumData.finished.ToString());
                        // Model.getInstance().frmFrame.GetfrmMain().close_Door_Close_Popup();
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[0] - 1, Battery_Error.Door_Closing_Error, false);
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[1] - 1, Battery_Error.Door_Closing_Error, false);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    else if (getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor &&
                        getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor)
                    {
                        Model.getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        Model.getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                    }
                    break;

            }


            if (Model.getInstance().Send_bootnotification)
            {
                CsWakeup.interverWakeUP(); // 배터리가 슬롯에 왔을떄 wakeup을 시켜줌
                Model.getInstance().csErrorControl.Check_Error_Occured();
            }
        }


        static DateTime nextHeartBeatTime = DateTime.Now.AddSeconds(getInstance().HeartBeatInterval);
        static DateTime nextMeterValues = DateTime.Now.AddSeconds(getInstance().MeterValuesInterval);
        static DateTime nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);
        public static void OCPP_IntervalCycle()
        {
            /*if (Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time.AddSeconds(5).IsAfter(DateTime.Now) && !Model.getInstance().oCPP_Comm_Manager.get_WebSocket_State())
            {
                Model.getInstance().oCPP_Comm_Manager.WebSocketOpen();
            }*/
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
