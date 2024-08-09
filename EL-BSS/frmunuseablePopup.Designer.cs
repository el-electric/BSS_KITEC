namespace EL_BSS
{
    partial class frmunuseablePopup
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
            this.lb_Noti = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Noti
            // 
            this.lb_Noti.AutoSize = true;
            this.lb_Noti.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Noti.ForeColor = System.Drawing.Color.White;
            this.lb_Noti.Location = new System.Drawing.Point(68, 255);
            this.lb_Noti.Name = "lb_Noti";
            this.lb_Noti.Size = new System.Drawing.Size(503, 110);
            this.lb_Noti.TabIndex = 0;
            this.lb_Noti.Text = "침수로 인해 사용이 불가합니다.\r\n관리자에게 문의해주세요.";
            this.lb_Noti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmunuseablePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(665, 694);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_Noti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmunuseablePopup";
            this.Opacity = 0.5D;
            this.Text = "frmunuseablePopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Noti;
        private System.Windows.Forms.Button button1;
    }
}