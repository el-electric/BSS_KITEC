﻿namespace EL_BSS
{
    partial class frmNotiPopup
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
            this.lbl_context = new System.Windows.Forms.Label();
            this.drakeUIButton1 = new DrakeUI.Framework.DrakeUIButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.26042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.73958F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_context, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.drakeUIButton1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.21073F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.81992F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.96935F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 200);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbl_context
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_context, 2);
            this.lbl_context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_context.Font = new System.Drawing.Font("Pretendard", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_context.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_context.Location = new System.Drawing.Point(3, 90);
            this.lbl_context.Name = "lbl_context";
            this.lbl_context.Size = new System.Drawing.Size(344, 53);
            this.lbl_context.TabIndex = 1;
            this.lbl_context.Text = "ㅇㅇㅇㅇ";
            this.lbl_context.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUIButton1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.drakeUIButton1, 2);
            this.drakeUIButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(245)))));
            this.drakeUIButton1.FillHoverColor = System.Drawing.Color.White;
            this.drakeUIButton1.FillPressColor = System.Drawing.Color.White;
            this.drakeUIButton1.FillSelectedColor = System.Drawing.Color.White;
            this.drakeUIButton1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton1.Location = new System.Drawing.Point(50, 153);
            this.drakeUIButton1.Margin = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.drakeUIButton1.Name = "drakeUIButton1";
            this.drakeUIButton1.RectColor = System.Drawing.Color.White;
            this.drakeUIButton1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton1.Size = new System.Drawing.Size(250, 37);
            this.drakeUIButton1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton1.TabIndex = 2;
            this.drakeUIButton1.Text = "CLOSE";
            this.drakeUIButton1.Click += new System.EventHandler(this.drakeUIButton1_Click);
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EL_BSS.Properties.Resources.reddanger1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmNotiPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotiPopup";
            this.Text = "frmNotiPopup";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_context;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}