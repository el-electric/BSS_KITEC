using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public static class CsErrorControl
    {
        public static void Check_Error_Occured()
        {
            var model = Model.getInstance();


            for (int m = 0; m < 2; m++)
            {
                if (model.list_MasterRecv[m].vibrationWarning)  //지진
                {
                    model.frmFrame.GetfrmMain().show_p("진동으로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                    model.ChargingStop_All_Slot();
                }
                else if (model.list_MasterRecv[m].floodingDanger)  //침수
                {
                    model.frmFrame.GetfrmMain().show_p("침수로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                    model.ChargingStop_All_Slot();
                }
                else if (model.list_MasterRecv[m].floodingWarning)  // 침수
                {
                    model.frmFrame.GetfrmMain().show_p("침수로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                    model.ChargingStop_All_Slot();
                }
                else if (model.list_MasterRecv[m].Charger_Humidity > 90)
                {
                    model.frmFrame.GetfrmMain().show_p("습도가 높아서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                    model.ChargingStop_All_Slot();
                }
                else if (model.list_MasterRecv[m].Charger_UpperTemper > 100 || model.list_MasterRecv[m].Charger_LowerTemper > 100)
                {
                    model.frmFrame.GetfrmMain().show_p("스테이션 고온으로 사용이 불가합니다.\n관리자에게 문의해주세요.");
                    model.ChargingStop_All_Slot();
                }
            }

            for (int s = 0; s < 8; s++)
            {
                if (model.list_SlaveRecv[s].rowVoltage) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Low_Voltage); model.list_SlaveRecv[s].Error_Occured = true;}
                if (model.list_SlaveRecv[s].highVoltage) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Voltage); }
                if (model.list_SlaveRecv[s].packLowVoltage) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Low_Voltage); }
                if (model.list_SlaveRecv[s].packHighVoltage) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage); }
                if (model.list_SlaveRecv[s].cellRecycleOverChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Regeneration_OverCharge_Protection); }
                if (model.list_SlaveRecv[s].packRecycleOverChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Regeneration_OverCharge_Protection); }
                if (model.list_SlaveRecv[s].overDischarge) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Discharge); }
                if (model.list_SlaveRecv[s].overCharging) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Charge); }
                    
                if (model.list_SlaveRecv[s].reCycleOverCharging) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Regeneration_OverCharge); }
                if (model.list_SlaveRecv[s].cell_LowTemp) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Low_Temperature); }
                if (model.list_SlaveRecv[s].cell_HighTemp) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_High_Temperature); }
                if (model.list_SlaveRecv[s].FET_LowTemp) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_Low_Temperature); }
                if (model.list_SlaveRecv[s].FET_HighTemp) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_High_Temperature); }
                    
                if (model.list_SlaveRecv[s].lowVoltageProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Low_Voltage_Protection); }
                if (model.list_SlaveRecv[s].highVoltageProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.High_Voltage_Protection); }
                if (model.list_SlaveRecv[s].packLowVoltageProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage_Protection); }
                if (model.list_SlaveRecv[s].packHighVoltageProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage_Protection); }
                if (model.list_SlaveRecv[s].cellRecycleOverChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Regeneration_OverCharge_Protection); }
                if (model.list_SlaveRecv[s].packRecycleOverChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Regeneration_OverCharge_Protection); }
                if (model.list_SlaveRecv[s].overDischargeProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Discharge_Protection); }
                if (model.list_SlaveRecv[s].overChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Charge_Protection); }
                    
                if (model.list_SlaveRecv[s].reCycleOverChargingProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Regeneration_OverCharge_Protection); }
                if (model.list_SlaveRecv[s].cellLowTempProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Low_Temperature_Protection); }
                if (model.list_SlaveRecv[s].cellHighTempProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_High_Temperature_Protection); }
                if (model.list_SlaveRecv[s].FETLowTempProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_Low_Temperature_Protection); }
                if (model.list_SlaveRecv[s].FETHighTempProtection) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_High_Temperature_Protection); }
                if (model.list_SlaveRecv[s].shortProtect) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Short_Circuit_Protect); }
                if (model.list_SlaveRecv[s].VCUError) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.VCU_Error); }
                if (model.list_SlaveRecv[s].PreChargeError) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pre_Charge_Error); }

                if (model.list_SlaveRecv[s].BMS_ERR_State) { model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.BMS_Error); }

                if (model.list_SlaveRecv[s].ProcessStatus == 100)
                {
                    switch (model.list_SlaveRecv[s].Check_BatteryVoltage_Type)  // 과전류 
                    {
                        case 48:
                            if (model.list_SlaveRecv[s].PowerPackWattage > 165)
                            {
                                model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pre_Charge_Error);
                                model.ChargingStop_Slot(s);
                            }
                            break;
                        case 72:
                            if (model.list_SlaveRecv[s].PowerPackWattage > 110)
                            {
                                model.oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pre_Charge_Error);
                                model.ChargingStop_Slot(s);
                            }
                            break;
                    }
                }
            }

        }
    }
}
