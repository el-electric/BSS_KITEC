using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChangeCharger.OCPP
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EOCPP_Action_CSMS_Call
    {


        CancelReservation,
        ChangeAvailability,
        ChangeConfiguration,
        ClearCache,
        ClearChargingProfile,
        DataTransfer,

        GetCompositeSchedule,
        GetConfiguration,
        GetDiagnostics,
        GetLocalListVersion,

        RemoteStartTransaction,
        RemoteStopTransaction,
        ReserveNow,
        Reset,
        SendLocalList,
        SetChargingProfile,

        TriggerMessage,
        UnlockConnector,
        UpdateFirmware,
    }
}
