using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS
{
    internal class Vkeyvoard
    {
        [DllImport("User32.DLL")]
        public static extern Boolean PostMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
        public const Int32 WM_USER = 1024;
        public const Int32 WM_CSKEYBOARD = WM_USER + 192;
        public const Int32 WM_CSKEYBOARDMOVE = WM_USER + 193;
        public const Int32 WM_CSKEYBOARDRESIZE = WM_USER + 197;

        static Process keyboardPs = null;

        public void showKeyboard()
        {
            if (keyboardPs == null)
            {
                string filePath;
                if (Environment.Is64BitOperatingSystem)
                {
                    filePath = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"),
                        "amd64_microsoft-windows-osk_*")[0],
                        "osk.exe");
                }
                else
                {
                    filePath = @"C:\windows\system32\osk.exe";
                }
                if (File.Exists(filePath))
                {
                    keyboardPs = Process.Start(filePath);
                }
            }
        }
        public void hideKeyboard()
        {
            if (keyboardPs != null)
            {
                keyboardPs.Kill();
                keyboardPs = null;
            }
        }

        public void moveWindow(int x, int y, int w, int h)
        {
            if (keyboardPs.Handle != null)
            {
                PostMessage(keyboardPs.Handle.ToInt32(), WM_CSKEYBOARDMOVE, x, y); // Move to 0, 0 키보드 좌표
                PostMessage(keyboardPs.Handle.ToInt32(), WM_CSKEYBOARDRESIZE, w, h); // Resize to 600, 300 // 키보드 사이즈
            }
        }
    }
}

