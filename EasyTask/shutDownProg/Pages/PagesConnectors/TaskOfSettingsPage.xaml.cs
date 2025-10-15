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
    public partial class TaskOfSettingsPage : UserControl
    {
        public TaskOfSettingsPage()
        {
            InitializeComponent(); UiSettingsSectionPropertyes_EnbLockEvent(false);
            UiSet.UiSettingsSectionPropertyes.SWSEnbLockAppEvent += UiSettingsSectionPropertyes_EnbLockEvent;
        }

        private void UiSettingsSectionPropertyes_EnbLockEvent(bool obj)
        {
            if (UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp)
            {
                TaskRemovalSystem.IsEnabled = true;
                TaskRemovalSystem.Opacity = 1;
            }
            else
            {

                TaskRemovalSystem.IsEnabled = false;
                TaskRemovalSystem.Opacity = 0.2;
            }
        }
        private void TaskOfSettingsPageX_Loaded(object sender, RoutedEventArgs e)
        {

            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, this);
        }
    }
}
