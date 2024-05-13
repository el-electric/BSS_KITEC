using DrakeUI.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Cycle
{
    public static class CsWork
    {
        public static int CurrentStep = 0;

        public static void Main_WorkCycle() //자동동작 시퀀스
        {
            switch (CsDefine.Cyc_Rail[CsDefine.CYC_RUN])
            {
                case CsDefine.CYC_WORK:
                    CurrentStep = CsDefine.CYC_WORK;
                    NextStep();
                    break;
                case CsDefine.CYC_WORK + 1:
                    mainFormLabelUpdate("1245");
                    NextStep();
                    break;
            }

        }
        private static void NextStep()
        {
            CsDefine.Delayed[CsDefine.CYC_RUN] = 0;
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = ++CurrentStep;


        }

        private static void mainFormLabelUpdate(string context)
        {
            var observer = Model.getInstance().frmFrame.observers.FirstOrDefault(o => ReferenceEquals(o, Model.getInstance().frmFrame));
            observer?.UpdateForm(context);
        }

    }
}
