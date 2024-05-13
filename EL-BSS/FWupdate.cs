using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using EL_BSS.Serial;
using DrakeUI.Framework;

namespace EL_BSS
{
    public partial class FWupdate : Form, IObserver
    {
        public bool APP1_Exist = false;
        public bool APP2_Exist = false;

        public FWupdate()
        {
            InitializeComponent();

        }
        public void InitForm()
        {

        }
        public void UpdateForm(Model model)
        {
            notify_table_layout.Visible = false;
        }

        public void updateform()
        {
            FW_Update_Progress.Text = Model.binBufferCount.ToString() + " / " + Model.binFileBuffer.Count;   // 업데이트 값 
            FW_Update_Progress_Bar.Value = Model.binBufferCount;  // process bar 값 확인
            Receive_Send_Flag.Text = Model.PWUpdate_Send_Flag.ToString();  // 전송 플래그 확인

            if (Model.PWUpdate_Send_Flag == 1 || Model.PWUpdate_Send_Flag == 2)   // 업데이트 성공 유무 확인
            {
                string temp = "없음";

                if (Model.FirmWareisNck_Count== 3)
                {
                    temp = "실패";
                }
                else if (Model.PWUpdate_Send_Flag == 2)
                {
                    temp = "성공";
                }
                

                Model.PWUpdate_Send_Flag = 0;
                Model.FirmWareisNck_Count = 0;

                this.Invoke(new MethodInvoker(delegate ()
                {
                    show_Notify("업데이트 " + temp);
                }));
            }

            Boot_Version_Text.Text = Model.boot_Version_Major.ToString() + "." + Model.boot_Version_Minor.ToString() + "." + Model.boot_Version_Patch.ToString();  //f0 패킷 보내고 값 확인
            if (Model.app1_Version_Major == 255 && Model.app1_Version_Minor == 255 && Model.app1_Version_Patch == 255)
            {
                APP1_Exist = false;
                APP1_Version_Text.Text = "없음";
            }
            else
            {
                APP1_Exist = true;
                APP1_Version_Text.Text = Model.app1_Version_Major.ToString() + "." + Model.app1_Version_Minor.ToString() + "." + Model.app1_Version_Patch.ToString();
            }

            if (Model.app2_Version_Major == 255 && Model.app2_Version_Minor == 255 && Model.app2_Version_Patch == 255)
            {
                APP2_Exist = false;
                APP2_Version_Text.Text = "없음";
            }
            else
            {
                APP2_Exist = true;
                APP2_Version_Text.Text = Model.app2_Version_Major.ToString() + "." + Model.app2_Version_Minor.ToString() + "." + Model.app2_Version_Patch.ToString();
            }


            if (Model.PWUpdate_Jump_Flag == 1 || Model.PWUpdate_Jump_Flag == 2)  // 점프 확인
            {
                string temp = "없음";

                if (Model.PWUpdate_Jump_Flag == 1)
                { 
                    temp = "성공"; 
                }
                else if (Model.PWUpdate_Jump_Flag == 2)
                {
                    temp = "실패"; 
                }

                Model.PWUpdate_Jump_Flag = 0;

                this.Invoke(new MethodInvoker(delegate ()
                {
                    show_Notify("주소 점프 " + temp);
                }));
            }

        }

        private async void Select_File_Click(object sender, EventArgs e)
        {
            Model.FirmwareUpdate_step = 0;

            Model.binBufferCount = 0;
            Model.binFileBuffer.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "펌웨어 업데이트";
            ofd.FileName = "";
            ofd.Filter = "bin파일 (*.bin) | *.bin; | 모든 파일 (*.*) | *.*";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;
                Model.PWUpdate_New_Version_Major = Convert.ToInt32(fileFullName.Substring(fileFullName.Length - 9, 1));
                Model.PWUpdate_New_Version_Minor = Convert.ToInt32(fileFullName.Substring(fileFullName.Length - 7, 1));
                Model.PWUpdate_New_Version_Patch = Convert.ToInt32(fileFullName.Substring(fileFullName.Length - 5, 1));


                Model.binFile = File.ReadAllBytes(fileFullName);

                Console.WriteLine($"Read {Model.binFile.Length} bytes");
                //string hexString = BitConverter.ToString(fileData).Replace("-", " ");                


                int chunkSize = 200;
                for (int i = 0; i < Model.binFile.Length; i += chunkSize)
                {
                    // 현재 위치에서부터 chunkSize만큼 또는 배열의 끝까지의 길이를 계산
                    int length = Math.Min(chunkSize, Model.binFile.Length - i);
                    byte[] chunk = new byte[length];
                    Array.Copy(Model.binFile, i, chunk, 0, length);
                    Model.binFileBuffer.Add(chunk);
                }

                await Task.Delay(500);

                /* Model.masterFirmwareUpdate = true;*/

                FW_Update_Progress_Bar.Maximum = Convert.ToInt32(Model.binFileBuffer.Count);
            }
        }

        private void Update_FW_Click(object sender, EventArgs e)
        {
            if (Setting_Master_Id_CB.Text == "MASTER" || Setting_Slave_Id_CB.Text == "SLAVE")
            {
                show_Notify("마스터 아이디와 슬래이브 아이디를 입력하여 주세요");
            }
            else
            {
                Model.f0_OR_f1Update_OR_f1Jump = 2;
                Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
                Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);
                Model.Jump_APP = Convert.ToInt32(Jump_APP_CB_Box.Text);
                Model.FirmwareUpdate = true;
                Model.FirmwareUpdate_step = 0;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => updateform());
        }

        private void Back_To_Main_Click(object sender, EventArgs e)
        {
            Model.FirmwareUpdate = false;
            frmFrame.deleMenuClick(0);
        }

        private void Send_f0_start_Click(object sender, EventArgs e)
        {
            if (Setting_Master_Id_CB.Text == "MASTER" || Setting_Slave_Id_CB.Text == "SLAVE")
            {
                show_Notify("마스터 아이디와 슬래이브 아이디를 입력하여 주세요");
            }
            else
            {
                Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
                Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);
                Model.FirmwareUpdate = true;
                Model.FirmwareUpdate_step = 0;
                Model.f0_OR_f1Update_OR_f1Jump = 1;
            }
        }

        private void test_2_button_Click(object sender, EventArgs e)
        {
            notify_table_layout.Visible = false;
        }
        public void show_Notify(string message)
        {
            notify_message.Text = message;
            notify_table_layout.Visible = true;
            notify_table_layout.Location = new Point(194, 130);
            notify_table_layout.BringToFront();
        }

        private void Auto_Update_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto_Update_CheckBox.Checked)
                Model.Auto_Update = true;
            else
                Model.Auto_Update = false;
        }

        private void Test_popup_Click(object sender, EventArgs e)
        {
            //frmPopup frm = new frmPopup();

 

        }

        private void Jump_Packet_Button_Click(object sender, EventArgs e)
        {
            if (Setting_Master_Id_CB.Text == "MASTER" || Setting_Slave_Id_CB.Text == "SLAVE")
            {
                show_Notify("마스터 아이디와 슬래이브 아이디를 입력하여 주세요");
            }
            else
            {
                Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
                Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);
                Model.Jump_APP = Convert.ToInt32(cb_jumpid.Text);

                if (Model.Jump_APP == 1 && APP1_Exist == true)
                {
                    Model.FirmwareUpdate = true;
                    Model.FirmwareUpdate_step = 0;
                    Model.f0_OR_f1Update_OR_f1Jump = 3;
                }
                else if (Model.Jump_APP == 2 && APP2_Exist == true)
                {
                    Model.FirmwareUpdate = true;
                    Model.FirmwareUpdate_step = 0;
                    Model.f0_OR_f1Update_OR_f1Jump = 3;
                }
                else
                {
                    show_Notify("해당주소에는 프로그램이 없어 점프할수 없습니다");
                }
            }
            // Model.makeFirmwaref1_without_Binary(int.Parse(Setting_Master_Id_CB.Text), int.Parse(Setting_Slave_Id_CB.Text), int.Parse(cb_jumpid.Text));
        }

        public void Show_Update_State(int master , int slave , int send_flag)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (slave < 0)
                {
                    foreach (Control control in tableLayoutPanel1.Controls)
                    {
                        if (control.Name == "Master_" + master)
                        {
                            if (send_flag == 1)
                                ((DrakeUILabel)control).Text = "진행중";
                            else if (send_flag == 2)
                                ((DrakeUILabel)control).Text = "완료";
                            else if(send_flag == 3)
                                ((DrakeUILabel)control).Text = "실패";
                            break;
                        }
                    }
                }
                else if (slave > 0)
                {
                    foreach (Control control in tableLayoutPanel1.Controls)
                    {
                        if (control.Name == "Slave_" + slave)
                        {
                            if (send_flag == 1)
                                ((DrakeUILabel)control).Text = "진행중";
                            else if (send_flag == 2)
                                ((DrakeUILabel)control).Text = "완료";
                            else if (send_flag == 3)
                                ((DrakeUILabel)control).Text = "실패";
                            break;
                        }
                    }
                }
            }));
        }
    }
}
