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
        public List<JArray> list_Jarray = new List<JArray>();

        public ChargePointStatus[] channelStatuses = new ChargePointStatus[2];

        public void sendOCPP_CP_Req_BootNotification()
        {
            var data = new Object[]
            {
                new
                {
                    chargeBoxSerialNumber = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID", ""),
                }
            };
            sendMessage("BootNotification", data);
        }
        public string sendOCPP_CP_Req_StatusNotification(int ChannelIdx, string errorCode, string status)
        {
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

            //Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
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
            //string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            //Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
        }
        //public void sendOCPP_CP_Req_Battery_Info()  // datatransfer
        //{
        //    Req_Battery_Info battery_Info = new Req_Battery_Info();
        //    battery_Info.setRequiredValue(3);
        //    setSendPacket_Call_CP(
        //        battery_Info.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
        //        JsonConvert.SerializeObject(battery_Info, Model.getInstance().mJsonSerializerSettings));
        //}
        //protected List<MeterValue> mOCPP_List_MeterValue_Charging = new List<MeterValue>();
        //public void sendOCPP_CP_Req_MeterValue()
        //{
        //    //DataTable dt = MyApplication.getInstance().oCPP_Manager_Table_Setting.selectData(CONST_INDEX_OCPP_Setting.ClockAlignedDataInterval.ToString());

        //    int _interval = int.Parse("60");
        //    MeterValue meterValue = new MeterValue();
        //    List<SampledValue> list_SampledValue = new List<SampledValue>();

        //    SampledValue sampledValue = new SampledValue();

        //    Req_MeterValues req_MeterValues = new Req_MeterValues();

        //    if (_interval > 0)
        //    {
        //        sampledValue = new SampledValue();
        //        sampledValue.measurand = "Energy.Active.Export.Interval";
        //        sampledValue.format = ValueFormat.Raw;
        //        sampledValue.context = "Sample.Clock";
        //        DateTime dt1 = DateTime.Now;
        //        DateTime nextSamplingTime = dt1.AddSeconds(_interval);
        //        sampledValue.value = nextSamplingTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        //        sampledValue.location = Location.Body;

        //    }
        //    else
        //    {

        //        sampledValue.setRequiredValue("" + (int)(100));
        //        sampledValue.format = ValueFormat.Raw;
        //        sampledValue.context = "Sample.Periodic";
        //        sampledValue.measurand = "Current.Export";
        //        sampledValue.unit = UnitOfMeasure.A;
        //        sampledValue.location = Location.Cable;
        //        list_SampledValue.Add(sampledValue);

        //        sampledValue = new SampledValue();
        //        sampledValue.setRequiredValue("" + (300));
        //        sampledValue.format = ValueFormat.Raw;
        //        sampledValue.context = "Sample.Periodic";
        //        sampledValue.measurand = "Voltage";
        //        sampledValue.location = Location.Cable;
        //        sampledValue.unit = UnitOfMeasure.V;

        //    }
        //    list_SampledValue.Add(sampledValue);

        //    meterValue.setRequiredValue(getTime(), list_SampledValue);
        //    mOCPP_List_MeterValue_Charging.Add(meterValue);

        //    req_MeterValues.setRequiredValue(1, mOCPP_List_MeterValue_Charging);
        //    req_MeterValues.transactionId = (long)conf_StartTransaction.transactionId;

        //    setSendPacket_Call_CP(
        //req_MeterValues.GetType().Name.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1],
        //JsonConvert.SerializeObject(req_MeterValues, Model.getInstance().mJsonSerializerSettings));

        //    mOCPP_List_MeterValue_Charging.Clear();
        //}



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
            try
            {
                JArray jsonArray = JArray.Parse(_packet);
                string _uid = jsonArray[1].ToString();

                switch ((int)jsonArray[0])
                {
                    //수신
                    case 2:
                        break;
                    //응답
                    case 3:
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


            string json = JsonConvert.SerializeObject(temp, Formatting.Indented);

            JArray jsonObject = JArray.Parse(json);
            list_Jarray.Add(jsonObject);

            _ = Model.getInstance().oCPP_Comm_Manager.SendMessageAsync(json);
        }
    }
}
