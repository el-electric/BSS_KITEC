using DrakeUI.Framework;
using EL_BSS;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EL_BSS.Model;

namespace EL_DC_Charger.ocpp.ver16.packet.cp2csms
{
    public class Req_Authorize
    {
        // public String idTag;

        public String uid;
        public String errCode;
        public String staionId;
        public int userNo;
        public String userName;
        public int batterySetNo;
        public String batterySetName;
        public List<string> returnBatteryIds;
        public bool ticketAvailable;
        public int cashBalance;
        public int batteryType;
        public string[] returnbatteryId = new string[2];
        public string ticketAvailable_value;
        public string errMsg;
        public string status;

        /*public MoreAuthorizeReq moreAuthorizeReq;*/

        public void setting_Authorize_value()
        {

            if (Model.getInstance().Authorize_Type == enumData.APP.ToString())
            { errCode = "00000"; }

            if (this.errCode == "00000")
            {
                List<string> returnbatteryIdList = new List<string>();

                foreach (var item in returnBatteryIds)
                {
                    string[] splititem = item.Split(',');
                    returnbatteryIdList.AddRange(splititem);
                }
                this.returnbatteryId = returnbatteryIdList.ToArray();

                if (ticketAvailable)
                { ticketAvailable_value = "O"; }
                else
                { ticketAvailable_value = "X"; }
            }
        }
    }
}
