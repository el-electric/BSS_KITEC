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
    public partial class frmFrame : Form
    {

        private List<IObserver> _observers = new List<IObserver>();
        frmMain frmMain = new frmMain();
        public frmFrame()
        {
            InitializeComponent();
        }




        private void frmFrame_Load(object sender, EventArgs e)
        {
            initForm();
            viewForm(0);
        }

        private void initForm()
        {
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
    }
}
