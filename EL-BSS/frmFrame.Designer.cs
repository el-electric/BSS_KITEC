namespace EL_BSS
{
    partial class frmFrame
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
            this.ui_timer_500ms = new System.Windows.Forms.Timer(this.components);
            this.bck_Protocol = new System.ComponentModel.BackgroundWorker();
            this.bck_Sequnce = new System.ComponentModel.BackgroundWorker();
            this.bck_Counting = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Notify_Tv = new DrakeUI.Framework.DrakeUILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_time = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel1 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.lamp_ems = new DrakeUI.Framework.DrakeUILampLED();
            this.panel1 = new System.Windows.Forms.Panel();
            this.visual = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.drakeUISymbolLabel5 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel4 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel3 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel2 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.lb_authorize_user = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_return = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_authorize = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_lent = new DrakeUI.Framework.DrakeUILabel();
            this.lb_finish = new DrakeUI.Framework.DrakeUILabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.visual.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_timer_500ms
            // 
            this.ui_timer_500ms.Enabled = true;
            this.ui_timer_500ms.Interval = 500;
            this.ui_timer_500ms.Tick += new System.EventHandler(this.ui_timer_500ms_Tick);
            // 
            // bck_Protocol
            // 
            this.bck_Protocol.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Protocol_DoWork);
            // 
            // bck_Sequnce
            // 
            this.bck_Sequnce.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Sequnce_DoWork);
            // 
            // bck_Counting
            // 
            this.bck_Counting.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Counting_DoWork);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 657);
            this.panel2.TabIndex = 5;
            // 
            // lbl_Notify_Tv
            // 
            this.lbl_Notify_Tv.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Notify_Tv.ForeColor = System.Drawing.Color.White;
            this.lbl_Notify_Tv.Location = new System.Drawing.Point(3, 33);
            this.lbl_Notify_Tv.Name = "lbl_Notify_Tv";
            this.lbl_Notify_Tv.Size = new System.Drawing.Size(1018, 41);
            this.lbl_Notify_Tv.TabIndex = 1;
            this.lbl_Notify_Tv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.59288F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.20553F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.drakeUISymbolLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lamp_ems, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(771, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 74);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbl_time
            // 
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.BackgroundImage = global::EL_BSS.Properties.Resources.empty;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_time, 3);
            this.lbl_time.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.White;
            this.lbl_time.Location = new System.Drawing.Point(3, 3);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.lbl_time.Size = new System.Drawing.Size(247, 31);
            this.lbl_time.Style = DrakeUI.Framework.UIStyle.Custom;
            this.lbl_time.Symbol = 125;
            this.lbl_time.SymbolColor = System.Drawing.Color.White;
            this.lbl_time.SymbolSize = 36;
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "drakeUISymbolLabel1";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_time.DoubleClick += new System.EventHandler(this.lbl_time_DoubleClick);
            // 
            // drakeUISymbolLabel1
            // 
            this.drakeUISymbolLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUISymbolLabel1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 14F);
            this.drakeUISymbolLabel1.ForeColor = System.Drawing.Color.White;
            this.drakeUISymbolLabel1.Location = new System.Drawing.Point(87, 40);
            this.drakeUISymbolLabel1.Name = "drakeUISymbolLabel1";
            this.drakeUISymbolLabel1.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.drakeUISymbolLabel1.Size = new System.Drawing.Size(121, 31);
            this.drakeUISymbolLabel1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUISymbolLabel1.Symbol = 57567;
            this.drakeUISymbolLabel1.SymbolColor = System.Drawing.Color.White;
            this.drakeUISymbolLabel1.SymbolSize = 28;
            this.drakeUISymbolLabel1.TabIndex = 1;
            this.drakeUISymbolLabel1.Text = "EMS";
            this.drakeUISymbolLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lamp_ems
            // 
            this.lamp_ems.Color = System.Drawing.Color.Lime;
            this.lamp_ems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lamp_ems.Location = new System.Drawing.Point(214, 40);
            this.lamp_ems.Name = "lamp_ems";
            this.lamp_ems.On = false;
            this.lamp_ems.Size = new System.Drawing.Size(36, 31);
            this.lamp_ems.TabIndex = 2;
            this.lamp_ems.Text = "drakeUILampLED1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lbl_Notify_Tv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 74);
            this.panel1.TabIndex = 3;
            // 
            // visual
            // 
            this.visual.ColumnCount = 1;
            this.visual.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.visual.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.visual.Controls.Add(this.panel2, 0, 0);
            this.visual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visual.Location = new System.Drawing.Point(0, 74);
            this.visual.Name = "visual";
            this.visual.RowCount = 2;
            this.visual.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.73684F));
            this.visual.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.visual.Size = new System.Drawing.Size(1024, 694);
            this.visual.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.Controls.Add(this.lb_finish, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_lent, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_authorize, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_return, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel5, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_authorize_user, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 660);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1018, 31);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // drakeUISymbolLabel5
            // 
            this.drakeUISymbolLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUISymbolLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUISymbolLabel5.Location = new System.Drawing.Point(801, 3);
            this.drakeUISymbolLabel5.Name = "drakeUISymbolLabel5";
            this.drakeUISymbolLabel5.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.drakeUISymbolLabel5.Size = new System.Drawing.Size(44, 25);
            this.drakeUISymbolLabel5.Symbol = 61537;
            this.drakeUISymbolLabel5.TabIndex = 8;
            // 
            // drakeUISymbolLabel4
            // 
            this.drakeUISymbolLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUISymbolLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUISymbolLabel4.Location = new System.Drawing.Point(589, 3);
            this.drakeUISymbolLabel4.Name = "drakeUISymbolLabel4";
            this.drakeUISymbolLabel4.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.drakeUISymbolLabel4.Size = new System.Drawing.Size(44, 25);
            this.drakeUISymbolLabel4.Symbol = 61537;
            this.drakeUISymbolLabel4.TabIndex = 7;
            // 
            // drakeUISymbolLabel3
            // 
            this.drakeUISymbolLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUISymbolLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUISymbolLabel3.Location = new System.Drawing.Point(377, 3);
            this.drakeUISymbolLabel3.Name = "drakeUISymbolLabel3";
            this.drakeUISymbolLabel3.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.drakeUISymbolLabel3.Size = new System.Drawing.Size(44, 25);
            this.drakeUISymbolLabel3.Symbol = 61537;
            this.drakeUISymbolLabel3.TabIndex = 6;
            // 
            // drakeUISymbolLabel2
            // 
            this.drakeUISymbolLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUISymbolLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUISymbolLabel2.Location = new System.Drawing.Point(165, 3);
            this.drakeUISymbolLabel2.Name = "drakeUISymbolLabel2";
            this.drakeUISymbolLabel2.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.drakeUISymbolLabel2.Size = new System.Drawing.Size(44, 25);
            this.drakeUISymbolLabel2.Symbol = 61537;
            this.drakeUISymbolLabel2.TabIndex = 5;
            // 
            // lb_authorize_user
            // 
            this.lb_authorize_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_authorize_user.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_authorize_user.Location = new System.Drawing.Point(3, 0);
            this.lb_authorize_user.Name = "lb_authorize_user";
            this.lb_authorize_user.Size = new System.Drawing.Size(156, 31);
            this.lb_authorize_user.TabIndex = 9;
            this.lb_authorize_user.Text = "사용자 인증";
            this.lb_authorize_user.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_battery_return
            // 
            this.lb_battery_return.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_battery_return.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_battery_return.Location = new System.Drawing.Point(215, 0);
            this.lb_battery_return.Name = "lb_battery_return";
            this.lb_battery_return.Size = new System.Drawing.Size(156, 31);
            this.lb_battery_return.TabIndex = 10;
            this.lb_battery_return.Text = "배터리 반납";
            this.lb_battery_return.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_battery_authorize
            // 
            this.lb_battery_authorize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_battery_authorize.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_battery_authorize.Location = new System.Drawing.Point(427, 0);
            this.lb_battery_authorize.Name = "lb_battery_authorize";
            this.lb_battery_authorize.Size = new System.Drawing.Size(156, 31);
            this.lb_battery_authorize.TabIndex = 11;
            this.lb_battery_authorize.Text = "배터리 인증";
            this.lb_battery_authorize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_battery_lent
            // 
            this.lb_battery_lent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_battery_lent.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_battery_lent.Location = new System.Drawing.Point(639, 0);
            this.lb_battery_lent.Name = "lb_battery_lent";
            this.lb_battery_lent.Size = new System.Drawing.Size(156, 31);
            this.lb_battery_lent.TabIndex = 12;
            this.lb_battery_lent.Text = "배터리 대여";
            this.lb_battery_lent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_finish
            // 
            this.lb_finish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_finish.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_finish.Location = new System.Drawing.Point(851, 0);
            this.lb_finish.Name = "lb_finish";
            this.lb_finish.Size = new System.Drawing.Size(164, 31);
            this.lb_finish.TabIndex = 13;
            this.lb_finish.Text = "사용 완료";
            this.lb_finish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.visual);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFrame";
            this.Text = "frmFrame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFrame_FormClosing);
            this.Load += new System.EventHandler(this.frmFrame_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.visual.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer ui_timer_500ms;
        private System.ComponentModel.BackgroundWorker bck_Protocol;
        private System.ComponentModel.BackgroundWorker bck_Sequnce;
        private System.ComponentModel.BackgroundWorker bck_Counting;
        private System.Windows.Forms.Panel panel2;
        public DrakeUI.Framework.DrakeUILabel lbl_Notify_Tv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DrakeUI.Framework.DrakeUISymbolLabel lbl_time;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel1;
        public DrakeUI.Framework.DrakeUILampLED lamp_ems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel visual;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel4;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel3;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel2;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel5;
        private DrakeUI.Framework.DrakeUILabel lb_authorize_user;
        private DrakeUI.Framework.DrakeUILabel lb_finish;
        private DrakeUI.Framework.DrakeUILabel lb_battery_lent;
        private DrakeUI.Framework.DrakeUILabel lb_battery_authorize;
        private DrakeUI.Framework.DrakeUILabel lb_battery_return;
    }
}