using EasyTask.Class;
using EasyTask.Class.Default_Storyboards;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors
{
    /// <summary>
    /// Interaction logic for ProcessOfSettingsPage.xaml
    /// </summary>
    public partial class ProcessOfSettingsPage : UserControl
    {
        public ProcessOfSettingsPage()
        {
            InitializeComponent();

        }

        private void ProcessOfSettingsPageX_Loaded(object sender, RoutedEventArgs e)
        {

            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, this);
        }
    }
}
