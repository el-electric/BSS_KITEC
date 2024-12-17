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
            if (tb_intput.Text.Length < 4)
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
                    lbl_main_status.Text = "보안 코드 입력";
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

                    if (response == null || response == "TIMEOUT")
                    {
                        lbl_sub_status.Text = "서버 응답 없음";
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
                                lbl_sub_status.Text = "인증 성공";

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
            lbl_main_status.Text = "식별 코드 입력";
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

        private async void button1_Click(object sender, EventArgs e)
        {
            int[] retur = new int[2] { 1, 2 };
            int[] retri = new int[2] { 3, 4 };
            string res = await Model.getInstance().oCPP_Comm_SendMgr.Send_OCPP_CP_Req_DataTransfer_battery_exchange(retur, retri);

            switch (res)
            {
                case "00000":
                    frmFrame.deleMenuClick(5, "배터리 인증 성공");
                    // JumpStep(CsDefine.CYC_MAIN + 7);
                    break;
                case "11101":
                    frmFrame.deleMenuClick(5, "배터리를 찾을 수 없습니다.");
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    frmFrame.deleMenuClick(0);
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    break;
                case "11102":
                    frmFrame.deleMenuClick(5, "배터리 세트를 찾을 수 없습니다.");
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    frmFrame.deleMenuClick(0);
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    break;
                case "10002":
                    frmFrame.deleMenuClick(5, "이용자가 없습니다.");
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    frmFrame.deleMenuClick(0);
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    break;
                case "12102":
                    frmFrame.deleMenuClick(5, "스테이션이 존재하지 않습니다.");
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    frmFrame.deleMenuClick(0);
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    break;
                default:
                    frmFrame.deleMenuClick(5, "없는 애러코드");
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[0] - 1].doorOpen = true;
                    Model.getInstance().list_SlaveSend[getInstance().Lent_slot[1] - 1].doorOpen = true;
                    frmFrame.deleMenuClick(0);
                    CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_INIT;
                    break;
            }

        }
    }
}
