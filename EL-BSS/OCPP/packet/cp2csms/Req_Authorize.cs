using DrakeUI.Framework;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_DC_Charger.ocpp.ver16.packet.cp2csms
{
    public class Req_Authorize
    {
        // public String idTag;

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

        /*public MoreAuthorizeReq moreAuthorizeReq;*/

        public void setting_Authorize_value()
        {
            if (this.errCode == "00000")
            {
                List<string> returnbatteryIdList = new List<string>();

                foreach (var item in returnBatteryIds)
                {
                    string[] splititem = item.Split(',');
                    returnbatteryIdList.AddRange(splititem);
                }
                this.returnbatteryId = returnbatteryIdList.ToArray();

                if (ticketAvailable) ticketAvailable_value = "구독중";
                else ticketAvailable_value = "구독 취소";
            }
        }
    }
}
