using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EL_BSS.Model;

namespace EL_BSS.Cycle
{
    public class CsErrorControl
    {
        public void Check_Error_Occured()
        {
            for (int m = 0; m < 2; m++)
            {
                if (Model.getInstance().list_MasterRecv[m].vibrationWarning)
                {
                    Model.getInstance().frmFrame.GetfrmMain().show_p("진동으로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                }
                else if (Model.getInstance().list_MasterRecv[m].floodingDanger)
                {
                    Model.getInstance().frmFrame.GetfrmMain().show_p("침수로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                }
                else if (Model.getInstance().list_MasterRecv[m].floodingWarning)
                {
                    Model.getInstance().frmFrame.GetfrmMain().show_p("침수로 인해서 사용이 불가합니다.\n관리자에게 문의해주세요.");
                }
            }

            for (int s = 0; s < 8; s++)
            {
                if (Model.getInstance().list_SlaveRecv[s].rowVoltage) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Low_Voltage); }
                if (Model.getInstance().list_SlaveRecv[s].highVoltage) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Voltage); }
                if (Model.getInstance().list_SlaveRecv[s].packLowVoltage) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Low_Voltage); }
                if (Model.getInstance().list_SlaveRecv[s].packHighVoltage) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage); }
                if (Model.getInstance().list_SlaveRecv[s].cellRecycleOverChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Regeneration_OverCharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].packRecycleOverChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Regeneration_OverCharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].overDischarge) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Discharge); }
                if (Model.getInstance().list_SlaveRecv[s].overCharging) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Charge); }
                                                       
                if (Model.getInstance().list_SlaveRecv[s].reCycleOverCharging) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Regeneration_OverCharge); }
                if (Model.getInstance().list_SlaveRecv[s].cell_LowTemp) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Low_Temperature); }
                if (Model.getInstance().list_SlaveRecv[s].cell_HighTemp) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_High_Temperature); }
                if (Model.getInstance().list_SlaveRecv[s].FET_LowTemp) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_Low_Temperature); }
                if (Model.getInstance().list_SlaveRecv[s].FET_HighTemp) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_High_Temperature); }
                                                       
                if (Model.getInstance().list_SlaveRecv[s].lowVoltageProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Low_Voltage_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].highVoltageProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.High_Voltage_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].packLowVoltageProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].packHighVoltageProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_High_Voltage_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].cellRecycleOverChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Regeneration_OverCharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].packRecycleOverChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pack_Regeneration_OverCharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].overDischargeProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Discharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].overChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Over_Charge_Protection); }
                                                       
                if (Model.getInstance().list_SlaveRecv[s].reCycleOverChargingProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Regeneration_OverCharge_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].cellLowTempProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_Low_Temperature_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].cellHighTempProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Cell_High_Temperature_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].FETLowTempProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_Low_Temperature_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].FETHighTempProtection) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.FET_High_Temperature_Protection); }
                if (Model.getInstance().list_SlaveRecv[s].shortProtect) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Short_Circuit_Protect); }
                if (Model.getInstance().list_SlaveRecv[s].VCUError) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.VCU_Error); }
                if (Model.getInstance().list_SlaveRecv[s].PreChargeError) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.Pre_Charge_Error); }

                if (Model.getInstance().list_SlaveRecv[s].BMS_ERR_State) { Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_AddInfoErrorEvent(s, Battery_Error_Code.BMS_Error); }
            }

        }
    }
}
