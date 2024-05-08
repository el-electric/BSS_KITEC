using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _24_BSS_KTC
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        Mutex mutex = null;

        public App()
        {
            // 어플리케이션 이름 확인
            string applicationName = Process.GetCurrentProcess().ProcessName;
            Duplicate_execution(applicationName);
        }
        /// <summary>
        /// 중복실행방지
        /// </summary>
        /// <param name="mutexName"></param>
        private void Duplicate_execution(string mutexName)
        {
            try
            {
                mutex = new Mutex(false, mutexName);
            }
            catch (Exception ex)
            {
                Application.Current.Shutdown();
            }
            if (mutex.WaitOne(0, false))
            {
                InitializeComponent();
            }
            else
            {
                if (MessageBox.Show("프로그램이 이미 실행 중 입니다.") == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
