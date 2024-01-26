namespace EL_BSS
{
    partial class frmPopup
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
            this.drakeUIButton1 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUILabel1 = new DrakeUI.Framework.DrakeUILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drakeUIButton1
            // 
            this.drakeUIButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUIButton1.Location = new System.Drawing.Point(264, 242);
            this.drakeUIButton1.Name = "drakeUIButton1";
            this.drakeUIButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton1.Size = new System.Drawing.Size(124, 38);
            this.drakeUIButton1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton1.TabIndex = 0;
            this.drakeUIButton1.Text = "버튼";
            this.drakeUIButton1.Click += new System.EventHandler(this.drakeUIButton1_Click);
            // 
            // drakeUILabel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.drakeUILabel1, 3);
            this.drakeUILabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUILabel1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.drakeUILabel1.Location = new System.Drawing.Point(68, 68);
            this.drakeUILabel1.Name = "drakeUILabel1";
            this.drakeUILabel1.Size = new System.Drawing.Size(516, 156);
            this.drakeUILabel1.TabIndex = 1;
            this.drakeUILabel1.Text = "펌웨어 업데이트 중입니다. \n 잠시만 기다려 주세요.";
            this.drakeUILabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.drakeUIButton1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.drakeUILabel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.38229F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.61771F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 327);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 327);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPopup";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DrakeUI.Framework.DrakeUIButton drakeUIButton1;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}