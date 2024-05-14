﻿using DrakeUI.Framework;
using EL_BSS.Cycle;
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

        public List<IObserver> observers = new List<IObserver>();
        private Model.SlaveSend slaveSend;

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

            for (int i = 0; i < Model.getInstance().slaveCount; i++)
            {
                Model.getInstance().list_MasterSend.Add(new MasterSend());
                Model.getInstance().list_MasterRecv.Add(new MasterRecv());
                Model.getInstance().list_SlaveSend.Add(new SlaveSend(int.Parse(CsUtil.IniReadValue(getInstance().DefaultPath, "CONFIG", "VOLT" + i + 1, "0")), int.Parse(CsUtil.IniReadValue(getInstance().DefaultPath, "CONFIG", "WATT" + i + 1, "0"))));
                Model.getInstance().list_SlaveRecv.Add(new SlaveRecv());
                Model.getInstance().list_SlaveDataRecvDatetime.Add(new DateTime());
                Model.getInstance().list_MasterDataRecvDatetime.Add(new DateTime());
            }


            //if (!sp_Master.Open(Master_PortName))
            //    MessageBox.Show("마스터 포트 오픈 실패");
            //if (!sp_Slave.Open(Model.Slave_PortName))
            //    MessageBox.Show("슬레이브 포트 오픈 실패");

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
            getInstance().frmFrame = this;

            if (!bck_Protocol.IsBusy)
                bck_Protocol.RunWorkerAsync();

            if (!bck_Sequnce.IsBusy)
                bck_Sequnce.RunWorkerAsync();

            if (!bck_Counting.IsBusy)
                bck_Counting.RunWorkerAsync();

            MenuClick += FrmFrame_MenuClick;

            observers.Add(this);
            observers.Add(frmMain);
            observers.Add(frmManual);
            observers.Add(FWupdate);

            frmMain.TopLevel = false;
            frmManual.TopLevel = false;
            FWupdate.TopLevel = false;
            frmMain.Show();
            frmManual.Show();
            FWupdate.Show();

            foreach (IObserver observer in observers)
            {
                observer.InitForm();
            }
        }

        public async void viewForm(int idx)
        {
            panel2.Controls.Clear();
            //frmManual.timer1.Enabled = false;
            frmManual.timer.Stop();
            frmMain.timer1.Enabled = false;
            FWupdate.timer1.Enabled = false;
            if (Model.getInstance().list_SlaveSend.Count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Model.getInstance().list_SlaveSend[i].hmiManual = false;
                }
            }
            switch (idx)
            {
                case 0:
                    frmMain.timer1.Enabled = true;
                    panel2.Controls.Add(frmMain);
                    break;
                case 1:
                    frmManual.timer.Start();
                    //frmManual.timer1.Enabled = true;
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
                if (getInstance().FirmwareUpdate)  // 파일을 선택하고 나면
                {
                    switch (getInstance().FirmwareUpdate_step)
                    {
                        case 0: // 처음에 업데이트 버튼을 누르면                            
                            getInstance().FirmWareisNck_Count = 0;
                            if (Model.getInstance().PWUpdate_SlaveID > 0)   // 업데이트 할 보드가 master인지 slave 인지 구분
                            {
                                Model.getInstance().list_SlaveSend[Model.getInstance().PWUpdate_SlaveID - 1].boardReset = true;// 업데이트 하기전 슬래이브 보드를 한번 리셋시켜준다
                                byte[] bytes = getInstance().makeSlavePacket(Model.getInstance().PWUpdate_SlaveID);
                                sp_Slave.Write(bytes);
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                Model.getInstance().list_MasterSend[Model.getInstance().PWUpdate_MasterID - 1].boardReset = true;  // 업데이트 하기전 마스터 보드를 한번 리셋시켜준다  
                                byte[] bytes = getInstance().makeMaserPacket(Model.getInstance().PWUpdate_MasterID);
                                sp_Master.Write(bytes);
                                Thread.Sleep(2000);
                            }

                            getInstance().FirmwareUpdate_step = 1;
                            break;

                        case 1:  // 업데이트 패킷을 보내고 
                            Model.getInstance().FirmWareisAck = false; //성공함
                            Model.getInstance().FirmWareisNak = false; // 실패함

                            if (Model.getInstance().f0_OR_f1Update_OR_f1Jump == 1)
                            {
                                Model.makeFirmwareF0(Model.getInstance().PWUpdate_MasterID, Model.getInstance().PWUpdate_SlaveID);  // 마스터 보드에 패킷을 쏘는것도 포함
                            }
                            else if (Model.getInstance().f0_OR_f1Update_OR_f1Jump == 2)
                            {
                                Model.makeFirmwareupdate(Model.getInstance().PWUpdate_MasterID, Model.getInstance().PWUpdate_SlaveID);  // 마스터 보드에 패킷을 쏘는것도 포함
                                Model.getInstance().Send_FWUpdate_Packet_Time = DateTime.Now;
                                getInstance().FirmwareUpdate_step = 2;
                            }
                            else if (Model.getInstance().f0_OR_f1Update_OR_f1Jump == 3)
                            {
                                Model.makeFirmwaref1_without_Binary(Model.getInstance().PWUpdate_MasterID, Model.getInstance().PWUpdate_SlaveID, Model.getInstance().Jump_APP);
                                getInstance().FirmwareUpdate_step = 3;
                            }
                            break;

                        case 2:  // 보드에서 업데이트가 되었는지 확인
                            if (getInstance().FirmWareisAck)   // 업데이트 성공하였다고 받았다면
                            {
                                getInstance().FirmwareUpdate_step = 1;
                            }
                            else if (getInstance().FirmWareisNak)  // 업데이트가 실패하였다고 받았다면
                            {
                                if (getInstance().FirmWareisNck_Count < 3)  // 업데이트를 3번 미만 실패하였다면
                                {
                                    getInstance().binBufferCount = 0;
                                    getInstance().FirmWareisNck_Count++;  // 카운트를 센다
                                    getInstance().FirmwareUpdate_step = 1;
                                    getInstance().FirmwareUpdate = true;
                                }
                                else if (getInstance().FirmWareisNck_Count == 3) // 업데이트가 3번 실패하였다면
                                {
                                    Model.getInstance().Jump_APP = (Model.getInstance().Jump_APP == 1) ? 2 : 1;  // 만약 Jump_APP가 1인 조건의 참이면 2로 아니면 1로

                                    Model.getInstance().f0_OR_f1Update_OR_f1Jump = 3; // 점프를 시킨다
                                    getInstance().FirmwareUpdate_step = 1;
                                }
                            }

                            if (getInstance().Send_FWUpdate_Packet_Time != null && getInstance().Send_FWUpdate_Packet_Time.Value.AddSeconds(2) < DateTime.Now && getInstance().binBufferCount != 0)
                            {
                                getInstance().binBufferCount--;
                                getInstance().FirmwareUpdate_step = 1;
                            }

                            break;

                        case 3:  // 점프용 f1패킷
                            if (Model.getInstance().PWUpdate_Jump_Flag == 1 || Model.getInstance().PWUpdate_Jump_Flag == 2)  //첨프용 f1패킷의 답장을 받으면 1 = 점프 성공 2 = 점프 실패 
                            {
                                getInstance().FirmwareUpdate = false;
                            }
                            break;
                    }
                }
                else  // 펌웨어 업데이트 하면 정상 패킷을 보내는걸 중지
                {
                    if (getInstance().isOpen_Master)
                    {
                        byte[] bytes = getInstance().makeMaserPacket(masterIdx++);
                        sp_Master.Write(bytes);
                        if (masterIdx > getInstance().masterCount)
                        {
                            masterIdx = 1;
                        }
                    }
                    if (getInstance().isOpen_Slave)
                    {
                        byte[] bytes = getInstance().makeSlavePacket(slaveIdx++);
                        sp_Slave.Write(bytes);
                        if (slaveIdx > getInstance().slaveCount)
                        {
                            slaveIdx = 1;
                        }
                    }

                }

                Thread.Sleep(50);
            }
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
            while (true)
            {
                CsWork.Main_WorkCycle();
                //CsFirmwareUpdate.Main_WorkCycle();
                Thread.Sleep(1);
            }
        }

        
        private void bck_Counting_DoWork(object sender, DoWorkEventArgs e)
        {
            
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (CsDefine.Delayed[i] == 0)
                    {
                        CsDefine.dt_beforeDealy[i] = DateTime.Now;
                        CsDefine.Delayed[i] = 1;
                    }
                    else
                    {
                        if (CsDefine.Delayed[i] < 999999999)
                        {
                            CsDefine.Delayed[i] = (int)(DateTime.Now - CsDefine.dt_beforeDealy[i]).TotalMilliseconds;
                        }
                    }

                    if (CsDefine.Counted[i] == 0)
                    {
                        CsDefine.dt_beforeCount[i] = DateTime.Now;
                        CsDefine.Counted[i] = 1;
                    }
                    else
                    {
                        if (CsDefine.Counted[i] < 999999999)
                        {
                            CsDefine.Counted[i] = (int)(DateTime.Now - CsDefine.dt_beforeCount[i]).TotalMilliseconds;
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void UpdateForm(string data)
        {
            lbl_Notify_Tv.Text = data;
        }
    }
}



