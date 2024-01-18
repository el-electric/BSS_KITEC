using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_BSS
{
    public class CsUtil
    {
        #region INI 읽기/쓰기

        // ==========ini 파일 의 읽고 쓰기를 위한 API 함수 선언 =================
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, int Key,
              string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
              int Size, string FileName);

        // Third Method
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(int Section, string Key,
               string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
               int Size, string FileName);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // ini Read 함수
                    String section,
                    String key,
                     String def,
                    StringBuilder retVal,
                    int size,
                    String filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // ini Write 함수
                    String section,
                    String key,
                    String val,
                    String filePath);
        //==========================================================================


        public static string[] IniReadSectionNames(string iniPath)
        {
            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileString(0, "", "", bytes, maxsize, iniPath);

                if (size < maxsize - 2)
                {
                    string Selected = Encoding.ASCII.GetString(bytes, 0,
                                               size - (size > 0 ? 1 : 0));
                    return Selected.Split(new char[] { '\0' });
                }
            }
        }

        public static string[] IniReadEntryNames(string iniPath, string section)
        {
            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileString(section, 0, "", bytes, maxsize, iniPath);

                if (size < maxsize - 2)
                {
                    string entries = Encoding.ASCII.GetString(bytes, 0,
                                              size - (size > 0 ? 1 : 0));
                    return entries.Split(new char[] { '\0' });
                }
            }
        }

        // ini파일에 쓰기
        public static void IniWriteValue(string iniPath, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }
        public static void IniWriteValue(string iniPath, string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), iniPath);
        }
        public static void IniWriteValue(string iniPath, string Section, string Key, double Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), iniPath);
        }
        public static void IniWriteValue(string iniPath, string Section, string Key, bool Value)
        {
            WritePrivateProfileString(Section, Key, Value ? "1" : "0", iniPath);
        }

        // ini파일에서 읽어 오기
        public static string IniReadValue(string iniPath, string Section, string Key)
        {

            StringBuilder temp = new StringBuilder(2000);

            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, iniPath);

            return temp.ToString();
        }
        public static string IniReadValue(string iniPath, string Section, string Key, string defaltValue)
        {

            StringBuilder temp = new StringBuilder(2000);

            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, iniPath);

            if (temp.ToString() == "")
                return defaltValue;

            return temp.ToString();
        }
        #endregion
        public static async void WriteLog(string LogMessage, string fileName = "Log")
        {
            try
            {
                string LogDate;

                string LogContent;

                LogDate = DateTime.Now.ToString("yyyyMMdd");

                LogContent = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + LogMessage;

                if (!Directory.Exists(Application.StartupPath + "\\" + fileName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0')))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\" + fileName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0'));
                }

                if (!File.Exists(Application.StartupPath + "\\" + fileName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + LogDate + ".Log"))
                {
                    using (StreamWriter stream = File.CreateText(Application.StartupPath + "\\" + fileName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + LogDate + ".Log"))
                    {
                        stream.WriteLine(LogContent);
                    }
                }
                else
                {

                    using (StreamWriter stream = File.AppendText(Application.StartupPath + "\\" + fileName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + LogDate + ".Log"))
                    {
                        stream.WriteLine(LogContent);
                    }
                    await Task.Delay(100);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static byte[] CCITT_Tab_H = {
        0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,
        0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte)0x81,0x40,0x00,(byte)0xC1,(byte)0x81,0x40,0x01,(byte) 0xC0,
        (byte)0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,
        (byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,
        0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,
        0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,
        (byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,
        (byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,
        0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,
        0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,
        (byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,
        (byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,
        0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,
        0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,
        (byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,
        (byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,
        0x00,(byte) 0xC1,(byte) 0x81,0x40,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x01,(byte) 0xC0,(byte) 0x80,0x41,0x00,(byte) 0xC1,(byte) 0x81,
        0x40
    };

        static byte[] CCITT_Tab_L = {
        0x00,(byte) 0xC0,(byte) 0xC1,0x01,(byte) 0xC3,0x03,0x02,(byte) 0xC2,(byte) 0xC6,0x06,0x07,(byte) 0xC7,0x05,(byte) 0xC5,(byte) 0xC4,
        0x04,(byte) 0xCC,0x0C,0x0D,(byte) 0xCD,0x0F,(byte) 0xCF,(byte) 0xCE,0x0E,0x0A,(byte) 0xCA,(byte) 0xCB,0x0B,(byte) 0xC9,0x09,
        0x08,(byte) 0xC8,(byte) 0xD8,0x18,0x19,(byte) 0xD9,0x1B,(byte) 0xDB,(byte) 0xDA,0x1A,0x1E,(byte) 0xDE,(byte) 0xDF,0x1F,(byte) 0xDD,
        0x1D,0x1C,(byte) 0xDC,0x14,(byte) 0xD4,(byte) 0xD5,0x15,(byte) 0xD7,0x17,0x16,(byte) 0xD6,(byte) 0xD2,0x12,0x13,(byte) 0xD3,
        0x11,(byte) 0xD1,(byte) 0xD0,0x10,(byte) 0xF0,0x30,0x31,(byte) 0xF1,0x33,(byte) 0xF3,(byte) 0xF2,0x32,0x36,(byte) 0xF6,(byte) 0xF7,
        0x37,(byte) 0xF5,0x35,0x34,(byte) 0xF4,0x3C,(byte) 0xFC,(byte) 0xFD,0x3D,(byte) 0xFF,0x3F,0x3E,(byte) (byte)0xFE,(byte) 0xFA,0x3A,
        0x3B,(byte) 0xFB,0x39,(byte) 0xF9,(byte) 0xF8,0x38,0x28,(byte) 0xE8,(byte) 0xE9,0x29,(byte) 0xEB,0x2B,0x2A,(byte) 0xEA,(byte) 0xEE,
        0x2E,0x2F,(byte) 0xEF,0x2D,(byte) 0xED,(byte) 0xEC,0x2C,(byte) 0xE4,0x24,0x25,(byte) 0xE5,0x27,(byte) 0xE7,(byte) 0xE6,0x26,
        0x22,(byte) 0xE2,(byte) 0xE3,0x23,(byte) 0xE1,0x21,0x20,(byte) 0xE0,(byte) 0xA0,0x60,0x61,(byte) 0xA1,0x63,(byte) 0xA3,(byte) 0xA2,
        0x62,0x66,(byte) 0xA6,(byte) 0xA7,0x67,(byte) 0xA5,0x65,0x64,(byte) 0xA4,0x6C,(byte) 0xAC,(byte) 0xAD,0x6D,(byte) 0xAF,0x6F,
        0x6E,(byte) 0xAE,(byte) 0xAA,0x6A,0x6B,(byte) 0xAB,0x69,(byte) 0xA9,(byte) 0xA8,0x68,0x78,(byte) 0xB8,(byte) 0xB9,0x79,(byte) 0xBB,
        0x7B,0x7A,(byte) 0xBA,(byte) 0xBE,0x7E,0x7F,(byte) 0xBF,0x7D,(byte) 0xBD,(byte) 0xBC,0x7C,(byte) 0xB4,0x74,0x75,(byte) 0xB5,
        0x77,(byte) 0xB7,(byte) 0xB6,0x76,0x72,(byte) 0xB2,(byte) 0xB3,0x73,(byte) 0xB1,0x71,0x70,(byte) 0xB0,0x50,(byte) 0x90,(byte) 0x91,
        0x51,(byte) 0x93,0x53,0x52,(byte) 0x92,(byte) 0x96,0x56,0x57,(byte) 0x97,0x55,(byte) 0x95,(byte) 0x94,0x54,(byte) 0x9C,0x5C,
        0x5D,(byte) 0x9D,0x5F,(byte) 0x9F,(byte) 0x9E,0x5E,0x5A,(byte) 0x9A,(byte) 0x9B,0x5B,(byte) 0x99,0x59,0x58,(byte) 0x98,(byte) 0x88,
        0x48,0x49,(byte) 0x89,0x4B,(byte) 0x8B,(byte) 0x8A,0x4A,0x4E,(byte) 0x8E,(byte) 0x8F,0x4F,(byte) 0x8D,0x4D,0x4C,(byte) 0x8C,
        0x44,(byte) 0x84,(byte) 0x85,0x45,(byte) 0x87,0x47,0x46,(byte) 0x86,(byte) 0x82,0x42,0x43,(byte) 0x83,0x41,(byte) 0x81,(byte) 0x80,
        0x40
    };
        public static byte[] getCRC16_CCITT(byte[] ptr, int startIndexArray, int endIndex)
        {
            int i, xtmp = 0;
            byte Crc_Hi = (byte)0xff, Crc_Low = (byte)0xff;

            for (i = startIndexArray + 1; i < endIndex - 3; i++)
            {
                xtmp = (byte)(Crc_Hi ^ ptr[i]);
                if (xtmp < 0)
                    xtmp = xtmp + 256;

                Crc_Hi = (byte)(Crc_Low ^ CCITT_Tab_H[xtmp]);
                Crc_Low = CCITT_Tab_L[xtmp];
            }


            return new byte[] { Crc_Hi, Crc_Low };
        }
    }
}
