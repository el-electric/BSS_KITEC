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
    public partial class frmunuseablePopup : Form
    {
        public frmunuseablePopup(string message)
        {
            InitializeComponent();

            lb_Noti.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        public void set_lb_Noti(string message)
        {
            lb_Noti.Text = message;
        }
    }
}
