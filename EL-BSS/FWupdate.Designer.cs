namespace EL_BSS
{
    partial class FWupdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Back_To_Main = new DrakeUI.Framework.DrakeUIButton();
            this.Select_File = new DrakeUI.Framework.DrakeUIButton();
            this.Update_FW = new DrakeUI.Framework.DrakeUIButton();
            this.Check_Slave_Or_Master = new DrakeUI.Framework.DrakeUILabel();
            this.FW_Update_Progress = new DrakeUI.Framework.DrakeUILabel();
            this.drakeUILabel2 = new DrakeUI.Framework.DrakeUILabel();
            this.Setting_Master_Id_CB = new DrakeUI.Framework.DrakeUIComboBox();
            this.drakeUILabel1 = new DrakeUI.Framework.DrakeUILabel();
            this.Setting_Slave_Id_CB = new DrakeUI.Framework.DrakeUIComboBox();
            this.drakeUILabel4 = new DrakeUI.Framework.DrakeUILabel();
            this.drakeUILabel5 = new DrakeUI.Framework.DrakeUILabel();
            this.Download_APP_Set_1 = new DrakeUI.Framework.DrakeUIButton();
            this.Download_APP_Set_2 = new DrakeUI.Framework.DrakeUIButton();
            this.Jump_APP_Set_1 = new DrakeUI.Framework.DrakeUIButton();
            this.Jump_APP_Set_2 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUILabel6 = new DrakeUI.Framework.DrakeUILabel();
            this.Receive_Send_Flag = new DrakeUI.Framework.DrakeUILabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FW_Update_Progress_Bar = new System.Windows.Forms.ProgressBar();
            this.drakeUILabel8 = new DrakeUI.Framework.DrakeUILabel();
            this.drakeUILabel9 = new DrakeUI.Framework.DrakeUILabel();
            this.drakeUILabel10 = new DrakeUI.Framework.DrakeUILabel();
            this.Boot_Version_Text = new DrakeUI.Framework.DrakeUILabel();
            this.APP1_Version_Text = new DrakeUI.Framework.DrakeUILabel();
            this.APP2_Version_Text = new DrakeUI.Framework.DrakeUILabel();
            this.Send_f0_start = new DrakeUI.Framework.DrakeUIButton();
            this.notify_table_layout = new System.Windows.Forms.TableLayoutPanel();
            this.notify_message = new DrakeUI.Framework.DrakeUILabel();
            this.test_2_button = new DrakeUI.Framework.DrakeUIButton();
            this.jump_flag_text = new DrakeUI.Framework.DrakeUILabel();
            this.notify_table_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Back_To_Main
            // 
            this.Back_To_Main.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back_To_Main.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Back_To_Main.FillPressColor = System.Drawing.Color.Blue;
            this.Back_To_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Back_To_Main.Location = new System.Drawing.Point(849, 28);
            this.Back_To_Main.Name = "Back_To_Main";
            this.Back_To_Main.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Back_To_Main.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Back_To_Main.Size = new System.Drawing.Size(128, 44);
            this.Back_To_Main.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Back_To_Main.TabIndex = 0;
            this.Back_To_Main.Text = "돌아가기";
            this.Back_To_Main.Click += new System.EventHandler(this.Back_To_Main_Click);
            // 
            // Select_File
            // 
            this.Select_File.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Select_File.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Select_File.FillPressColor = System.Drawing.Color.Blue;
            this.Select_File.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.Select_File.Location = new System.Drawing.Point(29, 271);
            this.Select_File.Name = "Select_File";
            this.Select_File.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Select_File.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Select_File.Size = new System.Drawing.Size(121, 44);
            this.Select_File.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Select_File.TabIndex = 1;
            this.Select_File.Text = "파일 선택";
            this.Select_File.Click += new System.EventHandler(this.Select_File_Click);
            // 
            // Update_FW
            // 
            this.Update_FW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Update_FW.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Update_FW.FillPressColor = System.Drawing.Color.Blue;
            this.Update_FW.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Update_FW.Location = new System.Drawing.Point(29, 333);
            this.Update_FW.Name = "Update_FW";
            this.Update_FW.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Update_FW.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Update_FW.Size = new System.Drawing.Size(121, 44);
            this.Update_FW.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Update_FW.TabIndex = 2;
            this.Update_FW.Text = "업데이트 시작";
            this.Update_FW.Click += new System.EventHandler(this.Update_FW_Click);
            // 
            // Check_Slave_Or_Master
            // 
            this.Check_Slave_Or_Master.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Check_Slave_Or_Master.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check_Slave_Or_Master.ForeColor = System.Drawing.Color.White;
            this.Check_Slave_Or_Master.Location = new System.Drawing.Point(29, 28);
            this.Check_Slave_Or_Master.Name = "Check_Slave_Or_Master";
            this.Check_Slave_Or_Master.Size = new System.Drawing.Size(105, 44);
            this.Check_Slave_Or_Master.TabIndex = 3;
            this.Check_Slave_Or_Master.Text = "마스터";
            this.Check_Slave_Or_Master.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FW_Update_Progress
            // 
            this.FW_Update_Progress.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.FW_Update_Progress.Location = new System.Drawing.Point(137, 463);
            this.FW_Update_Progress.Name = "FW_Update_Progress";
            this.FW_Update_Progress.Size = new System.Drawing.Size(159, 44);
            this.FW_Update_Progress.TabIndex = 4;
            this.FW_Update_Progress.Text = "100/100";
            this.FW_Update_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUILabel2
            // 
            this.drakeUILabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel2.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel2.Location = new System.Drawing.Point(26, 462);
            this.drakeUILabel2.Name = "drakeUILabel2";
            this.drakeUILabel2.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel2.TabIndex = 5;
            this.drakeUILabel2.Text = "진행상황";
            this.drakeUILabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Setting_Master_Id_CB
            // 
            this.Setting_Master_Id_CB.FillColor = System.Drawing.Color.White;
            this.Setting_Master_Id_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Setting_Master_Id_CB.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.Setting_Master_Id_CB.Location = new System.Drawing.Point(141, 37);
            this.Setting_Master_Id_CB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Setting_Master_Id_CB.MinimumSize = new System.Drawing.Size(63, 0);
            this.Setting_Master_Id_CB.Name = "Setting_Master_Id_CB";
            this.Setting_Master_Id_CB.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.Setting_Master_Id_CB.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.Setting_Master_Id_CB.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Setting_Master_Id_CB.Size = new System.Drawing.Size(173, 26);
            this.Setting_Master_Id_CB.Style = DrakeUI.Framework.UIStyle.Green;
            this.Setting_Master_Id_CB.TabIndex = 6;
            this.Setting_Master_Id_CB.Text = "MASTER";
            this.Setting_Master_Id_CB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // drakeUILabel1
            // 
            this.drakeUILabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel1.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel1.Location = new System.Drawing.Point(29, 84);
            this.drakeUILabel1.Name = "drakeUILabel1";
            this.drakeUILabel1.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel1.TabIndex = 7;
            this.drakeUILabel1.Text = "슬래이브";
            this.drakeUILabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Setting_Slave_Id_CB
            // 
            this.Setting_Slave_Id_CB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Setting_Slave_Id_CB.FillColor = System.Drawing.Color.White;
            this.Setting_Slave_Id_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Setting_Slave_Id_CB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Setting_Slave_Id_CB.Location = new System.Drawing.Point(141, 93);
            this.Setting_Slave_Id_CB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Setting_Slave_Id_CB.MinimumSize = new System.Drawing.Size(63, 0);
            this.Setting_Slave_Id_CB.Name = "Setting_Slave_Id_CB";
            this.Setting_Slave_Id_CB.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.Setting_Slave_Id_CB.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.Setting_Slave_Id_CB.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Setting_Slave_Id_CB.Size = new System.Drawing.Size(173, 26);
            this.Setting_Slave_Id_CB.Style = DrakeUI.Framework.UIStyle.Green;
            this.Setting_Slave_Id_CB.TabIndex = 7;
            this.Setting_Slave_Id_CB.Text = "SLAVE";
            this.Setting_Slave_Id_CB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // drakeUILabel4
            // 
            this.drakeUILabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel4.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel4.Location = new System.Drawing.Point(29, 144);
            this.drakeUILabel4.Name = "drakeUILabel4";
            this.drakeUILabel4.Size = new System.Drawing.Size(121, 44);
            this.drakeUILabel4.TabIndex = 11;
            this.drakeUILabel4.Text = "다운로드 주소";
            this.drakeUILabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUILabel5
            // 
            this.drakeUILabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel5.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel5.Location = new System.Drawing.Point(29, 200);
            this.drakeUILabel5.Name = "drakeUILabel5";
            this.drakeUILabel5.Size = new System.Drawing.Size(121, 44);
            this.drakeUILabel5.TabIndex = 12;
            this.drakeUILabel5.Text = "점프 주소";
            this.drakeUILabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Download_APP_Set_1
            // 
            this.Download_APP_Set_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Download_APP_Set_1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Download_APP_Set_1.FillPressColor = System.Drawing.Color.Blue;
            this.Download_APP_Set_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Download_APP_Set_1.Location = new System.Drawing.Point(171, 144);
            this.Download_APP_Set_1.Name = "Download_APP_Set_1";
            this.Download_APP_Set_1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Download_APP_Set_1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Download_APP_Set_1.Size = new System.Drawing.Size(44, 44);
            this.Download_APP_Set_1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Download_APP_Set_1.TabIndex = 13;
            this.Download_APP_Set_1.Text = "1";
            this.Download_APP_Set_1.Click += new System.EventHandler(this.Download_APP_Set_1_Click);
            // 
            // Download_APP_Set_2
            // 
            this.Download_APP_Set_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Download_APP_Set_2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Download_APP_Set_2.FillPressColor = System.Drawing.Color.Blue;
            this.Download_APP_Set_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Download_APP_Set_2.Location = new System.Drawing.Point(232, 144);
            this.Download_APP_Set_2.Name = "Download_APP_Set_2";
            this.Download_APP_Set_2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Download_APP_Set_2.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Download_APP_Set_2.Size = new System.Drawing.Size(44, 44);
            this.Download_APP_Set_2.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Download_APP_Set_2.TabIndex = 14;
            this.Download_APP_Set_2.Text = "2";
            this.Download_APP_Set_2.Click += new System.EventHandler(this.Download_APP_Set_2_Click);
            // 
            // Jump_APP_Set_1
            // 
            this.Jump_APP_Set_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Jump_APP_Set_1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Jump_APP_Set_1.FillPressColor = System.Drawing.Color.Blue;
            this.Jump_APP_Set_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Jump_APP_Set_1.Location = new System.Drawing.Point(171, 200);
            this.Jump_APP_Set_1.Name = "Jump_APP_Set_1";
            this.Jump_APP_Set_1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Jump_APP_Set_1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Jump_APP_Set_1.Size = new System.Drawing.Size(44, 44);
            this.Jump_APP_Set_1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Jump_APP_Set_1.TabIndex = 15;
            this.Jump_APP_Set_1.Text = "1";
            this.Jump_APP_Set_1.Click += new System.EventHandler(this.Jump_APP_Set_1_Click);
            // 
            // Jump_APP_Set_2
            // 
            this.Jump_APP_Set_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Jump_APP_Set_2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Jump_APP_Set_2.FillPressColor = System.Drawing.Color.Blue;
            this.Jump_APP_Set_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Jump_APP_Set_2.Location = new System.Drawing.Point(232, 200);
            this.Jump_APP_Set_2.Name = "Jump_APP_Set_2";
            this.Jump_APP_Set_2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Jump_APP_Set_2.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Jump_APP_Set_2.Size = new System.Drawing.Size(44, 44);
            this.Jump_APP_Set_2.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Jump_APP_Set_2.TabIndex = 16;
            this.Jump_APP_Set_2.Text = "2";
            this.Jump_APP_Set_2.Click += new System.EventHandler(this.Jump_APP_Set_2_Click);
            // 
            // drakeUILabel6
            // 
            this.drakeUILabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel6.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel6.Location = new System.Drawing.Point(24, 518);
            this.drakeUILabel6.Name = "drakeUILabel6";
            this.drakeUILabel6.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel6.TabIndex = 19;
            this.drakeUILabel6.Text = "전송 flag";
            this.drakeUILabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Receive_Send_Flag
            // 
            this.Receive_Send_Flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Receive_Send_Flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Receive_Send_Flag.ForeColor = System.Drawing.Color.White;
            this.Receive_Send_Flag.Location = new System.Drawing.Point(161, 523);
            this.Receive_Send_Flag.Name = "Receive_Send_Flag";
            this.Receive_Send_Flag.Size = new System.Drawing.Size(153, 34);
            this.Receive_Send_Flag.TabIndex = 20;
            this.Receive_Send_Flag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FW_Update_Progress_Bar
            // 
            this.FW_Update_Progress_Bar.BackColor = System.Drawing.Color.White;
            this.FW_Update_Progress_Bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.FW_Update_Progress_Bar.Location = new System.Drawing.Point(302, 463);
            this.FW_Update_Progress_Bar.Name = "FW_Update_Progress_Bar";
            this.FW_Update_Progress_Bar.Size = new System.Drawing.Size(337, 44);
            this.FW_Update_Progress_Bar.TabIndex = 21;
            // 
            // drakeUILabel8
            // 
            this.drakeUILabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel8.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel8.Location = new System.Drawing.Point(428, 75);
            this.drakeUILabel8.Name = "drakeUILabel8";
            this.drakeUILabel8.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel8.TabIndex = 24;
            this.drakeUILabel8.Text = "Boot_Version";
            this.drakeUILabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUILabel9
            // 
            this.drakeUILabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel9.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel9.Location = new System.Drawing.Point(428, 130);
            this.drakeUILabel9.Name = "drakeUILabel9";
            this.drakeUILabel9.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel9.TabIndex = 25;
            this.drakeUILabel9.Text = "APP1_Version";
            this.drakeUILabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUILabel10
            // 
            this.drakeUILabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel10.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel10.Location = new System.Drawing.Point(428, 190);
            this.drakeUILabel10.Name = "drakeUILabel10";
            this.drakeUILabel10.Size = new System.Drawing.Size(105, 44);
            this.drakeUILabel10.TabIndex = 26;
            this.drakeUILabel10.Text = "APP2_Version";
            this.drakeUILabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Boot_Version_Text
            // 
            this.Boot_Version_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Boot_Version_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boot_Version_Text.ForeColor = System.Drawing.Color.White;
            this.Boot_Version_Text.Location = new System.Drawing.Point(560, 85);
            this.Boot_Version_Text.Name = "Boot_Version_Text";
            this.Boot_Version_Text.Size = new System.Drawing.Size(153, 34);
            this.Boot_Version_Text.TabIndex = 27;
            this.Boot_Version_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // APP1_Version_Text
            // 
            this.APP1_Version_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.APP1_Version_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APP1_Version_Text.ForeColor = System.Drawing.Color.White;
            this.APP1_Version_Text.Location = new System.Drawing.Point(560, 133);
            this.APP1_Version_Text.Name = "APP1_Version_Text";
            this.APP1_Version_Text.Size = new System.Drawing.Size(153, 34);
            this.APP1_Version_Text.TabIndex = 28;
            this.APP1_Version_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // APP2_Version_Text
            // 
            this.APP2_Version_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.APP2_Version_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APP2_Version_Text.ForeColor = System.Drawing.Color.White;
            this.APP2_Version_Text.Location = new System.Drawing.Point(560, 193);
            this.APP2_Version_Text.Name = "APP2_Version_Text";
            this.APP2_Version_Text.Size = new System.Drawing.Size(153, 34);
            this.APP2_Version_Text.TabIndex = 29;
            this.APP2_Version_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Send_f0_start
            // 
            this.Send_f0_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Send_f0_start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Send_f0_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Send_f0_start.Location = new System.Drawing.Point(431, 28);
            this.Send_f0_start.Name = "Send_f0_start";
            this.Send_f0_start.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Send_f0_start.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Send_f0_start.Size = new System.Drawing.Size(129, 26);
            this.Send_f0_start.Style = DrakeUI.Framework.UIStyle.Custom;
            this.Send_f0_start.TabIndex = 30;
            this.Send_f0_start.Text = "f0 전송";
            this.Send_f0_start.Click += new System.EventHandler(this.Send_f0_start_Click);
            // 
            // notify_table_layout
            // 
            this.notify_table_layout.BackColor = System.Drawing.Color.White;
            this.notify_table_layout.ColumnCount = 5;
            this.notify_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.notify_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.notify_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.notify_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.notify_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.notify_table_layout.Controls.Add(this.notify_message, 1, 1);
            this.notify_table_layout.Controls.Add(this.test_2_button, 2, 2);
            this.notify_table_layout.Location = new System.Drawing.Point(221, 133);
            this.notify_table_layout.Name = "notify_table_layout";
            this.notify_table_layout.RowCount = 4;
            this.notify_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.65625F));
            this.notify_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.34375F));
            this.notify_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.notify_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.notify_table_layout.Size = new System.Drawing.Size(654, 327);
            this.notify_table_layout.TabIndex = 31;
            this.notify_table_layout.Visible = false;
            // 
            // notify_message
            // 
            this.notify_table_layout.SetColumnSpan(this.notify_message, 3);
            this.notify_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notify_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.notify_message.Location = new System.Drawing.Point(68, 58);
            this.notify_message.Name = "notify_message";
            this.notify_message.Size = new System.Drawing.Size(516, 198);
            this.notify_message.TabIndex = 0;
            this.notify_message.Text = "해당 주소에는 프로그램이 없어 업데이트를 할수 없습니다";
            this.notify_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // test_2_button
            // 
            this.test_2_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.test_2_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.test_2_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.test_2_button.FillHoverColor = System.Drawing.Color.Black;
            this.test_2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.test_2_button.Location = new System.Drawing.Point(264, 259);
            this.test_2_button.Name = "test_2_button";
            this.test_2_button.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.test_2_button.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.test_2_button.Size = new System.Drawing.Size(124, 44);
            this.test_2_button.Style = DrakeUI.Framework.UIStyle.Custom;
            this.test_2_button.TabIndex = 1;
            this.test_2_button.Text = "확인";
            this.test_2_button.Click += new System.EventHandler(this.test_2_button_Click);
            // 
            // jump_flag_text
            // 
            this.jump_flag_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.jump_flag_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jump_flag_text.ForeColor = System.Drawing.Color.White;
            this.jump_flag_text.Location = new System.Drawing.Point(356, 518);
            this.jump_flag_text.Name = "jump_flag_text";
            this.jump_flag_text.Size = new System.Drawing.Size(153, 34);
            this.jump_flag_text.TabIndex = 32;
            this.jump_flag_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FWupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1017, 586);
            this.ControlBox = false;
            this.Controls.Add(this.jump_flag_text);
            this.Controls.Add(this.notify_table_layout);
            this.Controls.Add(this.Send_f0_start);
            this.Controls.Add(this.APP2_Version_Text);
            this.Controls.Add(this.APP1_Version_Text);
            this.Controls.Add(this.Boot_Version_Text);
            this.Controls.Add(this.drakeUILabel10);
            this.Controls.Add(this.drakeUILabel9);
            this.Controls.Add(this.drakeUILabel8);
            this.Controls.Add(this.FW_Update_Progress_Bar);
            this.Controls.Add(this.Receive_Send_Flag);
            this.Controls.Add(this.drakeUILabel6);
            this.Controls.Add(this.Jump_APP_Set_2);
            this.Controls.Add(this.Jump_APP_Set_1);
            this.Controls.Add(this.Download_APP_Set_2);
            this.Controls.Add(this.Download_APP_Set_1);
            this.Controls.Add(this.drakeUILabel5);
            this.Controls.Add(this.drakeUILabel4);
            this.Controls.Add(this.Setting_Slave_Id_CB);
            this.Controls.Add(this.drakeUILabel1);
            this.Controls.Add(this.Setting_Master_Id_CB);
            this.Controls.Add(this.drakeUILabel2);
            this.Controls.Add(this.FW_Update_Progress);
            this.Controls.Add(this.Check_Slave_Or_Master);
            this.Controls.Add(this.Update_FW);
            this.Controls.Add(this.Select_File);
            this.Controls.Add(this.Back_To_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FWupdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.notify_table_layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DrakeUI.Framework.DrakeUIButton Back_To_Main;
        private DrakeUI.Framework.DrakeUIButton Select_File;
        private DrakeUI.Framework.DrakeUIButton Update_FW;
        private DrakeUI.Framework.DrakeUILabel Check_Slave_Or_Master;
        private DrakeUI.Framework.DrakeUILabel FW_Update_Progress;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel2;
        private DrakeUI.Framework.DrakeUIComboBox Setting_Master_Id_CB;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel1;
        private DrakeUI.Framework.DrakeUIComboBox Setting_Slave_Id_CB;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel4;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel5;
        private DrakeUI.Framework.DrakeUIButton Download_APP_Set_1;
        private DrakeUI.Framework.DrakeUIButton Download_APP_Set_2;
        private DrakeUI.Framework.DrakeUIButton Jump_APP_Set_1;
        private DrakeUI.Framework.DrakeUIButton Jump_APP_Set_2;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel6;
        private DrakeUI.Framework.DrakeUILabel Receive_Send_Flag;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar FW_Update_Progress_Bar;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel8;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel9;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel10;
        private DrakeUI.Framework.DrakeUILabel Boot_Version_Text;
        private DrakeUI.Framework.DrakeUILabel APP1_Version_Text;
        private DrakeUI.Framework.DrakeUILabel APP2_Version_Text;
        private DrakeUI.Framework.DrakeUIButton Send_f0_start;
        private System.Windows.Forms.TableLayoutPanel notify_table_layout;
        private DrakeUI.Framework.DrakeUILabel notify_message;
        private DrakeUI.Framework.DrakeUIButton test_2_button;
        private DrakeUI.Framework.DrakeUILabel jump_flag_text;
    }
}