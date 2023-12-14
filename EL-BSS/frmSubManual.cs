using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmSubManual : Form
    {
        public frmSubManual()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        protected int mSLot_Number = 0;

        public frmSubManual(int Slot_Number) : this()
        {
            mSLot_Number = Slot_Number;
            gb_Slot.Text = mSLot_Number + "번 슬롯";
        }
        string val;
        public void updateView()
        {

            if (Model.list_SlaveRecv.Count > 0)
            {
                // 시간이 흐를때 마다 변경되는 내용을 넣어서 업데이트를 시킨다
                SOC_percent.Text = Model.list_SlaveRecv[mSLot_Number - 1].SOC.ToString() + "%";
                SOH_percent.Text = Model.list_SlaveRecv[mSLot_Number - 1].SOH.ToString() + "%";
                if (Model.list_SlaveRecv[mSLot_Number - 1].PowerPackStatus)
                {
                    Power_Pack_State.Text = "ON";
                }
                else if (!Model.list_SlaveRecv[mSLot_Number - 1].PowerPackStatus)
                {
                    Power_Pack_State.Text = "OFF";
                }

                switch (Model.list_SlaveRecv[mSLot_Number - 1].ProcessStatus.ToString())
                {

                    case "1":
                        val = "대기중";
                        break;
                    case "2":
                        val = "초기화 성공";
                        break;
                    case "3":
                        val = "충전 대기";
                        break;
                    case "10":
                        val = "Wake Up";
                        break;
                    case "11":
                        val = "통신 시작";
                        break;
                    case "100":
                        val = "충전 중";
                        break;
                    case "101":
                        val = "충전 완료";
                        break;
                    case "102":
                        val = "충전 오류";
                        break;
                    default:
                        val = "";
                        break;
                }
                Process_State.Text = val;

                Power_Pack_outvoltage.Text = ((double)Model.list_SlaveRecv[mSLot_Number - 1].PowerPackVoltage / 10).ToString();
                Power_Pack_Wattage.Text = Model.list_SlaveRecv[mSLot_Number - 1].PowerPackWattage.ToString();
                Battery_get_Voltage.Text = ((double)Model.list_SlaveRecv[mSLot_Number - 1].BatteryRequestVoltage / 10).ToString();
                Battery_get_Wattage.Text = Model.list_SlaveRecv[mSLot_Number - 1].BatteryRequestWattage.ToString();
                Battery_Current_Voltage.Text = ((double)Model.list_SlaveRecv[mSLot_Number - 1].BatteryCurrentVoltage / 10).ToString();
                Battery_Current_Wattage.Text = Model.list_SlaveRecv[mSLot_Number - 1].BatteryCurrentWattage.ToString();
                Battery_Highest_temp.Text = Model.list_SlaveRecv[mSLot_Number - 1].BatteryMaxTemper.ToString();
                Battery_Lowest_temp.Text = Model.list_SlaveRecv[mSLot_Number - 1].BatteryMinTemper.ToString();

                Bettery_Type.Text = Model.list_SlaveRecv[mSLot_Number - 1].BatteryType.ToString();

            }


        }


        private void button1_Click(object sender, EventArgs e) // door open
        {

            Model.list_SlaveSend[mSLot_Number - 1].doorOpen = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmSubManual_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)  // 출력 없음
        {
            Model.list_SlaveSend[mSLot_Number - 1].BatteryOutput = false;
            Model.list_SlaveSend[mSLot_Number - 1].Output = false;
        }

        private void button10_Click(object sender, EventArgs e) // 출력(배터리 연동)
        {
            Model.list_SlaveSend[mSLot_Number - 1].BatteryOutput = true;
            Model.list_SlaveSend[mSLot_Number - 1].Output = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Model.list_SlaveSend[mSLot_Number - 1].LED_Blue == false)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Blue = true; }
            else if (Model.list_SlaveSend[mSLot_Number - 1].LED_Blue == true)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Blue = false; }
        }

        private void button9_Click(object sender, EventArgs e) // 출력(배터리 연동 없음)
        {
            Model.list_SlaveSend[mSLot_Number - 1].BatteryOutput = false;
            Model.list_SlaveSend[mSLot_Number - 1].Output = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Model.list_SlaveSend[mSLot_Number - 1].LED_Green == false)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Green = true; }
            else if (Model.list_SlaveSend[mSLot_Number - 1].LED_Green == true)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Green = false; }
        }

        private void button8_Click(object sender, EventArgs e) // Led_red
        {
            if (Model.list_SlaveSend[mSLot_Number - 1].LED_Red == false)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Red = true; }
            else if (Model.list_SlaveSend[mSLot_Number - 1].LED_Red == true)
            { Model.list_SlaveSend[mSLot_Number - 1].LED_Red = false; }
        }

        private void DOOR_CLOSE_Button_Click(object sender, EventArgs e) // door close
        {
            Model.list_SlaveSend[mSLot_Number - 1].doorOpen = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Model.list_SlaveSend[mSLot_Number - 1].BatteryWakeup == false)
            { Model.list_SlaveSend[mSLot_Number - 1].BatteryWakeup = true; }
            else if (Model.list_SlaveSend[mSLot_Number - 1].BatteryWakeup == true)
            { Model.list_SlaveSend[mSLot_Number - 1].BatteryWakeup = false; }
        }

        public void InitForm()
        {
            throw new NotImplementedException();
        }

        public void UpdateForm(string data, Model model)
        {
            throw new NotImplementedException();
        }

        private void manual_on_Click(object sender, EventArgs e)
        {
            Model.list_SlaveSend[mSLot_Number - 1].hmiManual = true;
        }

        private void manual_off_Click(object sender, EventArgs e)
        {
            Model.list_SlaveSend[mSLot_Number - 1].hmiManual = false;
        }

        private void send_voltage_wattage_Click(object sender, EventArgs e)
        {
            Model.list_SlaveSend[mSLot_Number - 1].request_Voltage = (Convert.ToInt32(put_Battery_voltage.Text) * 10);
            Model.list_SlaveSend[mSLot_Number - 1].request_Wattage = (Convert.ToInt32(put_Battery_wattage.Text) * 10);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "VOLT" + mSLot_Number, (Convert.ToDouble(put_Battery_voltage.Text) * 10));
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "WATT" + mSLot_Number, (Convert.ToDouble(put_Battery_wattage.Text) * 10));
        }

        private void send_voltage_wattage_Click_1(object sender, EventArgs e)
        {
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "VOLT" + mSLot_Number, (Convert.ToDouble(put_Battery_voltage.Text) * 10));
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "WATT" + mSLot_Number, (Convert.ToDouble(put_Battery_wattage.Text) * 10));
        }
    }
}
