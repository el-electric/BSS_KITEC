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
                chargeBoxSerialNumber = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID", ""),
            };
            string msg = makeMessage(enumData.BootNotification.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
        }
        public string sendOCPP_CP_Req_StatusNotification(int ChannelIdx, string status)
        {
            var data = new Object[]
            {
                2,
                Guid.NewGuid().ToString(),
                enumData.StatusNotification.ToString(),
                    new
                    {                        
                        connectorId = ChannelIdx,
                        status = status
                    }
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

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
        public async Task<string> sendOCPP_CP_Req_Authorize(string _idTag)
        {
            var data = new
            {
                idTag = _idTag
            };

            string msg = makeMessage(enumData.Authorize.ToString(), data);
            string response = await Model.getInstance().oCPP_Comm_Manager.SendMessageAndWaitForResponse(msg);
            return response;
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


            string json = JsonConvert.SerializeObject(temp, Formatting.Indented);

            JArray jsonObject = JArray.Parse(json);
            list_Jarray.Add(jsonObject);
            return json;
        }
    }
}
