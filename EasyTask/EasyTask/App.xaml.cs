using EasyTask.Class;
using EasyTask.Pages.Element;
using EasyTask.Class.Actions;
using EasyTask.Class.SettingsConfiguration;
using EasyTask.Class.YesOrNoClass;
using EasyTask.Pages;
using System;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using EasyTask.Class.NotificationSystem;
using Windows.UI.Notifications;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Controls;
using Microsoft.Vbe.Interop.Forms;
using System.Windows.Media;
using System.Threading;

namespace _21_4_23
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool LightMode;



        private System.ComponentModel.IContainer components;
        public static int ButtonMainWindowClicked = 1;
        static NotiticationCore NotiticationCoreSystem = new NotiticationCore();


        public static bool exitOn = false;

        public static string database = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = actionDetails_Run.mdb;" + "User Id=admin; password=;";
        public static string databaseRecentActions = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = recentDetails_Run.mdb;" + "User Id=admin; password=;";
        public App()
        {
            UiSet.UiSetStart();

        }


        private void EnbLock_OnRunningChanged(bool EnbLock)
        {
            MessageBox.Show("Connected");

            throw new NotImplementedException();
        }

        public static string Title = EasyTask.Properties.Languages.Lang.Notify_Welcome, DataTitle = "EasyTask";
      
        public static void STARTNOTIF(string Title, string data)
        {
            if (UiSet.UiSettingsSectionPropertyes.IsNotify)
            {
                NotiticationCoreSystem.Create(Title, data);

            }

        }



        public static void closeApp()
        {
            if (exitOn == false)
            {
                STARTNOTIF(EasyTask.Properties.Languages.Lang.Notify_Application_Minimized, EasyTask.Properties.Languages.Lang.Notify_for_Enable_Tasks__application_Minimized);

            }
        }



        // for dark mode title auto





        public static TaskbarIcon trayIcon;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var langCode = EasyTask.Properties.Settings.Default.LanguageCode;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
          
            trayIcon = new TaskbarIcon
            {
                Icon = new System.Drawing.Icon("Logo.ico"),
                ToolTipText = "Easy Task"
            };

            // Menu
            trayIcon.ContextMenu = new CustomContextMenu();
            trayIcon.TrayMouseDoubleClick += (sender, args) =>
            {
                MainWindow.ShowInTaskbar = true;
                MainWindow.WindowState = WindowState.Normal;
                MainWindow.Activate();
                MainWindow.Show();
            };
            }


    }

}

// for dark mode title auto




