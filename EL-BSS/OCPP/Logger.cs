using BatteryChangeCharger.BatteryChange_Charger.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace BatteryChangeCharger.OCPP
{
    public class Logger
    {
        public static async void d(String log)
        {
            Console.WriteLine(log);

            try
            {
                CsUtil.WriteLog(log, "CSMS");
            }
            catch
            {
                await Task.Delay(50);
                CsUtil.WriteLog(log, "CSMS");
            }
        }
    }
}
