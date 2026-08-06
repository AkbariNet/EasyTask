using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyTask.Pages.MainWindowElement.Elements
{
    /// <summary>
    /// Interaction logic for SLElement.xaml
    /// </summary>
    public partial class SLElement : UserControl
    {
        public SLElement()
        {
            InitializeComponent();
        }


        public string NameOfLanguage
        {
            get { return (string)GetValue(NameOfLanguageProperty); }
            set { SetValue(NameOfLanguageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOfLanguage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOfLanguageProperty =
            DependencyProperty.Register("NameOfLanguage", typeof(string), typeof(SLElement), new PropertyMetadata("None"));



        public SolidColorBrush BackGR
        {
            get { return (SolidColorBrush)GetValue(BackGRProperty); }
            set { SetValue(BackGRProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackGR.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackGRProperty =
            DependencyProperty.Register("BackGR", typeof(SolidColorBrush), typeof(SLElement), new PropertyMetadata(new SolidColorBrush (Color.FromRgb(255,255,255))));



        public SolidColorBrush ForeGR
        {
            get { return (SolidColorBrush)GetValue(ForeGRProperty); }
            set { SetValue(ForeGRProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeGR.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeGRProperty =
            DependencyProperty.Register("ForeGR", typeof(SolidColorBrush), typeof(SLElement), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(1, 1, 1))));



    }
}
