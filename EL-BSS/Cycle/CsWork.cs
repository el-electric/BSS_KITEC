﻿using BatteryChangeCharger.OCPP;
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
using System.Windows.Forms;
using WebSocket4Net;
using static EL_BSS.Model;
using static System.Windows.Forms.AxHost;

namespace EL_BSS.Cycle
{
    public static class CsWork
    {
        public static int CurrentStep = 0;
        static int recvSlot1;
        static int recvSlot2;
        static Nullable<DateTime> dt_Door_Error = null;
        private static Sound_Player sound_Player;

        public async static Task Main_WorkCycle() //자동동작 시퀀스
        {
            if (CsDefine.Delayed[CsDefine.CYC_BAR_COLOR] >= 1000)
            {
                CsDefine.Delayed[CsDefine.CYC_BAR_COLOR] = 0;
                Model.getInstance().frmFrame.Set_Change_progress_Color();
            }

            if (Model.getInstance().bis_Click_Home_button)
            {
                Model.getInstance().bis_Click_Home_button = false;
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
                        "User Nanme : " + getInstance().Authorize.userName + "\n" +
                        "Battery Set : " + getInstance().Authorize.batterySetName + "\n" +
                        "Subscribe : " + getInstance().Authorize.ticketAvailable_value + "\n" +
                        "Remain Cash : " + getInstance().Authorize.cashBalance + "IDR" + "\n" +
                        "Battery Type : " + getInstance().Authorize.batteryType + "V";
                    frmFrame.deleMenuClick(5, puttext);
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 2:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 3:
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
                        mainFormLabelUpdate("Put the battery in the open slot and close the door.");
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
                        getInstance().frmFrame.NotiShow("No slots available.\nPlease use another station", 1000);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    break;
                case CsDefine.CYC_MAIN + 4:
                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false &&  // 배터리가 들어있고 문이 닫혔다면
                        getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)
                    {
                        mainFormLabelUpdate("Battery Certification");
                        NextStep();
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].isDoor == false)  // 문을 열었는데 배터리를 넣지않고 문을 닫으면
                    {
                        mainFormLabelUpdate("Put the battery in the slot and close the door");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].isDoor == false)  // 문을 열었는데 배터리를 넣지않고 문을 닫으면
                    {
                        mainFormLabelUpdate("Put the battery in the slot and close the door");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    }
                    break;
                case CsDefine.CYC_MAIN + 5:  // wakeup 시퀀스

                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].WAKEUP_Signal && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].WAKEUP_Signal)
                    {
                        if (Model.getInstance().Battery_Error_Code[getInstance().Lent_slot[0] - 1][Battery_Error.Wake_Up_Error] &&
                            Model.getInstance().Battery_Error_Code[getInstance().Lent_slot[1] - 1][Battery_Error.Wake_Up_Error])
                        { Model.getInstance().csErrorControl.Is_Slot_Error(getInstance().Lent_slot, Battery_Error.Wake_Up_Error, false); }

                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].BatteryFETON = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].BatteryFETON = true;
                        NextStep();
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 20000)
                    {
                        mainFormLabelUpdate("Please reseat the battery.");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                        Model.getInstance().csErrorControl.Is_Slot_Error(getInstance().Lent_slot, Battery_Error.Wake_Up_Error, true);
                        JumpStep(CsDefine.CYC_MAIN + 4);
                    }
                    break;
                case CsDefine.CYC_MAIN + 6:  // feton 시퀀스
                    if (getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].FET_ON_State && getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].FET_ON_State)
                    {
                        if (Model.getInstance().Battery_Error_Code[getInstance().Lent_slot[0] - 1][Battery_Error.FET_On_Error] &&
                            Model.getInstance().Battery_Error_Code[getInstance().Lent_slot[1] - 1][Battery_Error.FET_On_Error])
                        { Model.getInstance().csErrorControl.Is_Slot_Error(getInstance().Lent_slot, Battery_Error.FET_On_Error, false); }

                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_TEMP;  // 함수실행중 또 함수가 실행되는 것을 막음
                    }
                    else if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 20000)
                    {
                        mainFormLabelUpdate("Please reseat the battery.");
                        getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;

                        Model.getInstance().csErrorControl.Is_Slot_Error(getInstance().Lent_slot, Battery_Error.FET_On_Error, true);
                        JumpStep(CsDefine.CYC_MAIN + 4);
                    }
                    break;

                case CsDefine.CYC_MAIN + 7:
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 8:
                    CsCharging.isCharging_Two_Slot(getInstance().Lent_slot);
                    mainFormLabelUpdate("Return Complete");
                    frmFrame.deleMenuClick(0);
                    NextStep();
                    break;
                case CsDefine.CYC_MAIN + 9:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 1000)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                        mainFormLabelUpdate("Please take the battery in the slot with the door open.");
                        CsDefine.Delayed[CsDefine.CYC_RUN] = 0;
                        NextStep();
                    }
                    break;
                case CsDefine.CYC_MAIN + 10:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        NextStep();
                    }

                    break;
                case CsDefine.CYC_MAIN + 11:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive &&
                        !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        mainFormLabelUpdate("Thank you. Goodbye");
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_battery_Excange_Finished(enumData.finished.ToString());
                        NextStep();
                    }
                    else if (!Model.getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        mainFormLabelUpdate("Please remove the battery and close the door");
                    }
                    else if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && Model.getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                        mainFormLabelUpdate("Please remove the battery and close the door");
                    }

                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 15000)
                    {
                        JumpStep(CsDefine.CYC_DOOR_ERROR);
                    }
                    break;
                case CsDefine.CYC_MAIN + 12:
                    if (CsDefine.Delayed[CsDefine.CYC_RUN] >= 5000)
                    {
                        JumpStep(CsDefine.CYC_INIT);
                        CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    }
                    break;

                case CsDefine.CYC_TEMP:

                    //CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_TEMP + 1;


                    if (
                        ((getInstance().Authorize.returnbatteryId[0].Equals(getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString()) &&  // 서버에서 받은 batteryid와 배터리에서 받은 serialnum이 일치할때
                        getInstance().Authorize.returnbatteryId[1].Equals(getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))
                        ||
                        (getInstance().Authorize.returnbatteryId[1].Equals(getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Serial_Number.ToString()) &&
                         getInstance().Authorize.returnbatteryId[0].Equals(getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Serial_Number.ToString()))) &&
                         is_Same_Battery_Type()
                         )
                    {
                        string response = await Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_DataTransfer_battery_exchange(Model.getInstance().Lent_slot, Model.getInstance().Retreive_slot);

                        switch (response)
                        {
                            case "00000":
                                frmFrame.deleMenuClick(5, "배터리 인증 성공");
                                JumpStep(CsDefine.CYC_MAIN + 7);
                                break;
                            case "11101":
                                getInstance().frmFrame.NotiShow("Battery not found", 10000);
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "11102":
                                getInstance().frmFrame.NotiShow("Battery set not found", 10000);
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "10002":
                                getInstance().frmFrame.NotiShow("User not found", 10000);
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            case "12102":
                                getInstance().frmFrame.NotiShow("Station does not exist", 10000);
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                            default:
                                getInstance().frmFrame.NotiShow(" No Error Code-" + response, 10000);
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                                Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                                frmFrame.deleMenuClick(0);
                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                                break;
                        }
                    }
                    else
                    {
                        getInstance().frmFrame.NotiShow("The ID of the battery does not match.\nPlease contact the customer center", 10000);
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
                    mainFormLabelUpdate("Please close the door");
                    getInstance().frmFrame.GetfrmMain().show_Door_Close_Popup(getInstance().Retreive_slot);
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[0] - 1, Battery_Error.Door_Closing_Error, true);
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[1] - 1, Battery_Error.Door_Closing_Error, true);
                    sound_Player.play_Sound(true);
                    NextStep();
                    break;
                case CsDefine.CYC_DOOR_ERROR + 1:
                    if (!getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive &&
                        !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor && !getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive)
                    {
                        sound_Player.Stop_play();
                        sound_Player = null;
                        getInstance().frmFrame.GetfrmMain().close_Door_Close_Popup();
                        mainFormLabelUpdate("Thank you. Goodbye.");
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_battery_Excange_Finished(enumData.finished.ToString());
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[0] - 1, Battery_Error.Door_Closing_Error, false);
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(getInstance().Retreive_slot[1] - 1, Battery_Error.Door_Closing_Error, false);
                        JumpStep(CsDefine.CYC_INIT);
                    }
                    else if (getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Retreive_slot[0] - 1].isDoor &&
                        getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].BatterArrive && getInstance().list_SlaveRecv[getInstance().Retreive_slot[1] - 1].isDoor)
                    {
                        Model.getInstance().list_SlaveSend[getInstance().Retreive_slot[0] - 1].doorOpen = true;
                        Model.getInstance().list_SlaveSend[getInstance().Retreive_slot[1] - 1].doorOpen = true;
                    }
                    break;

                case CsDefine.CYC_HOME_BUTTON:
                    JumpStep(CsDefine.CYC_INIT);
                    break;

            }
        }


        static DateTime nextHeartBeatTime = DateTime.Now.AddSeconds(getInstance().HeartBeatInterval);
        static DateTime nextMeterValues = DateTime.Now.AddSeconds(getInstance().MeterValuesInterval);
        public static DateTime nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);
        public static void OCPP_IntervalCycle()
        {
            /*if (Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time != null && Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time.Value.AddSeconds(10) <= DateTime.Now &&  // 왭소켓 제연결
                !Model.getInstance().oCPP_Comm_Manager.get_WebSocket_State())
            {
                Model.getInstance().oCPP_Comm_Manager.Server_Disconnect_Time = null;
                Model.getInstance().oCPP_Comm_Manager.WebSocketOpen();
            }*/

            if (Model.getInstance().Send_bootnotification) Model.getInstance().oCPP_Comm_Manager.Send_Packet_Buffer(Model.getInstance().oCPP_Comm_Manager.buffer);


            if (DateTime.Now >= nextHeartBeatTime)
            {
                nextHeartBeatTime = DateTime.Now.AddSeconds(getInstance().HeartBeatInterval);
            }
            if (DateTime.Now >= nextMeterValues)
            {
                nextMeterValues = DateTime.Now.AddSeconds(getInstance().MeterValuesInterval);
            }
            if (DateTime.Now >= nextStationInfo && Model.getInstance().Send_bootnotification)  // stationinfo 와 addinfostaionBatterystate 전송주기
            {
                nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);

                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StaionInfo(0);
                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StaionInfo(1);

                for (int i = 0; i < 8; i++)
                {
                    Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(i);
                }
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
            CsDefine.Delayed[CsDefine.CYC_RUN] = 0;
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

        private static bool is_Same_Battery_Type()
        {
            if (getInstance().list_SlaveRecv[getInstance().Lent_slot[1] - 1].Check_BatteryVoltage_Type != getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Check_BatteryVoltage_Type)
                return false;

            if (Model.getInstance().Authorize.batteryType != getInstance().list_SlaveRecv[getInstance().Lent_slot[0] - 1].Check_BatteryVoltage_Type)
                return false;

            return true;
        }

    }
}
