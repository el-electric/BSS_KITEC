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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ui_timer_500ms = new System.Windows.Forms.Timer(this.components);
            this.bck_Protocol = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drakeUISymbolLabel1 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.lamp_ems = new DrakeUI.Framework.DrakeUILampLED();
            this.lbl_Notify_Tv = new DrakeUI.Framework.DrakeUILabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bck_Sequnce = new System.ComponentModel.BackgroundWorker();
            this.bck_Counting = new System.ComponentModel.BackgroundWorker();
            this.lbl_time = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 768);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(182)))), ((int)(((byte)(176)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lbl_Notify_Tv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 74);
            this.panel1.TabIndex = 3;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(768, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 74);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 694);
            this.panel2.TabIndex = 5;
            // 
            // bck_Sequnce
            // 
            this.bck_Sequnce.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Sequnce_DoWork);
            // 
            // bck_Counting
            // 
            this.bck_Counting.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Counting_DoWork);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFrame";
            this.Text = "frmFrame";
            this.Load += new System.EventHandler(this.frmFrame_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer ui_timer_500ms;
        private System.ComponentModel.BackgroundWorker bck_Protocol;
        private DrakeUI.Framework.DrakeUISymbolLabel lbl_time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bck_Sequnce;
        private System.ComponentModel.BackgroundWorker bck_Counting;
        public DrakeUI.Framework.DrakeUILabel lbl_Notify_Tv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DrakeUI.Framework.DrakeUISymbolLabel drakeUISymbolLabel1;
        public DrakeUI.Framework.DrakeUILampLED lamp_ems;
        private System.Windows.Forms.Button button1;
    }
}