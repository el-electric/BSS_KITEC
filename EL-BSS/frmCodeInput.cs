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
            if (tb_intput.Text.Length < 10)
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
            if (lbl_sub_status.Text == "앱에 표시된 4자리 식별코드를 입력하세요")
            {
                if (tb_intput.Text.Length == 4)
                {
                    identificationCode = tb_intput.Text;
                    tb_intput.Text = string.Empty;

                    lbl_sub_status.Text = "앱에 표시된 4자리 보안코드를 입력하세요";
                }
            }
            else
            {
                if (tb_intput.Text.Length == 4)
                {
                    securityCode = tb_intput.Text;
                    lbl_sub_status.Text = "인증코드 전송";


                    btn_enter.Enabled = false;
                    string response = await Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_Authorize(identificationCode , securityCode);
                    btn_enter.Enabled = true;

                    if (response == null)
                    {
                        lbl_sub_status.Text = "서버 응답 없음";
                        return;
                    }
                    // JArray responseObject = null;
                    // JArray jsonArray = JArray.Parse(_packet);
                    try
                    {
                        JArray responseObject = JArray.Parse(response);
                        Model.getInstance().Authorize = JsonConvert.DeserializeObject<Req_Authorize>(responseObject[2].ToString());
                        Model.getInstance().Authorize.setting_Authorize_value();
                        string errCode = responseObject?[2]?["errCode"]?.ToString();
                        string errMsg = responseObject?[2]?["errMsg"]?.ToString();

                        switch (errCode) 
                        {
                            case "00000":
                                lbl_sub_status.Text = "인증 성공";
                                Model.getInstance().Authorize_Type = enumData.STATION.ToString();

                                CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_MAIN;
                                break;
                            default:
                                lbl_sub_status.Text = "인증 실패: " + errMsg;
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

        private void drakeUIButtonIcon1_Click_1(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(0);
        }

        public void InitForm()
        {
            lbl_sub_status.Text = "앱에 표시된 4자리 식별코드를 입력하세요";
            tb_intput.Text = string.Empty;
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
