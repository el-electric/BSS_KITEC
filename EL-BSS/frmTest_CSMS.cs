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
        bool is_wss = true;
        public frmTest_CSMS()
        {
            InitializeComponent();

            tb_csms.Text = "";

            TopMost = true;

            is_wss = true;

            for (int i = 0; i < Model.getInstance().test_csms_buffer.Count; i++)
            {
                tb_csms.Text += Model.getInstance().test_csms_buffer[i] + "\r\n";
            }
        }

        public void input_text(string value,bool mis_wss)
        {
            if(mis_wss == is_wss)
            tb_csms.Text += value + "\r\n";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (is_wss)
            {
                Model.getInstance().test_csms_buffer = new List<string>();

                Model.getInstance().uid_array = new string[1024, 2];
                Model.getInstance().test_uid_length = 0;
            }
            else 
            {
                Model.getInstance().test_error_buffer = new List<string>();
            }

            tb_csms.Text = "";
        }

        private void frmTest_CSMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.getInstance().frmTest_CSMS = null;
        }

        private void button_wss_Click(object sender, EventArgs e)
        {
            is_wss = true;
            tb_csms.Text = "";
            for (int i = 0; i < Model.getInstance().test_csms_buffer.Count; i++)
            {
                tb_csms.Text += Model.getInstance().test_csms_buffer[i] + "\r\n";
            }
        }

        private void btn_error_Click(object sender, EventArgs e)
        {
            is_wss = false;
            tb_csms.Text = "";
            for (int i = 0; i < Model.getInstance().test_error_buffer.Count; i++)
            {
                tb_csms.Text += Model.getInstance().test_error_buffer[i] + "\r\n";
            }
        }

        private void btn_ws_reconnect_Click(object sender, EventArgs e)
        {
            if (!Model.getInstance().oCPP_Comm_Manager.get_WebSocket_State())
            { Model.getInstance().oCPP_Comm_Manager.WebSocketOpen(); }
        }

        private void drakeUIButton1_Click(object sender, EventArgs e)
        {
            Model.getInstance().oCPP_Comm_Manager.WebSocketClose();
        }
    }
}
