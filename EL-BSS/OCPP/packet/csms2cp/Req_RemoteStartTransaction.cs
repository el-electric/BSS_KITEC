﻿using EL_DC_Charger.ocpp.ver16.datatype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_DC_Charger.ocpp.ver16.packet.csms2cp
{
    public class Req_RemoteStartTransaction
    {
        public int? connectorId;
        public String idTag;
        public ChargingProfile chargingProfile;
    }
}
