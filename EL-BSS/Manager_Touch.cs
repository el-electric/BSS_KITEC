using DrakeUI.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public class Manager_Touch
    {
        protected Thread mtthread = null;
        public Manager_Touch(Form con)
        {
            if (!Model.getInstance().TouchManagerInit)
            {
                Model.getInstance().TouchManagerInit = true;
                SetBrightness(100);
                init();
            }

            if (con != null)
            {
                EnumerateChildren(con);
            }
        }

        protected void init()
        {
            mtthread = new Thread(run);
            mtthread.Start();
        }

        private void EnumerateChildren(Control root)
        {
            foreach (Control control in root.Controls)
            {
                if (control.Controls != null)
                {
                    control.Click += Control_Click1;
                    EnumerateChildren(control);
                }
            }
        }

        private void Control_Click1(object sender, EventArgs e)
        {
            SetBrightness(100);
            //ineedSetBrightness(100);

        }

        protected void run()
        {
            while (true)
            {
                if (!Model.getInstance().DT_Screen_Touch_Time.AddMinutes(5).IsAfter(DateTime.Now))
                {
                    Model.getInstance().DT_Screen_Touch_Time = DateTime.Now;
                    SetBrightness(10);
                }

                Thread.Sleep(1000);
            }
        }

        protected static void SetBrightness(byte targetBrightness)
        {
            //define scope (namespace)
            System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");
            //define query
            System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightnessMethods");
            //output current brightness
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);
            System.Management.ManagementObjectCollection moc = mos.Get();
            foreach (System.Management.ManagementObject o in moc)
            {
                o.InvokeMethod("WmiSetBrightness", new object[] { uint.MaxValue, targetBrightness });
                //note the reversed order - won't work otherwise!
                break; //only work on the first object
            }

            moc.Dispose();
            mos.Dispose();
        }
    }
}
