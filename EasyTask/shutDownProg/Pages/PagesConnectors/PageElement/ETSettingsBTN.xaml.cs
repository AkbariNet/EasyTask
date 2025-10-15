using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors.PageElement
{
    /// <summary>
    /// Interaction logic for ETSettingsBTN.xaml
    /// </summary>
    public partial class ETSettingsBTN : Button
    {


        public string SetContent
        {
            get { return (string)GetValue(SetContentProperty); }
            set { SetValue(SetContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetContentProperty =
            DependencyProperty.Register("SetContent", typeof(string), typeof(ETSettingsBTN), new PropertyMetadata("Button"));


        public ETSettingsBTN()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
