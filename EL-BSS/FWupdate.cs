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
        Vkeyvoard VKeyboard = new Vkeyvoard();
        
        public FWupdate()
        {
            InitializeComponent();

        }
        public  void InitForm()
        {
            
        }
        public void UpdateForm(Model model)
        {
            
        }

        public void updateform()
        {
            FW_Update_Progress.Text = Model.binBufferCount.ToString() + " / " + Model.binFileBuffer.Count;
            Receive_Send_Flag.Text = Model.PWUpdate_Send_Flag.ToString();

            FW_Update_Progress_Bar.Value = Model.binBufferCount;
        }

        private async void Select_File_Click(object sender, EventArgs e)
        {
            Model.PWUpdate_MasterID = Convert.ToInt32(Setting_Master_Id_CB.Text);
            Model.PWUpdate_SlaveID = Convert.ToInt32(Setting_Slave_Id_CB.Text);

            Model.masterFirmwareUpdate_step = 0;

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
            // Model.makeFirmwareupdate(Convert.ToInt32(Setting_Master_Id_CB.Text), Convert.ToInt32(Setting_Slave_Id_CB.Text));
            Model.masterFirmwareUpdate = true;
            Model.masterFirmwareUpdate_Check_Finish = true;
            Model.masterFirmwareUpdate_step = 2;
        }

        private void Setting_New_Version_Button_Click(object sender, EventArgs e)
        {
            Model.PWUpdate_New_Version_Major = Convert.ToInt32(Setting_New_Version_TextBox.Text.Substring(0, 1));
            Model.PWUpdate_New_Version_Minor = Convert.ToInt32(Setting_New_Version_TextBox.Text.Substring(2, 1));
            Model.PWUpdate_New_Version_Patch = Convert.ToInt32(Setting_New_Version_TextBox.Text.Substring(4, 1));

        }

        private void Download_APP_Set_1_Click(object sender, EventArgs e)
        {
            Model.Download_APP = 1;
        }

        private void Download_APP_Set_2_Click(object sender, EventArgs e)
        {
            Model.Download_APP = 2;
        }

        private void Jump_APP_Set_1_Click(object sender, EventArgs e)
        {
            Model.Jump_APP = 1;
        }

        private void Jump_APP_Set_2_Click(object sender, EventArgs e)
        {
            Model.Jump_APP = 2;
        }

        private void Vkey_ON_button_Click(object sender, EventArgs e)
        {
            VKeyboard.showKeyboard();
            VKeyboard.moveWindow(0, 0, 250, 100);
        }

        private void Vkey_OFF_button_Click(object sender, EventArgs e)
        {
            VKeyboard.hideKeyboard();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => updateform());
        }

        private void Back_To_Main_Click(object sender, EventArgs e)
        {
            frmFrame.deleMenuClick(0);
        }

        private void Send_f0_start_Click(object sender, EventArgs e)
        {
            Model.masterFirmwareUpdate = true;
            Model.masterFirmwareUpdate_Check_Finish = true;
            Model.masterFirmwareUpdate_step = 3;
        }
    }
}
