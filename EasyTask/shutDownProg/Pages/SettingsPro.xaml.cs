using EasyTask.Class;
using EasyTask.Pages.PagesConnectors;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPro.xaml
    /// </summary>
    /// 

    public partial class SettingsPro : FluentWindow
    {
        ProcessOfSettingsPage processOfSettingsPage;
        TaskOfSettingsPage taskOfSettingsPage;
        ConnectionOfSettingsPage connectionOfSettingsPage;
        SecurityOfSettingsPage securityOfSettingsPage;
        ThemeOfSettingsPage themeOfSettingsPage;
        public SettingsPro()
        {
            InitializeComponent();
            processOfSettingsPage = new ProcessOfSettingsPage();
            taskOfSettingsPage = new TaskOfSettingsPage();
            connectionOfSettingsPage = new ConnectionOfSettingsPage();
            securityOfSettingsPage = new SecurityOfSettingsPage();
            themeOfSettingsPage = new ThemeOfSettingsPage(SpecialGridPlace,settings_Grid);
            /*
            
            processOfSettingsPage.DataContext = UiSet.UiSettingsSection;
            taskOfSettingsPage.DataContext = UiSet.UiSettingsSection;
            connectionOfSettingsPage.DataContext = UiSet.UiSettingsSection;
            securityOfSettingsPage.DataContext = UiSet.UiSettingsSection;
            themeOfSettingsPage.DataContext = UiSet.UiSettingsSection;*/


            string sAttr = ConfigurationManager.AppSettings.Get("SWCAlwaysTry");
           // MessageBox.Show(sAttr);
        }

        private void EXTButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ProcessBTN_Click(object sender, RoutedEventArgs e)
        {
            TargetGrid.Children.Clear();
            processOfSettingsPage.VerticalAlignment = VerticalAlignment.Top;
            processOfSettingsPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            TargetGrid.Children.Add(processOfSettingsPage);
        }

        private void TasksBTN_Click(object sender, RoutedEventArgs e)
        {
            TargetGrid.Children.Clear();
            taskOfSettingsPage.VerticalAlignment = VerticalAlignment.Top;
            taskOfSettingsPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            TargetGrid.Children.Add(taskOfSettingsPage);

        }

        private void ConnectionBTN_Click(object sender, RoutedEventArgs e)
        {
            TargetGrid.Children.Clear();
            connectionOfSettingsPage.VerticalAlignment = VerticalAlignment.Top;
            connectionOfSettingsPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            TargetGrid.Children.Add(connectionOfSettingsPage);

        }

        private void SecurityBTN_Click(object sender, RoutedEventArgs e)
        {
            TargetGrid.Children.Clear();
            securityOfSettingsPage.VerticalAlignment = VerticalAlignment.Top;
            securityOfSettingsPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            TargetGrid.Children.Add(securityOfSettingsPage);

        }

        private void ThemeBTN_Click(object sender, RoutedEventArgs e)
        {
            TargetGrid.Children.Clear();
            themeOfSettingsPage.VerticalAlignment = VerticalAlignment.Top;
            themeOfSettingsPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            TargetGrid.Children.Add(themeOfSettingsPage);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void RibbonHelper_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void FluentWindow_Loaded(object sender, RoutedEventArgs e)
        {

            RunStoryboard.Run("In", this, null, SettingsBar);
        }

        private void FluentWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width>=780)
            {
                RunStoryboard.Run("SandwichIn", this, null, SandwichPanel);
                RunStoryboard.Run("MiniSandwichOut", this, null, MiniSandwichPanel);
            }
            else {

                RunStoryboard.Run("SandwichOut", this, null, SandwichPanel);
                RunStoryboard.Run("MiniSandwichIn", this, null, MiniSandwichPanel);
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            RunStoryboard.Run("SandwichOut", this, null, SandwichPanel);
            RunStoryboard.Run("MiniSandwichIn", this, null, MiniSandwichPanel);
        }

        private void MiniSettings_Click(object sender, RoutedEventArgs e)
        {
            RunStoryboard.Run("SandwichIn", this, null, SandwichPanel);
            RunStoryboard.Run("MiniSandwichOut", this, null, MiniSandwichPanel);

        }
    }
}
