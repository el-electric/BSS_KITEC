using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using Brush = System.Windows.Media.Brush;
using UserControl = System.Windows.Controls.UserControl;

namespace EL_BSS
{
    /// <summary>
    /// UC_Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UC_Main : UserControl
    {
        private System.Timers.Timer timer;
        System.Windows.Controls.Image[] images;
        System.Windows.Controls.TextBlock[] socs;
        StackPanel[] panels;
        Border[] borders;

        Bitmap empty = Properties.Resources.battery_empty;
        Bitmap batteryIn_doorOpen = Properties.Resources.batteryIn_doorOpen;
        Bitmap doorOpen = Properties.Resources.doorOpen;
        Ellipse[] slaveStatus;
        System.Windows.Shapes.Rectangle[] masterStatus;

        private Brush redBrush;
        private Brush purpleBrush;
        private Brush blueBrush;
        private BitmapImage cachedBatteryInDoorOpen;
        private BitmapImage cachedDoorOpen;
        private BitmapImage cachedEmpty;

        public UC_Main()
        {
            InitializeComponent();

            Loaded += UC_Main_Loaded;


        }

        private void UC_Main_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new System.Timers.Timer(1000); // 1초 간격
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true; // 반복 실행
            timer.Enabled = true;

            images = new System.Windows.Controls.Image[] { img_1, img_2, img_3, img_4, img_5, img_6, img_7, img_8 };
            socs = new TextBlock[] { soc_1, soc_2, soc_3, soc_4, soc_5, soc_6, soc_7, soc_8 };
            borders = new Border[] { border_1, border_2, border_3, border_4, border_5, border_6, border_7, border_8 };
            panels = new StackPanel[] { panel_1, panel_2, panel_3, panel_4, panel_5, panel_6, panel_7, panel_8 };
            slaveStatus = new Ellipse[] { status_1, status_2, status_3, status_4, status_5, status_6, status_7, status_8 };
            masterStatus = new System.Windows.Shapes.Rectangle[] { masterStatus_1, MasterStatus_2 };


            cachedBatteryInDoorOpen = ConvertBitmapToBitmapImage(batteryIn_doorOpen);
            cachedDoorOpen = ConvertBitmapToBitmapImage(doorOpen);
            cachedEmpty = ConvertBitmapToBitmapImage(empty);

            redBrush = (Brush)new BrushConverter().ConvertFrom("#f32b10");
            purpleBrush = (Brush)new BrushConverter().ConvertFrom("#a618f0");
            blueBrush = (Brush)new BrushConverter().ConvertFrom("#2f89f5");

            ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;
            barcodeWriter.Options.Margin = 0;
            barcodeWriter.Options.Width = 180;
            barcodeWriter.Options.Height = 180;
            string qr_data = CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\Config.ini", "STATION", "ID");
            if (qr_data != "")
                img_qr.Source = ConvertBitmapToBitmapImage(barcodeWriter.Write(qr_data));

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < 8; i++)
                {
                    ///////////////////////////////// DOOR ///////////////////////////////////////////
                    if (Model.getInstance().list_SlaveRecv[i].BatterArrive && Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        images[i].Source = cachedBatteryInDoorOpen;
                    }
                    else if (Model.getInstance().list_SlaveRecv[i].BatterArrive && !Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        images[i].Source = null;
                    }
                    else if (!Model.getInstance().list_SlaveRecv[i].BatterArrive && Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        images[i].Source = cachedDoorOpen;

                    }
                    else if (!Model.getInstance().list_SlaveRecv[i].BatterArrive && !Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        images[i].Source = cachedEmpty;
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////

                    ///////////////////////////////// SOC ///////////////////////////////////////////

                    if (Model.getInstance().list_SlaveRecv[i].SOC > 0)
                    {
                        int soc = Model.getInstance().list_SlaveRecv[i].SOC;

                        if (soc < 30)
                            borders[i].Background = redBrush;
                        else if (soc < 60)
                            borders[i].Background = purpleBrush;
                        else
                            borders[i].Background = blueBrush;

                        panels[i].Visibility = Visibility.Visible;
                        socs[i].Text = soc + "%";
                    }

                    else
                    {
                        panels[i].Visibility = Visibility.Hidden;
                    }
                    /////////////////////////////////////////////////////////////////////////////////

                    if (Model.getInstance().list_SlaveDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                        slaveStatus[i].Fill = new SolidColorBrush(Colors.Lime);
                    else
                        slaveStatus[i].Fill = new SolidColorBrush(Colors.Red);
                }

                for (int i = 0; i < 2; i++)
                {
                    if (Model.getInstance().list_MasterDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                        masterStatus[i].Fill = new SolidColorBrush(Colors.Lime);
                    else
                        masterStatus[i].Fill = new SolidColorBrush(Colors.Red);
                }
            }));

            timer.Start();
        }



        public BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            frmFrame.deleMenuClick(3);

            Keyboard.ClearFocus();
        }
    }
}
