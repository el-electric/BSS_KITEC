namespace EL_BSS
{
    partial class frmCodeInput
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
            this.drakeUILabel1 = new DrakeUI.Framework.DrakeUILabel();
            this.lbl_status = new DrakeUI.Framework.DrakeUILabel();
            this.tb_intput = new DrakeUI.Framework.DrakeUIRichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.drakeUIButton13 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton1 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton2 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton3 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton4 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton5 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton6 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton7 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton8 = new DrakeUI.Framework.DrakeUIButton();
            this.drakeUIButton9 = new DrakeUI.Framework.DrakeUIButton();
            this.btn_enter = new DrakeUI.Framework.DrakeUIButtonIcon();
            this.drakeUIButtonIcon2 = new DrakeUI.Framework.DrakeUIButtonIcon();
            this.drakeUIButtonIcon1 = new DrakeUI.Framework.DrakeUIButtonIcon();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.drakeUILabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_status, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_intput, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 694);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // drakeUILabel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.drakeUILabel1, 2);
            this.drakeUILabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUILabel1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUILabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drakeUILabel1.Location = new System.Drawing.Point(3, 0);
            this.drakeUILabel1.Name = "drakeUILabel1";
            this.drakeUILabel1.Size = new System.Drawing.Size(1018, 138);
            this.drakeUILabel1.TabIndex = 1;
            this.drakeUILabel1.Text = "보안 코드 입력";
            this.drakeUILabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbl_status
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_status, 2);
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_status.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_status.Location = new System.Drawing.Point(3, 138);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(1018, 138);
            this.lbl_status.TabIndex = 2;
            this.lbl_status.Text = "앱에 표시된 6자리 코드를 입력하세요";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_intput
            // 
            this.tb_intput.AutoWordSelection = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tb_intput, 2);
            this.tb_intput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_intput.FillColor = System.Drawing.Color.White;
            this.tb_intput.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_intput.Location = new System.Drawing.Point(100, 276);
            this.tb_intput.Margin = new System.Windows.Forms.Padding(100, 0, 100, 30);
            this.tb_intput.Multiline = false;
            this.tb_intput.Name = "tb_intput";
            this.tb_intput.Padding = new System.Windows.Forms.Padding(2);
            this.tb_intput.Radius = 10;
            this.tb_intput.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.tb_intput.Size = new System.Drawing.Size(824, 108);
            this.tb_intput.Style = DrakeUI.Framework.UIStyle.Custom;
            this.tb_intput.TabIndex = 3;
            this.tb_intput.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton13, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton8, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButton9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_enter, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButtonIcon2, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.drakeUIButtonIcon1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 417);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1018, 274);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // drakeUIButton13
            // 
            this.drakeUIButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton13.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton13.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton13.Location = new System.Drawing.Point(3, 139);
            this.drakeUIButton13.Name = "drakeUIButton13";
            this.drakeUIButton13.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton13.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton13.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton13.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton13.TabIndex = 4;
            this.drakeUIButton13.Text = "8";
            this.drakeUIButton13.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton1
            // 
            this.drakeUIButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton1.Location = new System.Drawing.Point(3, 3);
            this.drakeUIButton1.Name = "drakeUIButton1";
            this.drakeUIButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton1.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton1.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton1.TabIndex = 0;
            this.drakeUIButton1.Text = "1";
            this.drakeUIButton1.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton2
            // 
            this.drakeUIButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton2.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton2.Location = new System.Drawing.Point(257, 3);
            this.drakeUIButton2.Name = "drakeUIButton2";
            this.drakeUIButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton2.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton2.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton2.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton2.TabIndex = 0;
            this.drakeUIButton2.Text = "2";
            this.drakeUIButton2.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton3
            // 
            this.drakeUIButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton3.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton3.Location = new System.Drawing.Point(511, 3);
            this.drakeUIButton3.Name = "drakeUIButton3";
            this.drakeUIButton3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton3.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton3.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton3.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton3.TabIndex = 0;
            this.drakeUIButton3.Text = "3";
            this.drakeUIButton3.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton4
            // 
            this.drakeUIButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton4.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton4.Location = new System.Drawing.Point(3, 71);
            this.drakeUIButton4.Name = "drakeUIButton4";
            this.drakeUIButton4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton4.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton4.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton4.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton4.TabIndex = 0;
            this.drakeUIButton4.Text = "4";
            this.drakeUIButton4.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton5
            // 
            this.drakeUIButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton5.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton5.Location = new System.Drawing.Point(257, 71);
            this.drakeUIButton5.Name = "drakeUIButton5";
            this.drakeUIButton5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton5.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton5.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton5.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton5.TabIndex = 0;
            this.drakeUIButton5.Text = "5";
            this.drakeUIButton5.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton6
            // 
            this.drakeUIButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton6.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton6.Location = new System.Drawing.Point(511, 71);
            this.drakeUIButton6.Name = "drakeUIButton6";
            this.drakeUIButton6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton6.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton6.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton6.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton6.TabIndex = 0;
            this.drakeUIButton6.Text = "6";
            this.drakeUIButton6.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton7
            // 
            this.drakeUIButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton7.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton7.Location = new System.Drawing.Point(257, 139);
            this.drakeUIButton7.Name = "drakeUIButton7";
            this.drakeUIButton7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton7.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton7.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton7.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton7.TabIndex = 0;
            this.drakeUIButton7.Text = "7";
            this.drakeUIButton7.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton8
            // 
            this.drakeUIButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton8.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton8.Location = new System.Drawing.Point(257, 207);
            this.drakeUIButton8.Name = "drakeUIButton8";
            this.drakeUIButton8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton8.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton8.Size = new System.Drawing.Size(248, 64);
            this.drakeUIButton8.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton8.TabIndex = 8;
            this.drakeUIButton8.Text = "0";
            this.drakeUIButton8.Click += new System.EventHandler(this.NumClick);
            // 
            // drakeUIButton9
            // 
            this.drakeUIButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButton9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drakeUIButton9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton9.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButton9.Location = new System.Drawing.Point(511, 139);
            this.drakeUIButton9.Name = "drakeUIButton9";
            this.drakeUIButton9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButton9.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButton9.Size = new System.Drawing.Size(248, 62);
            this.drakeUIButton9.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButton9.TabIndex = 9;
            this.drakeUIButton9.Text = "9";
            this.drakeUIButton9.Click += new System.EventHandler(this.NumClick);
            // 
            // btn_enter
            // 
            this.btn_enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_enter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_enter.FillDisableColor = System.Drawing.Color.Silver;
            this.btn_enter.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_enter.Location = new System.Drawing.Point(765, 207);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btn_enter.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btn_enter.Size = new System.Drawing.Size(250, 64);
            this.btn_enter.Style = DrakeUI.Framework.UIStyle.Custom;
            this.btn_enter.Symbol = 61584;
            this.btn_enter.TabIndex = 11;
            this.btn_enter.Text = "ENTER";
            this.btn_enter.Click += new System.EventHandler(this.drakeUIButtonIcon1_Click);
            // 
            // drakeUIButtonIcon2
            // 
            this.drakeUIButtonIcon2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButtonIcon2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButtonIcon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drakeUIButtonIcon2.Location = new System.Drawing.Point(511, 207);
            this.drakeUIButtonIcon2.Name = "drakeUIButtonIcon2";
            this.drakeUIButtonIcon2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.drakeUIButtonIcon2.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButtonIcon2.Size = new System.Drawing.Size(248, 64);
            this.drakeUIButtonIcon2.Style = DrakeUI.Framework.UIStyle.Custom;
            this.drakeUIButtonIcon2.Symbol = 61536;
            this.drakeUIButtonIcon2.SymbolSize = 36;
            this.drakeUIButtonIcon2.TabIndex = 12;
            this.drakeUIButtonIcon2.Click += new System.EventHandler(this.drakeUIButtonIcon2_Click);
            // 
            // drakeUIButtonIcon1
            // 
            this.drakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drakeUIButtonIcon1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.drakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.drakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.drakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.drakeUIButtonIcon1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drakeUIButtonIcon1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.drakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.drakeUIButtonIcon1.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.drakeUIButtonIcon1.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.drakeUIButtonIcon1.Location = new System.Drawing.Point(765, 3);
            this.drakeUIButtonIcon1.Name = "drakeUIButtonIcon1";
            this.drakeUIButtonIcon1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.drakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.drakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.drakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.drakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.drakeUIButtonIcon1.Size = new System.Drawing.Size(250, 62);
            this.drakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.DrakeColorSilver;
            this.drakeUIButtonIcon1.Symbol = 61461;
            this.drakeUIButtonIcon1.SymbolSize = 48;
            this.drakeUIButtonIcon1.TabIndex = 13;
            this.drakeUIButtonIcon1.Text = "HOME";
            this.drakeUIButtonIcon1.Click += new System.EventHandler(this.drakeUIButtonIcon1_Click_1);
            // 
            // frmCodeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1024, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCodeInput";
            this.Text = "frmCodeInput";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DrakeUI.Framework.DrakeUILabel drakeUILabel1;
        private DrakeUI.Framework.DrakeUILabel lbl_status;
        private DrakeUI.Framework.DrakeUIRichTextBox tb_intput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton1;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton2;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton3;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton4;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton5;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton6;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton7;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton13;
        private DrakeUI.Framework.DrakeUIButtonIcon btn_enter;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton8;
        private DrakeUI.Framework.DrakeUIButton drakeUIButton9;
        private DrakeUI.Framework.DrakeUIButtonIcon drakeUIButtonIcon2;
        private DrakeUI.Framework.DrakeUIButtonIcon drakeUIButtonIcon1;
    }
}