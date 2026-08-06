using EasyTask.Class.Default_Storyboards;
using EasyTask.Class;
using EasyTask.Class.DynamicTheme;
using EasyTask.Class.SettingsConfiguration;
using System.Windows;
using System.Windows.Controls;
namespace EasyTask.Pages.PagesConnectors.Theme_Childrens
{
    /// <summary>
    /// Interaction logic for ChangeThemeOfThemeUserControl.xaml
    /// </summary>
    public partial class ChangeThemeOfThemeUserControl : UserControl
    {
        Grid SpetialGrid,SettingsGrid;
        public ChangeThemeOfThemeUserControl(Grid _SpetialGrid,Grid _SettingsGrid)
        {

            InitializeComponent();
            SpetialGrid = _SpetialGrid; SettingsGrid = _SettingsGrid;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
Button button = sender as Button;
            if (button.Name == "DeffaultTheme")
            {
                UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme = "Default";


            }
            else if (button.Name == "BlueTheme")
            {
                UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme = "Blue";

            }
            else if (button.Name == "YellowTheme")
            {

                UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme = "Yellow";
            }
            DynamicTheme.setTheme();/*
            SpetialGrid.Children.Clear();*/

            DefaultStoryboardsByWindow DS = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("ComeInWithScale", DS, null, SettingsGrid);
            DefaultStoryboardsByWindow DS2 = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("ComeOutWithScale", DS2, null, SpetialGrid);
        }
    }
}
