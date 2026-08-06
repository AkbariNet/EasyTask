using System.Windows;
using System.Windows.Input;
using _21_4_23;
using EasyTask.Class;
using Microsoft.Win32;
using EasyTask.Pages;
using EasyTask.Class.SettingsConfiguration;
using Wpf.Ui.Controls;
using EasyTask.Class.DynamicTheme;
using EasyTask.Pages.MainWindowElement;
using MessageBox = System.Windows.MessageBox;
using EasyTask.Pages.PagesConnectors;


namespace EasyTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FluentWindow
    {
       
        MainWindow_MainPage MW_MainPage= new MainWindow_MainPage();
        RecentActions MW_RecentActions= new RecentActions();
        MainWindow_AboutPage MW_AboutPage = new MainWindow_AboutPage();
        public MainWindow()
        {
            

            string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            InitializeComponent();
            // System.Windows.MessageBox.Show(applicationLocation);
            ClockIconBar_Click(null, null);
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            Window_Loaded(null, null);
            //For Load Sections
            DynamicTheme.setTheme();
            ForTest.ForTestStart();
            SystemEvents.UserPreferenceChanged += (s, e) => { DynamicTheme.SystemEvents_UserPreferenceChanged(s, e); };
            IncludeDefaultResources.Include();
            UiSettingsSectionPropertyes_isLockEvent(false);
            UiSettingsSectionPropertyes_isNotifyEvent(false);
            UiSet.UiSettingsSectionPropertyes.isLockEvent += UiSettingsSectionPropertyes_isLockEvent;
            UiSet.UiSettingsSectionPropertyes.isNotifyEvent += UiSettingsSectionPropertyes_isNotifyEvent;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void deleteEntered(object sender, RoutedEventArgs e)
        {

        }
        public void startError(string texterror)
        {
            ProcessInProduct processInProduct = new ProcessInProduct();
            processInProduct.StartProssesing(Properties.Languages.Lang.ProcessInProduct_Finding_Error__, Properties.Languages.Lang.ProcessInProduct_Start_finding__);
            processInProduct.GetRespond(false, "Error", texterror);
        }

  






        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
            if (e.ClickCount == 2)
            {
                this.WindowState = WindowState.Maximized;
            }
        }



        private void ClockIconBar_Click(object sender, RoutedEventArgs e)
        {
            
           Content_Grid.Children.Clear();
            Content_Grid.Children.Add(MW_MainPage);
        }

        private void RecentIconBar_Click(object sender, RoutedEventArgs e)
        {
           
            Content_Grid.Children.Clear();
            Content_Grid.Children.Add(MW_RecentActions);
        }
        private void AboutIconBar_Click(object sender, RoutedEventArgs e)
        {
            Content_Grid.Children.Clear();
            Content_Grid.Children.Add(MW_AboutPage);
        }

        private void NothingIconPic_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Window_Loaded(sender, null);
        }



        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
            App.closeApp();
        }





        // -- Change Language & Run CHange.Lan Class
        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {

        }
        //-- CHL.FINSISH


    


        private void SettingsIconBar_Click(object sender, RoutedEventArgs e)
        {
            if (!UiSet.UiSettingsSectionPropertyes.IsLock)
            {
                SettingsPro settingsPro = new SettingsPro();
                settingsPro.DataContext = UiSet.UiSettingsSection;
                RunStoryboard.Run("OutFocusElementIn", this, null, OutFocusDarkBorder);
                settingsPro.ShowDialog();
                RunStoryboard.Run("OutFocusElementOut", this, null, OutFocusDarkBorder);
                UiSet.SaveSettings();

            }
            else { ProcessInProduct processInProduct = new ProcessInProduct();
                processInProduct.GetRespond(false, Properties.Languages.Lang.ProcessInProduct_The_App_is_Locked, Properties.Languages.Lang.ProcessInProduct_When_the_app_is_locked__you_cannot_change_the_settings_);
                processInProduct.Show();
            }
        }





        private void RingButton_Click(object sender, RoutedEventArgs e)
        {
            UiSet.UiSettingsSectionPropertyes.IsNotify = false;
        }

        private void RingDButton_Click(object sender, RoutedEventArgs e)
        {
            UiSet.UiSettingsSectionPropertyes.IsNotify = true;
        }

        private void UiSettingsSectionPropertyes_isNotifyEvent(bool obj)
        {
            if (UiSet.UiSettingsSectionPropertyes.IsNotify)
            {
                RingButton.Visibility = Visibility.Visible;
                RingDButton.Visibility = Visibility.Collapsed;

            }
            else
            {
                RingButton.Visibility = Visibility.Collapsed;
                RingDButton.Visibility = Visibility.Visible;

            }
        }

        private void LockButton_Click(object sender, RoutedEventArgs e)
        {
            if (UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp)
            {

                UnLockWindow unLockWindow = new UnLockWindow();
                unLockWindow.ParentIsMainWindow = true;
                RunStoryboard.Run("OutFocusElementIn", this, null, OutFocusDarkBorder);
                unLockWindow.GetMainWindowOutFocusBorder(OutFocusDarkBorder, this);
                unLockWindow.ShowDialog();
            }
            else
            {
                CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
                createPasswordWindow.ShowDialog();
            }
        }
        
        private void UnLockButton_Click(object sender, RoutedEventArgs e)
        {
            if (UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp)
            {
                UiSet.UiSettingsSectionPropertyes.IsLock = true;
            }
            else
            {

                CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
                createPasswordWindow.ShowDialog();
            }
        }

        private void UiSettingsSectionPropertyes_isLockEvent(bool obj)
        {
            if (UiSet.UiSettingsSectionPropertyes.IsLock)
            {

                LockButton.Visibility = Visibility.Visible;
                UnLockButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                LockButton.Visibility = Visibility.Collapsed;
                UnLockButton.Visibility = Visibility.Visible;

            }
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            SelectLanguage selectLanguage = new SelectLanguage();
            PlaceForFillAll.Children.Add( selectLanguage);
            selectLanguage.GetGrid(PlaceForFillAll);
            
        }
    }

}
