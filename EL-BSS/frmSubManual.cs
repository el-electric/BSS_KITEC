using EL_BSS.Cycle;
using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static EL_BSS.frmNotiPopup;

namespace EL_BSS
{
    public partial class frmSubManual : Form
    {
        public frmSubManual()
        {
            InitializeComponent();

            Model.getInstance().setTouchManger(this);
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

            if (Model.getInstance().list_SlaveRecv.Count > 0)
            {
                // 시간이 흐를때 마다 변경되는 내용을 넣어서 업데이트를 시킨다
                SOC_percent.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].SOC.ToString() + "%";
                SOH_percent.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].SOH.ToString() + "%";
                if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].PowerPackStatus)
                {
                    Power_Pack_State.Text = "ON";
                }
                else if (!Model.getInstance().list_SlaveRecv[mSLot_Number - 1].PowerPackStatus)
                {
                    Power_Pack_State.Text = "OFF";
                }
                ///////////////////////////////////////////////////////////////////////////////////////////
                /*switch (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].ProcessStatus.ToString())
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
                }*/

                if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].ProcessStatus == 100)
                {
                    val = "충전 중";
                }
                else if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].FET_ON_State)
                {
                    val = "FET ON";
                }
                else if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].WAKEUP_Signal == true)
                {
                    val = "Wake Up";
                }
                else if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatterArrive)
                {
                    val = "배터리 도착";
                }
                else
                {
                    val = "대기 중";
                }


                Process_State.Text = val;

                ////////////////////////////////////////////////////////////////////////////////////////////////

                Power_Pack_outvoltage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].PowerPackVoltage / 10).ToString();
                Power_Pack_Wattage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].PowerPackWattage / 10).ToString();
                Battery_get_Voltage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryRequestVoltage / 10).ToString();
                Battery_get_Wattage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryRequestWattage / 10).ToString();
                Battery_Current_Voltage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryCurrentVoltage / 10).ToString();
                Battery_Current_Wattage.Text = ((double)Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryCurrentWattage / 100).ToString();
                Battery_Highest_temp.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryMaxTemper.ToString() + " / " + Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryMinTemper.ToString();

                /*Bettery_Type.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatteryType.ToString();*/
                Bettery_Type.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].Check_BatteryVoltage_Type.ToString() + " V";

                FET_Temp.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].FET_Temper.ToString();

                lb_serial_num.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].Serial_Number.ToString();
            }


            if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].BatterArrive) lb_battery_arrive.Text = "있음";
            else lb_battery_arrive.Text = "없음";

            Slot_Temp.Text = Model.getInstance().list_SlaveRecv[mSLot_Number - 1].Battery_Slot_Temp.ToString();

            if (Model.getInstance().list_SlaveRecv[mSLot_Number - 1].SOC == 100)
            {
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryFETON = false;
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryOutput = false;
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].Output = false;
            }

        }


        private void button1_Click(object sender, EventArgs e) // door open
        {

            Model.getInstance().list_SlaveSend[mSLot_Number - 1].doorOpen = true;
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
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryOutput = false;
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].Output = false;
        }

        private async void button10_Click(object sender, EventArgs e) // 출력(배터리 연동)
        {
            bool isCharging = await Task.Run(() => CsCharging.isCharging(mSLot_Number));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Blue == false)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Blue = true; }
            else if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Blue == true)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Blue = false; }
        }

        private void button9_Click(object sender, EventArgs e) // 출력(배터리 연동 없음)
        {
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryOutput = false;
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].Output = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Green == false)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Green = true; }
            else if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Green == true)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Green = false; }
        }

        private void button8_Click(object sender, EventArgs e) // Led_red
        {
            if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Red == false)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Red = true; }
            else if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Red == true)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].LED_Red = false; }
        }

        private void DOOR_CLOSE_Button_Click(object sender, EventArgs e) // door close
        {
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].doorOpen = false;
        }

        private  async void button3_Click_1(object sender, EventArgs e)
        {
            /*if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup == false)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup = true; }
            else if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup == true)
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup = false; }*/

            if (!Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup)
            {
                bool isWakeup = await Task.Run(() => CsWakeup.isWakeUP(mSLot_Number));
                if (isWakeup)
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " WakeUP 성공", 1000 , IconName.BlueCheck.ToString());
                else
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " WakeUP 실패", 1000 , IconName.RedDanger.ToString());
            }
            else
            {
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryWakeup = false;
                Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " WakeUP 해제", 1000 , IconName.BlueNotify.ToString());
            }



        }
        private async void button1_Click_2(object sender, EventArgs e)
        {
            if (!Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryFETON)
            {
                bool isFeton = await Task.Run(() => CsWakeup.isFETon(mSLot_Number));

                if (isFeton)
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " FETON 성공", 1000 , IconName.BlueCheck.ToString());
                else
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " FETON 실패", 1000 , IconName.RedDanger.ToString());
            }
            else
            {
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].BatteryFETON = false;
                Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " FETON 해제", 1000 , IconName.BlueNotify.ToString());
            }
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
            if (!Model.getInstance().list_SlaveSend[mSLot_Number - 1].hmiManual)
            {
                Model.getInstance().list_SlaveSend[mSLot_Number - 1].hmiManual = true;
                Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " 매뉴얼 ON", 1000, IconName.BlueNotify.ToString());
            }
            else
            { Model.getInstance().list_SlaveSend[mSLot_Number - 1].hmiManual = false;
              Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " 매뉴얼 OFF", 1000 , IconName.BlueNotify.ToString());
            }
        }

        private void send_voltage_wattage_Click_1(object sender, EventArgs e)
        {
            // CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "VOLT" + mSLot_Number, (Convert.ToDouble(put_Battery_voltage.Text) * 10));
            CsUtil.IniWriteValue(Application.StartupPath + @"\Config.ini", "CONFIG", "WATT" + mSLot_Number, (Convert.ToDouble(put_Battery_curent.Text) * 10));
        }

        private void send_board_Reset_Click(object sender, EventArgs e)
        {
            Model.getInstance().list_SlaveSend[mSLot_Number - 1].boardReset = true;
        }

        private void set_Current_Click_1(object sender, EventArgs e)
        {
            if (Model.getInstance().list_SlaveSend[mSLot_Number - 1].hmiManual)
            {
                if (Convert.ToInt32(put_Battery_voltage.Text.ToString()) >= 30 && Convert.ToInt32(put_Battery_curent.Text.ToString()) >= 3)
                {
                    Model.getInstance().list_SlaveSend[mSLot_Number - 1].request_Voltage = (Convert.ToInt32(put_Battery_voltage.Text) * 10);
                    Model.getInstance().list_SlaveSend[mSLot_Number - 1].request_Wattage = (Convert.ToInt32(put_Battery_curent.Text) * 10);
                }
                else if(Convert.ToInt32(put_Battery_voltage.Text.ToString()) < 30)
                {
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " V값은 30미만이 될수없습니다.", 1000, IconName.BlueNotify.ToString());
                }
                else if (Convert.ToInt32(put_Battery_curent.Text.ToString()) < 3)
                {
                    Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " A값은 3미만이 될수없습니다.", 1000, IconName.BlueNotify.ToString());
                }
            }
            else 
            {
                Model.getInstance().frmFrame.NotiShow("Slot : " + mSLot_Number + " 전압과 전류는 매뉴얼중에서 설정할수 있습니다.", 1000, IconName.BlueNotify.ToString());
            }
        }
    }
}
