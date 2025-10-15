using EasyTask.Class;
using EasyTask.Class.Default_Storyboards;
using EasyTask.Pages.PagesConnectors.Theme_Childrens;
using System.Windows;
using System.Windows.Controls;
namespace EasyTask.Pages.PagesConnectors
{
    
    /// <summary>
    /// Interaction logic for ProcessOfSettingsPage.xaml
    /// </summary>
    public partial class ThemeOfSettingsPage : UserControl  
    {
        Grid SpetialGrid,SettingsGrid;
        public ThemeOfSettingsPage(Grid _SpetialGrid,Grid _SettingsGrid)
        {
            InitializeComponent();
            SpetialGrid= _SpetialGrid;
            SettingsGrid= _SettingsGrid;
        }

        private void ThemeOfSettingsPageX_Loaded(object sender, RoutedEventArgs e)
        {
            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, this);
        }

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeThemeOfThemeUserControl changeThemeOfThemeUserControl = new ChangeThemeOfThemeUserControl(SpetialGrid,SettingsGrid);
            SpetialGrid.Children.Add(changeThemeOfThemeUserControl);

            DefaultStoryboardsByWindow DS = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("ComeInWithScale", DS, null, SpetialGrid);
            DefaultStoryboardsByWindow DS2 = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("ComeOutWithScale", DS2, null, SettingsGrid);
        }
    }
}
