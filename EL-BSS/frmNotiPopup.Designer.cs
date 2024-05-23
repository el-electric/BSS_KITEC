namespace EL_BSS
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_context = new System.Windows.Forms.Label();
            this.drakeUIButton1 = new DrakeUI.Framework.DrakeUIButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EL_BSS.Properties.Resources.bell;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.26042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.73958F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_context, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.drakeUIButton1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.21073F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.81992F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.96935F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbl_context
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_context, 2);
            this.lbl_context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_context.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_context.Location = new System.Drawing.Point(3, 67);
            this.lbl_context.Name = "lbl_context";
            this.lbl_context.Size = new System.Drawing.Size(294, 40);
            this.lbl_context.TabIndex = 1;
            this.lbl_context.Text = "context";
            this.lbl_context.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drakeUIButton1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.drakeUIButton1, 2);
            this.drakeUIButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton1.Location = new System.Drawing.Point(50, 117);
            this.drakeUIButton1.Margin = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.drakeUIButton1.Name = "drakeUIButton1";
            this.drakeUIButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton1.Size = new System.Drawing.Size(200, 23);
            this.drakeUIButton1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton1.TabIndex = 2;
            this.drakeUIButton1.Text = "CLOSE";
            this.drakeUIButton1.Click += new System.EventHandler(this.drakeUIButton1_Click);
            // 
            // frmNotiPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotiPopup";
            this.Text = "frmNotiPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_context;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton1;
    }
}