using EasyTask.Class;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.MainWindowElement
{
    /// <summary>
    /// Interaction logic for MainWindow_AboutPage.xaml
    /// </summary>
    public partial class MainWindow_AboutPage : UserControl
    {
        public MainWindow_AboutPage()
        {
            InitializeComponent();
        }

        private void AboutPageX_Loaded(object sender, RoutedEventArgs e)
        {

            RunStoryboard.Run("In", null, this, this);
        }

    }
}
