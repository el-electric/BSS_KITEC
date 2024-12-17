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
            this.Battery_Highest_temp = new System.Windows.Forms.Label();
            this.SOH_percent = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.gb_Slot = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.put_Battery_voltage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.send_board_Reset = new System.Windows.Forms.Button();
            this.set_Current = new System.Windows.Forms.Button();
            this.put_Battery_curent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_discharging = new System.Windows.Forms.CheckBox();
            this.Slot_Temp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_battery_arrive = new System.Windows.Forms.Label();
            this.lb_serial_num = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FET_Temp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.manual_on = new System.Windows.Forms.Button();
            this.cb_Slot_num = new System.Windows.Forms.ComboBox();
            this.gb_Slot.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DOOR_OPEN_Button
            // 
            this.DOOR_OPEN_Button.BackColor = System.Drawing.Color.White;
            this.DOOR_OPEN_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DOOR_OPEN_Button.Location = new System.Drawing.Point(500, 20);
            this.DOOR_OPEN_Button.Name = "DOOR_OPEN_Button";
            this.DOOR_OPEN_Button.Size = new System.Drawing.Size(57, 39);
            this.DOOR_OPEN_Button.TabIndex = 2;
            this.DOOR_OPEN_Button.Text = "열기";
            this.DOOR_OPEN_Button.UseVisualStyleBackColor = false;
            this.DOOR_OPEN_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // DOOR_CLOSE_Button
            // 
            this.DOOR_CLOSE_Button.BackColor = System.Drawing.Color.White;
            this.DOOR_CLOSE_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DOOR_CLOSE_Button.Location = new System.Drawing.Point(565, 20);
            this.DOOR_CLOSE_Button.Name = "DOOR_CLOSE_Button";
            this.DOOR_CLOSE_Button.Size = new System.Drawing.Size(57, 39);
            this.DOOR_CLOSE_Button.TabIndex = 3;
            this.DOOR_CLOSE_Button.Text = "닫기";
            this.DOOR_CLOSE_Button.UseVisualStyleBackColor = false;
            this.DOOR_CLOSE_Button.Click += new System.EventHandler(this.DOOR_CLOSE_Button_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(688, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "A";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LED_BLUE_Button
            // 
            this.LED_BLUE_Button.BackColor = System.Drawing.Color.White;
            this.LED_BLUE_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LED_BLUE_Button.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.LED_GREEN_Button.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.LED_RED_Button.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.button9.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.button10.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.button11.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label7.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label8.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label9.Location = new System.Drawing.Point(6, 22);
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
            this.label10.Location = new System.Drawing.Point(328, 118);
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
            this.label11.Location = new System.Drawing.Point(210, 118);
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
            this.Battery_get_Wattage.Location = new System.Drawing.Point(252, 118);
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
            this.Battery_get_Voltage.Location = new System.Drawing.Point(137, 118);
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
            this.Process_State.Location = new System.Drawing.Point(83, 75);
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
            this.label15.Location = new System.Drawing.Point(474, 28);
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
            this.Power_Pack_State.Location = new System.Drawing.Point(571, 28);
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
            this.button3.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(401, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 51);
            this.button3.TabIndex = 28;
            this.button3.Text = "WAKE UP";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Bettery_Type
            // 
            this.Bettery_Type.BackColor = System.Drawing.Color.White;
            this.Bettery_Type.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Bettery_Type.Location = new System.Drawing.Point(6, 75);
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
            this.label18.Location = new System.Drawing.Point(105, 25);
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
            this.SOC_percent.Location = new System.Drawing.Point(181, 25);
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
            this.label20.Location = new System.Drawing.Point(647, 75);
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
            this.label21.Location = new System.Drawing.Point(530, 75);
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
            this.Power_Pack_Wattage.Location = new System.Drawing.Point(571, 75);
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
            this.Power_Pack_outvoltage.Location = new System.Drawing.Point(457, 75);
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
            this.label24.Location = new System.Drawing.Point(331, 164);
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
            this.label25.Location = new System.Drawing.Point(213, 164);
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
            this.Battery_Current_Wattage.Location = new System.Drawing.Point(255, 164);
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
            this.Battery_Current_Voltage.Location = new System.Drawing.Point(137, 164);
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
            this.label28.Location = new System.Drawing.Point(6, 118);
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
            this.label29.Location = new System.Drawing.Point(6, 164);
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
            this.label30.Location = new System.Drawing.Point(11, 242);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(125, 37);
            this.label30.TabIndex = 42;
            this.label30.Text = "최고/최저 온도";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Battery_Highest_temp
            // 
            this.Battery_Highest_temp.BackColor = System.Drawing.Color.White;
            this.Battery_Highest_temp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Battery_Highest_temp.Location = new System.Drawing.Point(142, 242);
            this.Battery_Highest_temp.Name = "Battery_Highest_temp";
            this.Battery_Highest_temp.Size = new System.Drawing.Size(112, 37);
            this.Battery_Highest_temp.TabIndex = 44;
            this.Battery_Highest_temp.Text = "57.4 / 57.4";
            this.Battery_Highest_temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SOH_percent
            // 
            this.SOH_percent.BackColor = System.Drawing.Color.White;
            this.SOH_percent.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SOH_percent.Location = new System.Drawing.Point(351, 25);
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
            this.label35.Location = new System.Drawing.Point(275, 25);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 37);
            this.label35.TabIndex = 46;
            this.label35.Text = "S.O.H";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_Slot
            // 
            this.gb_Slot.Controls.Add(this.label3);
            this.gb_Slot.Controls.Add(this.put_Battery_voltage);
            this.gb_Slot.Controls.Add(this.button1);
            this.gb_Slot.Controls.Add(this.send_board_Reset);
            this.gb_Slot.Controls.Add(this.set_Current);
            this.gb_Slot.Controls.Add(this.put_Battery_curent);
            this.gb_Slot.Controls.Add(this.label5);
            this.gb_Slot.Controls.Add(this.button3);
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
            this.gb_Slot.Location = new System.Drawing.Point(12, 49);
            this.gb_Slot.Name = "gb_Slot";
            this.gb_Slot.Size = new System.Drawing.Size(723, 168);
            this.gb_Slot.TabIndex = 48;
            this.gb_Slot.TabStop = false;
            this.gb_Slot.Text = "1번 슬롯";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(688, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "V";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // put_Battery_voltage
            // 
            this.put_Battery_voltage.Location = new System.Drawing.Point(612, 79);
            this.put_Battery_voltage.Multiline = true;
            this.put_Battery_voltage.Name = "put_Battery_voltage";
            this.put_Battery_voltage.ShortcutsEnabled = false;
            this.put_Battery_voltage.Size = new System.Drawing.Size(70, 25);
            this.put_Battery_voltage.TabIndex = 37;
            this.put_Battery_voltage.Text = "15";
            this.put_Battery_voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(500, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 51);
            this.button1.TabIndex = 36;
            this.button1.Text = "FET ON";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // send_board_Reset
            // 
            this.send_board_Reset.BackColor = System.Drawing.Color.White;
            this.send_board_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send_board_Reset.Location = new System.Drawing.Point(650, 21);
            this.send_board_Reset.Name = "send_board_Reset";
            this.send_board_Reset.Size = new System.Drawing.Size(67, 36);
            this.send_board_Reset.TabIndex = 35;
            this.send_board_Reset.Text = "보드리셋";
            this.send_board_Reset.UseVisualStyleBackColor = false;
            this.send_board_Reset.Click += new System.EventHandler(this.send_board_Reset_Click);
            // 
            // set_Current
            // 
            this.set_Current.Location = new System.Drawing.Point(611, 142);
            this.set_Current.Name = "set_Current";
            this.set_Current.Size = new System.Drawing.Size(106, 20);
            this.set_Current.TabIndex = 34;
            this.set_Current.Text = "전류 전압 설정";
            this.set_Current.UseVisualStyleBackColor = true;
            this.set_Current.Click += new System.EventHandler(this.set_Current_Click_1);
            // 
            // put_Battery_curent
            // 
            this.put_Battery_curent.Location = new System.Drawing.Point(612, 110);
            this.put_Battery_curent.Multiline = true;
            this.put_Battery_curent.Name = "put_Battery_curent";
            this.put_Battery_curent.ShortcutsEnabled = false;
            this.put_Battery_curent.Size = new System.Drawing.Size(70, 26);
            this.put_Battery_curent.TabIndex = 33;
            this.put_Battery_curent.Text = "15";
            this.put_Battery_curent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.Power_Pack_Wattage);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.SOH_percent);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.Power_Pack_outvoltage);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.Power_Pack_State);
            this.groupBox2.Controls.Add(this.Battery_Current_Wattage);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.cb_discharging);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.Battery_Current_Voltage);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.Slot_Temp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lb_battery_arrive);
            this.groupBox2.Controls.Add(this.lb_serial_num);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Battery_Highest_temp);
            this.groupBox2.Controls.Add(this.FET_Temp);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Bettery_Type);
            this.groupBox2.Controls.Add(this.Battery_get_Wattage);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.manual_on);
            this.groupBox2.Controls.Add(this.Process_State);
            this.groupBox2.Controls.Add(this.Battery_get_Voltage);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.SOC_percent);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 309);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "배터리";
            // 
            // cb_discharging
            // 
            this.cb_discharging.AutoSize = true;
            this.cb_discharging.Location = new System.Drawing.Point(565, 135);
            this.cb_discharging.Name = "cb_discharging";
            this.cb_discharging.Size = new System.Drawing.Size(58, 20);
            this.cb_discharging.TabIndex = 53;
            this.cb_discharging.Text = "방전";
            this.cb_discharging.UseVisualStyleBackColor = true;
            this.cb_discharging.CheckedChanged += new System.EventHandler(this.cb_discharging_CheckedChanged);
            // 
            // Slot_Temp
            // 
            this.Slot_Temp.BackColor = System.Drawing.Color.White;
            this.Slot_Temp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Slot_Temp.Location = new System.Drawing.Point(549, 242);
            this.Slot_Temp.Name = "Slot_Temp";
            this.Slot_Temp.Size = new System.Drawing.Size(78, 37);
            this.Slot_Temp.TabIndex = 52;
            this.Slot_Temp.Text = "57.4";
            this.Slot_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(457, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 37);
            this.label4.TabIndex = 51;
            this.label4.Text = "슬롯 온도";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_battery_arrive
            // 
            this.lb_battery_arrive.BackColor = System.Drawing.Color.White;
            this.lb_battery_arrive.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_battery_arrive.Location = new System.Drawing.Point(292, 75);
            this.lb_battery_arrive.Name = "lb_battery_arrive";
            this.lb_battery_arrive.Size = new System.Drawing.Size(88, 37);
            this.lb_battery_arrive.TabIndex = 50;
            this.lb_battery_arrive.Text = "없음";
            this.lb_battery_arrive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_serial_num
            // 
            this.lb_serial_num.BackColor = System.Drawing.Color.White;
            this.lb_serial_num.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_serial_num.Location = new System.Drawing.Point(497, 189);
            this.lb_serial_num.Name = "lb_serial_num";
            this.lb_serial_num.Size = new System.Drawing.Size(130, 43);
            this.lb_serial_num.TabIndex = 48;
            this.lb_serial_num.Text = "시리얼 번호";
            this.lb_serial_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(398, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 43);
            this.label2.TabIndex = 47;
            this.label2.Text = "시리얼 번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FET_Temp
            // 
            this.FET_Temp.BackColor = System.Drawing.Color.White;
            this.FET_Temp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FET_Temp.Location = new System.Drawing.Point(361, 242);
            this.FET_Temp.Name = "FET_Temp";
            this.FET_Temp.Size = new System.Drawing.Size(78, 37);
            this.FET_Temp.TabIndex = 46;
            this.FET_Temp.Text = "57.4";
            this.FET_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(271, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 37);
            this.label1.TabIndex = 44;
            this.label1.Text = "FET 온도";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // manual_on
            // 
            this.manual_on.Location = new System.Drawing.Point(401, 135);
            this.manual_on.Name = "manual_on";
            this.manual_on.Size = new System.Drawing.Size(125, 23);
            this.manual_on.TabIndex = 0;
            this.manual_on.Text = "매뉴얼";
            this.manual_on.UseVisualStyleBackColor = true;
            this.manual_on.Click += new System.EventHandler(this.manual_on_Click);
            // 
            // cb_Slot_num
            // 
            this.cb_Slot_num.FormattingEnabled = true;
            this.cb_Slot_num.Location = new System.Drawing.Point(13, 13);
            this.cb_Slot_num.Name = "cb_Slot_num";
            this.cb_Slot_num.Size = new System.Drawing.Size(121, 20);
            this.cb_Slot_num.TabIndex = 50;
            this.cb_Slot_num.SelectedIndexChanged += new System.EventHandler(this.cb_Slot_num_SelectedIndexChanged);
            // 
            // frmSubManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 553);
            this.Controls.Add(this.cb_Slot_num);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_Slot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubManual";
            this.Text = "frmSubManual";
            this.Load += new System.EventHandler(this.frmSubManual_Load);
            this.gb_Slot.ResumeLayout(false);
            this.gb_Slot.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DOOR_OPEN_Button;
        private System.Windows.Forms.Button DOOR_CLOSE_Button;
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
        private System.Windows.Forms.Label Battery_Highest_temp;
        private System.Windows.Forms.Label SOH_percent;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox gb_Slot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox put_Battery_curent;
        private System.Windows.Forms.Button manual_on;
        private System.Windows.Forms.Button set_Current;
        private System.Windows.Forms.Button send_board_Reset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FET_Temp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_serial_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox put_Battery_voltage;
        private System.Windows.Forms.Label lb_battery_arrive;
        private System.Windows.Forms.Label Slot_Temp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_discharging;
        private System.Windows.Forms.ComboBox cb_Slot_num;
    }
}