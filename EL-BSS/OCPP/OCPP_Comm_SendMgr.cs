using EL_DC_Charger.ocpp.ver16.datatype;
using EL_DC_Charger.ocpp.ver16.packet;
using EL_DC_Charger.ocpp.ver16.packet.common_action;
using EL_DC_Charger.ocpp.ver16.packet.cp2csms;
using EL_DC_Charger.ocpp.ver16.packet.csms2cp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BatteryChangeCharger.OCPP;
using System;
using System.Collections.Generic;

using System.Data;
using EL_BSS;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using static EL_BSS.Model;
using System.Xml;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Net.Http.Headers;
using EL_BSS.Serial;
using EL_BSS.Cycle;

namespace EL_DC_Charger.ocpp.ver16.comm
{
    public class OCPP_Comm_SendMgr
    {

        protected EL_OCPP_Packet_Wrapper mPacket_SendPacket_Call_CP = null;
        public List<EL_OCPP_Packet_Wrapper> list_packet = new List<EL_OCPP_Packet_Wrapper>();
        public List<JArray> list_Jarray = new List<JArray>();

        public ChargePointStatus[] channelStatuses = new ChargePointStatus[2];

        public async Task<string> sendOCPP_CP_Req_BootNotification()
        {
            var data = new
            {
                chargeBoxSerialNumber = Model.getInstance().chargeBoxSerialNumber,
                chargePointModel = Model.getInstance().chargeBoxSerialNumber,
                chargePointSerialNumber = Model.getInstance().chargePointSerialNumber,
                chargePointVendor = Model.getInstance().chargePointVendor,
                firmwareVersion = "1.1.1", //임시
                iccid = Model.getInstance().iccid,
                imsi = Model.getInstance().imsi

            };
            string msg = makeMessage(enumData.BootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }
        public async Task<string> sendOCPP_CP_Req_AddInforBootNotification()
        {
            var data = new
            {

                chargePointModel = Model.getInstance().chargeBoxSerialNumber,
                stationName = "남양주 1",
                stationLocationLat = Model.getInstance().stationLocationLat,
                stationLocationLong = Model.getInstance().stationLocationLong,
                stationAddressDetail = Model.getInstance().stationAddressDetail,
                stationAddressConvenient = Model.getInstance().stationAddressConvenient,
                countSlot = "8",
                connectorType = "Both",
                chargerMaximumPower = "72",
                maker = Model.getInstance().maker,
                makeDate = Model.getInstance().makeDate,
                runDate = Model.getInstance().runDate,
                manager = Model.getInstance().Manager,
                swVersion = "1.1.1"

            };
            string msg = makeMessage(enumData.AddInforBootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }

        public string sendOCPP_CP_Req_StatusNotification(int ChannelIdx, string status, int errorLevel = 0)
        {
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.StatusNotification.ToString(),
                    new
                    { 
                        stationId = Model.getInstance().chargePointSerialNumber,
                        //chargePointSerialNumber =
                        connectorId = ChannelIdx,
                        status = status,
                        //errorCode =
                        errorLevel =  errorLevel.ToString(),
                        //info = 
                        //batteryId = 
                        //soc = 
                        timestamp = DateTime.Now.ToString(),

        }
    };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public void sendOCPP_CP_Req_StatusNotification_for_Check_Battery(int ChannelIdx, string status, int errorLevel = 0)
        {
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.StatusNotification.ToString(),
                    new
                    {
                        stationId = Model.getInstance().chargePointSerialNumber,
                        //chargePointSerialNumber =
                        connectorId = ChannelIdx,
                        status = status,
                        //errorCode =
                        errorLevel =  errorLevel.ToString(),
                        //info = 
                        batteryId = Model.getInstance().list_SlaveRecv[ChannelIdx - 1].Serial_Number,
                        soc = Model.getInstance().list_SlaveRecv[ChannelIdx - 1].SOC, 
                        timestamp = DateTime.Now.ToString(),

        }
    };
            
            /*string msg = makeMessage(enumData.AddInforBootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);

            return response;*/

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);

        }

        public async Task<string> sendOCPP_CP_Req_StatusNotification_for_authorize(string status, int errorLevel, string errormessage)
        {
            var data = new 
            {
                stationId = Model.getInstance().chargePointSerialNumber,
                status = status,
                // errorCode =  
                errorLevel =  errorLevel.ToString(),
                errorMassege = errormessage,
                timestamp = DateTime.Now.ToString(),       
            };
            
            string msg = makeMessage(enumData.StatusNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }

        public string sendOCPP_CP_Req_AddInfoStationBatteryState(int ChannelIdx)
        {
            var data = new Object[]
           {
                2,
                Guid.NewGuid().ToString(),
                enumData.AddInfoStationBatteryState.ToString(),
                    new
                    {
                        timeStamp = DateTime.Now.ToString(),
                        stationId = getInstance().chargeBoxSerialNumber,
                        slotId=ChannelIdx,
                        jobSequenceName=0,
                        isErrorOccured=0,
                        batteryId=getInstance().list_SlaveRecv[ChannelIdx - 1].Serial_Number,
                        SOC = getInstance().list_SlaveRecv[ChannelIdx].SOC,
                        SOH = getInstance().list_SlaveRecv[ChannelIdx].SOH,
                        batteryPackVoltage=getInstance().list_SlaveRecv[ChannelIdx].BatteryCurrentVoltage,
                        batteryPackCurrent=getInstance().list_SlaveRecv[ChannelIdx].BatteryCurrentWattage,
                        batteryModuleTempMax=getInstance().list_SlaveRecv[ChannelIdx].BatteryMaxTemper,
                        batteryModuleTempMin=getInstance().list_SlaveRecv[ChannelIdx].BatteryMinTemper,
                        batteryFetTemp=getInstance().list_SlaveRecv[ChannelIdx].FET_Temper,
                        batteryCellVoltageMax=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_High_Voltage,
                        BatteryCellVoltageMin=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Low_Voltage,
                        cellBalancingFlag=getInstance().list_SlaveRecv[ChannelIdx].Cell_Belancing_Flag,
                        batteryModuleVoltage=getInstance().list_SlaveRecv[ChannelIdx].Battery_Moduel_Voltage,
                        batteryCellVoltage01=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_01,
                        batteryCellVoltage02=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_02,
                        batteryCellVoltage03=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_03,
                        batteryCellVoltage04=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_04,
                        batteryCellVoltage05=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_05,
                        batteryCellVoltage06=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_06,
                        batteryCellVoltage07=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_07,
                        batteryCellVoltage08=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_08,
                        batteryCellVoltage09=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_09,
                        batteryCellVoltage10=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_10,
                        batteryCellVoltage11=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_11,
                        batteryCellVoltage12=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_12,
                        batteryCellVoltage13=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_13,
                        batteryCellVoltage14=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_14,
                        slotConnectState=getInstance().list_SlaveRecv[ChannelIdx].charger_Connect,
                        stationConnectState=getInstance().list_SlaveRecv[ChannelIdx].chargeStationConnect,
                        chargingState=getInstance().list_SlaveRecv[ChannelIdx].ChargingStatus,
                        dischargingState=getInstance().list_SlaveRecv[ChannelIdx].Discharge_State,
                        recoveryState=getInstance().list_SlaveRecv[ChannelIdx].Regeneration_State,
                        readyState=getInstance().list_SlaveRecv[ChannelIdx].Ready_State,
                        warningState=getInstance().list_SlaveRecv[ChannelIdx].Emergence_State,
                        protectState=getInstance().list_SlaveRecv[ChannelIdx].Protect_State,
                        balancingState=getInstance().list_SlaveRecv[ChannelIdx].Balancing_State,

                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
        public string sendOCPP_CP_Req_AddInforBatteryExchange(int ChannelIdx)
        {
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.AddInfoStationBatteryState.ToString(),
                    new
                    {
                        timeStamp = DateTime.Now.ToString(),
                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
        //public async Task<string> sendOCPP_CP_Req_HearthBeat()
        //{
        //    var data = new
        //    {
        //        idTag = _idTag
        //    };

        //    string msg = makeMessage(enumData.Heartbeat.ToString(), data);
        //    string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
        //    return response;
        //}
        public async Task<string> sendOCPP_CP_Req_Authorize(int midentificationCode , int msecurityCode)
        {
            var data = new
            {
                stationId = Model.getInstance().chargePointSerialNumber,
                identificationCode = midentificationCode,
                securityCode = msecurityCode
            };

            string msg = makeMessage(enumData.Authorize.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }

        public void sendOCPP_CP_Conf_Authorize(string uid, string confdata)
        {
            var data = new
            {
                errcode = 00000,
                contents = confdata
            };

            SendConf_with_data(uid, data);
        }

        /*public async Task<string> sendOCPP_CP_Req_StartTransaction(int slot_id)
        {
            var data = new
            {
                idTag = _idTag
            };

            string msg = makeMessage(enumData.Authorize.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }*/
        private void setSendPacket_Call_CP(String actionName, String payloadString)
        {


            JArray call_Packet = new JArray();
            call_Packet.Add(2);
            call_Packet.Add(Guid.NewGuid().ToString());
            call_Packet.Add(actionName);
            if (payloadString != null && payloadString.Length > 0)
            {
                //try
                //{
                call_Packet.Add(JObject.Parse(payloadString));

                //}
                //catch (JSONException e)
                //{
                //    e.printStackTrace();
                //}
            }
            //try
            //{
            mPacket_SendPacket_Call_CP =
                    new EL_OCPP_Packet_Wrapper(call_Packet[2].ToString(), call_Packet[1].ToString(), call_Packet);

            list_packet.Add(mPacket_SendPacket_Call_CP);

            //if (!MyApplication.getInstance().is_offline)
            //Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(mPacket_SendPacket_Call_CP.mPacket.ToString());
        }

        public void ReceivedPacket(string _packet)
        {
            Logger.d("☆Receive☆ OCPP CSMS->CP Call => " + _packet.ToString());
            try
            {
                JArray jsonArray = JArray.Parse(_packet);
                string _uid = jsonArray[1].ToString();
                string messageName = jsonArray[2].ToString();

                switch ((int)jsonArray[0])
                {
                    //수신
                    case 2:
                        if (messageName == enumData.Authorize.ToString())
                        {
                            if (sp_Slave.Check_able_battery_slot())
                            {
                                sendOCPP_CP_Conf_Authorize(_uid, enumData.success.ToString()); //답장

                                Model.getInstance().Req_Authorize = JsonConvert.DeserializeObject<Req_Authorize>(jsonArray[3].ToString());
                                Model.getInstance().Req_Authorize.setting_returnbatteryId();

                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN;
                            }
                            else
                            {
                                sendOCPP_CP_Conf_Authorize(_uid, enumData.fail.ToString());
                            }
                        }
                        break;
                    //응답
                    case 3:
                        if (messageName == enumData.Authorize.ToString())
                        {
                            
                        }
                        list_Jarray.RemoveAll(jObject => (string)jObject[1] == _uid);
                        break;
                    //에러
                    case 4:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " 패킷 json 변환 실패");
            }
        }
        private string getTime()
        {
            string Time = DateTime.UtcNow.AddHours(9).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return Time;
        }
        private void sendMessage(string name, object data)
        {
            var temp = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                name,
                data,
            };


            string json = JsonConvert.SerializeObject(temp, Newtonsoft.Json.Formatting.Indented);

            JArray jsonObject = JArray.Parse(json);
            list_Jarray.Add(jsonObject);

            //_ = Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
        }
        private string makeMessage(string name, object data)
        {
            var temp = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                name,
                data,
            };


            string json = JsonConvert.SerializeObject(temp, Newtonsoft.Json.Formatting.Indented);

            JArray jsonObject = JArray.Parse(json);
            list_Jarray.Add(jsonObject);
            return json;
        }

        private void SendConf_by_Req(string uid)
        {
            var data = new { current = DateTime.Now.ToString() };

            var temp = new Object[]
            {
                3,
                uid,
                data,
            };


            string json = JsonConvert.SerializeObject(temp, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
        }

        private void SendConf_with_data(string uid , object data)
        {
            
            var temp = new Object[]
            {
                3,
                uid,
                data,
            };


            string json = JsonConvert.SerializeObject(temp, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
        }
    }
}
