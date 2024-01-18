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
using static EL_BSS.Model;

namespace EL_BSS
{
    public partial class frmFrame : Form, IObserver
    {


        public delegate void ClickEvent(int idx);
        public static event ClickEvent MenuClick;
        private bool ThreadRun = true;


        private List<IObserver> _observers = new List<IObserver>();
        private Model.SlaveSend slaveSend;
        private Model model = new Model();
        frmMain frmMain = new frmMain();
        frmManual frmManual = new frmManual();
        FWupdate FWupdate = new FWupdate();

        public frmFrame()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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



        private void frmFrame_Load(object sender, EventArgs e)
        {
            initForm();
            viewForm(0);

            for (int i = 0; i < model.slaveCount; i++)
            {
                list_MasterSend.Add(new MasterSend());
                list_MasterRecv.Add(new MasterRecv());
                list_SlaveSend.Add(new SlaveSend(int.Parse(CsUtil.IniReadValue(model.DefaultPath, "CONFIG", "VOLT" + i + 1, "0")), int.Parse(CsUtil.IniReadValue(model.DefaultPath, "CONFIG", "WATT" + i + 1, "0"))));
                list_SlaveRecv.Add(new SlaveRecv());
                list_SlaveDataRecvDatetime.Add(new DateTime());
                list_MasterDataRecvDatetime.Add(new DateTime());
            }


            if (!sp_Master.Open(Master_PortName))
                MessageBox.Show("마스터 포트 오픈 실패");
            if (!sp_Slave.Open(Model.Slave_PortName))
                MessageBox.Show("슬레이브 포트 오픈 실패");
        }

        public static void deleMenuClick(int idx)
        {
            MenuClick(idx);
        }
        private void FrmFrame_MenuClick(int idx)
        {
            viewForm(idx);
        }

        private void initForm()
        {
            model.frmFrame = this;

            if (!bck_Protocol.IsBusy)
                bck_Protocol.RunWorkerAsync();

            if (!bck_Sequnce.IsBusy)
                bck_Sequnce.RunWorkerAsync();

            MenuClick += FrmFrame_MenuClick;

            _observers.Add(frmMain);
            _observers.Add(frmManual);
            _observers.Add(FWupdate);

            frmMain.TopLevel = false;
            frmManual.TopLevel = false;
            FWupdate.TopLevel = false;
            frmMain.Show();
            frmManual.Show();
            FWupdate.Show();

            foreach (IObserver observer in _observers)
            {
                observer.InitForm();
            }
        }

        public async void viewForm(int idx)
        {
            panel2.Controls.Clear();
            frmManual.timer1.Enabled = false;
            frmMain.timer1.Enabled = false;
            FWupdate.timer1.Enabled = false;
            if (list_SlaveSend.Count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Model.list_SlaveSend[i].hmiManual = false;
                }
            }
            switch (idx)
            {
                case 0:
                    frmMain.timer1.Enabled = true;
                    panel2.Controls.Add(frmMain);
                    break;
                case 1:
                    frmManual.timer1.Enabled = true;
                    panel2.Controls.Add(frmManual);
                    break;
                case 2:
                    FWupdate.timer1.Enabled = true;
                    panel2.Controls.Add(FWupdate);
                    break;
                case 10:

                    ThreadRun = false;
                    await Task.Delay(500);
                    try
                    {
                        sp_Master.Close();
                        sp_Slave.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.InnerException);
                    }
                    Application.Exit();
                    break;
            }
        }

        private void ui_timer_500ms_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString();
        }
        int masterIdx = 1;
        int slaveIdx = 1;
        private void bck_Protocol_DoWork(object sender, DoWorkEventArgs e)
        {
            while (ThreadRun)
            {
                if (masterFirmwareUpdate)  // 파일을 선택하고 나면
                {
                    switch (masterFirmwareUpdate_step)
                    {
                        case 0:
                            Model.masterFirmWareisAck = false; //성공함
                            Model.masterFirmWareisNck = false; // 실패함

                            Model.makeFirmwareupdate(Model.PWUpdate_MasterID, Model.PWUpdate_SlaveID);  // 마스터 보드에 패킷을 쏘는것도 포함
                            masterFirmwareUpdate_step++;
                            break;
                        case 1:

                            if (masterFirmWareisAck)
                                masterFirmwareUpdate_step = 0;
                            else if (masterFirmWareisNck)
                            {
                                masterFirmwareUpdate = false;
                            }
                            break;
                        case 2:
                            if (Model.PWUpdate_SlaveID > 0)   // 업데이트 할 보드가 master인지 slave 인지 구분
                            {
                                Model.list_SlaveSend[Model.PWUpdate_SlaveID - 1].boardReset = true;// 업데이트 하기전 슬래이브 보드를 한번 리셋시켜준다
                                byte[] bytes = model.makeSlavePacket(Model.PWUpdate_SlaveID);
                                sp_Slave.Write(bytes);
                                Thread.Sleep(3000);
                            }
                            else
                            {
                                Model.list_MasterSend[Model.PWUpdate_MasterID - 1].boardReset = true;  // 업데이트 하기전 마스터 보드를 한번 리셋시켜준다  
                                byte[] bytes = model.makeMaserPacket(Model.PWUpdate_MasterID);
                                sp_Master.Write(bytes);
                                Thread.Sleep(3000);
                            }
                            masterFirmwareUpdate_step = 0;
                            break;
                        case 3:
                            Model.makeFirmwareF0(Model.PWUpdate_MasterID, Model.PWUpdate_SlaveID);
                            if (Model.masterFirmware_f0)
                            {
                                Model.masterFirmware_f0 = false;
                                masterFirmwareUpdate_step = 0;
                            }
                            break;
                    }
                }
                else  // 펌웨어 업데이트 하면 정상 패킷을 보내는걸 중지
                {
                    if (isOpen_Master)
                    {
                        byte[] bytes = model.makeMaserPacket(masterIdx++);
                        sp_Master.Write(bytes);
                        if (masterIdx > model.masterCount)
                        {
                            masterIdx = 1;
                        }
                    }
                    if (isOpen_Slave)
                    {
                        byte[] bytes = model.makeSlavePacket(slaveIdx++);
                        sp_Slave.Write(bytes);
                        if (slaveIdx > model.slaveCount)
                        {
                            slaveIdx = 1;
                        }
                    }

                }


                if (slaveFirmwareUpdate)
                {

                }


                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] a = model.makeSlavePacket(1);

            sp_Slave.Write(a);
        }

        public void InitForm()
        {

        }

        public void UpdateForm(Model model)
        {

        }

        private void lbl_time_DoubleClick(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(1);
        }


        int step = 0;
        int Door_Opened_Slot = 0;
        int Highest_Battery_SOC_Slot = 0;
        int max_soc;
        bool find_100SOC_Battery = false;
        DateTime minute2;
        private async void bck_Sequnce_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (step)
            {
                case 0:
                    if (Model.Start_Return_Button)
                    {
                        Model.dt_First_ClickStartButton_Time = DateTime.Now;
                        step = 1;
                        Model.Start_Return_Button = false;
                    }
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case 1:
                    max_soc = 0;
                    if (Model.dt_First_ClickStartButton_Time.Value.AddMinutes(3) <= DateTime.Now)
                    {
                        lbl_Notify_Tv.Text = "3분간 활동이 없어 처음으로 돌아갑니다.";
                        await Task.Delay(3000);
                        step = 0;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        if (Model.list_SlaveRecv[i].SOC == 0 && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time != null && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time.Value.AddMinutes(5) <= DateTime.Now)  //널 허용 개체는 값이 있어야 합니다
                        {
                            find_100SOC_Battery = true;
                            step = 2;
                            break;
                        }
                    }
                    if (!find_100SOC_Battery)
                    {
                        for (int i = 4; i < 8; i++)
                        {
                            if (Model.list_SlaveRecv[i].SOC > max_soc)
                            {
                                max_soc = Model.list_SlaveRecv[i].SOC;
                                Highest_Battery_SOC_Slot = i;
                            }
                        }

                        if (max_soc >= 55)  // SOC가 가장 높은 슬롯의 배터리가 80%가 넘는지
                        {
                            step = 2;
                        }
                        else  // 80%를 못넘는다면
                        {
                            lbl_Notify_Tv.Text = "모든 슬롯의 배터리의 충전량이 적어 사용이 불가합니다.";
                            await Task.Delay(1000);
                            lbl_Notify_Tv.Text = "";
                            step = 0;
                        }
                    }
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////
                case 2:
                    Door_Opened_Slot = 0;
                    lbl_Notify_Tv.Text = "문이 열린 슬롯에 배터리를 집어넣어주세요.";
                    for (int i = 4; i < 8; i++)  // 배터리가 없는 슬롯을 찾음
                    {
                        if (!Model.list_SlaveRecv[i].BatterArrive)
                        {
                            Model.list_SlaveSend[i].doorOpen = true;
                            await Task.Delay(1000);
                            Door_Opened_Slot = i;
                            step = 3;
                            break;
                        }
                    }
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////                        
                case 3:
                    if (Model.list_SlaveRecv[Door_Opened_Slot].BatterArrive) // 연 슬롯에서 배터리 안착 신호가 들어온다면
                    {
                        lbl_Notify_Tv.Text = "배터리를 집어넣은 슬롯의 문을 닫아주세요.";
                        step = 4;
                    }
                    else
                    {
                        lbl_Notify_Tv.Text = "문이 열린 슬롯에 배터리를 집어넣어주세요.";
                    }
                    if (!Model.list_SlaveRecv[Door_Opened_Slot].isDoor)
                    {
                        if (Model.list_SlaveRecv[Door_Opened_Slot].BatteryCurrentWattage < 3 || !Model.list_SlaveRecv[Door_Opened_Slot].BatterArrive) // 슬롯에 배터리가 들어가지 않았는데 문을 닫는다면
                        {
                            Model.list_SlaveSend[Door_Opened_Slot].doorOpen = true;
                            lbl_Notify_Tv.Text = "배터리가 잘 안착이 되어있는지 확인해주세요.";
                        }
                    }

                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////
                case 4:
                    if (!Model.list_SlaveRecv[Door_Opened_Slot].isDoor)
                    {
                        if (!Model.list_SlaveRecv[Door_Opened_Slot].BatterArrive) // 슬롯에 배터리가 들어가지 않았는데 문을 닫는다면
                        {
                            Model.list_SlaveSend[Door_Opened_Slot].doorOpen = true;
                            lbl_Notify_Tv.Text = "배터리가 잘 안착이 되어있는지 확인해주세요.";
                        }
                        else if (Model.list_SlaveRecv[Door_Opened_Slot].BatterArrive)
                        {
                            lbl_Notify_Tv.Text = "배터리 인식중입니다.";
                            minute2 = DateTime.Now;
                            step = 5;
                        }
                    }
                    break;


                case 5:
                    if (Model.list_SlaveRecv[Door_Opened_Slot].BatteryCurrentWattage > 3)
                    {
                        lbl_Notify_Tv.Text = "배터리가 충전됩니다.";
                        await Task.Delay(1000);
                        lbl_Notify_Tv.Text = "문이 열린 슬롯의 배터리를 꺼내주세요.";
                        step = 6;
                    }
                    else if (Model.list_SlaveRecv[Door_Opened_Slot].BatteryCurrentWattage < 3 && DateTime.Now >= minute2.AddSeconds(30))
                    {
                        Model.list_SlaveSend[Door_Opened_Slot].doorOpen = true;
                        await Task.Delay(1000);
                        lbl_Notify_Tv.Text = "배터리가 잘 안착이 되어있는지 확인해주세요.";
                        step = 4;
                    }
                    break;



                /////////////////////////////////////////////////////////////////////////////////////////////////
                case 6:  // 슬롯중 배터리의 SOC가 가장 높은 슬롯을 찾는다.
                    /* for (int i = 0; i < 8; i++)
                    {
                        if (Model.list_SlaveRecv[Door_Opened_Slot].Check_BatteryVoltage_Type == Model.list_SlaveRecv[i].Check_BatteryVoltage_Type)
                        {
                            find_SameType_Battery = true;
                        }
                    }

                    if (find_SameType_Battery)
                    { */
                    if (Model.list_SlaveRecv[Door_Opened_Slot].Check_BatteryVoltage_Type == " 72V")
                    {
                        max_soc = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            if (Model.list_SlaveRecv[i].Check_BatteryVoltage_Type == " 72V" && Model.list_SlaveRecv[i].SOC == 0 && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time != null && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time.Value.AddMinutes(5) >= DateTime.Now)  //널 허용 개체는 값이 있어야 합니다
                            {
                                Model.list_SlaveSend[i].doorOpen = true;
                                find_100SOC_Battery = true;
                                step = 7;
                                break;
                            }
                        }
                        if (!find_100SOC_Battery)
                        {
                            for (int i = 4; i < 8; i++)
                            {
                                if (Model.list_SlaveRecv[i].SOC > max_soc && Model.list_SlaveRecv[i].Check_BatteryVoltage_Type == " 72V")
                                {
                                    max_soc = Model.list_SlaveRecv[i].SOC;
                                    Highest_Battery_SOC_Slot = i;
                                }
                            }

                            Model.list_SlaveSend[Highest_Battery_SOC_Slot].doorOpen = true;
                            await Task.Delay(1000);
                            step = 7;
                        }
                    }
                    else if (Model.list_SlaveRecv[Door_Opened_Slot].Check_BatteryVoltage_Type == " 48V")
                    {
                        max_soc = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            if (Model.list_SlaveRecv[i].Check_BatteryVoltage_Type == " 48V" && Model.list_SlaveRecv[i].SOC == 0 && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time != null && Model.list_SlaveRecv[i].dt_First_BatterArrive_Time.Value.AddMinutes(5) >= DateTime.Now)  //널 허용 개체는 값이 있어야 합니다
                            {
                                Model.list_SlaveSend[i].doorOpen = true;
                                find_100SOC_Battery = true;
                                step = 7;
                                break;
                            }
                        }
                        if (!find_100SOC_Battery)
                        {
                            for (int i = 4; i < 8; i++)
                            {
                                if (Model.list_SlaveRecv[i].SOC > max_soc && Model.list_SlaveRecv[i].Check_BatteryVoltage_Type == " 48V")
                                {
                                    max_soc = Model.list_SlaveRecv[i].SOC;
                                    Highest_Battery_SOC_Slot = i;
                                }
                            }

                            Model.list_SlaveSend[Highest_Battery_SOC_Slot].doorOpen = true;
                            await Task.Delay(1000);
                            step = 7;

                        }
                    }
                    /* }
                     else if (!find_SameType_Battery)
                    {
                        lbl_Notify_Tv.Text = "같은 타입의 배터리가 없습니다.";
                        await Task.Delay(2000);
                        step = 0;
                    } */
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////
                case 7:
                    if (!Model.list_SlaveRecv[Highest_Battery_SOC_Slot].BatterArrive)
                    {
                        lbl_Notify_Tv.Text = "슬롯의 문을 닫아주세요.";
                        step = 8;
                    }
                    else if (Model.list_SlaveRecv[Highest_Battery_SOC_Slot].BatterArrive && !Model.list_SlaveRecv[Highest_Battery_SOC_Slot].isDoor)
                    {
                        Model.list_SlaveSend[Highest_Battery_SOC_Slot].doorOpen = true;
                        lbl_Notify_Tv.Text = "슬롯의 배터리를 가져가고 문을 닫아주세요.";
                    }
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////////////
                case 8:
                    if (!Model.list_SlaveRecv[Highest_Battery_SOC_Slot].isDoor)
                    {
                        lbl_Notify_Tv.Text = "이용해 주셔서 감사합니다.";
                        await Task.Delay(1000);
                        Model.dt_First_ClickStartButton_Time = null;
                        lbl_Notify_Tv.Text = "";
                        step = 0;
                    }
                    break;
            }

            Thread.Sleep(1);

        }
    }
}



