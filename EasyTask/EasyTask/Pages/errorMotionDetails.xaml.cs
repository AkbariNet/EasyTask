using System.Windows;
using System.Windows.Controls;

namespace shutDownProg
{
    /// <summary>
    /// Interaction logic for errorMotionDetails.xaml
    /// </summary>
    public partial class errorMotionDetails : Page
    {
        public errorMotionDetails()
        {
            InitializeComponent();
            mainErrorGrid.Focus();
            mainErrorGrid.Focusable = false;
            

        }

        private void mainErrorGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void restart()
        {
        }
    }
}
