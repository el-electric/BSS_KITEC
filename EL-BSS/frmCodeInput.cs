using DrakeUI.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
using static EL_BSS.Model;
using EL_DC_Charger.ocpp.ver16.packet.cp2csms;
using EL_BSS.Cycle;
using System.Threading;

namespace EL_BSS
{
    public partial class frmCodeInput : Form, IObserver
    {
        public string identificationCode;
        public string securityCode;
        public frmCodeInput()
        {
            InitializeComponent();
            tb_intput.SelectionAlignment = HorizontalAlignment.Center;

            Model.getInstance().setTouchManger(this);
        }


        private void NumClick(object sender, EventArgs e)
        {
            int limit;
            if (!Model.getInstance().is_manual_mode) { limit = 4; }
            else { limit = 6; }


            if (tb_intput.Text.Length < limit)
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
            if (!Model.getInstance().is_manual_mode)
            {
                if (lbl_sub_status.Text == "Enter the identification code shown in the app")
                {
                    if (tb_intput.Text.Length == 4)
                    {
                        identificationCode = tb_intput.Text;
                        tb_intput.Text = string.Empty;

                        lbl_sub_status.Text = "Enter the Security code shown in the app";
                        lbl_main_status.Text = "Enter Security Code";
                    }
                }
                else
                {
                    if (tb_intput.Text.Length == 4)
                    {
                        securityCode = tb_intput.Text;
                        lbl_sub_status.Text = "Send Authentication Code";


                        btn_enter.Enabled = false;
                        string response = await Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_Authorize(identificationCode, securityCode);
                        btn_enter.Enabled = true;

                        if (response == null || response == "TIMEOUT")
                        {
                            lbl_sub_status.Text = "No Server Response";
                            return;
                        }
                        // JArray responseObject = null;
                        // JArray jsonArray = JArray.Parse(_packet);
                        try
                        {
                            Model.getInstance().Authorize_Type = enumData.STATION.ToString();
                            JArray responseObject = JArray.Parse(response);
                            Model.getInstance().Authorize = JsonConvert.DeserializeObject<Req_Authorize>(responseObject[2].ToString());
                            Model.getInstance().Authorize.setting_Authorize_value();
                            string errCode = responseObject?[2]?["errCode"]?.ToString();
                            string errMsg = responseObject?[2]?["errMsg"]?.ToString();

                            switch (errCode)
                            {
                                case "00000":
                                    lbl_sub_status.Text = "Verification Successful";

                                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN;
                                    break;
                                default:
                                    lbl_sub_status.Text = "Verification Failed: " + errMsg;
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            frmFrame.deleMenuClick(0);
                        }
                    }
                }
            }
            else
            {
                if (tb_intput.Text.Equals("009988"))
                {
                    frmFrame.deleMenuClick(1);
                }
            }
        }

        private void drakeUIButtonIcon1_Click_1(object sender, EventArgs e)
        {
            Model.getInstance().is_manual_mode = false;
            frmFrame.deleMenuClick(0);
        }

        public void InitForm()
        {
            if (!Model.getInstance().is_manual_mode)
            {
                lbl_sub_status.Text = "Enter the identification code shown in the app";
                lbl_main_status.Text = "Enter identification Code";
                tb_intput.Text = string.Empty;
            }
            else
            {
                lbl_sub_status.Text = "Enter the manual code";
                lbl_main_status.Text = "Enter the manual Code";
                tb_intput.Text = string.Empty;
            }
        }

        public void UpdateForm(Model model)
        {
            throw new NotImplementedException();
        }

        public void UpdateForm(string data)
        {
            throw new NotImplementedException();
        }

    }
}
