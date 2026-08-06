using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyTask.Pages.PagesConnectors.Theme_Childrens.ChangeTheme_Childrens
{
    /// <summary>
    /// Interaction logic for ThemeButtonOfChangeThemeUserControl.xaml
    /// </summary>
    public partial class ThemeButtonOfChangeThemeUserControl : Button
    {
        public ThemeButtonOfChangeThemeUserControl()
        {
            InitializeComponent();
        }


        public SolidColorBrush MainColor
        {
            get { return (SolidColorBrush)GetValue(MainColorProperty); }
            set { SetValue(MainColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainColorProperty =
            DependencyProperty.Register("MainColor", typeof(SolidColorBrush), typeof(ThemeButtonOfChangeThemeUserControl), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        

        public SolidColorBrush SecoundColor
        {
            get { return (SolidColorBrush)GetValue(SecoundColorProperty); }
            set { SetValue(SecoundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecoundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecoundColorProperty =
            DependencyProperty.Register("SecoundColor", typeof(SolidColorBrush), typeof(ThemeButtonOfChangeThemeUserControl), new PropertyMetadata(new SolidColorBrush(Colors.Red)));



        public SolidColorBrush BColor
        {
            get { return (SolidColorBrush)GetValue(BColorProperty); }
            set { SetValue(BColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BColorProperty =
            DependencyProperty.Register("BColor", typeof(SolidColorBrush), typeof(ThemeButtonOfChangeThemeUserControl), new PropertyMetadata(new SolidColorBrush(Colors.DarkRed)));



    }
}
