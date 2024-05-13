using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_DC_Charger.ocpp.ver16.packet.cp2csms
{
    public class Req_BootNotification
    {
        /*public String chargePointSerialNumber;*/
        public String chargePointModel;
        /*public String chargeBoxSerialNumber;*/
        public String chargePointVendor;
        /*public String firmwareVersion;*/
        /*public String iccid;*/
        /*public String imsi;*/
        /*public String meterType;*/
        /*public String meterSerialNumber;*/

        public void setRequiredValue(String chargePointModel, String chargePointVendor)
        {           

            this.chargePointModel = chargePointModel;
            this.chargePointVendor = chargePointVendor;


        }
    }
}
