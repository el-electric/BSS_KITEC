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
using static EL_BSS.Model;

namespace EL_BSS
{
    public partial class frmMain : Form, IObserver
    {
        frmManual showfrmManual = new frmManual();
        frmunuseablePopup frmunuseablePopup;
        frmDoorClosePopup frmDoorClosePopup;

        public frmMain()
        {
            InitializeComponent();
            Model.getInstance().setTouchManger(this);
            Model.getInstance().csErrorControl = new CsErrorControl();
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
            elementHost1.Child = getInstance().frmFrame.userControl1;
        }

        public void UpdateForm(Model model)
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

            //ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            //barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

            //barcodeWriter.Options.Width = pb_qr.Width;
            //barcodeWriter.Options.Height = pb_qr.Height;
            //barcodeWriter.Options.Margin = 0;
            //pb_qr.SizeMode = PictureBoxSizeMode.Zoom;
            //string qr_data = CsUtil.IniReadValue(Application.StartupPath + @"\Config.ini", "STATION", "ID");
            //if (qr_data != "")
            //    this.pb_qr.Image = barcodeWriter.Write(qr_data);
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

        public void setting_button_visible(bool setting)
        {
            //pb_qr.Visible = setting;
            //drakeUIButton1.Visible = setting;

        }

        public void show_p(string message)
        {
            Form currentForm = this;
            frmunuseablePopup = new frmunuseablePopup(message);
            frmunuseablePopup.StartPosition = FormStartPosition.Manual;

            frmunuseablePopup.Location = this.PointToScreen(new System.Drawing.Point(0, 0));
            frmunuseablePopup.Owner = this;

            this.BeginInvoke(new Action(() =>
            {
                frmunuseablePopup.ShowDialog();
            }));
        }

        public void close_p()
        {
            if (this.InvokeRequired) // Invoke 예외 처리
            {
                frmunuseablePopup.Close();
            }
        }

        public void show_Door_Close_Popup(int slot1 , int slot2)
        {
            Form currentForm = this;
            frmDoorClosePopup = new frmDoorClosePopup(slot1 , slot2);
            frmDoorClosePopup.StartPosition = FormStartPosition.CenterScreen;
            frmDoorClosePopup.Owner = this;

            this.BeginInvoke(new Action(() =>
            {
                frmDoorClosePopup.Show();
            }));
        }

        public void close_Door_Close_Popup()
        {
            if (this.InvokeRequired) // Invoke 예외 처리
            {
                frmDoorClosePopup.Close();
            }
        }
    }
}
