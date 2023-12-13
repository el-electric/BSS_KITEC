using DrakeUI.Framework;
using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmMain : Form, IObserver
    {
        frmManual showfrmManual = new frmManual();


        public frmMain()
        {
            InitializeComponent();
        }

        public void InitForm()
        {

        }

        public void UpdateForm(Model model)
        {

        }

        public void UpdateForm(string data, Model model)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            frmFrame.deleMenuClick(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Text = ((double)588 / 10).ToString();
        }

        private void BatteryInfoShow()
        {


            this.Invoke(new MethodInvoker(delegate ()
            {
                for (int i = 0; i < 8; i++)
                {
                    bool foundBattery = false;
                    bool foundLabel = false;

                    foreach (Control control in tableLayoutPanel1.Controls)
                    {
                        if (!foundBattery && control.Name == "Battery_" + i)
                        {
                            ((DrakeUIBatteryBar)control).Power = Model.list_SlaveRecv[i].SOC;
                            foundBattery = true;
                        }
                        if (!foundLabel && control.Name == "lbl_soc" + i)
                        {
                            control.Text = Model.list_SlaveRecv[i].SOC.ToString() + "%";
                            foundLabel = true;
                        }
                        if (foundBattery && foundLabel)
                            break;
                    }

                    bool foundDoor = false;
                    foreach (Control control in splitContainer1.Panel1.Controls)
                    {
                        if (!foundDoor && control.Name == "picDoor_" + i)
                        {
                            if (Model.list_SlaveRecv[i].isDoor)
                            {
                                ((PictureBox)control).Visible = true;
                            }
                            else if (!Model.list_SlaveRecv[i].isDoor)
                            {
                                ((PictureBox)control).Visible = false;
                            }

                            foundDoor = true;
                        }

                        if (foundDoor)
                            break;
                    }
                }
            }));

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => BatteryInfoShow());
        }

        private void drakeUIButtonIcon1_Click(object sender, EventArgs e)
        {

        }
    }
}
