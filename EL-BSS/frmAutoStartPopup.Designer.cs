namespace EL_BSS
{
    partial class frmAutoStartPopup
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
            this.btn_add_service = new DrakeUI.Framework.DrakeUIButton();
            this.btn_remove_service = new DrakeUI.Framework.DrakeUIButton();
            this.btn_confirm_service = new DrakeUI.Framework.DrakeUIButton();
            this.lb_auto_start = new DrakeUI.Framework.DrakeUILabel();
            this.btn_close = new DrakeUI.Framework.DrakeUIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_add_service, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_remove_service, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_confirm_service, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_auto_start, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_close, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_add_service
            // 
            this.btn_add_service.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add_service.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_add_service.Font = new System.Drawing.Font("Pretendard", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_add_service.Location = new System.Drawing.Point(23, 105);
            this.btn_add_service.Name = "btn_add_service";
            this.btn_add_service.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_add_service.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btn_add_service.Size = new System.Drawing.Size(130, 49);
            this.btn_add_service.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_add_service.TabIndex = 0;
            this.btn_add_service.Text = "등록";
            this.btn_add_service.Click += new System.EventHandler(this.btn_add_service_Click);
            // 
            // btn_remove_service
            // 
            this.btn_remove_service.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_remove_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_remove_service.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_remove_service.Font = new System.Drawing.Font("Pretendard", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_remove_service.Location = new System.Drawing.Point(227, 105);
            this.btn_remove_service.Name = "btn_remove_service";
            this.btn_remove_service.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_remove_service.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btn_remove_service.Size = new System.Drawing.Size(130, 49);
            this.btn_remove_service.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_remove_service.TabIndex = 1;
            this.btn_remove_service.Text = "제거";
            this.btn_remove_service.Click += new System.EventHandler(this.btn_remove_service_Click);
            // 
            // btn_confirm_service
            // 
            this.btn_confirm_service.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_confirm_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_confirm_service.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_confirm_service.Font = new System.Drawing.Font("Pretendard", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_confirm_service.Location = new System.Drawing.Point(431, 105);
            this.btn_confirm_service.Name = "btn_confirm_service";
            this.btn_confirm_service.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_confirm_service.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btn_confirm_service.Size = new System.Drawing.Size(130, 49);
            this.btn_confirm_service.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_confirm_service.TabIndex = 2;
            this.btn_confirm_service.Text = "확인";
            this.btn_confirm_service.Click += new System.EventHandler(this.btn_confirm_service_Click);
            // 
            // lb_auto_start
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lb_auto_start, 5);
            this.lb_auto_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_auto_start.Font = new System.Drawing.Font("Pretendard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_auto_start.Location = new System.Drawing.Point(23, 184);
            this.lb_auto_start.Name = "lb_auto_start";
            this.lb_auto_start.Size = new System.Drawing.Size(538, 55);
            this.lb_auto_start.TabIndex = 3;
            this.lb_auto_start.Text = "자동실행을 등록해주세요";
            this.lb_auto_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_close.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_close.Font = new System.Drawing.Font("Pretendard", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_close.Location = new System.Drawing.Point(431, 23);
            this.btn_close.Name = "btn_close";
            this.btn_close.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_close.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btn_close.Size = new System.Drawing.Size(130, 49);
            this.btn_close.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "닫기";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // frmAutoStartPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "frmAutoStartPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmAutoStartPopup";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DrakeUI.Framework.DrakeUIButton btn_add_service;
        private DrakeUI.Framework.DrakeUIButton btn_remove_service;
        private DrakeUI.Framework.DrakeUIButton btn_confirm_service;
        private DrakeUI.Framework.DrakeUILabel lb_auto_start;
        private DrakeUI.Framework.DrakeUIButton btn_close;
    }
}