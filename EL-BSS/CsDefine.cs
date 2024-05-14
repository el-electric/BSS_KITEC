using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public class CsDefine
    {

        public const int CYC_INIT = 1;
        public const int CYC_MAIN = 100;
        public const int CYC_AUTHORIZE = 200;
        public const int CYC_INSERT_BATTERY_FIRST = 300;
        public const int CYC_INSERT_BATTERY_SECOND = 400;
        public const int CYC_CHARGING = 500;
        public const int CYC_RETRIEVE_BATTERY_FIRST = 600;
        public const int CYC_RETRIEVE_BATTERY_SECOND = 700;
        public const int CYC_COMPLETE = 800;
        public const int CYC_ERROR = 900;

        public const int CYC_END = 0;


        public const int CYC_RUN = 1;
        //public const int CYC_Firmware = 2;

        public static int[] Cyc_Rail = new int[5];
        public static int[] Delayed = new int[5];
        public static int[] Counted = new int[5];
        public static DateTime[] dt_beforeDealy = new DateTime[31];
        public static DateTime[] dt_beforeCount = new DateTime[31];
    }
}
