namespace EL_BSS
{
    partial class frmManual
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_buzzer_Stop = new System.Windows.Forms.Button();
            this.AutoStart_Popup = new System.Windows.Forms.Button();
            this.btn_buzzer_start = new System.Windows.Forms.Button();
            this.Chage_To_FW = new System.Windows.Forms.Button();
            this.Vkey_OFF_button = new System.Windows.Forms.Button();
            this.Vkey_ON_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Back_Main = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.All_Door_Close = new System.Windows.Forms.Button();
            this.All_Door_Open = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1021, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btn_buzzer_Stop);
            this.groupBox1.Controls.Add(this.AutoStart_Popup);
            this.groupBox1.Controls.Add(this.btn_buzzer_start);
            this.groupBox1.Controls.Add(this.Chage_To_FW);
            this.groupBox1.Controls.Add(this.Vkey_OFF_button);
            this.groupBox1.Controls.Add(this.Vkey_ON_button);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Back_Main);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "전체충전전력변경";
            // 
            // btn_buzzer_Stop
            // 
            this.btn_buzzer_Stop.Location = new System.Drawing.Point(454, 54);
            this.btn_buzzer_Stop.Name = "btn_buzzer_Stop";
            this.btn_buzzer_Stop.Size = new System.Drawing.Size(45, 36);
            this.btn_buzzer_Stop.TabIndex = 38;
            this.btn_buzzer_Stop.Text = "정지";
            this.btn_buzzer_Stop.UseVisualStyleBackColor = true;
            this.btn_buzzer_Stop.Click += new System.EventHandler(this.btn_buzzer_Stop_Click);
            // 
            // AutoStart_Popup
            // 
            this.AutoStart_Popup.Location = new System.Drawing.Point(503, 53);
            this.AutoStart_Popup.Name = "AutoStart_Popup";
            this.AutoStart_Popup.Size = new System.Drawing.Size(69, 36);
            this.AutoStart_Popup.TabIndex = 37;
            this.AutoStart_Popup.Text = "자동실행";
            this.AutoStart_Popup.UseVisualStyleBackColor = true;
            this.AutoStart_Popup.Click += new System.EventHandler(this.AutoStart_Popup_Click);
            // 
            // btn_buzzer_start
            // 
            this.btn_buzzer_start.Location = new System.Drawing.Point(352, 55);
            this.btn_buzzer_start.Name = "btn_buzzer_start";
            this.btn_buzzer_start.Size = new System.Drawing.Size(96, 36);
            this.btn_buzzer_start.TabIndex = 36;
            this.btn_buzzer_start.Text = "경고음 재생";
            this.btn_buzzer_start.UseVisualStyleBackColor = true;
            this.btn_buzzer_start.Click += new System.EventHandler(this.btn_buzzer_start_Click);
            // 
            // Chage_To_FW
            // 
            this.Chage_To_FW.Location = new System.Drawing.Point(252, 53);
            this.Chage_To_FW.Name = "Chage_To_FW";
            this.Chage_To_FW.Size = new System.Drawing.Size(94, 38);
            this.Chage_To_FW.TabIndex = 3;
            this.Chage_To_FW.Text = "펌웨어 \n업데이트 창";
            this.Chage_To_FW.UseVisualStyleBackColor = true;
            this.Chage_To_FW.Click += new System.EventHandler(this.Chage_To_FW_Click);
            // 
            // Vkey_OFF_button
            // 
            this.Vkey_OFF_button.Location = new System.Drawing.Point(164, 52);
            this.Vkey_OFF_button.Name = "Vkey_OFF_button";
            this.Vkey_OFF_button.Size = new System.Drawing.Size(82, 38);
            this.Vkey_OFF_button.TabIndex = 33;
            this.Vkey_OFF_button.Text = "화상키보드 OFF";
            this.Vkey_OFF_button.UseVisualStyleBackColor = true;
            this.Vkey_OFF_button.Click += new System.EventHandler(this.Vkey_OFF_button_Click);
            // 
            // Vkey_ON_button
            // 
            this.Vkey_ON_button.Location = new System.Drawing.Point(79, 49);
            this.Vkey_ON_button.Name = "Vkey_ON_button";
            this.Vkey_ON_button.Size = new System.Drawing.Size(79, 41);
            this.Vkey_ON_button.TabIndex = 32;
            this.Vkey_ON_button.Text = "화상키보드 ON";
            this.Vkey_ON_button.UseVisualStyleBackColor = true;
            this.Vkey_ON_button.Click += new System.EventHandler(this.Vkey_ON_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 68);
            this.button1.TabIndex = 31;
            this.button1.Text = "설정 창";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Back_Main
            // 
            this.Back_Main.Location = new System.Drawing.Point(6, 49);
            this.Back_Main.Name = "Back_Main";
            this.Back_Main.Size = new System.Drawing.Size(67, 41);
            this.Back_Main.TabIndex = 30;
            this.Back_Main.Text = "매인";
            this.Back_Main.UseVisualStyleBackColor = true;
            this.Back_Main.Click += new System.EventHandler(this.Back_Main_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(252, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 33);
            this.button3.TabIndex = 29;
            this.button3.Text = "적용";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(200, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 29);
            this.label10.TabIndex = 28;
            this.label10.Text = "A";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(82, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 29);
            this.label11.TabIndex = 27;
            this.label11.Text = "V";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(124, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 29);
            this.label12.TabIndex = 26;
            this.label12.Text = "15";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(6, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 29);
            this.label13.TabIndex = 25;
            this.label13.Text = "57.4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.All_Door_Close);
            this.groupBox2.Controls.Add(this.All_Door_Open);
            this.groupBox2.Location = new System.Drawing.Point(721, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 97);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "전체도어";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "프로그램 종료";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // All_Door_Close
            // 
            this.All_Door_Close.Location = new System.Drawing.Point(102, 20);
            this.All_Door_Close.Name = "All_Door_Close";
            this.All_Door_Close.Size = new System.Drawing.Size(90, 41);
            this.All_Door_Close.TabIndex = 1;
            this.All_Door_Close.Text = "닫힘";
            this.All_Door_Close.UseVisualStyleBackColor = true;
            this.All_Door_Close.Click += new System.EventHandler(this.All_Door_Close_Click);
            // 
            // All_Door_Open
            // 
            this.All_Door_Open.Location = new System.Drawing.Point(6, 20);
            this.All_Door_Open.Name = "All_Door_Open";
            this.All_Door_Open.Size = new System.Drawing.Size(90, 41);
            this.All_Door_Open.TabIndex = 0;
            this.All_Door_Open.Text = "열림";
            this.All_Door_Open.UseVisualStyleBackColor = true;
            this.All_Door_Open.Click += new System.EventHandler(this.All_Door_Open_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 107);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1017, 586);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 694);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManual";
            this.Text = "frmManual";
            this.Load += new System.EventHandler(this.frmManual_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button All_Door_Close;
        private System.Windows.Forms.Button All_Door_Open;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Back_Main;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Vkey_OFF_button;
        private System.Windows.Forms.Button Vkey_ON_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Chage_To_FW;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_buzzer_start;
        private System.Windows.Forms.Button AutoStart_Popup;
        private System.Windows.Forms.Button btn_buzzer_Stop;
    }
}