using DrakeUI.Framework;
using EL_BSS.Cycle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace EL_BSS
{
    public partial class frmCheckConnction : Form
    {
        public System.Timers.Timer timer = null;
        public frmCheckConnction()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer1_tick;
            timer.Enabled = true;
            timer.Start();
        }

        private async void Timer1_tick(object sender, EventArgs e)
        {
            await Task.Run(() => UpdateView());
        }

        private void UpdateView()
        {
            DrakeUILabel lb_name = new DrakeUILabel();

            for (int i = 1; i < 9; i++)
            {

                foreach (Control control in tableLayoutPanel3.Controls)
                {
                    if (control is DrakeUILabel drakeUILabel)
                    {
                        if (control.Name == "lb_slave_" + i)
                        {
                            if (!Model.getInstance().list_SlaveDataRecvDatetime[i -1].IsAfter(DateTime.Now.AddSeconds(5)))
                            {
                                control.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                control.BackColor = System.Drawing.Color.Green;
                            }
                        }
                    }

                    else if (control is Label label)
                    {
                        if (control.Name == ("lb_slave_" + i + "_time"))
                        {
                            if (!Model.getInstance().list_SlaveDataRecvDatetime[i - 1].IsAfter(DateTime.Now.AddSeconds(5)))
                            {
                                TimeSpan time = DateTime.Now - Model.getInstance().list_SlaveDataRecvDatetime[i -1];
                                control.Text = time.Seconds.ToString() + "초 지남";
                            }
                            else
                            {
                                control.Text = "연결됨";
                            }
                        }
                    }
                }
            }

            for (int i = 1; i < 3; i++)
            {
                foreach (Control control in tableLayoutPanel3.Controls)
                {
                    if (control is DrakeUILabel drakeUILabel)
                    {
                        if (control.Name == "lb_master_" + i)
                        {
                            if (!Model.getInstance().list_MasterDataRecvDatetime[i - 1].IsAfter(DateTime.Now.AddSeconds(5)))
                            {
                                control.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                control.BackColor = System.Drawing.Color.Green;
                            }
                        }
                    }

                    else if (control is Label label)
                    {
                        if (control.Name == ("lb_master_" + i + "_time"))
                        {
                            if (!Model.getInstance().list_MasterDataRecvDatetime[i - 1].IsAfter(DateTime.Now.AddSeconds(5)))
                            {
                                TimeSpan time = DateTime.Now - Model.getInstance().list_MasterDataRecvDatetime[i - 1];
                                control.Text = time.Seconds.ToString() + "초 지남";
                            }
                            else
                            {
                                control.Text = "연결됨";
                            }
                        }
                    }
                }
            }
        }

        private void frmCheckConnction_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void drakeUIButton1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}

    

            
    

