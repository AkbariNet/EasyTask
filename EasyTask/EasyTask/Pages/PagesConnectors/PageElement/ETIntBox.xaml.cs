using EasyTask.Class.SettingsConfiguration;

using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors.PageElement
{
    /// <summary>
    /// Interaction logic for ETIntBox.xaml
    /// </summary>
    public partial class ETIntBox : UserControl
    {
        public string ContentOfMainLabel
        {
            get { return (string)GetValue(ContentOfMainLabelProperty); }
            set { SetValue(ContentOfMainLabelProperty, value); }
        }
        public static readonly DependencyProperty ContentOfMainLabelProperty =
          DependencyProperty.Register("ContentOfMainLabel", typeof(string), typeof(ETIntBox), new PropertyMetadata("Content Of IntBox"));



        public int IntBoxValue
        {
            get { return (int)GetValue(IntBoxValueProperty); }
            set { SetValue(IntBoxValueProperty, value); }
        }

        public static readonly DependencyProperty IntBoxValueProperty =
            DependencyProperty.Register("IntBoxValue", typeof(int), typeof(ETIntBox), new PropertyMetadata(30));



        public ETIntBox()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            UiSet.SaveSettings();
        }
    }
}
