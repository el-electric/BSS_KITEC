using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EL_BSS.Model;

namespace EL_BSS
{
    public partial class frmFrame : Form, IObserver
    {


        public delegate void ClickEvent(int idx);
        public static event ClickEvent MenuClick;
        private bool ThreadRun = true;


        private List<IObserver> _observers = new List<IObserver>();
        private Model.SlaveSend slaveSend;
        private Model model = new Model();
        frmMain frmMain = new frmMain();
        frmManual frmManual = new frmManual();
        public frmFrame()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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



        private void frmFrame_Load(object sender, EventArgs e)
        {
            initForm();
            viewForm(0);

            for (int i = 0; i < model.slaveCount; i++)
            {
                list_SlaveSend.Add(new SlaveSend(int.Parse(CsUtil.IniReadValue(model.DefaultPath, "CONFIG", "VOLT" + i + 1, "0")), int.Parse(CsUtil.IniReadValue(model.DefaultPath, "CONFIG", "WATT" + i + 1, "0"))));
                list_SlaveRecv.Add(new SlaveRecv());
            }


            if (!sp_Master.Open(Master_PortName))
                MessageBox.Show("마스터 포트 오픈 실패");
            if (!sp_Slave.Open(Model.Slave_PortName))
                MessageBox.Show("슬레이브 포트 오픈 실패");
        }

        public static void deleMenuClick(int idx)
        {
            MenuClick(idx);
        }
        private void FrmFrame_MenuClick(int idx)
        {
            viewForm(idx);
        }

        private void initForm()
        {
            if (!bck_Protocol.IsBusy)
                bck_Protocol.RunWorkerAsync();

            MenuClick += FrmFrame_MenuClick;

            _observers.Add(frmMain);
            _observers.Add(frmManual);

            frmMain.TopLevel = false;
            frmManual.TopLevel = false;
            frmMain.Show();
            frmManual.Show();

            foreach (IObserver observer in _observers)
            {
                observer.InitForm();
            }
        }

        public async void viewForm(int idx)
        {
            panel2.Controls.Clear();
            frmManual.timer1.Enabled = false;
            frmMain.timer1.Enabled = false;
            if (list_SlaveSend.Count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Model.list_SlaveSend[i].hmiManual = false;
                }
            }
            switch (idx)
            {
                case 0:
                    frmMain.timer1.Enabled = true;

                    panel2.Controls.Add(frmMain);
                    break;
                case 1:
                    frmManual.timer1.Enabled = true;
                    panel2.Controls.Add(frmManual);
                    break;

                case 10:

                    ThreadRun = false;
                    await Task.Delay(500);
                    sp_Master.Close();
                    sp_Slave.Close();
                    Application.Exit();
                    break;
            }
        }

        private void ui_timer_500ms_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString();
        }
        int masterIdx = 1;
        int slaveIdx = 1;
        private void bck_Protocol_DoWork(object sender, DoWorkEventArgs e)
        {
            while (ThreadRun)
            {
                if (isOpen_Master)
                {
                    model.makeMaserPacket(masterIdx++);

                    if (masterIdx > model.masterCount)
                    {
                        masterIdx = 1;
                    }
                }
                if (isOpen_Slave)
                {
                    byte[] bytes = model.makeSlavePacket(slaveIdx++);
                    sp_Slave.Write(bytes);
                    if (slaveIdx > model.slaveCount)
                    {
                        slaveIdx = 1;
                    }
                }

                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] a = model.makeSlavePacket(1);

            sp_Slave.Write(a);
        }

        public void InitForm()
        {

        }

        public void UpdateForm(Model model)
        {

        }

        private void lbl_time_DoubleClick(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(1);
        }
    }
}
