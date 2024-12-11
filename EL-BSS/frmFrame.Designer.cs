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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFrame));
            this.ui_timer_500ms = new System.Windows.Forms.Timer(this.components);
            this.bck_Protocol = new System.ComponentModel.BackgroundWorker();
            this.bck_Sequnce = new System.ComponentModel.BackgroundWorker();
            this.bck_Counting = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Notify_Tv = new DrakeUI.Framework.DrakeUILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drakeUISymbolLabel1 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.lamp_ems = new DrakeUI.Framework.DrakeUILampLED();
            this.panel1 = new System.Windows.Forms.Panel();
            this.visual = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_finish = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_lent = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_authorize = new DrakeUI.Framework.DrakeUILabel();
            this.lb_battery_return = new DrakeUI.Framework.DrakeUILabel();
            this.drakeUISymbolLabel5 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel4 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel3 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.drakeUISymbolLabel2 = new DrakeUI.Framework.DrakeUISymbolLabel();
            this.lb_authorize_user = new DrakeUI.Framework.DrakeUILabel();
            this.lbl_time = new DrakeUI.Framework.DrakeUISymbolLabel();
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Name = "panel2";
            // 
            // lbl_Notify_Tv
            // 
            resources.ApplyResources(this.lbl_Notify_Tv, "lbl_Notify_Tv");
            this.lbl_Notify_Tv.ForeColor = System.Drawing.Color.White;
            this.lbl_Notify_Tv.Name = "lbl_Notify_Tv";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lbl_time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.drakeUISymbolLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lamp_ems, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // drakeUISymbolLabel1
            // 
            resources.ApplyResources(this.drakeUISymbolLabel1, "drakeUISymbolLabel1");
            this.drakeUISymbolLabel1.ForeColor = System.Drawing.Color.White;
            this.drakeUISymbolLabel1.Name = "drakeUISymbolLabel1";
            this.drakeUISymbolLabel1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUISymbolLabel1.Symbol = 57567;
            this.drakeUISymbolLabel1.SymbolColor = System.Drawing.Color.White;
            this.drakeUISymbolLabel1.SymbolSize = 28;
            this.drakeUISymbolLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lamp_ems
            // 
            resources.ApplyResources(this.lamp_ems, "lamp_ems");
            this.lamp_ems.Color = System.Drawing.Color.Lime;
            this.lamp_ems.Name = "lamp_ems";
            this.lamp_ems.On = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lbl_Notify_Tv);
            this.panel1.Name = "panel1";
            // 
            // visual
            // 
            resources.ApplyResources(this.visual, "visual");
            this.visual.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.visual.Controls.Add(this.panel2, 0, 0);
            this.visual.Name = "visual";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lb_finish, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_lent, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_authorize, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_battery_return, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel5, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUISymbolLabel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_authorize_user, 0, 0);
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // lb_finish
            // 
            resources.ApplyResources(this.lb_finish, "lb_finish");
            this.lb_finish.Name = "lb_finish";
            // 
            // lb_battery_lent
            // 
            resources.ApplyResources(this.lb_battery_lent, "lb_battery_lent");
            this.lb_battery_lent.Name = "lb_battery_lent";
            // 
            // lb_battery_authorize
            // 
            resources.ApplyResources(this.lb_battery_authorize, "lb_battery_authorize");
            this.lb_battery_authorize.Name = "lb_battery_authorize";
            // 
            // lb_battery_return
            // 
            resources.ApplyResources(this.lb_battery_return, "lb_battery_return");
            this.lb_battery_return.Name = "lb_battery_return";
            // 
            // drakeUISymbolLabel5
            // 
            resources.ApplyResources(this.drakeUISymbolLabel5, "drakeUISymbolLabel5");
            this.drakeUISymbolLabel5.Name = "drakeUISymbolLabel5";
            this.drakeUISymbolLabel5.Symbol = 61537;
            // 
            // drakeUISymbolLabel4
            // 
            resources.ApplyResources(this.drakeUISymbolLabel4, "drakeUISymbolLabel4");
            this.drakeUISymbolLabel4.Name = "drakeUISymbolLabel4";
            this.drakeUISymbolLabel4.Symbol = 61537;
            // 
            // drakeUISymbolLabel3
            // 
            resources.ApplyResources(this.drakeUISymbolLabel3, "drakeUISymbolLabel3");
            this.drakeUISymbolLabel3.Name = "drakeUISymbolLabel3";
            this.drakeUISymbolLabel3.Symbol = 61537;
            // 
            // drakeUISymbolLabel2
            // 
            resources.ApplyResources(this.drakeUISymbolLabel2, "drakeUISymbolLabel2");
            this.drakeUISymbolLabel2.Name = "drakeUISymbolLabel2";
            this.drakeUISymbolLabel2.Symbol = 61537;
            // 
            // lb_authorize_user
            // 
            resources.ApplyResources(this.lb_authorize_user, "lb_authorize_user");
            this.lb_authorize_user.Name = "lb_authorize_user";
            // 
            // lbl_time
            // 
            resources.ApplyResources(this.lbl_time, "lbl_time");
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.BackgroundImage = global::EL_BSS.Properties.Resources.empty;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_time, 3);
            this.lbl_time.ForeColor = System.Drawing.Color.White;
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Style = DrakeUI.Framework.UIStyle.Custom;
            this.lbl_time.Symbol = 125;
            this.lbl_time.SymbolColor = System.Drawing.Color.White;
            this.lbl_time.SymbolSize = 36;
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_time.DoubleClick += new System.EventHandler(this.lbl_time_DoubleClick);
            // 
            // frmFrame
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.visual);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFrame";
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