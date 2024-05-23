using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public partial class frmNotiPopup : Form, IDisposable
    {
        private Timer showTimer;
        private Timer hideTimer;
        private int targetPositionY;
        private int startPositionY;
        private int _showingTime = 3000;
        Form parentForm;

        public frmNotiPopup(Form parentForm, int showingTime = 3000, string context = "")
        {
            InitializeComponent();
            InitializeTimers();
            this.parentForm = parentForm;
            _showingTime = showingTime;

            lbl_context.Text = context;
        }

        private void InitializeTimers()
        {
            showTimer = new Timer();
            showTimer.Interval = 1; // 타이머 간격 (밀리초)
            showTimer.Tick += ShowTimer_Tick;

            hideTimer = new Timer();
            hideTimer.Interval = 1; // 타이머 간격 (밀리초)
            hideTimer.Tick += HideTimer_Tick;
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            if (this.Top > targetPositionY)
            {
                this.Top -= 5; // 폼이 올라가는 속도
            }
            else
            {
                showTimer.Stop();
                Timer delayTimer = new Timer();
                delayTimer.Interval = _showingTime; // 폼이 유지될 시간 (밀리초)
                delayTimer.Tick += (s, args) =>
                {
                    delayTimer.Stop();
                    delayTimer.Dispose(); // 타이머 해제
                    hideTimer.Start();
                };
                delayTimer.Start();
            }
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Top < startPositionY)
            {
                this.Top += 5; // 폼이 내려가는 속도
            }
            else
            {
                hideTimer.Stop();
                this.Close();
            }
        }

        public void ShowNotification()
        {
            this.StartPosition = FormStartPosition.Manual;

            // 부모 폼의 위치와 크기를 기준으로 NotificationForm의 위치 설정
            startPositionY = parentForm.Bottom;
            targetPositionY = parentForm.Bottom - this.Height; // 폼이 멈출 위치

            this.Location = new Point(parentForm.Left + (parentForm.Width - this.Width) / 2, startPositionY);
            this.TopMost = true;

            showTimer.Start();
            this.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // 타이머 해제
            showTimer.Stop();
            showTimer.Dispose();

            hideTimer.Stop();
            hideTimer.Dispose();
        }        

        private void drakeUIButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
