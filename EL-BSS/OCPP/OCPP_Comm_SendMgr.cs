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
using System.IdentityModel.Protocols.WSTrust;
using System.Windows.Interop;
using EL_BSS.OCPP.packet.cp2csms;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json.Converters;
using ZXing;
using System.Text.RegularExpressions;

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
                chargePointModel = Model.getInstance().chargePointModel,
                chargePointSerialNumber = Model.getInstance().chargePointSerialNumber,
                chargePointVendor = Model.getInstance().chargePointVendor,
                firmwareVersion = Model.getInstance().list_MasterRecv[0].FW_ver, //임시
                iccid = "EMPTY",
                imsi = "EMPTY",

                /*chargeBoxSerialnumber = "BSS-Station01",
                chargepointmodel = "BSS-KI",
                chargepointserialnumber = "BSS-01",
                chargepointvendor = "EL",
                firmwareversion = "1.1.1", //임시
                iccid = "empty",
                imsi = "empty",*/

            };
            string msg = makeMessage(enumData.BootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponseAsync(msg);
            return response;
        }

        public async Task<string> sendOCPP_CP_Req_AddInforBootNotification()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"{version.Major}.{version.Minor}.{version.Build}";
            var data = new
            {

                chargePointModel = Model.getInstance().chargePointModel,
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
                swVersion = versionString

            };
            string msg = makeMessage(enumData.AddInforBootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponseAsync(msg);
            Model.getInstance().Send_bootnotification = true;
            return response;
        }



        public void sendOCPP_CP_Req_StatusNotification_for_Check_Battery(int ChannelIdx, string status)
        {
            string Info = "";

                List<Battery_Error> info_array = new List<Battery_Error>();

                var dic_Battery_Error_Code = Model.getInstance().Battery_Error_Code[ChannelIdx];

                foreach (var error in dic_Battery_Error_Code)
                {
                    if (error.Value == true)
                    {
                        info_array.Add(error.Key);
                    }
                }

            Info = JsonConvert.SerializeObject(info_array, new StringEnumConverter());
                /*info = info.Replace("\", "");*/
                //string subStringList = "[\\]";
                //Info = Regex.Replace(enum_info, subStringList, "");

                var json_Info = JsonConvert.DeserializeObject<List<string>>(Info); // 보낼때 \가 붙어서 다시 json으로 바꿈
            

            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.StatusNotification.ToString(),
                    new
                    {
                        stationId = Model.getInstance().chargePointSerialNumber,
                        connectorId = ChannelIdx,
                        status = status,
                        info = json_Info,
                        batteryId = Model.getInstance().list_SlaveRecv[ChannelIdx].Serial_Number,
                        soc = Model.getInstance().list_SlaveRecv[ChannelIdx].SOC,
                        timestamp = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")),

        }
    };

            /*string msg = makeMessage(enumData.AddInforBootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);

            return response;*/

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);

        }

        public void sendOCPP_CP_Req_AddInfoStationBatteryState(int ChannelIdx)
        {
            bool chargingState = false;
            string mjobSequenceName;

            List<Battery_Error> info_array = new List<Battery_Error>();
            List<string> charging_info_array = new List<string>();

            if (getInstance().list_SlaveRecv[ChannelIdx].Error_Occured)
            {
                var dic_Battery_Error_Code = Model.getInstance().Battery_Error_Code[ChannelIdx];

                foreach (var error in dic_Battery_Error_Code)
                {
                    if (error.Value == true)
                    {
                        info_array.Add(error.Key);
                    }
                }

                mjobSequenceName = JsonConvert.SerializeObject(info_array, new StringEnumConverter());
            }
            else if (getInstance().list_SlaveRecv[ChannelIdx].ChargingStatus == 100)
            {
                chargingState = true;
                charging_info_array.Add(enumData.CHARGING.ToString());

                mjobSequenceName = JsonConvert.SerializeObject(charging_info_array);
            }
            else if (getInstance().list_SlaveRecv[ChannelIdx].BatterArrive)
            {
                charging_info_array.Add(enumData.BATTERY_INSERT.ToString());

                mjobSequenceName = JsonConvert.SerializeObject(charging_info_array);
            }
            else
            {
                charging_info_array.Add(enumData.SLOT_EMPTY.ToString());

                mjobSequenceName = JsonConvert.SerializeObject(charging_info_array);
            }

            var json_mjobSequenceName = JsonConvert.DeserializeObject<List<string>>(mjobSequenceName);


            var data = new Object[]
           {
                2,
                Guid.NewGuid().ToString(),
                enumData.AddInfoStationBatteryState.ToString(),
                    new
                    {
                        timestamp = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")),
                        stationId = getInstance().chargeBoxSerialNumber,
                        slotId=ChannelIdx,
                        jobSequenceName=json_mjobSequenceName,
                        isErrorOccured=0,
                        batteryId=getInstance().list_SlaveRecv[ChannelIdx].Serial_Number,
                        SOC = getInstance().list_SlaveRecv[ChannelIdx].SOC,
                        SOH = getInstance().list_SlaveRecv[ChannelIdx].SOH,
                        SlotTemper = getInstance().list_SlaveRecv[ChannelIdx].Battery_Slot_Temp,
                        batteryPackVoltage=getInstance().list_SlaveRecv[ChannelIdx].BatteryCurrentVoltage / 10,
                        batteryPackCurrent=getInstance().list_SlaveRecv[ChannelIdx].BatteryCurrentWattage / 10,
                        batteryModuleTempMax=getInstance().list_SlaveRecv[ChannelIdx].BatteryMaxTemper,
                        batteryModuleTempMin=getInstance().list_SlaveRecv[ChannelIdx].BatteryMinTemper,
                        batteryFetTemp=getInstance().list_SlaveRecv[ChannelIdx].FET_Temper,
                        batteryCellVoltageMax=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_High_Voltage,
                        BatteryCellVoltageMin=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Low_Voltage,
                        cellBalancingFlag=getInstance().list_SlaveRecv[ChannelIdx].Cell_Belancing_Flag,
                        batteryModuleVoltage=getInstance().list_SlaveRecv[ChannelIdx].Battery_Moduel_Voltage,
                        batteryCellVoltage01=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_01 / 1000,
                        batteryCellVoltage02=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_02 / 1000,
                        batteryCellVoltage03=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_03 / 1000,
                        batteryCellVoltage04=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_04 / 1000,
                        batteryCellVoltage05=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_05 / 1000,
                        batteryCellVoltage06=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_06 / 1000,
                        batteryCellVoltage07=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_07 / 1000,
                        batteryCellVoltage08=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_08 / 1000,
                        batteryCellVoltage09=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_09 / 1000,
                        batteryCellVoltage10=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_10 / 1000,
                        batteryCellVoltage11=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_11 / 1000,
                        batteryCellVoltage12=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_12 / 1000,
                        batteryCellVoltage13=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_13 / 1000,
                        batteryCellVoltage14=getInstance().list_SlaveRecv[ChannelIdx].Battery_Cell_Vol_14 / 1000,
                        slotConnectState=getInstance().list_SlaveRecv[ChannelIdx].charger_Connect,
                        stationConnectState=getInstance().list_SlaveRecv[ChannelIdx].chargeStationConnect,
                        chargingState=chargingState,
                        dischargingState=getInstance().list_SlaveRecv[ChannelIdx].Discharge_State,
                        recoveryState=getInstance().list_SlaveRecv[ChannelIdx].Regeneration_State,
                        readyState=getInstance().list_SlaveRecv[ChannelIdx].Ready_State,
                        warningState=getInstance().list_SlaveRecv[ChannelIdx].Emergence_State,
                        protectState=getInstance().list_SlaveRecv[ChannelIdx].Protect_State,
                        balancingState=getInstance().list_SlaveRecv[ChannelIdx].Balancing_State,

                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            // return json;

            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
        }

        public void sendOCPP_CP_Req_StaionInfo(int ChannelIdx)
        {
            StaionInfo StaionInfo1 = new StaionInfo(ChannelIdx);

            string division;

            if (ChannelIdx == 0)
            {
                division = "Master";
            }
            else
            {
                division = "Slave";
            }

            var data = new Object[]
           {
                2,
                Guid.NewGuid().ToString(),
                enumData.StationInfo.ToString(),
                    new
                    {
                     stationId = getInstance().chargeBoxSerialNumber,
                     division = division,
                     Values = StaionInfo1
                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            // return json;

            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
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
                        timestamp = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")),
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
        public async Task<string> sendOCPP_CP_Req_Authorize(string midentificationCode, string msecurityCode)
        {
            var data = new
            {
                stationId = Model.getInstance().chargeBoxSerialNumber,
                identificationCode = midentificationCode,
                securityCode = msecurityCode
            };

            string msg = makeMessage(enumData.Authorize.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponseAsync(msg);
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

        public async Task<string> Send_OCPP_CP_Req_DataTransfer_battery_exchange(int[] returnid, int[] lentid)
        {
            List<SET_Batteries_Value> returnBatteries = new List<SET_Batteries_Value>();
            List<SET_Batteries_Value> lentBatteries = new List<SET_Batteries_Value>();

            for (int i = 0; i <= 1; i++)
            {
                SET_Batteries_Value m_returnBatteries = new SET_Batteries_Value(returnid[i]);
                returnBatteries.Add(m_returnBatteries);

                SET_Batteries_Value m_lentBatteries = new SET_Batteries_Value(lentid[i]);
                lentBatteries.Add(m_lentBatteries);
            }

            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.DataTransfer.ToString(),
                    new
                    {
                        stationId = Model.getInstance().chargeBoxSerialNumber,
                        userNo = Model.getInstance().Authorize.userNo,
                        batterySetNo = Model.getInstance().Authorize.batterySetNo,
                        returnBatteries = returnBatteries,
                        lendingBattteries = lentBatteries,
                        timestamp = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")),
                    }
            };
            string returnvlaue = "";
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponseAsync(json);

            if (response == null)
            {
                returnvlaue = "응답없음";
                return returnvlaue;
            }


            JArray responseObject = JArray.Parse(response);

            string errCode = responseObject?[2]?["errCode"]?.ToString();

            if (errCode == null)
            {
                returnvlaue = "응답없음";
                return returnvlaue;
            }

            switch (errCode)
            {
                case "00000":
                    returnvlaue = "성공";
                    break;
                case "11101":
                    returnvlaue = "배터리를 찾을 수 없습니다.";
                    break;
                case "11102":
                    returnvlaue = "배터리 세트를 찾을 수 없습니다.";
                    break;
                case "10002":
                    returnvlaue = "이용자가 없습니다.";
                    break;
                case "12102":
                    returnvlaue = "스테이션이 존재하지 않습니다";
                    break;
                default:
                    returnvlaue = "없는 애러코드";
                    break;
            }

            return errCode;
        }

        public void Send_OCPP_CP_Req_battery_Excange_Finished(string finishedSignal)
        {
            var data = new
            {
                stationId = Model.getInstance().chargeBoxSerialNumber,
                userNo = Model.getInstance().Authorize.userNo,
                finishedSignal = finishedSignal
            };

            string msg = makeMessage(enumData.battery_exchange_finished.ToString(), data);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(msg);
        }

        public void Send_OCPP_CP_Req_AddInfoErrorEvent(int index, Battery_Error errorName, bool isMeasure)
        {
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.AddInfoErrorEvent.ToString(),
                    new
                    {
                        timeStamp = DateTime.Now.ToString(),
                        batteryId = Model.getInstance().list_SlaveRecv[index].Serial_Number,
                        stationid = Model.getInstance().chargePointSerialNumber,
                        slotId = index,
                        eventName = errorName.ToString(),
                        isMeasure = isMeasure,
                        timeStampMeasure = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR"))
                    }
            };
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
        }

        public void Send_OCPP_CP_Req_StationAddInfoErrorEvent(int index, Station_Error errorName, bool isMeansure)
        {
            string division;


            if (index == 0)
            {
                division = "Master";
            }
            else
            {
                division = "Slave";
            }

            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.StationAddInfoErrorEvent.ToString(),
                    new
                    {
                        stationId = Model.getInstance().chargePointSerialNumber,
                        timeStamp = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss", new CultureInfo("ko-KR")),
                        division = division,
                        eventName = errorName.ToString(),
                        isMeasure = isMeansure
                    }
            };

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Model.getInstance().oCPP_Comm_Manager.SendMessagePacket(json);
        }





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
                            Model.getInstance().Authorize_Type = enumData.APP.ToString();
                            Model.getInstance().Authorize = JsonConvert.DeserializeObject<Req_Authorize>(jsonArray[3].ToString());
                            Model.getInstance().Authorize.setting_Authorize_value();

                            Model.getInstance().Authorize.uid = _uid;

                            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN;
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

        private void SendConf_with_data(string uid, object data)
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
