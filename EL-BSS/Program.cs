using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*string a = "FE-00-01-00-01-02-4D-53-31-7A-00-38-00-01-00-00-03-00-02-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-0A-00-00-00-00-00-00-01-01-01-00-01-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-D6-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-9D-B8-FF";

            a = a.Replace("-", "");*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 예외 핸들러 등록
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                if (processes.Length > 1)
                {
                    MessageBox.Show(string.Format("'{0}' 프로그램이 이미 실행 중입니다.", Process.GetCurrentProcess().ProcessName));
                    return;
                }
                ProcessCall(Process.GetCurrentProcess().ProcessName);
                CurPath = Application.StartupPath;

                Application.Run(new frmFrame());
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        // 비 UI 스레드에서 발생한 예외를 처리하는 핸들러
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)

        {
            HandleException(e.ExceptionObject as Exception);
        }

        // 예외를 처리하는 메서드
        private static void HandleException(Exception ex)
        {
            if (ex == null) return;

            // 예외 메시지 구성
            string errorMessage = $"An unexpected error occurred: {ex.Message}\n\n" +
                                  $"Stack Trace:\n{ex.StackTrace}";

            // 이너 예외 처리
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                errorMessage += $"\n\nInner Exception: {innerException.Message}\n" +
                                $"Stack Trace:\n{innerException.StackTrace}";
                innerException = innerException.InnerException;
            }

            // 예외를 로깅하거나 사용자에게 알림
            // MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            CsUtil.WriteLog(errorMessage, "ERROR");

            // 필요한 경우 애플리케이션 종료
            Application.Exit();
        }

        public static string CurPath = string.Empty;

        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("User32")]
        private static extern void BringWindowToTop(IntPtr hwnd);

        private static void ProcessCall(string processName)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == processName)
                {
                    ShowWindow(process.MainWindowHandle, 9);
                    BringWindowToTop(process.MainWindowHandle);
                    SetForegroundWindow(process.MainWindowHandle);
                }
            }
        }
    }
}
