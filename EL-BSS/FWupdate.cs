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

namespace EL_BSS
{
    public partial class FWupdate : Form  , IObserver
    {
        
        public FWupdate()
        {
            InitializeComponent();

        }
        public  void InitForm()
        {
            
        }
        public void UpdateForm(Model model)
        {
            notify_table_layout.Visible = false;
        }

        public void updateform()
        {
            FW_Update_Progress.Text = Model.binBufferCount.ToString() + " / " + Model.binFileBuffer.Count;
            Receive_Send_Flag.Text = Model.PWUpdate_Send_Flag.ToString();

            Boot_Version_Text.Text = Model.boot_Version_Major.ToString() + "." +  Model.boot_Version_Minor.ToString() + "." + Model.boot_Version_Patch.ToString();
            if (Model.app1_Version_Major == 255)
            { APP1_Version_Text.Text = "파일이 없음"; }
            else
            { APP1_Version_Text.Text = Model.app1_Version_Major.ToString() + "." + Model.app1_Version_Minor.ToString() + "." + Model.app1_Version_Patch.ToString(); }

            if (Model.app2_Version_Major == 255)
            { APP2_Version_Text.Text = "파일이 없음"; }
            else
            { APP2_Version_Text.Text = Model.app2_Version_Major.ToString() + "." + Model.app2_Version_Minor.ToString() + "." + Model.app2_Version_Patch.ToString(); }
            FW_Update_Progress_Bar.Value = Model.binBufferCount;

            if (Model.PWUpdate_Jump_Flag == 1)
            {
                Model.FirmwareUpdate = false;
                Model.FirmwareUpdate_Check_Finish = false;
                Model.PWUpdate_Jump_Flag = 0;
                // show_Notify("주소 점프 성공");
                jump_flag_text.Text = "주소 점프 성공"; 
            }
            else if (Model.PWUpdate_Jump_Flag == 2)
            {
                Model.FirmwareUpdate = false;
                Model.FirmwareUpdate_Check_Finish = false;
                Model.PWUpdate_Jump_Flag = 0;
                // show_Notify("주소 점프 실패");
                jump_flag_text.Text = "주소 점프 실패";
            }
        }

        private async void Select_File_Click(object sender, EventArgs e)
        {
                Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
                Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);

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
            Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
            Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);

            if (Model.Download_APP != Model.Jump_APP  )
            {
                if (Model.Download_APP == 0)
                {
                    Model.FirmwareUpdate = true;
                    Model.FirmwareUpdate_Check_Finish = true;
                    Model.FirmwareUpdate_step = 2;
                }
                else
                {
                    show_Notify("다운로드 주소와 점프 주소는 다를수 없습니다");
                }
            }
            else if (Model.Download_APP == Model.Jump_APP)
            {
                if (Model.Download_APP == 0)
                {
                    show_Notify("점프주소는 0이 될수 없습니다.");
                }
                else 
                {
                    Model.FirmwareUpdate = true;
                    Model.FirmwareUpdate_Check_Finish = true;
                    Model.FirmwareUpdate_step = 2;
                }
            }
        }

        private void Download_APP_Set_1_Click(object sender, EventArgs e)
        {
            if (Download_APP_Set_1.FillColor == Color.FromArgb(30, 136, 229))
            {
                Model.Download_APP = 1;
                Download_APP_Set_1.FillColor = Color.Blue;
                Download_APP_Set_2.FillColor = Color.FromArgb(30, 136, 229);
            }
            else if (Download_APP_Set_1.FillColor == Color.Blue)
            {
                Model.Download_APP = 0;
                Download_APP_Set_1.FillColor = Color.FromArgb(30, 136, 229);
            }
        }

        private void Download_APP_Set_2_Click(object sender, EventArgs e)
        {
            if (Download_APP_Set_2.FillColor == Color.FromArgb(30, 136, 229)) // 누른적이 없으면
            {
                Model.Download_APP = 2;
                Download_APP_Set_1.FillColor = Color.FromArgb(30, 136, 229);
                Download_APP_Set_2.FillColor = Color.Blue;
            }
            else if (Download_APP_Set_2.FillColor == Color.Blue) // 눌려저 있으면
            {
                Model.Download_APP = 0;
                Download_APP_Set_2.FillColor = Color.FromArgb(30, 136, 229);
            }
        }

        private void Jump_APP_Set_1_Click(object sender, EventArgs e)
        {
            if (Jump_APP_Set_1.FillColor == Color.FromArgb(30, 136, 229))
            {
                Model.Jump_APP = 1;
                Jump_APP_Set_1.FillColor = Color.Blue;
                Jump_APP_Set_2.FillColor = Color.FromArgb(30, 136, 229);
            }
            else if (Jump_APP_Set_1.FillColor == Color.Blue)
            {
                Model.Jump_APP = 0;
                Jump_APP_Set_1.FillColor = Color.FromArgb(30, 136, 229);
            }
        }

        private void Jump_APP_Set_2_Click(object sender, EventArgs e)
        {
            if (Jump_APP_Set_2.FillColor == Color.FromArgb(30, 136, 229)) // 누른적이 없으면
            {
                Model.Jump_APP = 2;
                Jump_APP_Set_1.FillColor = Color.FromArgb(30, 136, 229);
                Jump_APP_Set_2.FillColor = Color.Blue;
            }
            else if (Jump_APP_Set_2.FillColor == Color.Blue) // 눌려저 있으면
            {
                Model.Jump_APP = 0;
                Jump_APP_Set_2.FillColor = Color.FromArgb(30, 136, 229);
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
            Model.FirmwareUpdate_Check_Finish = true;
            Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
            Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);
            Model.FirmwareUpdate = true;
            Model.FirmwareUpdate_step = 3;
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
    }
}
