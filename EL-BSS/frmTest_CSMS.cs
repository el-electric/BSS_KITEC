using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmTest_CSMS : Form
    { 
        public frmTest_CSMS()
        {
            InitializeComponent();

            tb_csms.Text = "";

            TopMost = true;

            for (int i = 0; i < Model.getInstance().test_csms_buffer.Count; i++)
            {
                tb_csms.Text += Model.getInstance().test_csms_buffer[i] + "\r\n";
            }
        }

        public void input_text(string value)
        {
            tb_csms.Text += value + "\r\n";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Model.getInstance().test_csms_buffer = new List<string>();

            Model.getInstance().uid_array = new string[1024, 2];
            Model.getInstance().test_uid_length = 0;

            tb_csms.Text = "";
        }

        private void frmTest_CSMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.getInstance().frmTest_CSMS = null;
        }
    }
}
