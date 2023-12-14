namespace EL_BSS
{
    partial class frmSubManual
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
            this.DOOR_OPEN_Button = new System.Windows.Forms.Button();
            this.DOOR_CLOSE_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LED_BLUE_Button = new System.Windows.Forms.Button();
            this.LED_GREEN_Button = new System.Windows.Forms.Button();
            this.LED_RED_Button = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Battery_get_Wattage = new System.Windows.Forms.Label();
            this.Battery_get_Voltage = new System.Windows.Forms.Label();
            this.Process_State = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Power_Pack_State = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Bettery_Type = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SOC_percent = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Power_Pack_Wattage = new System.Windows.Forms.Label();
            this.Power_Pack_outvoltage = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Battery_Current_Wattage = new System.Windows.Forms.Label();
            this.Battery_Current_Voltage = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.Battery_Highest_temp = new System.Windows.Forms.Label();
            this.Battery_Lowest_temp = new System.Windows.Forms.Label();
            this.SOH_percent = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.gb_Slot = new System.Windows.Forms.GroupBox();
            this.send_voltage_wattage = new System.Windows.Forms.Button();
            this.put_Battery_wattage = new System.Windows.Forms.TextBox();
            this.put_Battery_voltage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.manual_off = new System.Windows.Forms.Button();
            this.manual_on = new System.Windows.Forms.Button();
            this.drakeUIContextMenuStrip1 = new DrakeUI.Framework.DrakeUIContextMenuStrip();
            this.gb_Slot.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DOOR_OPEN_Button
            // 
            this.DOOR_OPEN_Button.BackColor = System.Drawing.Color.White;
            this.DOOR_OPEN_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DOOR_OPEN_Button.Location = new System.Drawing.Point(506, 20);
            this.DOOR_OPEN_Button.Name = "DOOR_OPEN_Button";
            this.DOOR_OPEN_Button.Size = new System.Drawing.Size(69, 51);
            this.DOOR_OPEN_Button.TabIndex = 2;
            this.DOOR_OPEN_Button.Text = "열기";
            this.DOOR_OPEN_Button.UseVisualStyleBackColor = false;
            this.DOOR_OPEN_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // DOOR_CLOSE_Button
            // 
            this.DOOR_CLOSE_Button.BackColor = System.Drawing.Color.White;
            this.DOOR_CLOSE_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DOOR_CLOSE_Button.Location = new System.Drawing.Point(581, 20);
            this.DOOR_CLOSE_Button.Name = "DOOR_CLOSE_Button";
            this.DOOR_CLOSE_Button.Size = new System.Drawing.Size(69, 51);
            this.DOOR_CLOSE_Button.TabIndex = 3;
            this.DOOR_CLOSE_Button.Text = "닫기";
            this.DOOR_CLOSE_Button.UseVisualStyleBackColor = false;
            this.DOOR_CLOSE_Button.Click += new System.EventHandler(this.DOOR_CLOSE_Button_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(576, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 37);
            this.label4.TabIndex = 9;
            this.label4.Text = "V";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(694, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 37);
            this.label5.TabIndex = 10;
            this.label5.Text = "A";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LED_BLUE_Button
            // 
            this.LED_BLUE_Button.BackColor = System.Drawing.Color.White;
            this.LED_BLUE_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LED_BLUE_Button.Location = new System.Drawing.Point(294, 17);
            this.LED_BLUE_Button.Name = "LED_BLUE_Button";
            this.LED_BLUE_Button.Size = new System.Drawing.Size(93, 51);
            this.LED_BLUE_Button.TabIndex = 13;
            this.LED_BLUE_Button.Text = "Blue 동작";
            this.LED_BLUE_Button.UseVisualStyleBackColor = false;
            this.LED_BLUE_Button.Click += new System.EventHandler(this.button6_Click);
            // 
            // LED_GREEN_Button
            // 
            this.LED_GREEN_Button.BackColor = System.Drawing.Color.White;
            this.LED_GREEN_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LED_GREEN_Button.Location = new System.Drawing.Point(195, 17);
            this.LED_GREEN_Button.Name = "LED_GREEN_Button";
            this.LED_GREEN_Button.Size = new System.Drawing.Size(93, 51);
            this.LED_GREEN_Button.TabIndex = 12;
            this.LED_GREEN_Button.Text = "Green 동작";
            this.LED_GREEN_Button.UseVisualStyleBackColor = false;
            this.LED_GREEN_Button.Click += new System.EventHandler(this.button7_Click);
            // 
            // LED_RED_Button
            // 
            this.LED_RED_Button.BackColor = System.Drawing.Color.White;
            this.LED_RED_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LED_RED_Button.Location = new System.Drawing.Point(96, 17);
            this.LED_RED_Button.Name = "LED_RED_Button";
            this.LED_RED_Button.Size = new System.Drawing.Size(93, 51);
            this.LED_RED_Button.TabIndex = 11;
            this.LED_RED_Button.Text = "Red 동작";
            this.LED_RED_Button.UseVisualStyleBackColor = false;
            this.LED_RED_Button.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.Location = new System.Drawing.Point(302, 94);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(93, 51);
            this.button9.TabIndex = 16;
            this.button9.Text = "출력시작\n(배터리연동 X)";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button10.Location = new System.Drawing.Point(203, 94);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 51);
            this.button10.TabIndex = 15;
            this.button10.Text = "충전시작\n(배터리연동)";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button11.Location = new System.Drawing.Point(104, 94);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(93, 51);
            this.button11.TabIndex = 14;
            this.button11.Text = "출력없음";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(410, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 37);
            this.label6.TabIndex = 17;
            this.label6.Text = "도어조정";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 37);
            this.label7.TabIndex = 18;
            this.label7.Text = "LED";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 37);
            this.label8.TabIndex = 19;
            this.label8.Text = "충전제어";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(14, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 43);
            this.label9.TabIndex = 20;
            this.label9.Text = "베터리";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(348, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 37);
            this.label10.TabIndex = 24;
            this.label10.Text = "A";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(230, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 37);
            this.label11.TabIndex = 23;
            this.label11.Text = "V";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_get_Wattage
            // 
            this.Battery_get_Wattage.BackColor = System.Drawing.Color.White;
            this.Battery_get_Wattage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_get_Wattage.Location = new System.Drawing.Point(272, 322);
            this.Battery_get_Wattage.Name = "Battery_get_Wattage";
            this.Battery_get_Wattage.Size = new System.Drawing.Size(70, 37);
            this.Battery_get_Wattage.TabIndex = 22;
            this.Battery_get_Wattage.Text = "15";
            this.Battery_get_Wattage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_get_Voltage
            // 
            this.Battery_get_Voltage.BackColor = System.Drawing.Color.White;
            this.Battery_get_Voltage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_get_Voltage.Location = new System.Drawing.Point(154, 322);
            this.Battery_get_Voltage.Name = "Battery_get_Voltage";
            this.Battery_get_Voltage.Size = new System.Drawing.Size(70, 37);
            this.Battery_get_Voltage.TabIndex = 21;
            this.Battery_get_Voltage.Text = "57.4";
            this.Battery_get_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Process_State
            // 
            this.Process_State.BackColor = System.Drawing.Color.White;
            this.Process_State.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Process_State.Location = new System.Drawing.Point(110, 273);
            this.Process_State.Name = "Process_State";
            this.Process_State.Size = new System.Drawing.Size(203, 37);
            this.Process_State.TabIndex = 25;
            this.Process_State.Text = "대기중";
            this.Process_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(483, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 37);
            this.label15.TabIndex = 26;
            this.label15.Text = "파워팩";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Power_Pack_State
            // 
            this.Power_Pack_State.BackColor = System.Drawing.Color.White;
            this.Power_Pack_State.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Power_Pack_State.Location = new System.Drawing.Point(594, 226);
            this.Power_Pack_State.Name = "Power_Pack_State";
            this.Power_Pack_State.Size = new System.Drawing.Size(119, 37);
            this.Power_Pack_State.TabIndex = 27;
            this.Power_Pack_State.Text = "OFF";
            this.Power_Pack_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(401, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 51);
            this.button3.TabIndex = 28;
            this.button3.Text = "배터리\nWAKE UP";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Bettery_Type
            // 
            this.Bettery_Type.BackColor = System.Drawing.Color.White;
            this.Bettery_Type.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Bettery_Type.Location = new System.Drawing.Point(23, 273);
            this.Bettery_Type.Name = "Bettery_Type";
            this.Bettery_Type.Size = new System.Drawing.Size(71, 37);
            this.Bettery_Type.TabIndex = 29;
            this.Bettery_Type.Text = "BS";
            this.Bettery_Type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(113, 226);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 37);
            this.label18.TabIndex = 30;
            this.label18.Text = "S.O.C";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SOC_percent
            // 
            this.SOC_percent.BackColor = System.Drawing.Color.White;
            this.SOC_percent.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SOC_percent.Location = new System.Drawing.Point(189, 226);
            this.SOC_percent.Name = "SOC_percent";
            this.SOC_percent.Size = new System.Drawing.Size(88, 37);
            this.SOC_percent.TabIndex = 31;
            this.SOC_percent.Text = "100%";
            this.SOC_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(677, 273);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 37);
            this.label20.TabIndex = 35;
            this.label20.Text = "A";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(559, 273);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 37);
            this.label21.TabIndex = 34;
            this.label21.Text = "V";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Power_Pack_Wattage
            // 
            this.Power_Pack_Wattage.BackColor = System.Drawing.Color.White;
            this.Power_Pack_Wattage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Power_Pack_Wattage.Location = new System.Drawing.Point(601, 273);
            this.Power_Pack_Wattage.Name = "Power_Pack_Wattage";
            this.Power_Pack_Wattage.Size = new System.Drawing.Size(70, 37);
            this.Power_Pack_Wattage.TabIndex = 33;
            this.Power_Pack_Wattage.Text = "15";
            this.Power_Pack_Wattage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Power_Pack_outvoltage
            // 
            this.Power_Pack_outvoltage.BackColor = System.Drawing.Color.White;
            this.Power_Pack_outvoltage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Power_Pack_outvoltage.Location = new System.Drawing.Point(483, 273);
            this.Power_Pack_outvoltage.Name = "Power_Pack_outvoltage";
            this.Power_Pack_outvoltage.Size = new System.Drawing.Size(70, 37);
            this.Power_Pack_outvoltage.TabIndex = 32;
            this.Power_Pack_outvoltage.Text = "57.4";
            this.Power_Pack_outvoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(348, 376);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 37);
            this.label24.TabIndex = 39;
            this.label24.Text = "A";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(230, 376);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 37);
            this.label25.TabIndex = 38;
            this.label25.Text = "V";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_Current_Wattage
            // 
            this.Battery_Current_Wattage.BackColor = System.Drawing.Color.White;
            this.Battery_Current_Wattage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_Current_Wattage.Location = new System.Drawing.Point(272, 376);
            this.Battery_Current_Wattage.Name = "Battery_Current_Wattage";
            this.Battery_Current_Wattage.Size = new System.Drawing.Size(70, 37);
            this.Battery_Current_Wattage.TabIndex = 37;
            this.Battery_Current_Wattage.Text = "15";
            this.Battery_Current_Wattage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_Current_Voltage
            // 
            this.Battery_Current_Voltage.BackColor = System.Drawing.Color.White;
            this.Battery_Current_Voltage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_Current_Voltage.Location = new System.Drawing.Point(154, 376);
            this.Battery_Current_Voltage.Name = "Battery_Current_Voltage";
            this.Battery_Current_Voltage.Size = new System.Drawing.Size(70, 37);
            this.Battery_Current_Voltage.TabIndex = 36;
            this.Battery_Current_Voltage.Text = "57.4";
            this.Battery_Current_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.White;
            this.label28.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.Location = new System.Drawing.Point(23, 322);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(125, 37);
            this.label28.TabIndex = 40;
            this.label28.Text = "요청 전압,전류";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(23, 376);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(125, 37);
            this.label29.TabIndex = 41;
            this.label29.Text = "현재 전압,전류";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.White;
            this.label30.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.Location = new System.Drawing.Point(23, 429);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(84, 37);
            this.label30.TabIndex = 42;
            this.label30.Text = "최고온도";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.White;
            this.label31.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.Location = new System.Drawing.Point(229, 429);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 37);
            this.label31.TabIndex = 43;
            this.label31.Text = "최저온도";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_Highest_temp
            // 
            this.Battery_Highest_temp.BackColor = System.Drawing.Color.White;
            this.Battery_Highest_temp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_Highest_temp.Location = new System.Drawing.Point(128, 429);
            this.Battery_Highest_temp.Name = "Battery_Highest_temp";
            this.Battery_Highest_temp.Size = new System.Drawing.Size(78, 37);
            this.Battery_Highest_temp.TabIndex = 44;
            this.Battery_Highest_temp.Text = "57.4";
            this.Battery_Highest_temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_Lowest_temp
            // 
            this.Battery_Lowest_temp.BackColor = System.Drawing.Color.White;
            this.Battery_Lowest_temp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_Lowest_temp.Location = new System.Drawing.Point(326, 429);
            this.Battery_Lowest_temp.Name = "Battery_Lowest_temp";
            this.Battery_Lowest_temp.Size = new System.Drawing.Size(78, 37);
            this.Battery_Lowest_temp.TabIndex = 45;
            this.Battery_Lowest_temp.Text = "57.4";
            this.Battery_Lowest_temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SOH_percent
            // 
            this.SOH_percent.BackColor = System.Drawing.Color.White;
            this.SOH_percent.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SOH_percent.Location = new System.Drawing.Point(359, 226);
            this.SOH_percent.Name = "SOH_percent";
            this.SOH_percent.Size = new System.Drawing.Size(88, 37);
            this.SOH_percent.TabIndex = 47;
            this.SOH_percent.Text = "100%";
            this.SOH_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.White;
            this.label35.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.Location = new System.Drawing.Point(283, 226);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 37);
            this.label35.TabIndex = 46;
            this.label35.Text = "S.O.H";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_Slot
            // 
            this.gb_Slot.Controls.Add(this.send_voltage_wattage);
            this.gb_Slot.Controls.Add(this.put_Battery_wattage);
            this.gb_Slot.Controls.Add(this.put_Battery_voltage);
            this.gb_Slot.Controls.Add(this.label5);
            this.gb_Slot.Controls.Add(this.button3);
            this.gb_Slot.Controls.Add(this.label4);
            this.gb_Slot.Controls.Add(this.label7);
            this.gb_Slot.Controls.Add(this.button9);
            this.gb_Slot.Controls.Add(this.label8);
            this.gb_Slot.Controls.Add(this.button10);
            this.gb_Slot.Controls.Add(this.LED_RED_Button);
            this.gb_Slot.Controls.Add(this.button11);
            this.gb_Slot.Controls.Add(this.label6);
            this.gb_Slot.Controls.Add(this.LED_GREEN_Button);
            this.gb_Slot.Controls.Add(this.LED_BLUE_Button);
            this.gb_Slot.Controls.Add(this.DOOR_OPEN_Button);
            this.gb_Slot.Controls.Add(this.DOOR_CLOSE_Button);
            this.gb_Slot.Location = new System.Drawing.Point(12, 12);
            this.gb_Slot.Name = "gb_Slot";
            this.gb_Slot.Size = new System.Drawing.Size(723, 168);
            this.gb_Slot.TabIndex = 48;
            this.gb_Slot.TabStop = false;
            this.gb_Slot.Text = "1번 슬롯";
            // 
            // send_voltage_wattage
            // 
            this.send_voltage_wattage.Location = new System.Drawing.Point(506, 142);
            this.send_voltage_wattage.Name = "send_voltage_wattage";
            this.send_voltage_wattage.Size = new System.Drawing.Size(106, 20);
            this.send_voltage_wattage.TabIndex = 34;
            this.send_voltage_wattage.Text = "전압 전류 설정";
            this.send_voltage_wattage.UseVisualStyleBackColor = true;
            this.send_voltage_wattage.Click += new System.EventHandler(this.send_voltage_wattage_Click_1);
            // 
            // put_Battery_wattage
            // 
            this.put_Battery_wattage.Location = new System.Drawing.Point(618, 99);
            this.put_Battery_wattage.Multiline = true;
            this.put_Battery_wattage.Name = "put_Battery_wattage";
            this.put_Battery_wattage.ShortcutsEnabled = false;
            this.put_Battery_wattage.Size = new System.Drawing.Size(70, 37);
            this.put_Battery_wattage.TabIndex = 33;
            this.put_Battery_wattage.Text = "15";
            this.put_Battery_wattage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // put_Battery_voltage
            // 
            this.put_Battery_voltage.Location = new System.Drawing.Point(500, 97);
            this.put_Battery_voltage.Multiline = true;
            this.put_Battery_voltage.Name = "put_Battery_voltage";
            this.put_Battery_voltage.ShortcutsEnabled = false;
            this.put_Battery_voltage.Size = new System.Drawing.Size(70, 37);
            this.put_Battery_voltage.TabIndex = 32;
            this.put_Battery_voltage.Text = "57.4";
            this.put_Battery_voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.manual_off);
            this.groupBox2.Controls.Add(this.manual_on);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 309);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "배터리";
            // 
            // manual_off
            // 
            this.manual_off.Location = new System.Drawing.Point(592, 180);
            this.manual_off.Name = "manual_off";
            this.manual_off.Size = new System.Drawing.Size(109, 23);
            this.manual_off.TabIndex = 1;
            this.manual_off.Text = "매뉴얼OFF";
            this.manual_off.UseVisualStyleBackColor = true;
            this.manual_off.Click += new System.EventHandler(this.manual_off_Click);
            // 
            // manual_on
            // 
            this.manual_on.Location = new System.Drawing.Point(450, 180);
            this.manual_on.Name = "manual_on";
            this.manual_on.Size = new System.Drawing.Size(125, 23);
            this.manual_on.TabIndex = 0;
            this.manual_on.Text = "매뉴얼ON";
            this.manual_on.UseVisualStyleBackColor = true;
            this.manual_on.Click += new System.EventHandler(this.manual_on_Click);
            // 
            // drakeUIContextMenuStrip1
            // 
            this.drakeUIContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUIContextMenuStrip1.Name = "drakeUIContextMenuStrip1";
            this.drakeUIContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmSubManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 508);
            this.Controls.Add(this.SOH_percent);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.Battery_Lowest_temp);
            this.Controls.Add(this.Battery_Highest_temp);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.Battery_Current_Wattage);
            this.Controls.Add(this.Battery_Current_Voltage);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Power_Pack_Wattage);
            this.Controls.Add(this.Power_Pack_outvoltage);
            this.Controls.Add(this.SOC_percent);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Bettery_Type);
            this.Controls.Add(this.Power_Pack_State);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Process_State);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Battery_get_Wattage);
            this.Controls.Add(this.Battery_get_Voltage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_Slot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubManual";
            this.Text = "frmSubManual";
            this.Load += new System.EventHandler(this.frmSubManual_Load);
            this.gb_Slot.ResumeLayout(false);
            this.gb_Slot.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DOOR_OPEN_Button;
        private System.Windows.Forms.Button DOOR_CLOSE_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LED_BLUE_Button;
        private System.Windows.Forms.Button LED_GREEN_Button;
        private System.Windows.Forms.Button LED_RED_Button;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Battery_get_Wattage;
        private System.Windows.Forms.Label Battery_get_Voltage;
        private System.Windows.Forms.Label Process_State;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label Power_Pack_State;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Bettery_Type;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label SOC_percent;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label Power_Pack_Wattage;
        private System.Windows.Forms.Label Power_Pack_outvoltage;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label Battery_Current_Wattage;
        private System.Windows.Forms.Label Battery_Current_Voltage;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label Battery_Highest_temp;
        private System.Windows.Forms.Label Battery_Lowest_temp;
        private System.Windows.Forms.Label SOH_percent;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox gb_Slot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox put_Battery_voltage;
        private System.Windows.Forms.TextBox put_Battery_wattage;
        private DrakeUI.Framework.DrakeUIContextMenuStrip drakeUIContextMenuStrip1;
        private System.Windows.Forms.Button manual_off;
        private System.Windows.Forms.Button manual_on;
        private System.Windows.Forms.Button send_voltage_wattage;
    }
}