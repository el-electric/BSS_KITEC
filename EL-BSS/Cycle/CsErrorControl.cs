﻿using EL_BSS.Serial;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using static EL_BSS.Model;
using static System.Windows.Forms.AxHost;

namespace EL_BSS.Cycle
{
    public class CsErrorControl
    {
        public CsErrorControl()
        {
            for (int i = 0; i < 8; i++)
            {
                Model.getInstance().Battery_Error_Code[i] = new Dictionary<Battery_Error, bool>
                {
                    // 배터리 관련 에러
                    { Battery_Error.Low_Voltage,                                  false},
                    { Battery_Error.Over_Voltage,                                 false},
                    { Battery_Error.Pack_Low_Voltage,                             false},
                    { Battery_Error.Pack_High_Voltage,                            false},
                    { Battery_Error.Cell_Regeneration_OverCharge,                 false},
                    { Battery_Error.Pack_Regeneration_OverCharge,                 false},
                    { Battery_Error.Over_Discharge,                               false},
                    { Battery_Error.Over_Charge,                                  false},
                    { Battery_Error.Regeneration_OverCharge,                      false},
                    { Battery_Error.Cell_Low_Temperature,                         false},
                    { Battery_Error.Cell_High_Temperature,                        false},
                    { Battery_Error.FET_Low_Temperature,                          false},
                    { Battery_Error.FET_High_Temperature,                         false},
                    { Battery_Error.Low_Voltage_Protection,                       false},
                    { Battery_Error.High_Voltage_Protection,                      false},
                    { Battery_Error.Pack_Low_Voltage_Protection,                  false},
                    { Battery_Error.Pack_High_Voltage_Protection,                 false},
                    { Battery_Error.Cell_Regeneration_OverCharge_Protection,      false},
                    { Battery_Error.Pack_Regeneration_OverCharge_Protection,      false},
                    { Battery_Error.Over_Discharge_Protection,                    false},
                    { Battery_Error.Over_Charge_Protection,                       false},
                    { Battery_Error.Regeneration_OverCharge_Protection,           false},
                    { Battery_Error.Cell_Low_Temperature_Protection,              false},
                    { Battery_Error.Cell_High_Temperature_Protection,             false},
                    { Battery_Error.FET_Low_Temperature_Protection,               false},
                    { Battery_Error.FET_High_Temperature_Protection,              false},
                    { Battery_Error.Short_Circuit_Protect,                        false},
                    { Battery_Error.VCU_Error,                                    false},
                    { Battery_Error.Pre_Charge_Error,                             false},
                    { Battery_Error.BMS_Error,                                    false},
                    { Battery_Error.Over_Current,                                 false},


                    // 슬롯 관련 에러
                    { Battery_Error.Slot_Temperature_Error,                       false},
                    { Battery_Error.FET_On_Error,                                 false},
                    { Battery_Error.Wake_Up_Error,                                false},
                    { Battery_Error.Door_Closing_Error,                           false},
                    { Battery_Error.Door_Opening_Error,                           false},
                    { Battery_Error.Power_Pack_Error,                             false},
                    { Battery_Error.Control_Board_Error,                          false}
                };
            }
            for (int i = 0; i < 2; i++)
            {
                Model.getInstance().dic_Station_Error_Code[i] = new Dictionary<Station_Error, bool>
                {
                    // 스테이션 에러
                    { Station_Error.vibrationWarning,                               false},
                    { Station_Error.floodingWarning,                                false},
                    { Station_Error.Charger_Humidity,                               false },
                    { Station_Error.Charger_UpperTemper,                            false},
                    { Station_Error.Control_Board_Error,                            false},
                };
            }
        }

        public void Check_Error_Occured()
        {
            var model = Model.getInstance();

            if (model.frmFrame.GetfrmMain() != null)
            {
                for (int m = 0; m < 2; m++)
                {
                    set_Error_LED(true, (Model.getInstance().list_MasterRecv[0].Error_Occured && Model.getInstance().list_SlaveRecv[1].Error_Occured));
                    if (!model.list_MasterRecv[m].Error_Occured)
                    {
                        if (model.list_MasterRecv[m].vibrationWarning)
                        {
                            model.frmFrame.GetfrmMain().show_p("Unable to use due to vibration.\nPlease contact the administrator");
                            is_station_error(m, Station_Error.vibrationWarning, true);
                        }
                        else if (model.list_MasterRecv[m].floodingWarning)
                        {
                            model.frmFrame.GetfrmMain().show_p("Unable to use due to flooding.\nPlease contact the administrator.");
                            is_station_error(m, Station_Error.floodingWarning, true);
                        }
                        else if (model.list_MasterRecv[m].Charger_UpperTemper > 70)
                        {
                            model.frmFrame.GetfrmMain().show_p("Station high temperature not available.\nPlease contact the administrator.");
                            is_station_error(m, Station_Error.Charger_UpperTemper, true);
                        }
                    }
                    else if (model.list_MasterRecv[m].Error_Occured)
                    {
                        if (Model.getInstance().dic_Station_Error_Code[m][Station_Error.vibrationWarning] && !model.list_MasterRecv[m].vibrationWarning)
                        {
                            Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(m, Station_Error.vibrationWarning, false);
                            Model.getInstance().dic_Station_Error_Code[m][Station_Error.vibrationWarning] = false;
                        }
                        if (Model.getInstance().dic_Station_Error_Code[m][Station_Error.floodingWarning] && !model.list_MasterRecv[m].floodingWarning)
                        {
                            Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(m, Station_Error.floodingWarning, false);
                            Model.getInstance().dic_Station_Error_Code[m][Station_Error.floodingWarning] = false;
                        }
                        if (Model.getInstance().dic_Station_Error_Code[m][Station_Error.Charger_UpperTemper] && model.list_MasterRecv[m].Charger_UpperTemper < 70)
                        {
                            Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(m, Station_Error.Charger_UpperTemper, false);
                            Model.getInstance().dic_Station_Error_Code[m][Station_Error.Charger_UpperTemper] = false;
                        }


                        if (!Model.getInstance().dic_Station_Error_Code[m][Station_Error.vibrationWarning] && !Model.getInstance().dic_Station_Error_Code[m][Station_Error.floodingWarning] &&
                            !Model.getInstance().dic_Station_Error_Code[m][Station_Error.Charger_UpperTemper])
                        {
                            model.frmFrame.GetfrmMain().close_p();
                            model.list_MasterRecv[m].Error_Occured = false;
                        }
                    }

                    /*if (!model.dic_Station_Error_Code[m][Station_Error.Control_Board_Error] && model.list_MasterDataRecvDatetime[m].AddSeconds(5) > DateTime.Now)
                    {
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(m, Station_Error.Control_Board_Error, true);
                        Model.getInstance().dic_Station_Error_Code[m][Station_Error.Control_Board_Error] = true;
                    }
                    else if (model.dic_Station_Error_Code[m][Station_Error.Control_Board_Error] && model.list_MasterDataRecvDatetime[m].AddSeconds(5) < DateTime.Now)
                    {
                        Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(m, Station_Error.Control_Board_Error, false);
                        Model.getInstance().dic_Station_Error_Code[m][Station_Error.Control_Board_Error] = false;
                    }*/
                }

                for (int s = 0; s < 8; s++)
                {
                    set_Error_LED(false, Model.getInstance().list_SlaveRecv[s].Error_Occured,s);

                    //if (model.Battery_Error_Code[s][Battery_Error.Low_Voltage] != model.list_SlaveRecv[s].rowVoltage) { Is_Slot_Error(s, Battery_Error.Low_Voltage, model.list_SlaveRecv[s].rowVoltage); }
                    if (model.Battery_Error_Code[s][Battery_Error.Over_Voltage] != model.list_SlaveRecv[s].highVoltage) { Is_Slot_Error(s, Battery_Error.Over_Voltage, model.list_SlaveRecv[s].highVoltage); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_Low_Voltage] != model.list_SlaveRecv[s].packLowVoltage) { Is_Slot_Error(s, Battery_Error.Pack_Low_Voltage, model.list_SlaveRecv[s].packLowVoltage); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_High_Voltage] != model.list_SlaveRecv[s].packHighVoltage) { Is_Slot_Error(s, Battery_Error.Pack_High_Voltage, model.list_SlaveRecv[s].packHighVoltage); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_Regeneration_OverCharge] != model.list_SlaveRecv[s].cellRecycleOverCharging) { Is_Slot_Error(s, Battery_Error.Cell_Regeneration_OverCharge, model.list_SlaveRecv[s].cellRecycleOverCharging); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_Regeneration_OverCharge] != model.list_SlaveRecv[s].packRecycleOverCharging) { Is_Slot_Error(s, Battery_Error.Pack_Regeneration_OverCharge, model.list_SlaveRecv[s].packRecycleOverCharging); }
                    if (model.Battery_Error_Code[s][Battery_Error.Over_Discharge] != model.list_SlaveRecv[s].overDischarge) { Is_Slot_Error(s, Battery_Error.Over_Discharge, model.list_SlaveRecv[s].overDischarge); }
                    if (model.Battery_Error_Code[s][Battery_Error.Over_Charge] != model.list_SlaveRecv[s].overCharging) { Is_Slot_Error(s, Battery_Error.Over_Charge, model.list_SlaveRecv[s].overCharging); }

                    if (model.Battery_Error_Code[s][Battery_Error.Regeneration_OverCharge] != model.list_SlaveRecv[s].reCycleOverCharging) { Is_Slot_Error(s, Battery_Error.Regeneration_OverCharge, model.list_SlaveRecv[s].reCycleOverCharging); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_Low_Temperature] != model.list_SlaveRecv[s].cell_LowTemp) { Is_Slot_Error(s, Battery_Error.Cell_Low_Temperature, model.list_SlaveRecv[s].cell_LowTemp); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_High_Temperature] != model.list_SlaveRecv[s].cell_HighTemp) { Is_Slot_Error(s, Battery_Error.Cell_High_Temperature, model.list_SlaveRecv[s].cell_HighTemp); }
                    if (model.Battery_Error_Code[s][Battery_Error.FET_Low_Temperature] != model.list_SlaveRecv[s].FET_LowTemp) { Is_Slot_Error(s, Battery_Error.FET_Low_Temperature, model.list_SlaveRecv[s].FET_LowTemp); }
                    if (model.Battery_Error_Code[s][Battery_Error.FET_High_Temperature] != model.list_SlaveRecv[s].FET_HighTemp) { Is_Slot_Error(s, Battery_Error.FET_High_Temperature, model.list_SlaveRecv[s].FET_HighTemp); }

                    //if (model.Battery_Error_Code[s][Battery_Error.Low_Voltage_Protection] != model.list_SlaveRecv[s].lowVoltageProtection) { Is_Slot_Error(s, Battery_Error.Low_Voltage_Protection, model.list_SlaveRecv[s].lowVoltageProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.High_Voltage_Protection] != model.list_SlaveRecv[s].highVoltageProtection) { Is_Slot_Error(s, Battery_Error.High_Voltage_Protection, model.list_SlaveRecv[s].highVoltageProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_Low_Voltage_Protection] != model.list_SlaveRecv[s].packLowVoltageProtection) { Is_Slot_Error(s, Battery_Error.Pack_Low_Voltage_Protection, model.list_SlaveRecv[s].packLowVoltageProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_High_Voltage_Protection] != model.list_SlaveRecv[s].packHighVoltageProtection) { Is_Slot_Error(s, Battery_Error.Pack_High_Voltage_Protection, model.list_SlaveRecv[s].packHighVoltageProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_Regeneration_OverCharge_Protection] != model.list_SlaveRecv[s].cellRecycleOverChargingProtection) { Is_Slot_Error(s, Battery_Error.Cell_Regeneration_OverCharge_Protection, model.list_SlaveRecv[s].cellRecycleOverChargingProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pack_Regeneration_OverCharge_Protection] != model.list_SlaveRecv[s].packRecycleOverChargingProtection) { Is_Slot_Error(s, Battery_Error.Pack_Regeneration_OverCharge_Protection, model.list_SlaveRecv[s].packRecycleOverChargingProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Over_Discharge_Protection] != model.list_SlaveRecv[s].overDischargeProtection) { Is_Slot_Error(s, Battery_Error.Over_Discharge_Protection, model.list_SlaveRecv[s].overDischargeProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Over_Charge_Protection] != model.list_SlaveRecv[s].overChargingProtection) { Is_Slot_Error(s, Battery_Error.Over_Charge_Protection, model.list_SlaveRecv[s].overChargingProtection); }

                    if (model.Battery_Error_Code[s][Battery_Error.Regeneration_OverCharge_Protection] != model.list_SlaveRecv[s].reCycleOverChargingProtection) { Is_Slot_Error(s, Battery_Error.Regeneration_OverCharge_Protection, model.list_SlaveRecv[s].reCycleOverChargingProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_Low_Temperature_Protection] != model.list_SlaveRecv[s].cellLowTempProtection) { Is_Slot_Error(s, Battery_Error.Cell_Low_Temperature_Protection, model.list_SlaveRecv[s].cellLowTempProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Cell_High_Temperature_Protection] != model.list_SlaveRecv[s].cellHighTempProtection) { Is_Slot_Error(s, Battery_Error.Cell_High_Temperature_Protection, model.list_SlaveRecv[s].cellHighTempProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.FET_Low_Temperature_Protection] != model.list_SlaveRecv[s].FETLowTempProtection) { Is_Slot_Error(s, Battery_Error.FET_Low_Temperature_Protection, model.list_SlaveRecv[s].FETLowTempProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.FET_High_Temperature_Protection] != model.list_SlaveRecv[s].FETHighTempProtection) { Is_Slot_Error(s, Battery_Error.FET_High_Temperature_Protection, model.list_SlaveRecv[s].FETHighTempProtection); }
                    if (model.Battery_Error_Code[s][Battery_Error.Short_Circuit_Protect] != model.list_SlaveRecv[s].shortProtect) { Is_Slot_Error(s, Battery_Error.Short_Circuit_Protect, model.list_SlaveRecv[s].shortProtect); }
                    if (model.Battery_Error_Code[s][Battery_Error.VCU_Error] != model.list_SlaveRecv[s].VCUError) { Is_Slot_Error(s, Battery_Error.VCU_Error, model.list_SlaveRecv[s].VCUError); }
                    if (model.Battery_Error_Code[s][Battery_Error.Pre_Charge_Error] != model.list_SlaveRecv[s].PreChargeError) { Is_Slot_Error(s, Battery_Error.Pre_Charge_Error, model.list_SlaveRecv[s].PreChargeError); }

                    if (model.Battery_Error_Code[s][Battery_Error.BMS_Error] != model.list_SlaveRecv[s].BMS_ERR_State) { Is_Slot_Error(s, Battery_Error.BMS_Error, model.list_SlaveRecv[s].BMS_ERR_State); }

                    if (model.list_SlaveRecv[s].ProcessStatus == 100)  //충전중일때 
                    {
                        if (!model.Battery_Error_Code[s][Battery_Error.Over_Current])
                        {
                            switch (model.list_SlaveRecv[s].Check_BatteryVoltage_Type)  // 과전류 
                            {
                                case 48:
                                    if (model.list_SlaveRecv[s].PowerPackWattage > 165)
                                        Is_Slot_Error(s, Battery_Error.Over_Current, true);
                                    break;
                                case 72:
                                    if (model.list_SlaveRecv[s].PowerPackWattage > 110) Is_Slot_Error(s, Battery_Error.Over_Current, true);
                                    break;
                            }
                        }
                    }

                    if (!model.Battery_Error_Code[s][Battery_Error.Power_Pack_Error] && model.list_SlaveRecv[s].FET_ON_State && !model.list_SlaveRecv[s].PowerPackStatus)  // 파워팩 에러
                    {
                        Is_Slot_Error(s, Battery_Error.Power_Pack_Error, true);
                    }
                    else if (model.Battery_Error_Code[s][Battery_Error.Power_Pack_Error] && model.list_SlaveRecv[s].PowerPackStatus)
                    {
                        Is_Slot_Error(s, Battery_Error.Power_Pack_Error, false);
                    }

                    if (!model.Battery_Error_Code[s][Battery_Error.Slot_Temperature_Error] && (model.list_SlaveRecv[s].FET_Temper >= 75 || model.list_SlaveRecv[s].Battery_Slot_Temp >= 75))  // 슬롯 온도 에러(충전중이 아닐떄)
                    {
                        Is_Slot_Error(s, Battery_Error.Slot_Temperature_Error, true);
                    }
                    else if (model.Battery_Error_Code[s][Battery_Error.Slot_Temperature_Error] && (model.list_SlaveRecv[s].FET_Temper <= 40 && model.list_SlaveRecv[s].Battery_Slot_Temp <= 40))
                    {
                        Is_Slot_Error(s, Battery_Error.Slot_Temperature_Error, false);
                    }

                    /*if (!model.Battery_Error_Code[s][Battery_Error.Control_Board_Error] && model.list_SlaveDataRecvDatetime[s].AddSeconds(5) < DateTime.Now)  // 슬롯 제어보드 통신 에러
                    {
                        Is_Slot_Error(s, Battery_Error.Control_Board_Error, true);
                    }
                    else if (model.Battery_Error_Code[s][Battery_Error.Control_Board_Error] && model.list_SlaveDataRecvDatetime[s].AddSeconds(5) > DateTime.Now)
                    {
                        Is_Slot_Error(s, Battery_Error.Control_Board_Error, false);
                    }*/



                    /*if (Check_Slave_Port_isAlive())  //예외 발생: 'System.IO.IOException'(System.dll)
                    {
                        sp_Slave.Close();
                        sp_Slave.Open(Model.getInstance().Slave_PortName);
                    }

                    if (Check_Master_Port_isAlive())
                    {
                        sp_Master.Close();
                        sp_Master.Open(Model.getInstance().Master_PortName);
                    }*/
                }

            }

        }
        public void Is_Slot_Error(object slot, Battery_Error errorName, bool state)
        {
            if (slot is int slot_num)
            {
                if ((Model.getInstance().list_SlaveRecv[slot_num].WAKEUP_Signal && Model.getInstance().list_SlaveRecv[slot_num].Check_BatteryVoltage_Type != -1  && state) || !state)
                {
                    Model.getInstance().Battery_Error_Code[slot_num][errorName] = state;
                    Model.getInstance().list_SlaveRecv[slot_num].Error_Occured = state;
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(slot_num, errorName, state);

                    int Slot = slot_num + 1;
                    string state_to_string = "";

                    if (state) state_to_string = "발생";
                    else state_to_string = "종료";

                    string format_text = DateTime.Now.ToString() + " " + Slot + "번" + " " + errorName.ToString() + " " + state_to_string;

                    Model.getInstance().test_error_buffer.Add(format_text);

                    if (Model.getInstance().frmTest_CSMS != null)
                    {
                        Model.getInstance().frmTest_CSMS.input_text(format_text, false);
                    }
                }
            }
            else if (slot is int[] idarray)
            {
                foreach (int id in idarray)
                {
                    Model.getInstance().Battery_Error_Code[id - 1][errorName] = state;
                    Model.getInstance().list_SlaveRecv[id - 1].Error_Occured = state;
                    Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(id - 1, errorName, state);
                }
            }


            for (int i = 0; i < 8; i++)
            {
                Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(i);
                CsWork.nextStationInfo = DateTime.Now.AddSeconds(getInstance().StationInfoInterval);
            }
        }

        public void is_station_error(int station, Station_Error errorname, bool state)
        {
            Model.getInstance().list_MasterRecv[station].Error_Occured = state;
            Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_StationAddInfoErrorEvent(station, errorname, state);
            Model.getInstance().dic_Station_Error_Code[station][errorname] = state;
        }

        public bool Check_Slave_Port_isAlive()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Model.getInstance().list_SlaveDataRecvDatetime[i].AddSeconds(5) < DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Check_Master_Port_isAlive()
        {
            if (Model.getInstance().list_MasterDataRecvDatetime[0].AddSeconds(5) < DateTime.Now || Model.getInstance().list_MasterDataRecvDatetime[1].AddSeconds(5) < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public void set_Error_LED(bool is_master, bool is_on  , int slot = 0)
        {
            if (!Model.getInstance().is_manual_mode)
            {
                if (is_master)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Model.getInstance().list_SlaveSend[i].hmiManual = is_on;
                        Model.getInstance().list_SlaveSend[i].LED_Red = is_on;
                    }
                }
                else
                {
                    Model.getInstance().list_SlaveSend[slot].hmiManual = is_on;
                    Model.getInstance().list_SlaveSend[slot].LED_Red = is_on;
                }
            }
        }
    }
}