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
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EL_BSS
{
    public partial class frmManual : Form, IObserver
    {
        protected frmSubManual frmSubManual = new frmSubManual();
        protected frmMaster_Manual master_layout = new frmMaster_Manual();
        public System.Timers.Timer timer = new System.Timers.Timer();
        Vkeyvoard VKeyboard = new Vkeyvoard();
        public Sound_Player sound_Player;
        public frmManual()
        {
            InitializeComponent();

            timer.Interval = 100;
            timer.Elapsed += Timer_Elapsed;

            master_layout.TopLevel = false;
            flowLayoutPanel2.Controls.Add(master_layout);
            master_layout.Show();

            /*for (int i = 1; i < 9; i++)
            {
                mLayouts[i - 1] = new frmSubManual(i);  // 하나씩 래이아웃에 집어넣음
                mLayouts[i - 1].TopLevel = false;  // topLevel를 false로                
                flowLayoutPanel2.Controls.Add(mLayouts[i - 1]);
                mLayouts[i - 1].Show();
            }*/

            frmSubManual = new frmSubManual(1);  // 하나씩 래이아웃에 집어넣음
            frmSubManual.TopLevel = false;  // topLevel를 false로                
            flowLayoutPanel2.Controls.Add(frmSubManual);
            frmSubManual.Show();

            updateView();

            Model.getInstance().setTouchManger(this);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                master_layout.updateView();
                frmSubManual.updateView();
            }));
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
            //await Task.Run(() => updateView());
        }

        private void All_Door_Open_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                Model.getInstance().list_SlaveSend[i - 1].doorOpen = true;
            }
        }

        private void All_Door_Close_Click(object sender, EventArgs e)
        {

        }

        private void Back_Main_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                Model.getInstance().list_SlaveRecv[i].DischargingMode = false;
                Model.getInstance().list_SlaveSend[i].hmiManual = false;
                Model.getInstance().list_SlaveSend[i].LED_Red = false;
                Model.getInstance().list_SlaveSend[i].LED_Blue = false;
                Model.getInstance().list_SlaveSend[i].LED_Green = false;
            }
            frmFrame.deleMenuClick(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCSMSSetting frmCSMSSetting = new frmCSMSSetting();
            frmCSMSSetting.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(10);
        }

        private void Vkey_ON_button_Click(object sender, EventArgs e)
        {
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;

            Vkeyvoard VKeyboard = new Vkeyvoard();
            VKeyboard.showKeyboard();

            int keyboardWidth = 250;  // 키보드의 너비
            int keyboardHeight = 100; // 키보드의 높이
            //VKeyboard.moveWindow(0, screenHeight - keyboardHeight, keyboardWidth, keyboardHeight);
        }

        private void Vkey_OFF_button_Click(object sender, EventArgs e)
        {
            try
            {
                VKeyboard.hideKeyboard();
            }
            catch { }
        }

        private async void btn_firmup1_Click(object sender, EventArgs e)   // 파일을 선택하는 버튼
        {
            Model.getInstance().FirmwareUpdate_step = 0;

            Model.getInstance().binBufferCount = 0;
            Model.getInstance().binFileBuffer.Clear();
            Model.getInstance().isOpen_Master = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "펌웨어 업데이트";
            ofd.FileName = "";
            ofd.Filter = "bin파일 (*.bin) | *.bin; | 모든 파일 (*.*) | *.*";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;

                Model.getInstance().binFile = File.ReadAllBytes(fileFullName);
                Console.WriteLine($"Read {Model.getInstance().binFile.Length} bytes");


                //string hexString = BitConverter.ToString(fileData).Replace("-", " ");                


                int chunkSize = 200;
                for (int i = 0; i < Model.getInstance().binFile.Length; i += chunkSize)
                {
                    // 현재 위치에서부터 chunkSize만큼 또는 배열의 끝까지의 길이를 계산
                    int length = Math.Min(chunkSize, Model.getInstance().binFile.Length - i);
                    byte[] chunk = new byte[length];
                    Array.Copy(Model.getInstance().binFile, i, chunk, 0, length);
                    Model.getInstance().binFileBuffer.Add(chunk);
                }

                await Task.Delay(500);

                Model.getInstance().FirmwareUpdate = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Model.makeFirmwareupdate(1, 1);
        }

        private void Chage_To_FW_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(2);
        }

        public void UpdateForm(string data)
        {
            throw new NotImplementedException();
        }

        private void btn_fan_1_Click(object sender, EventArgs e)
        {

        }

        private void btn_fan_2_Click(object sender, EventArgs e)
        {

        }

        private void AutoStart_Popup_Click(object sender, EventArgs e)
        {
            frmAutoStartPopup frmAutoStartPopup = new frmAutoStartPopup();
            frmAutoStartPopup.Show();
        }

        private void btn_buzzer_Stop_Click(object sender, EventArgs e)
        {
            if (sound_Player != null)
            {
                sound_Player.Stop_play();
            }
        }

        private void btn_buzzer_start_Click(object sender, EventArgs e)
        {
            sound_Player = new Sound_Player();
            sound_Player.play_Sound(true);
        }

        private void btn_check_connection_Click(object sender, EventArgs e)
        {
            frmCheckConnction frmCheckConnction = new frmCheckConnction();
            frmCheckConnction.Show();
        }

        private void btn_CheckCSMS_Click(object sender, EventArgs e)
        {
            Model.getInstance().frmTest_CSMS = new frmTest_CSMS();
            Model.getInstance().frmTest_CSMS.Show();
        }
    }
}
