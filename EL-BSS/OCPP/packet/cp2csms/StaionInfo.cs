using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EL_BSS.Model;

namespace EL_BSS.OCPP.packet.cp2csms
{
    public class StaionInfo
    {
        public bool vibrationWarning;
        public bool floodingWarning;
        public int Charger_UpperTemper;
        public int Charger_Humidity;
        public bool Control_Board_Error;
        public StaionInfo(int index) 
        {
            vibrationWarning = Model.getInstance().list_MasterRecv[index].vibrationWarning;
            floodingWarning = Model.getInstance().list_MasterRecv[index].floodingWarning;
            Charger_UpperTemper = Model.getInstance().list_MasterRecv[index].Charger_UpperTemper;
            Charger_Humidity = Model.getInstance().list_MasterRecv[index].Charger_Humidity;
            Control_Board_Error = Model.getInstance().dic_Station_Error_Code[index][Station_Error.Control_Board_Error];

            /*if (Model.getInstance().list_MasterDataRecvDatetime[index].AddSeconds(5) > DateTime.Now)
            {
                Control_Board_Error = true;
            }*/

        }


    }
}
