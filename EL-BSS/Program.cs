using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
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
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // 필요한 경우 애플리케이션 종료
            Application.Exit();
        }
    }
}
