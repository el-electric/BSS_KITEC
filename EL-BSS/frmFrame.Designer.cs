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
            this.panel2 = new System.Windows.Forms.Panel();
            this.bck_Protocol = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_time = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.panel1.SuspendLayout();
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 694);
            this.panel2.TabIndex = 4;
            // 
            // bck_Protocol
            // 
            this.bck_Protocol.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bck_Protocol_DoWork);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::EL_BSS.Properties.Resources.bgTitle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbl_time);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 74);
            this.panel1.TabIndex = 3;
            // 
            // lbl_time
            // 
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.BackgroundImage = global::EL_BSS.Properties.Resources.empty;
            this.lbl_time.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.Black;
            this.lbl_time.Location = new System.Drawing.Point(759, 3);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.lbl_time.Size = new System.Drawing.Size(259, 36);
            this.lbl_time.Style = DrakeUI.Framework.UIStyle.Custom;
            this.lbl_time.Symbol = 125;
            this.lbl_time.SymbolSize = 36;
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "drakeUISymbolLabel1";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_time.DoubleClick += new System.EventHandler(this.lbl_time_DoubleClick);
            // 
            // frmFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFrame";
            this.Text = "frmFrame";
            this.Load += new System.EventHandler(this.frmFrame_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer ui_timer_500ms;
        private System.Windows.Forms.Panel panel1;
        private DrakeUI.Framework.DrakeUISymbolLabel lbl_time;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bck_Protocol;
    }
}