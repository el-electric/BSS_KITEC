using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmAutoStartPopup : Form
    {
        public Setting_AutoStart Setting_AutoStart = new Setting_AutoStart();
        public bool adminMode = false;
        public frmAutoStartPopup()
        {
            InitializeComponent();
            lb_auto_start.Text = "";

            if (Setting_AutoStart.IsRunAsAdmin())
            {
                lb_auto_start.Text = "관리자 권한 실행";
                adminMode = true;
            }
            else
            {
                lb_auto_start.Text = "관리자 권한 없음";
                adminMode = false;
            }
        }

        private void btn_add_service_Click(object sender, EventArgs e)
        {
            if (adminMode) lb_auto_start.Text = Setting_AutoStart.Auto_Start_Add();
            else lb_auto_start.Text = "관리자 권한으로 실행시켜주세요";
        }

        private void btn_remove_service_Click(object sender, EventArgs e)
        {
            if (adminMode) lb_auto_start.Text = Setting_AutoStart.Auto_Start_Remove();
            else lb_auto_start.Text = "관리자 권한으로 실행시켜주세요";
        }

        private void btn_confirm_service_Click(object sender, EventArgs e)
        {
            if (adminMode) lb_auto_start.Text = Setting_AutoStart.Auto_Start_Confirm();
            else lb_auto_start.Text = "관리자 권한으로 실행시켜주세요";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            lb_auto_start.Text = "";
            this.Close();
        }
    }
}
