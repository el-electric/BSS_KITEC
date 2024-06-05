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

        public String staionId;
        public int userNo;
        public String userName;
        public int batterySetNo;
        public String batterySetName;
        public String batteryId1;
        public String batteryId2;
        public bool ticketAvailable;
        public int cashBalance;
        public int type;

        /*public MoreAuthorizeReq moreAuthorizeReq;*/


    }

}
