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

namespace EL_DC_Charger.ocpp.ver16.comm
{
    public class OCPP_Comm_SendMgr
    {

        protected EL_OCPP_Packet_Wrapper mPacket_SendPacket_Call_CP = null;
        public List<EL_OCPP_Packet_Wrapper> list_packet = new List<EL_OCPP_Packet_Wrapper>();

        public ChargePointStatus[] channelStatuses = new ChargePointStatus[2];

        public string sendOCPP_CP_Req_BootNotification()
        {

            //직렬화
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                "BootNotification",
                    new
                    {
                        chargeBoxSerialNumber = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID", ""),
        }
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            return json;
            //Req_BootNotification bootNotification = new Req_BootNotification();
            //bootNotification.setRequiredValue("EL-BSS", "BSS_01");
            //setSendPacket_Call_CP(
            //    bootNotification.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
            //    JsonConvert.SerializeObject(bootNotification, Model.getInstance().mJsonSerializerSettings));
        }
        public string sendOCPP_CP_Req_StatusNotification(int ChannelIdx, string errorCode, string status)
        {

            /*if (channelStatuses[1] == ChargePointStatus.Charging && status == ChargePointStatus.Preparing)
                return;

            if (channelStatuses[ChannelIdx] != status)
                channelStatuses[ChannelIdx] = status;
            else
                return;

            Req_StatusNotification statusNotification = new Req_StatusNotification();
            statusNotification.setRequiredValue(ChannelIdx, errorCode, status);

            setSendPacket_Call_CP(
                statusNotification.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(statusNotification, Model.getInstance().mJsonSerializerSettings));*/



            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                "StatusNotification",
                    new
                    {
                        connectorId = ChannelIdx,
                        errorCode = errorCode,
                        status = status
                    }
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            return json;
        }
        public void sendOCPP_CP_Req_StatusNotification_Direct(int ChannelIdx, ChargePointErrorCode errorCode, ChargePointStatus status)
        {
            Req_StatusNotification statusNotification = new Req_StatusNotification();
            statusNotification.setRequiredValue(ChannelIdx, errorCode, status);

            setSendPacket_Call_CP(
                statusNotification.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(statusNotification, Model.getInstance().mJsonSerializerSettings));
        }
        public void sendOCPP_CP_Req_HearthBeat()
        {
            /*Req_Heartbeat req_Heartbeat = new Req_Heartbeat();

            setSendPacket_Call_CP(
                req_Heartbeat.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(req_Heartbeat, Model.getInstance().mJsonSerializerSettings));*/
            //Model.getInstance().HeartBeatLastSendTime = DateTime.Now;

            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                "Heartbeat",
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
        }

        public void sendOCPP_CP_Req_Authorize(string id_tag)
        {
            Req_Authorize authorize = new Req_Authorize();
            authorize.setRequiredValue(id_tag);
            setSendPacket_Call_CP(
                authorize.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(authorize, Model.getInstance().mJsonSerializerSettings));

        }
        public void sendOCPP_CP_Req_StartTransAction(int ChannelIdx, int soc)
        {

            /*Req_StartTransaction startTransaction = new Req_StartTransaction();
            //startTransaction.setRequiredValue(1, Model.getInstance().Card_Number, 0, getTime());
            setSendPacket_Call_CP(
                startTransaction.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(startTransaction, Model.getInstance().mJsonSerializerSettings));*/
            
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                "StartTransaction",
                new
                    {
                        connectorId = ChannelIdx,
                        meterStart = soc
                    }
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
        }
        public void sendOCPP_CP_Req_Battery_Info()  // datatransfer
        {
            Req_Battery_Info battery_Info = new Req_Battery_Info();
            battery_Info.setRequiredValue(3);
            setSendPacket_Call_CP(
                battery_Info.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
                JsonConvert.SerializeObject(battery_Info, Model.getInstance().mJsonSerializerSettings));
        }
        protected List<MeterValue> mOCPP_List_MeterValue_Charging = new List<MeterValue>();
        public void sendOCPP_CP_Req_MeterValue()
        {
            //DataTable dt = MyApplication.getInstance().oCPP_Manager_Table_Setting.selectData(CONST_INDEX_OCPP_Setting.ClockAlignedDataInterval.ToString());

            int _interval = int.Parse("60");
            MeterValue meterValue = new MeterValue();
            List<SampledValue> list_SampledValue = new List<SampledValue>();

            SampledValue sampledValue = new SampledValue();

            Req_MeterValues req_MeterValues = new Req_MeterValues();

            if (_interval > 0)
            {
                sampledValue = new SampledValue();
                sampledValue.measurand = "Energy.Active.Export.Interval";
                sampledValue.format = ValueFormat.Raw;
                sampledValue.context = "Sample.Clock";
                DateTime dt1 = DateTime.Now;
                DateTime nextSamplingTime = dt1.AddSeconds(_interval);
                sampledValue.value = nextSamplingTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                sampledValue.location = Location.Body;

            }
            else
            {

                sampledValue.setRequiredValue("" + (int)(100));
                sampledValue.format = ValueFormat.Raw;
                sampledValue.context = "Sample.Periodic";
                sampledValue.measurand = "Current.Export";
                sampledValue.unit = UnitOfMeasure.A;
                sampledValue.location = Location.Cable;
                list_SampledValue.Add(sampledValue);

                sampledValue = new SampledValue();
                sampledValue.setRequiredValue("" + (300));
                sampledValue.format = ValueFormat.Raw;
                sampledValue.context = "Sample.Periodic";
                sampledValue.measurand = "Voltage";
                sampledValue.location = Location.Cable;
                sampledValue.unit = UnitOfMeasure.V;

            }
            list_SampledValue.Add(sampledValue);

            meterValue.setRequiredValue(getTime(), list_SampledValue);
            mOCPP_List_MeterValue_Charging.Add(meterValue);

            req_MeterValues.setRequiredValue(1, mOCPP_List_MeterValue_Charging);
            req_MeterValues.transactionId = (long)conf_StartTransaction.transactionId;

            setSendPacket_Call_CP(
        req_MeterValues.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
        JsonConvert.SerializeObject(req_MeterValues, Model.getInstance().mJsonSerializerSettings));

            mOCPP_List_MeterValue_Charging.Clear();
        }
        public void sendOCPP_CP_Req_StopTransAction(string idTag = null, Reason reason = Reason.None)
        {
            Req_StopTransaction stopTransaction = new Req_StopTransaction();
            stopTransaction.setInfor_Required(1250, getTime(), conf_StartTransaction.transactionId);

            if (idTag != null)
                stopTransaction.idTag = idTag;

            if (reason != Reason.None)
                stopTransaction.reason = reason;

            setSendPacket_Call_CP(
            stopTransaction.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
            JsonConvert.SerializeObject(stopTransaction, Model.getInstance().mJsonSerializerSettings));
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Conf_StartTransaction conf_StartTransaction = new Conf_StartTransaction();

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
            Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(mPacket_SendPacket_Call_CP.mPacket.ToString());
        }

        public void ReceivedPacket(string _packet)
        {
            Logger.d("☆Receive☆ OCPP CSMS->CP Call => " + _packet.ToString());
            String callResult_message = "";
            JArray callResult_Packet = new JArray();


            try
            {
                JArray jsonArray = JArray.Parse(_packet);
                string _uid = jsonArray[1].ToString();

                callResult_Packet.Add(3);
                callResult_Packet.Add(jsonArray[1].ToString());

                switch ((int)jsonArray[0])
                {

                    //받은거
                    case 2:

                    //if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.GetConfiguration.ToString()))
                    //{
                    //    //DataTable dt = Model.getInstance().oCPP_Manager_Table_Setting.selectDT();
                    //    Req_GetConfiguration data = JsonConvert.DeserializeObject<Req_GetConfiguration>(((JObject)jsonArray[3]).ToString());
                    //    Conf_GetConfiguration data_Result = new Conf_GetConfiguration();
                    //    data_Result.configurationKey = new List<KeyValue>();

                    //    if (data.key != null && data.key.Count == 1)
                    //    {
                    //        DataRow[] foundRows = dt.Select($"SettingKey = '{data.key[0]}'");
                    //        KeyValue key = new KeyValue();
                    //        key.key = foundRows[0]["SettingKey"].ToString();
                    //        key.value = foundRows[0]["SettingValue"].ToString();

                    //        if (foundRows[0]["AccessType"].ToString().Equals("RW"))
                    //            key.Readonly = false;
                    //        else
                    //            key.Readonly = true;

                    //        data_Result.configurationKey.Add(key);
                    //    }
                    //    else
                    //    {
                    //        for (int i = 0; i < dt.Rows.Count; i++)
                    //        {
                    //            KeyValue key = new KeyValue();
                    //            key.key = dt.Rows[i][0].ToString();
                    //            key.value = dt.Rows[i][1].ToString();

                    //            if (dt.Rows[i][2].ToString().Equals("RW"))
                    //                key.Readonly = false;
                    //            else
                    //                key.Readonly = true;

                    //            data_Result.configurationKey.Add(key);
                    //        }
                    //    }

                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_GetConfiguration.class);
                    //    callResult_message = callResult_message.Replace("Readonly", "readonly");
                    //}
                    //if (false)
                    //{

                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.ChangeConfiguration.ToString()))
                    //{
                    //    String replaceText = ((JObject)jsonArray[3]).ToString().Replace("Readonly", "readonly");
                    //    Req_ChangeConfiguration data = JsonConvert.DeserializeObject<Req_ChangeConfiguration>(replaceText);
                    //    Conf_ChangeConfiguration data_Result = new Conf_ChangeConfiguration();

                    //    DataTable dt = Model.getInstance().oCPP_Manager_Table_Setting.selectData(data.key);

                    //    if (dt.Rows.Count < 1)
                    //    {
                    //        data_Result.status = ConfigurationStatus.NotSupported;
                    //    }
                    //    else if (dt.Rows[0][2].ToString().ToUpper().Equals("RW") || dt.Rows[0][2].ToString().ToUpper().Equals("W"))
                    //    {
                    //        if (data.key.Equals("MeterValueSampleInterval") && int.Parse(data.value) < 0)
                    //        {
                    //            data_Result.status = ConfigurationStatus.Rejected;
                    //        }
                    //        else if (MyApplication.getInstance().oCPP_Manager_Table_Setting.updateData(data.key, data.value) > 0)
                    //        {
                    //            data_Result.status = ConfigurationStatus.Accepted;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        data_Result.status = ConfigurationStatus.Rejected;
                    //    }



                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings);
                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.ClearCache.ToString()))
                    //{
                    //    Req_ClearCache data = JsonConvert.DeserializeObject<Req_ClearCache>(((JObject)jsonArray[3]).ToString());
                    //    Conf_ClearCache data_Result = new Conf_ClearCache();
                    //    MyApplication.getInstance().oCPP_AuthCache.cacheDelete();

                    //    data_Result.status = ClearCacheStatus.Accepted;
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_ClearCache.class);
                    //}


                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.RemoteStartTransaction.ToString()))
                    //{
                    //    Req_RemoteStartTransaction data = JsonConvert.DeserializeObject<Req_RemoteStartTransaction>(((JObject)jsonArray[3]).ToString());
                    //    Conf_RemoteStartTransaction data_Result = new Conf_RemoteStartTransaction();

                    //    if (data.idTag == null || data.connectorId == null || channelStatuses[1] == ChargePointStatus.Charging)
                    //    {
                    //        data_Result.status = RemoteStartStopStatus.Rejected;
                    //    }
                    //    else
                    //    {
                    //        MyApplication.getInstance().conf_RemoteStartTransaction = true;
                    //        MyApplication.getInstance().Card_Number = data.idTag;
                    //        data_Result.status = RemoteStartStopStatus.Accepted;
                    //    }
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_ClearCache.class);
                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.RemoteStopTransaction.ToString()))
                    //{
                    //    Req_RemoteStopTransaction data = JsonConvert.DeserializeObject<Req_RemoteStopTransaction>(((JObject)jsonArray[3]).ToString());
                    //    Conf_RemoteStopTransaction data_Result = new Conf_RemoteStopTransaction();




                    //    if (conf_StartTransaction.transactionId == data.transactionId)
                    //    {
                    //        data_Result.status = RemoteStartStopStatus.Accepted;
                    //        MyApplication.getInstance().conf_RemoteStopTransaction = true;
                    //    }
                    //    else
                    //        data_Result.status = RemoteStartStopStatus.Rejected;

                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_ClearCache.class);
                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.Reset.ToString()))
                    //{
                    //    Req_Reset data = JsonConvert.DeserializeObject<Req_Reset>(((JObject)jsonArray[3]).ToString());
                    //    Conf_Reset data_Result = new Conf_Reset();
                    //    data_Result.status = ResetStatus.Accepted;


                    //    if (data.type == ResetType.Hard)
                    //        MyApplication.getInstance().conf_HardReset = true;
                    //    else
                    //        MyApplication.getInstance().conf_SoftReset = true;

                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings);
                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.ChangeAvailability.ToString()))
                    //{
                    //    Req_ChangeAvailability data = JsonConvert.DeserializeObject<Req_ChangeAvailability>(((JObject)jsonArray[3]).ToString());
                    //    Conf_ChangeAvailability data_Result = new Conf_ChangeAvailability();
                    //    data_Result.status = AvailabilityStatus.Accepted;


                    //    if (data.connectorId == 0)
                    //    {
                    //        if (data.type == AvailabilityType.Inoperative)
                    //        {
                    //            MyApplication.getInstance().conf_InOperative_0 = true;
                    //            CsUtil.IniWriteValue(System.Windows.Forms.Application.StartupPath + @"\config.ini", "RESET", "CON_ID_0", "Y");
                    //        }
                    //        else
                    //        {
                    //            MyApplication.getInstance().conf_Operative_0 = true;
                    //        }


                    //    }
                    //    else if (data.connectorId > 0)
                    //    {
                    //        if (data.type == AvailabilityType.Inoperative)
                    //            MyApplication.getInstance().conf_InOperative = true;
                    //        else
                    //            MyApplication.getInstance().conf_Operative = true;
                    //    }
                    //    MyApplication.getInstance().conf_ChangeAvailability = true;

                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings);
                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.UnlockConnector.ToString()))
                    //{
                    //    Req_UnlockConnector data = JsonConvert.DeserializeObject<Req_UnlockConnector>(((JObject)jsonArray[3]).ToString());
                    //    //else if (receivePacket.getString(2).equals(EOCPP_Action_CSMS_Call.UnlockConnector.name()))
                    //    //{
                    //    //    Req_UnlockConnector data = mGson.fromJson(((JSONObject)receivePacket.get(3)).toString(), Req_UnlockConnector.class);
                    //    Conf_UnlockConnector data_Result = new Conf_UnlockConnector();
                    //    //

                    //    data_Result.status = UnlockStatus.NotSupported;
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_UnlockConnector.class);

                    //}

                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.GetLocalListVersion.ToString()))
                    //{
                    //    Req_GetLocalListVersion data = JsonConvert.DeserializeObject<Req_GetLocalListVersion>(((JObject)jsonArray[3]).ToString());
                    //    //else if (receivePacket.getString(2).equals(EOCPP_Action_CSMS_Call.UnlockConnector.name()))
                    //    //{
                    //    //    Req_UnlockConnector data = mGson.fromJson(((JSONObject)receivePacket.get(3)).toString(), Req_UnlockConnector.class);
                    //    Conf_GetLocalListVersion data_Result = new Conf_GetLocalListVersion();
                    //    //

                    //    data_Result.listVersion = -1;
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_UnlockConnector.class);

                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.SendLocalList.ToString()))
                    //{
                    //    Req_SendLocalList data = JsonConvert.DeserializeObject<Req_SendLocalList>(((JObject)jsonArray[3]).ToString());
                    //    //else if (receivePacket.getString(2).equals(EOCPP_Action_CSMS_Call.UnlockConnector.name()))
                    //    //{
                    //    //    Req_UnlockConnector data = mGson.fromJson(((JSONObject)receivePacket.get(3)).toString(), Req_UnlockConnector.class);
                    //    Conf_SendLocalList data_Result = new Conf_SendLocalList();
                    //    //

                    //    data_Result.status = datatype.UpdateStatus.NotSupported;
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_UnlockConnector.class);

                    //}
                    //else if (jsonArray[2].ToString().Equals(EOCPP_Action_CSMS_Call.DataTransfer.ToString()))
                    //{
                    //    Req_DataTransfer data = JsonConvert.DeserializeObject<Req_DataTransfer>(((JObject)jsonArray[3]).ToString());
                    //    //else if (receivePacket.getString(2).equals(EOCPP_Action_CSMS_Call.UnlockConnector.name()))
                    //    //{
                    //    //    Req_UnlockConnector data = mGson.fromJson(((JSONObject)receivePacket.get(3)).toString(), Req_UnlockConnector.class);
                    //    Conf_DataTransfer data_Result = new Conf_DataTransfer();
                    //    //

                    //    data_Result.status = DataTransferStatus.UnknownVendorId;
                    //    callResult_message = JsonConvert.SerializeObject(data_Result, MyApplication.mJsonSerializerSettings); //mGson.toJson(data_Result, Conf_UnlockConnector.class);

                    //}


                    //if (callResult_message.Length > 0)
                    //{
                    //    JObject obj_Payload = JObject.Parse(callResult_message);
                    //    callResult_Packet.Add(obj_Payload);
                    //}
                    //String callResult_Packet_String = callResult_Packet.ToString();
                    //MyApplication.getInstance().oCPP_Comm_Manager.SendMessageAsync(callResult_Packet_String);

                    //break;
                    //응답                    
                    case 3:
                        int foundIndex = -1;
                        for (int i = 0; i < list_packet.Count; i++)
                        {
                            Console.WriteLine(list_packet[i].mPacket[1]);
                            Console.WriteLine(_uid);
                            if (list_packet[i].mPacket.Count > 2 && list_packet[i].mPacket[1].ToString().Equals(_uid))
                            {
                                foundIndex = i;
                                break;
                            }
                        }
                        if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.BootNotification.ToString()))
                        {
                            Conf_BootNotification data = JsonConvert.DeserializeObject<Conf_BootNotification>(((JObject)jsonArray[2]).ToString());
                            //Model.getInstance().conf_BootNotification = data;

                            //if (data.status == RegistrationStatus.Accepted)
                            //    MyApplication.getInstance().HeartBeatInterval = (int)data.interval;

                        }
                        else if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.Heartbeat.ToString()))
                        {
                            Conf_Heartbeat data = JsonConvert.DeserializeObject<Conf_Heartbeat>(((JObject)jsonArray[2]).ToString());
                        }

                        else if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.Authorize.ToString()))
                        {
                            Conf_Authorize data = JsonConvert.DeserializeObject<Conf_Authorize>(((JObject)jsonArray[2]).ToString());

                            switch (data.idTagInfo.status)
                            {
                                case AuthorizationStatus.Accepted:

                                    //Model.getInstance().oCPP_AuthCache.insertData(data.idTagInfo.parentIdTag, data.idTagInfo.expiryDate);

                                    //MyApplication.getInstance().bIsCertificationSuccess = true;
                                    //MyApplication.getInstance().bIsCertificationFailed = false;
                                    break;
                                case AuthorizationStatus.Blocked:
                                case AuthorizationStatus.Expired:
                                case AuthorizationStatus.Invalid:
                                case AuthorizationStatus.ConcurrentTx:
                                default:
                                    //MyApplication.getInstance().bIsCertificationFailed = true;
                                    //MyApplication.getInstance().bIsCertificationSuccess = false;
                                    break;
                            }
                        }
                        else if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.StartTransaction.ToString()))
                        {

                            conf_StartTransaction = JsonConvert.DeserializeObject<Conf_StartTransaction>(((JObject)jsonArray[2]).ToString());
                            //MyApplication.getInstance().oCPP_TransactionInfo.insertData(MyApplication.getInstance().Card_Number, conf_StartTransaction.transactionId.ToString());
                            //MyApplication.getInstance().bIsConfStartTransAction = true;

                        }
                        else if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.MeterValues.ToString()))
                        {

                        }
                        else if (list_packet[foundIndex].mPacket[2].ToString().Equals(EOCPP_Action_CP_Call.StopTransaction.ToString()))
                        {
                            Conf_StopTransaction data = JsonConvert.DeserializeObject<Conf_StopTransaction>(((JObject)jsonArray[2]).ToString());

                            //MyApplication.getInstance().oCPP_TransactionInfo.updateStopTrans(conf_StartTransaction.transactionId.ToString());
                            //MyApplication.getInstance().bIsConfStopTransAction = true;
                        }


                        if (foundIndex != -1)
                        {
                            list_packet.RemoveAt(foundIndex);
                        }
                        break;

                    //에러
                    case 4:
                        foundIndex = -1;
                        for (int i = 0; i < list_packet.Count; i++)
                        {
                            Console.WriteLine(list_packet[i].mPacket[1]);
                            Console.WriteLine(_uid);
                            if (list_packet[i].mPacket.Count > 2 && list_packet[i].mPacket[1].ToString().Equals(_uid))
                            {
                                foundIndex = i;
                                break;
                            }
                        }
                        if (foundIndex != -1)
                        {
                            list_packet.RemoveAt(foundIndex);
                        }
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
    }
}
