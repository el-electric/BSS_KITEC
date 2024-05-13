using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public class CsDefine
    {

        public const int CYC_INIT = 0;
        public const int CYC_WORK = 100;


        public const int CYC_RUN = 1;

        public static int[] Cyc_Rail = new int[5];
        public static int[] Delayed = new int[5];
        public static int[] Counted = new int[5];
        public static DateTime[] dt_beforeDealy = new DateTime[31];
        public static DateTime[] dt_beforeCount = new DateTime[31];
    }
}
