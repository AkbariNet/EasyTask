using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors.PageElement
{
    /// <summary>
    /// Interaction logic for ETBeginOfTab.xaml
    /// </summary>
    public partial class ETBeginOfTab : UserControl
    {


        public string ETBlabelContent
        {
            get { return (string)GetValue(ETBlabelContentProperty); }
            set { SetValue(ETBlabelContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ETBlabelContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ETBlabelContentProperty =
            DependencyProperty.Register("ETBlabelContent", typeof(string), typeof(ETBeginOfTab), new PropertyMetadata("Begin Of Property"));


        public ETBeginOfTab()
        {

            InitializeComponent();
        }
    }
}
