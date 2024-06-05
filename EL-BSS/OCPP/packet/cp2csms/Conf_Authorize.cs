using EL_DC_Charger.ocpp.ver16.datatype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EL_DC_Charger.ocpp.ver16.packet.cp2csms
{
    public class Conf_Authorize
    {
        // public IdTagInfo idTagInfo;
        /*public MoreAuthorizeConf moreAuthorizeConf;*/

        public String status;
        public String staionId;
        public int userNo;
        public String userName;
        public int batterySetNo;
        public String batterySetName;
        public String batteryId1;
        public String batteryId2;
        public bool ticketAvailable;
        public int cashBalance;
    }

}
