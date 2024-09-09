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
            this.Auto_Update_CheckBox = new System.Windows.Forms.CheckBox();
            this.Jump_APP_CB_Box = new DrakeUI.Framework.DrakeUIComboBox();
            this.cb_jumpid = new DrakeUI.Framework.DrakeUIComboBox();
            this.Jump_Packet_Button = new DrakeUI.Framework.DrakeUILabel();
            this.Master_1 = new DrakeUI.Framework.DrakeUILabel();
            this.Master_2 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_1 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_2 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_3 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_4 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_8 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_7 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_6 = new DrakeUI.Framework.DrakeUILabel();
            this.Slave_5 = new DrakeUI.Framework.DrakeUILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.drakeUIButton1 = new DrakeUI.Framework.DrakeUIButton();
            this.notify_table_layout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.Select_File.Location = new System.Drawing.Point(29, 218);
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
            this.Update_FW.Location = new System.Drawing.Point(29, 282);
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
            this.drakeUILabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILabel4.ForeColor = System.Drawing.Color.White;
            this.drakeUILabel4.Location = new System.Drawing.Point(29, 147);
            this.drakeUILabel4.Name = "drakeUILabel4";
            this.drakeUILabel4.Size = new System.Drawing.Size(121, 59);
            this.drakeUILabel4.TabIndex = 11;
            this.drakeUILabel4.Text = "다운로드 주소\n점프 주소";
            this.drakeUILabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.drakeUILabel8.Location = new System.Drawing.Point(428, 31);
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
            this.drakeUILabel9.Location = new System.Drawing.Point(428, 86);
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
            this.drakeUILabel10.Location = new System.Drawing.Point(428, 147);
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
            this.Boot_Version_Text.Location = new System.Drawing.Point(560, 38);
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
            this.APP1_Version_Text.Location = new System.Drawing.Point(560, 94);
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
            this.APP2_Version_Text.Location = new System.Drawing.Point(560, 150);
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
            this.Send_f0_start.Location = new System.Drawing.Point(431, 205);
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
            this.notify_table_layout.Location = new System.Drawing.Point(995, 572);
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
            this.notify_message.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // Auto_Update_CheckBox
            // 
            this.Auto_Update_CheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Auto_Update_CheckBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.Auto_Update_CheckBox.Location = new System.Drawing.Point(171, 282);
            this.Auto_Update_CheckBox.Name = "Auto_Update_CheckBox";
            this.Auto_Update_CheckBox.Size = new System.Drawing.Size(143, 44);
            this.Auto_Update_CheckBox.TabIndex = 32;
            this.Auto_Update_CheckBox.Text = "자동 업데이트";
            this.Auto_Update_CheckBox.UseVisualStyleBackColor = true;
            this.Auto_Update_CheckBox.CheckedChanged += new System.EventHandler(this.Auto_Update_CheckBox_CheckedChanged);
            // 
            // Jump_APP_CB_Box
            // 
            this.Jump_APP_CB_Box.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Jump_APP_CB_Box.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList;
            this.Jump_APP_CB_Box.FillColor = System.Drawing.Color.White;
            this.Jump_APP_CB_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Jump_APP_CB_Box.Items.AddRange(new object[] {
            "1",
            "2"});
            this.Jump_APP_CB_Box.Location = new System.Drawing.Point(157, 148);
            this.Jump_APP_CB_Box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Jump_APP_CB_Box.MinimumSize = new System.Drawing.Size(63, 0);
            this.Jump_APP_CB_Box.Name = "Jump_APP_CB_Box";
            this.Jump_APP_CB_Box.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.Jump_APP_CB_Box.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.Jump_APP_CB_Box.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Jump_APP_CB_Box.Size = new System.Drawing.Size(173, 26);
            this.Jump_APP_CB_Box.Style = DrakeUI.Framework.UIStyle.Green;
            this.Jump_APP_CB_Box.TabIndex = 8;
            this.Jump_APP_CB_Box.Text = "1";
            this.Jump_APP_CB_Box.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_jumpid
            // 
            this.cb_jumpid.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cb_jumpid.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList;
            this.cb_jumpid.FillColor = System.Drawing.Color.White;
            this.cb_jumpid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_jumpid.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_jumpid.Location = new System.Drawing.Point(804, 121);
            this.cb_jumpid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_jumpid.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_jumpid.Name = "cb_jumpid";
            this.cb_jumpid.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_jumpid.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.cb_jumpid.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.cb_jumpid.Size = new System.Drawing.Size(173, 26);
            this.cb_jumpid.Style = DrakeUI.Framework.UIStyle.Green;
            this.cb_jumpid.TabIndex = 9;
            this.cb_jumpid.Text = "1";
            this.cb_jumpid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Jump_Packet_Button
            // 
            this.Jump_Packet_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Jump_Packet_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jump_Packet_Button.ForeColor = System.Drawing.Color.White;
            this.Jump_Packet_Button.Location = new System.Drawing.Point(844, 162);
            this.Jump_Packet_Button.Name = "Jump_Packet_Button";
            this.Jump_Packet_Button.Size = new System.Drawing.Size(105, 44);
            this.Jump_Packet_Button.TabIndex = 33;
            this.Jump_Packet_Button.Text = "점프";
            this.Jump_Packet_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Jump_Packet_Button.Click += new System.EventHandler(this.Jump_Packet_Button_Click);
            // 
            // Master_1
            // 
            this.Master_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Master_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master_1.ForeColor = System.Drawing.Color.White;
            this.Master_1.Location = new System.Drawing.Point(3, 0);
            this.Master_1.Name = "Master_1";
            this.Master_1.Size = new System.Drawing.Size(60, 30);
            this.Master_1.TabIndex = 47;
            this.Master_1.Text = "마스터1";
            this.Master_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Master_2
            // 
            this.Master_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Master_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master_2.ForeColor = System.Drawing.Color.White;
            this.Master_2.Location = new System.Drawing.Point(69, 0);
            this.Master_2.Name = "Master_2";
            this.Master_2.Size = new System.Drawing.Size(59, 30);
            this.Master_2.TabIndex = 48;
            this.Master_2.Text = "마스터2";
            this.Master_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_1
            // 
            this.Slave_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_1.ForeColor = System.Drawing.Color.White;
            this.Slave_1.Location = new System.Drawing.Point(3, 0);
            this.Slave_1.Name = "Slave_1";
            this.Slave_1.Size = new System.Drawing.Size(63, 34);
            this.Slave_1.TabIndex = 50;
            this.Slave_1.Text = "슬레이브1";
            this.Slave_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_2
            // 
            this.Slave_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_2.ForeColor = System.Drawing.Color.White;
            this.Slave_2.Location = new System.Drawing.Point(3, 37);
            this.Slave_2.Name = "Slave_2";
            this.Slave_2.Size = new System.Drawing.Size(63, 34);
            this.Slave_2.TabIndex = 51;
            this.Slave_2.Text = "슬레이브2";
            this.Slave_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_3
            // 
            this.Slave_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_3.ForeColor = System.Drawing.Color.White;
            this.Slave_3.Location = new System.Drawing.Point(3, 74);
            this.Slave_3.Name = "Slave_3";
            this.Slave_3.Size = new System.Drawing.Size(63, 34);
            this.Slave_3.TabIndex = 52;
            this.Slave_3.Text = "슬레이브3";
            this.Slave_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_4
            // 
            this.Slave_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_4.ForeColor = System.Drawing.Color.White;
            this.Slave_4.Location = new System.Drawing.Point(3, 111);
            this.Slave_4.Name = "Slave_4";
            this.Slave_4.Size = new System.Drawing.Size(63, 34);
            this.Slave_4.TabIndex = 53;
            this.Slave_4.Text = "슬레이브4";
            this.Slave_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_8
            // 
            this.Slave_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_8.ForeColor = System.Drawing.Color.White;
            this.Slave_8.Location = new System.Drawing.Point(72, 111);
            this.Slave_8.Name = "Slave_8";
            this.Slave_8.Size = new System.Drawing.Size(63, 34);
            this.Slave_8.TabIndex = 57;
            this.Slave_8.Text = "슬레이브4";
            this.Slave_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_7
            // 
            this.Slave_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_7.ForeColor = System.Drawing.Color.White;
            this.Slave_7.Location = new System.Drawing.Point(72, 74);
            this.Slave_7.Name = "Slave_7";
            this.Slave_7.Size = new System.Drawing.Size(63, 34);
            this.Slave_7.TabIndex = 56;
            this.Slave_7.Text = "슬레이브3";
            this.Slave_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_6
            // 
            this.Slave_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_6.ForeColor = System.Drawing.Color.White;
            this.Slave_6.Location = new System.Drawing.Point(72, 37);
            this.Slave_6.Name = "Slave_6";
            this.Slave_6.Size = new System.Drawing.Size(63, 34);
            this.Slave_6.TabIndex = 55;
            this.Slave_6.Text = "슬레이브2";
            this.Slave_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slave_5
            // 
            this.Slave_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.Slave_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slave_5.ForeColor = System.Drawing.Color.White;
            this.Slave_5.Location = new System.Drawing.Point(72, 0);
            this.Slave_5.Name = "Slave_5";
            this.Slave_5.Size = new System.Drawing.Size(63, 34);
            this.Slave_5.TabIndex = 54;
            this.Slave_5.Text = "슬레이브1";
            this.Slave_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.tableLayoutPanel1.Controls.Add(this.Master_1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Master_2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(790, 296);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 30);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Slave_1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Slave_5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Slave_8, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.Slave_2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Slave_4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Slave_7, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.Slave_6, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Slave_3, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(790, 343);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(139, 149);
            this.tableLayoutPanel2.TabIndex = 59;
            // 
            // drakeUIButton1
            // 
            this.drakeUIButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.FillPressColor = System.Drawing.Color.Blue;
            this.drakeUIButton1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton1.Location = new System.Drawing.Point(29, 343);
            this.drakeUIButton1.Name = "drakeUIButton1";
            this.drakeUIButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton1.Size = new System.Drawing.Size(121, 44);
            this.drakeUIButton1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton1.TabIndex = 60;
            this.drakeUIButton1.Text = "SW 업데이트";
            this.drakeUIButton1.Click += new System.EventHandler(this.drakeUIButton1_Click);
            // 
            // FWupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1017, 586);
            this.ControlBox = false;
            this.Controls.Add(this.drakeUIButton1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Jump_Packet_Button);
            this.Controls.Add(this.cb_jumpid);
            this.Controls.Add(this.Jump_APP_CB_Box);
            this.Controls.Add(this.Auto_Update_CheckBox);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox Auto_Update_CheckBox;
        private DrakeUI.Framework.DrakeUIComboBox Jump_APP_CB_Box;
        private DrakeUI.Framework.DrakeUIComboBox cb_jumpid;
        private DrakeUI.Framework.DrakeUILabel Jump_Packet_Button;
        private DrakeUI.Framework.DrakeUILabel Master_1;
        private DrakeUI.Framework.DrakeUILabel Master_2;
        private DrakeUI.Framework.DrakeUILabel Slave_1;
        private DrakeUI.Framework.DrakeUILabel Slave_2;
        private DrakeUI.Framework.DrakeUILabel Slave_3;
        private DrakeUI.Framework.DrakeUILabel Slave_4;
        private DrakeUI.Framework.DrakeUILabel Slave_8;
        private DrakeUI.Framework.DrakeUILabel Slave_7;
        private DrakeUI.Framework.DrakeUILabel Slave_6;
        private DrakeUI.Framework.DrakeUILabel Slave_5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton1;
    }
}