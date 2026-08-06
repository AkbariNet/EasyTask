using EasyTask.Class;
using EasyTask.Class.Default_Storyboards;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyTask.Pages.PagesConnectors
{
    /// <summary>
    /// Interaction logic for ProcessOfSettingsPage.xaml
    /// </summary>
    public partial class ConnectionOfSettingsPage : UserControl
    {
        public ConnectionOfSettingsPage()
        {
            InitializeComponent();
        }

        private void ETCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void ConnectionOfSettingsPageX_Loaded(object sender, RoutedEventArgs e)
        {

            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, this);
        }
    }
}
