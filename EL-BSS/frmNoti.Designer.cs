﻿namespace EL_BSS
{
    partial class frmNoti
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
            this.drakeUILoadingBar1 = new DrakeUI.Framework.DrakeUILoadingBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_content = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drakeUILoadingBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.drakeUILoadingBar1, 2);
            this.drakeUILoadingBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUILoadingBar1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drakeUILoadingBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUILoadingBar1.Location = new System.Drawing.Point(3, 118);
            this.drakeUILoadingBar1.Name = "drakeUILoadingBar1";
            this.tableLayoutPanel1.SetRowSpan(this.drakeUILoadingBar1, 2);
            this.drakeUILoadingBar1.Size = new System.Drawing.Size(1018, 224);
            this.drakeUILoadingBar1.TabIndex = 0;
            this.drakeUILoadingBar1.Text = "서버와 연결 중 입니다";
            this.drakeUILoadingBar1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.drakeUILoadingBar1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_content, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 694);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbl_content
            // 
            this.lbl_content.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_content, 2);
            this.lbl_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_content.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_content.Location = new System.Drawing.Point(3, 345);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.tableLayoutPanel1.SetRowSpan(this.lbl_content, 2);
            this.lbl_content.Size = new System.Drawing.Size(1018, 230);
            this.lbl_content.TabIndex = 1;
            this.lbl_content.Text = "메시지";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmNoti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1024, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNoti";
            this.Text = "frmNoti";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DrakeUI.Framework.DrakeUILoadingBar drakeUILoadingBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_content;
    }
}