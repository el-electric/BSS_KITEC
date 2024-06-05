using BatteryChangeCharger.OCPP;
using DrakeUI.Framework;
using EL_BSS.Cycle;
using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management.Instrumentation;
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        public void InitForm()
        {

        }

        public void UpdateForm(Model model)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
        }

        private async Task aa()
        {
            await Task.Delay(1000);
            Console.WriteLine("didi");
        }
        private void button4_Click(object sender, EventArgs e)
        {

            frmFrame.deleMenuClick(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN;
        }

        private void BatteryInfoShow()
        {


            this.Invoke(new MethodInvoker(delegate ()
            {
                for (int i = 0; i < 8; i++)
                {

                    ///////////////////////
                    TimeSpan timeDifference = DateTime.Now - Model.getInstance().list_SlaveDataRecvDatetime[i];
                    Controls.Find("label" + (i + 1), true)[0].Text = $"{timeDifference.Hours:D2}:{timeDifference.Minutes:D2}:{timeDifference.Seconds:D2}";
                    ///////////////////////

                    bool foundBattery = false;
                    bool foundLabel = false;

                    foreach (Control control in tableLayoutPanel1.Controls)
                    {
                        if (!foundBattery && control.Name == "Battery_" + i)
                        {
                            ((DrakeUIBatteryBar)control).Power = Model.getInstance().list_SlaveRecv[i].SOC;

                            if (Model.getInstance().list_SlaveRecv[i].SOC.ToString().Equals("0"))
                            {
                                ((DrakeUIBatteryBar)control).MultiColor = false;
                                ((DrakeUIBatteryBar)control).FillColor = Color.Transparent;
                            }
                            else
                            {
                                ((DrakeUIBatteryBar)control).FillColor = Color.Transparent;
                                ((DrakeUIBatteryBar)control).MultiColor = true;
                            }

                            foundBattery = true;
                        }
                        if (!foundLabel && control.Name == "lbl_soc" + i)
                        {
                            if (Model.getInstance().list_SlaveRecv[i].SOC.ToString().Equals("0"))
                            {
                                control.ForeColor = Color.Gray;
                                control.Text = "Empty";
                            }
                            else
                            {
                                control.Text = Model.getInstance().list_SlaveRecv[i].SOC.ToString() + "%" + Model.getInstance().list_SlaveRecv[i].Check_BatteryVoltage_Type + "V";
                                control.ForeColor = Color.Black;
                            }
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
                            if (Model.getInstance().list_SlaveRecv[i].isDoor)
                            {
                                ((PictureBox)control).Visible = true;
                            }
                            else if (!Model.getInstance().list_SlaveRecv[i].isDoor)
                            {
                                ((PictureBox)control).Visible = false;
                            }

                            foundDoor = true;
                        }

                        if (foundDoor)
                            break;
                    }

                    foreach (Control control in tableLayoutPanel2.Controls)
                    {
                        if (control.Name == "lamp" + i)
                        {
                            if (Model.getInstance().list_SlaveDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                                ((DrakeUILampLED)control).On = true;
                            else
                                ((DrakeUILampLED)control).On = false;

                            break;
                        }
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    foreach (Control control in tableLayoutPanel3.Controls)
                    {
                        if (control.Name == "master_lamp" + i)
                        {
                            if (Model.getInstance().list_MasterDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                                ((DrakeUILampLED)control).On = true;
                            else
                                ((DrakeUILampLED)control).On = false;

                            break;
                        }
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

            barcodeWriter.Options.Width = pb_qr.Width;
            barcodeWriter.Options.Height = pb_qr.Height;
            pb_qr.SizeMode = PictureBoxSizeMode.Zoom;
            string qr_data = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID");
            if (qr_data != "")
                this.pb_qr.Image = barcodeWriter.Write(qr_data);
        }

        public void UpdateForm(string data)
        {
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(3);
        }

        private void drakeUIButton1_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(3);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            int validIndx = 0;
            var indices = Model.getInstance().list_SlaveRecv
            .Select((s, i) => new { Element = s, Index = i })
            .Where(x => x.Element.SOC == 100)
            .Select(x => x.Index)
            .ToList();

            if (indices.Count >= 2)
            {
                Console.WriteLine("조건을 만족하는 인덱스");
                foreach (var index in indices)
                {
                    Console.WriteLine(index);
                    //열고
                    validIndx++;
                    if (validIndx == 2)
                        break;
                }
            }
        }
    }
}
