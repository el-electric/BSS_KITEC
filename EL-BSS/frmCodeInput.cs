using DrakeUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EL_BSS
{
    public partial class frmCodeInput : Form
    {
        public frmCodeInput()
        {
            InitializeComponent();
            tb_intput.SelectionAlignment = HorizontalAlignment.Center;
        }


        private void NumClick(object sender, EventArgs e)
        {
            if (tb_intput.Text.Length < 6)
            {
                tb_intput.Text += ((DrakeUIButton)sender).Text;
            }


        }

        private void drakeUIButtonIcon2_Click(object sender, EventArgs e)
        {
            if (tb_intput.Text.Length > 0)
            {
                tb_intput.Text = tb_intput.Text.Substring(0, tb_intput.Text.Length - 1);
            }
        }

        private async void drakeUIButtonIcon1_Click(object sender, EventArgs e)
        {
            if (tb_intput.Text.Length == 6)
            {
                lbl_status.Text = "인증코드 전송";
                btn_enter.Enabled = false;
                string response = await Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_Authorize(tb_intput.Text);
                btn_enter.Enabled = true;
                if (response == null)
                    lbl_status.Text = "서버 응답 없음";

            }
        }

        private void drakeUIButtonIcon1_Click_1(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(0);
        }
    }
}
