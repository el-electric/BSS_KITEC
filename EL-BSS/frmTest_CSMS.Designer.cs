namespace EL_BSS
{
    partial class frmTest_CSMS
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_csms = new System.Windows.Forms.TextBox();
            this.btn_clear = new DrakeUI.Framework.DrakeUIButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_wss = new DrakeUI.Framework.DrakeUIButton();
            this.btn_error = new DrakeUI.Framework.DrakeUIButton();
            this.btn_ws_reconnect = new DrakeUI.Framework.DrakeUIButton();
            this.btn_Disconnect = new DrakeUI.Framework.DrakeUIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tb_csms, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tb_csms
            // 
            this.tb_csms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_csms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_csms.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_csms.Location = new System.Drawing.Point(3, 3);
            this.tb_csms.Multiline = true;
            this.tb_csms.Name = "tb_csms";
            this.tb_csms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_csms.Size = new System.Drawing.Size(794, 354);
            this.tb_csms.TabIndex = 0;
            // 
            // btn_clear
            // 
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.FillColor = System.Drawing.Color.White;
            this.btn_clear.FillHoverColor = System.Drawing.Color.White;
            this.btn_clear.FillPressColor = System.Drawing.Color.White;
            this.btn_clear.FillSelectedColor = System.Drawing.Color.White;
            this.btn_clear.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.Location = new System.Drawing.Point(3, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.RectColor = System.Drawing.Color.White;
            this.btn_clear.RectDisableColor = System.Drawing.Color.White;
            this.btn_clear.RectHoverColor = System.Drawing.Color.White;
            this.btn_clear.RectSelectedColor = System.Drawing.Color.White;
            this.btn_clear.Size = new System.Drawing.Size(100, 35);
            this.btn_clear.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_clear);
            this.flowLayoutPanel1.Controls.Add(this.button_wss);
            this.flowLayoutPanel1.Controls.Add(this.btn_error);
            this.flowLayoutPanel1.Controls.Add(this.btn_ws_reconnect);
            this.flowLayoutPanel1.Controls.Add(this.btn_Disconnect);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 363);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 84);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button_wss
            // 
            this.button_wss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_wss.FillColor = System.Drawing.Color.White;
            this.button_wss.FillHoverColor = System.Drawing.Color.White;
            this.button_wss.FillPressColor = System.Drawing.Color.White;
            this.button_wss.FillSelectedColor = System.Drawing.Color.White;
            this.button_wss.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_wss.ForeColor = System.Drawing.Color.Black;
            this.button_wss.Location = new System.Drawing.Point(109, 3);
            this.button_wss.Name = "button_wss";
            this.button_wss.RectColor = System.Drawing.Color.White;
            this.button_wss.RectDisableColor = System.Drawing.Color.White;
            this.button_wss.RectHoverColor = System.Drawing.Color.White;
            this.button_wss.RectSelectedColor = System.Drawing.Color.White;
            this.button_wss.Size = new System.Drawing.Size(100, 35);
            this.button_wss.Style = DrakeUI.Framework.UIStyle.Custom;
            this.button_wss.TabIndex = 2;
            this.button_wss.Text = "WSS Check";
            this.button_wss.Click += new System.EventHandler(this.button_wss_Click);
            // 
            // btn_error
            // 
            this.btn_error.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_error.FillColor = System.Drawing.Color.White;
            this.btn_error.FillHoverColor = System.Drawing.Color.White;
            this.btn_error.FillPressColor = System.Drawing.Color.White;
            this.btn_error.FillSelectedColor = System.Drawing.Color.White;
            this.btn_error.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_error.ForeColor = System.Drawing.Color.Black;
            this.btn_error.Location = new System.Drawing.Point(215, 3);
            this.btn_error.Name = "btn_error";
            this.btn_error.RectColor = System.Drawing.Color.White;
            this.btn_error.RectDisableColor = System.Drawing.Color.White;
            this.btn_error.RectHoverColor = System.Drawing.Color.White;
            this.btn_error.RectSelectedColor = System.Drawing.Color.White;
            this.btn_error.Size = new System.Drawing.Size(100, 35);
            this.btn_error.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_error.TabIndex = 3;
            this.btn_error.Text = "Error Check";
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_ws_reconnect
            // 
            this.btn_ws_reconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ws_reconnect.FillColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.FillHoverColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.FillPressColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.FillSelectedColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ws_reconnect.ForeColor = System.Drawing.Color.Black;
            this.btn_ws_reconnect.Location = new System.Drawing.Point(321, 3);
            this.btn_ws_reconnect.Name = "btn_ws_reconnect";
            this.btn_ws_reconnect.RectColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.RectDisableColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.RectHoverColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.RectSelectedColor = System.Drawing.Color.White;
            this.btn_ws_reconnect.Size = new System.Drawing.Size(100, 35);
            this.btn_ws_reconnect.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_ws_reconnect.TabIndex = 4;
            this.btn_ws_reconnect.Text = "WS Connect";
            this.btn_ws_reconnect.Click += new System.EventHandler(this.btn_ws_reconnect_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Disconnect.FillColor = System.Drawing.Color.White;
            this.btn_Disconnect.FillHoverColor = System.Drawing.Color.White;
            this.btn_Disconnect.FillPressColor = System.Drawing.Color.White;
            this.btn_Disconnect.FillSelectedColor = System.Drawing.Color.White;
            this.btn_Disconnect.Font = new System.Drawing.Font("Pretendard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Disconnect.ForeColor = System.Drawing.Color.Black;
            this.btn_Disconnect.Location = new System.Drawing.Point(427, 3);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.RectColor = System.Drawing.Color.White;
            this.btn_Disconnect.RectDisableColor = System.Drawing.Color.White;
            this.btn_Disconnect.RectHoverColor = System.Drawing.Color.White;
            this.btn_Disconnect.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Disconnect.Size = new System.Drawing.Size(100, 35);
            this.btn_Disconnect.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_Disconnect.TabIndex = 5;
            this.btn_Disconnect.Text = "WS Disconnect";
            this.btn_Disconnect.Click += new System.EventHandler(this.drakeUIButton1_Click);
            // 
            // frmTest_CSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTest_CSMS";
            this.Text = "frmTest_CSMS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTest_CSMS_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_csms;
        private DrakeUI.Framework.DrakeUIButton btn_clear;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DrakeUI.Framework.DrakeUIButton button_wss;
        private DrakeUI.Framework.DrakeUIButton btn_error;
        private DrakeUI.Framework.DrakeUIButton btn_ws_reconnect;
        private DrakeUI.Framework.DrakeUIButton btn_Disconnect;
    }
}