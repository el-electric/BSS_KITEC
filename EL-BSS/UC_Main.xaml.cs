﻿using EL_BSS.Cycle;
using EL_BSS.Serial;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static EL_BSS.frmNotiPopup;
using static EL_BSS.Model;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using Brush = System.Windows.Media.Brush;
using UserControl = System.Windows.Controls.UserControl;
using Image = System.Windows.Controls.Image;
namespace EL_BSS
{
    /// <summary>
    /// UC_Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UC_Main : UserControl
    {
        public System.Timers.Timer timer;
        System.Windows.Controls.Image[] images;
        System.Windows.Controls.TextBlock[] socs;
        StackPanel[] panels;
        Border[] borders;
        Border[] colorBoders;

        Bitmap empty = Properties.Resources.battery_empty;
        Bitmap batteryIn_doorOpen = Properties.Resources.batteryIn_doorOpen;
        Bitmap doorOpen = Properties.Resources.doorOpen;
        Bitmap batteryIn_doorOpen_Error = Properties.Resources.dooropen_batteryin_error;
        Bitmap batteryin_doorclose_Error = Properties.Resources.doorclose_batteryout_error;
        Bitmap doorOpen_Error = Properties.Resources.doorOpen_danger;
        Bitmap empty_Error = Properties.Resources.battery_empty_danger;
        Ellipse[] slaveStatus;
        System.Windows.Shapes.Rectangle[] masterStatus;

        private Brush redBrush;
        private Brush purpleBrush;
        private Brush blueBrush;
        private BitmapImage cachedBatteryInDoorOpen;
        private BitmapImage cachedDoorOpen;
        private BitmapImage cachedEmpty;
        private BitmapImage cachedbatteryIn_doorOpen_Error;
        private BitmapImage cachedbatteryin_doorclose_Error;
        private BitmapImage cachedDoorOpen_Error;
        private BitmapImage cachedDoorClose_Error;
        //클릭으로 문열기
        private DispatcherTimer longPressTimer;
        private const int LongPressThreshold = 1000; // 롱클릭 시간 (밀리초)
        private System.Windows.Controls.Image currentPressedImage;

        public UC_Main()
        {
            InitializeComponent();

            Loaded += UC_Main_Loaded;

#if DEBUG
            btn_test.Visibility = Visibility.Visible;
            panel_version.Visibility = Visibility.Visible;
#endif

            /*Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"{version.Major}.{version.Minor}.{version.Build}";

            sw_version.Text = versionString;
            fw_version.Text = Model.getInstance().list_MasterRecv[0].FW_ver;*/
        }

        private void UC_Main_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new System.Timers.Timer(1000); // 1초 간격
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true; // 반복 실행
            timer.Enabled = true;

            images = new System.Windows.Controls.Image[] { img_1, img_2, img_3, img_4, img_5, img_6, img_7, img_8 };

            longPressTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(LongPressThreshold)
            };
            longPressTimer.Tick += LongPressTimer_Tick;
            foreach (var image in images)
            {
                image.PreviewMouseLeftButtonDown += Image_MouseLeftButtonDown;
                image.PreviewMouseLeftButtonUp += Image_MouseLeftButtonUp;
                image.MouseLeave += Image_MouseLeave;
            }





            socs = new TextBlock[] { soc_1, soc_2, soc_3, soc_4, soc_5, soc_6, soc_7, soc_8 };
            borders = new Border[] { border_1, border_2, border_3, border_4, border_5, border_6, border_7, border_8 };
            panels = new StackPanel[] { panel_1, panel_2, panel_3, panel_4, panel_5, panel_6, panel_7, panel_8 };
            colorBoders = new Border[] { color_bar1, color_bar2, color_bar3, color_bar4, color_bar5, color_bar6, color_bar7, color_bar8 };
            slaveStatus = new Ellipse[] { status_1, status_2, status_3, status_4, status_5, status_6, status_7, status_8 };
            masterStatus = new System.Windows.Shapes.Rectangle[] { masterStatus_1, MasterStatus_2 };


            cachedBatteryInDoorOpen = ConvertBitmapToBitmapImage(batteryIn_doorOpen);
            cachedDoorOpen = ConvertBitmapToBitmapImage(doorOpen);
            cachedEmpty = ConvertBitmapToBitmapImage(empty);
            cachedbatteryIn_doorOpen_Error = ConvertBitmapToBitmapImage(batteryIn_doorOpen_Error);
            cachedbatteryin_doorclose_Error = ConvertBitmapToBitmapImage(batteryin_doorclose_Error);
            cachedDoorOpen_Error = ConvertBitmapToBitmapImage(doorOpen_Error);
            cachedDoorClose_Error = ConvertBitmapToBitmapImage(empty_Error);


            redBrush = (Brush)new BrushConverter().ConvertFrom("#f32b10");
            purpleBrush = (Brush)new BrushConverter().ConvertFrom("#a618f0");
            blueBrush = (Brush)new BrushConverter().ConvertFrom("#2f89f5");

            ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;
            barcodeWriter.Options.Margin = 0;
            barcodeWriter.Options.Width = 180;
            barcodeWriter.Options.Height = 180;
            //string qr_data = CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\Config.ini", "CSMS", "chargeBoxSerialNumber");
            //string qr_data = "https://voltymos.com/%ED%94%84%EB%A6%AC%ED%85%8C%EC%8A%A4%ED%8A%B8%20%EC%8A%A4%ED%85%8C%EC%9D%B4%EC%85%98/BSSStation01";

            string qr_data = "https://voltymos.com/%ED%94%84%EB%A6%AC%ED%85%8C%EC%8A%A4%ED%8A%B8%20%EC%8A%A4%ED%85%8C%EC%9D%B4%EC%85%98/" + CsUtil.IniReadValue(System.Windows.Forms.Application.StartupPath + @"\Config.ini", "CSMS", "chargeBoxSerialNumber");
            if (qr_data != "")
                img_qr.Source = ConvertBitmapToBitmapImage(barcodeWriter.Write(qr_data));


            ZXing.BarcodeWriter voltymos_qr = new ZXing.BarcodeWriter();
            voltymos_qr.Format = ZXing.BarcodeFormat.QR_CODE;
            voltymos_qr.Options.Margin = 0;
            voltymos_qr.Options.Width = 110;
            voltymos_qr.Options.Height = 110;
            string qr_vos = "https://www.kitech.re.kr/main/gate.htm";
            if (qr_vos != "")
                img_qr_voltimos.Source = ConvertBitmapToBitmapImage(voltymos_qr.Write(qr_vos));

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"{version.Major}.{version.Minor}.{version.Build}";

            sw_version.Text = "SW Ver : " + versionString;
            fw_version.Text = "FW Ver : " + Model.getInstance().list_MasterRecv[0].FW_ver;
        }
        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            longPressTimer.Stop();
            currentPressedImage = null;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            longPressTimer.Stop();
            currentPressedImage = null;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentPressedImage = sender as Image;
            longPressTimer.Start();

        }

        private void LongPressTimer_Tick(object sender, EventArgs e)
        {
            longPressTimer.Stop();

            if (currentPressedImage != null)
            {
                // 롱클릭 동작 처리
                int idx = int.Parse(currentPressedImage.Name.Substring(4, 1)) - 1;
                Model.getInstance().list_SlaveSend[idx].doorOpen = true;

            }
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
                        if (Model.getInstance().list_SlaveRecv[i].Error_Occured)
                        {

                            images[i].Source = cachedbatteryIn_doorOpen_Error;
                        }
                        else
                        {
                            images[i].Source = cachedBatteryInDoorOpen;
                        }
                        //images[i].Source = cachedBatteryInDoorOpen;

                        /*images[i].Source = cashedDanger;
                        images[i].Height = 60;
                        images[i].Width = 60;
                        images[i].Margin = new Thickness(25, 25, 0, 0);*/
                    }
                    else if (Model.getInstance().list_SlaveRecv[i].BatterArrive && !Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        if (Model.getInstance().list_SlaveRecv[i].Error_Occured)
                        {
                            images[i].Source = cachedbatteryin_doorclose_Error;
                        }
                        else
                        {
                            images[i].Source = CreateTransparentImage();
                        }


                        /*images[i].Height = 108;
                        images[i].Width = 124;
                        images[i].Margin = new Thickness(0, 0, 0, 0);*/
                    }
                    else if (!Model.getInstance().list_SlaveRecv[i].BatterArrive && Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        /*images[i].Height = 108;
                        images[i].Width = 124;
                        images[i].Margin = new Thickness(0, 0, 0, 0);*/


                        if (Model.getInstance().list_SlaveRecv[i].Error_Occured)
                        {
                            images[i].Source = cachedDoorOpen_Error;
                        }
                        else
                        {
                            images[i].Source = cachedDoorOpen;
                        }

                    }
                    else if (!Model.getInstance().list_SlaveRecv[i].BatterArrive && !Model.getInstance().list_SlaveRecv[i].isDoor)
                    {
                        /*images[i].Height = 108;
                        images[i].Width = 124;
                        images[i].Margin = new Thickness(0, 0, 0, 0);*/

                        if (Model.getInstance().list_SlaveRecv[i].Error_Occured)
                        {
                            images[i].Source = cachedDoorClose_Error;
                        }
                        else
                        {
                            images[i].Source = cachedEmpty;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////

                    ///////////////////////////////// SOC ///////////////////////////////////////////

                    if (Model.getInstance().list_SlaveRecv[i].SOC > 0 && Model.getInstance().list_SlaveRecv[i].BatterArrive && Model.getInstance().list_SlaveRecv[i].WAKEUP_Signal)
                    {
                        int soc = Model.getInstance().list_SlaveRecv[i].SOC;

                        if (soc < 30)
                            borders[i].Background = redBrush;
                        else if (soc < 60)
                            borders[i].Background = purpleBrush;
                        else
                            borders[i].Background = blueBrush;

                        panels[i].Visibility = Visibility.Visible;

                        string vtype = "";

                        if (Model.getInstance().list_SlaveRecv[i].Check_BatteryVoltage_Type == -1) vtype = "알수없음";
                        else vtype = Model.getInstance().list_SlaveRecv[i].Check_BatteryVoltage_Type.ToString();


                        socs[i].Text = " " + soc + "%" + " - " + vtype + "V" + " ";
                    }

                    else
                    {
                        panels[i].Visibility = Visibility.Hidden;
                    }
                    /////////////////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////

                    if (Model.getInstance().list_SlaveRecv[i].BatterArrive)
                    {
                        colorBoders[i].Background = blueBrush;
                    }
                    if (!Model.getInstance().list_SlaveRecv[i].BatterArrive)
                    {
                        colorBoders[i].Background = new SolidColorBrush(Colors.White);
                    }
                    else if (Model.getInstance().list_SlaveRecv[i].ProcessStatus == 100)
                    {
                        colorBoders[i].Background = new SolidColorBrush(Colors.Lime);
                    }

                    //////////////////////////////////
                    /*if (Model.getInstance().list_SlaveDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                        slaveStatus[i].Fill = new SolidColorBrush(Colors.Lime);
                    else
                        slaveStatus[i].Fill = new SolidColorBrush(Colors.Red);*/
                }

                /*for (int i = 0; i < 2; i++)
                {
                    if (Model.getInstance().list_MasterDataRecvDatetime[i].AddSeconds(5) > DateTime.Now)
                        masterStatus[i].Fill = new SolidColorBrush(Colors.Lime);
                    else
                        masterStatus[i].Fill = new SolidColorBrush(Colors.Red);
                }*/

                if (CsDefine.Cyc_Rail[CsDefine.CYC_RUN] == CsDefine.CYC_END)
                {
                    btn_home.Visibility = Visibility.Collapsed;
                    Right_Colunm.Width = new GridLength(3, GridUnitType.Star);
                    property_Canvas.Margin = new Thickness(0, 0, 0, 0);

                    Model.getInstance().frmFrame.Set_Bottom_Progressbar(false);
                    Image_translateTrnasform.Y = 60;
                    Canvas_translateTrnasform.Y = 0;


                    Canvas.SetLeft(color_bar1, 190.5);
                    Canvas.SetLeft(color_bar2, 190.5);
                    Canvas.SetLeft(color_bar3, 190.5);
                    Canvas.SetLeft(color_bar4, 190.5);
                    Canvas.SetLeft(color_bar5, 399);
                    Canvas.SetLeft(color_bar6, 399);
                    Canvas.SetLeft(color_bar7, 399);
                    Canvas.SetLeft(color_bar8, 399);


                }
                else
                {
                    btn_home.Visibility = Visibility.Collapsed;
                    Right_Colunm.Width = new GridLength(0);
                    property_Canvas.Margin = new Thickness(150, 0, 0, 0);

                    Model.getInstance().frmFrame.Set_Bottom_Progressbar(true);
                    Image_translateTrnasform.Y = 30;
                    Canvas_translateTrnasform.Y = -30;

                    Canvas.SetLeft(color_bar1, 194.2);
                    Canvas.SetLeft(color_bar2, 194.2);
                    Canvas.SetLeft(color_bar3, 194.2);
                    Canvas.SetLeft(color_bar4, 194.2);
                    Canvas.SetLeft(color_bar5, 402.5);
                    Canvas.SetLeft(color_bar6, 402.5);
                    Canvas.SetLeft(color_bar7, 402.5);
                    Canvas.SetLeft(color_bar8, 402.5);

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
            Model.getInstance().is_manual_mode = false;
            frmFrame.deleMenuClick(3,"station_start");

            Keyboard.ClearFocus();

            /*if (sp_Slave.Check_able_battery_slot())
            {
                frmFrame.deleMenuClick(3);

                Keyboard.ClearFocus();
            }
            else
            {
                Model.getInstance().frmFrame.NotiShow("No slots available.\nPlease visit another Station", 1000, IconName.RedDanger.ToString());
            }*/
        }

        private bool test = false;
        private bool test_1 = false;

        private void btn_test_Click_1(object sender, RoutedEventArgs e)
        {
            /*Dispatcher.BeginInvoke(new Action(() =>
            {
                if (test)
                {
                    Right_Colunm.Width = new GridLength(3, GridUnitType.Star);
                    property_Canvas.Margin = new Thickness(0, 0, 0, 0);
                    Model.getInstance().frmFrame.Set_Bottom_Progressbar(false);
                    Image_translateTrnasform.Y = 60;
                    Canvas_translateTrnasform.Y = 0;
                }
                else if (!test)
                {
                    Right_Colunm.Width = new GridLength(0);
                    property_Canvas.Margin = new Thickness(150, 0, 0, 0);
                    Model.getInstance().frmFrame.Set_Bottom_Progressbar(true);
                    Image_translateTrnasform.Y = 0;
                    Canvas_translateTrnasform.Y = -60;
                }
            }));*/

            // Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(1, enumData.ERROR.ToString());
            // Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_AddInfoStationBatteryState(1);

            /*if (test)
            {
                test = false;
                Model.getInstance().frmFrame.Set_Bottom_Progressbar(false);
                Image_translateTrnasform.Y = 60;
                Canvas_translateTrnasform.Y = 0;
            }
            else
            {
                test = true;
                Model.getInstance().frmFrame.Set_Bottom_Progressbar(true);
                Image_translateTrnasform.Y = 30;
                Canvas_translateTrnasform.Y = -30;
            }*/

            if (!Model.getInstance().test_button)
            {
                Model.getInstance().test_button = true;
                Model.getInstance().list_SlaveRecv[6].Battery_Slot_Temp = 100;
            }
            else
            {
                Model.getInstance().test_button = false;
                Model.getInstance().list_SlaveRecv[6].Battery_Slot_Temp = 0;
            }

            /* if (!this.test_1)
             {
                 this.test_1 = true;
                 Model.getInstance().frmFrame.GetfrmMain().show_Door_Close_Popup(new int[2] {0,0});

                 Task.Delay(3000).ContinueWith(t => {
                     Model.getInstance().frmFrame.GetfrmMain().close_Door_Close_Popup();
                 });
             }*/
            /*else
            {
                this.test_1 = false;
                Model.getInstance().frmFrame.GetfrmMain().close_Door_Close_Popup();
            }*/

            // CsDefine.Cyc_Rail[CsDefine.CYC_RUN] = CsDefine.CYC_DOOR_ERROR;

        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Model.getInstance().bis_Click_Home_button = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private BitmapImage CreateTransparentImage()
        {
            var transparentBitmap = new System.Drawing.Bitmap(1, 1);
            transparentBitmap.SetPixel(0, 0, System.Drawing.Color.Transparent);

            using (var ms = new System.IO.MemoryStream())
            {
                transparentBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void img_qr_voltimos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
