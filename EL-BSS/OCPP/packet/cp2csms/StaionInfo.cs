using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.OCPP.packet.cp2csms
{
    public class StaionInfo
    {
        public bool vibrationWarning;
        public bool floodingWarning;
        public bool floodingDanger;
        public int Charger_UpperTemper;
        public int Charger_Humidity;
        public int Charger_WaveSensor;
        public StaionInfo(int index) 
        {
            vibrationWarning = Model.getInstance().list_MasterRecv[index].vibrationWarning;
            floodingWarning = Model.getInstance().list_MasterRecv[index].floodingWarning;
            floodingDanger = Model.getInstance().list_MasterRecv[index].floodingDanger;
            Charger_UpperTemper = Model.getInstance().list_MasterRecv[index].Charger_UpperTemper;
            Charger_Humidity = Model.getInstance().list_MasterRecv[index].Charger_Humidity;
            Charger_WaveSensor = Model.getInstance().list_MasterRecv[index].Charger_WaveSensor;
        }


    }
}
