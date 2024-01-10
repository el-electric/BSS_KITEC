using DrakeUI.Framework;
using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EL_BSS
{
    public partial class frmManual : Form, IObserver
    {
        protected frmSubManual[] mLayouts = new frmSubManual[8];

        Vkeyvoard VKeyboard = new Vkeyvoard();
        public frmManual()
        {
            InitializeComponent();

            for (int i = 1; i < 9; i++)
            {
                mLayouts[i - 1] = new frmSubManual(i);  // 하나씩 래이아웃에 집어넣음
                mLayouts[i - 1].TopLevel = false;  // topLevel를 false로                
                flowLayoutPanel2.Controls.Add(mLayouts[i - 1]);
                mLayouts[i - 1].Show();
            }

            updateView();

            string[] port = SerialPort.GetPortNames();
            cb_master.Items.AddRange(port);
            cb_slave.Items.AddRange(port);

            if (!Model.Master_PortName.Equals(""))
                cb_master.Text = Model.Master_PortName;
            if (!Model.Slave_PortName.Equals(""))
                cb_slave.Text = Model.Slave_PortName;
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

        public void updateView()
        {
            lbl_test.Text = Model.binBufferCount.ToString() + " / " + Model.binFileBuffer.Count;

            for (int i = 1; i < 9; i++)
            {
                mLayouts[i - 1].updateView();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void frmManual_Load(object sender, EventArgs e)
        {

        }

        public void InitForm()
        {

        }

        public void UpdateForm(Model model)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => updateView());
        }

        private void All_Door_Open_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                Model.list_SlaveSend[i - 1].doorOpen = true;
            }
        }

        private void All_Door_Close_Click(object sender, EventArgs e)
        {

        }

        private void Back_Main_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "COMPORT", "MASTER", cb_master.Text);
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "COMPORT", "SLAVE", cb_slave.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(10);
        }

        private void Vkey_ON_button_Click(object sender, EventArgs e)
        {
            Vkeyvoard VKeyboard = new Vkeyvoard();
            VKeyboard.showKeyboard();
            VKeyboard.moveWindow(0, 0, 250, 100);
        }

        private void Vkey_OFF_button_Click(object sender, EventArgs e)
        {
            VKeyboard.hideKeyboard();
        }

        private async void btn_firmup1_Click(object sender, EventArgs e)
        {
            Model.masterFirmwareUpdate_step = 0;

            Model.binBufferCount = 0;
            Model.binFileBuffer.Clear();
            Model.isOpen_Master = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "펌웨어 업데이트";
            ofd.FileName = "";
            ofd.Filter = "bin파일 (*.bin) | *.bin; | 모든 파일 (*.*) | *.*";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;

                Model.binFile = File.ReadAllBytes(fileFullName);
                Console.WriteLine($"Read {Model.binFile.Length} bytes");


                //string hexString = BitConverter.ToString(fileData).Replace("-", " ");                


                int chunkSize = 200;
                for (int i = 0; i < Model.binFile.Length; i += chunkSize)
                {
                    // 현재 위치에서부터 chunkSize만큼 또는 배열의 끝까지의 길이를 계산
                    int length = Math.Min(chunkSize, Model.binFile.Length - i);
                    byte[] chunk = new byte[length];
                    Array.Copy(Model.binFile, i, chunk, 0, length);
                    Model.binFileBuffer.Add(chunk);
                }

                await Task.Delay(500);
                
                Model.masterFirmwareUpdate = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Model.makeFirmwareupdate();
        }
    }
}
