using EasyTask.Class;
using EasyTask.Class.Default_Storyboards;
using EasyTask.Class.SettingsConfiguration;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors
{
    /// <summary>
    /// Interaction logic for ProcessOfSettingsPage.xaml
    /// </summary>
    public partial class SecurityOfSettingsPage : UserControl
    {
        public SecurityOfSettingsPage()
        {
            InitializeComponent(); UiSettingsSectionPropertyes_EnbLockEvent(false);
            UiSet.UiSettingsSectionPropertyes.SWSEnbLockAppEvent += UiSettingsSectionPropertyes_EnbLockEvent;
        }

        private void UiSettingsSectionPropertyes_EnbLockEvent(bool obj)
        {
            if (UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp)
            {
                LockModeSubButton.IsEnabled = true;
                LockModeSubButton.Opacity = 1;
            }
            else
            {

                LockModeSubButton.IsEnabled = false;
                LockModeSubButton.Opacity = 0.2;
            }
        }

        private void SecurityOfSettingsPageX_Loaded(object sender, RoutedEventArgs e)
        {

            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, this);
        }

        private void SWSChangePassowrdButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.ShowDialog();  
        }

        private void EnbLockBox_Click(object sender, RoutedEventArgs e)
        {
            if (EnbLockBox.IsChecked == true)
            {
                CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
                createPasswordWindow.ShowDialog();
                if (!UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp)
                {
                    EnbLockBox.IsChecked = false;

                }
                createPasswordWindow.Close();
            }
            else
            {
                TwoWayYesNo twoWayYesNo = new TwoWayYesNo();
                twoWayYesNo.SetValuesOfTitles(Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, "", Properties.Languages.Lang.DefaultTextName_Yes, Properties.Languages.Lang.DefaultTextName_No, 2);
                twoWayYesNo.ShowDialog();
                if (twoWayYesNo.FinalValueOfYesOrNo==1)
                {
                    UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp = false;
                    UiSet.UiSettingsSectionPropertyes.IsLock = false;
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword1 = 0;
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword2 = 0;
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword3 = 0;
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword4 = 0;
                }
                else
                {
                    EnbLockBox.IsChecked = true;
                }

            }
        }
    }
}
