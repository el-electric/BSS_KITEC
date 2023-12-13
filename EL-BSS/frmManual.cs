using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EL_BSS
{
    public partial class frmManual : Form,IObserver
    {
        protected frmSubManual[] mLayouts = new frmSubManual[8];
        public frmManual()
        {
            InitializeComponent();

             for (int i = 1; i < 9; i++)
            {
                mLayouts[i - 1] = new frmSubManual(i);  // 하나씩 래이아웃에 집어넣음
                mLayouts[i - 1].TopLevel = false;  // topLevel를 false로                
                flowLayoutPanel2.Controls.Add(mLayouts[i - 1]);
                mLayouts[i-1].Show();
            }



            updateView();

            timer1.Enabled = true;
            timer1.Start();
        }

        public void updateView()
        {
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateView();
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
    }
}
