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
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tb_csms, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_clear, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
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
            this.btn_clear.Location = new System.Drawing.Point(3, 363);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_csms;
        private DrakeUI.Framework.DrakeUIButton btn_clear;
    }
}