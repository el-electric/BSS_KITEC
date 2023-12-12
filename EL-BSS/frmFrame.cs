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
    public partial class frmFrame : Form
    {
        private List<IObserver> _observers = new List<IObserver>();
        private Model.SlaveSend slaveSend;
        private Model model = new Model();

        frmMain frmMain = new frmMain();
        public frmFrame()
        {
            InitializeComponent();
        }




        private void frmFrame_Load(object sender, EventArgs e)
        {
            initForm();
            viewForm(0);

            for (int i = 0; i < model.slaveCount; i++)
            {
                list_SlaveSend.Add(new SlaveSend());
                list_SlaveRecv.Add(new SlaveRecv());
            }
        }

        private void initForm()
        {
            if (!bck_Protocol.IsBusy)
                bck_Protocol.RunWorkerAsync();

            _observers.Add(frmMain);

            frmMain.TopLevel = false;
            frmMain.Show();


            foreach (IObserver observer in _observers)
            {
                observer.InitForm();
            }




        }

        private void viewForm(int idx)
        {
            panel2.Controls.Clear();

            switch (idx)
            {
                case 0:
                    panel2.Controls.Add(frmMain);
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
            while (true)
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
    }
}
