using EasyTask.Class.SettingsConfiguration;
using System.Windows.Controls;

namespace EasyTask.Pages.PagesConnectors.PageElement
{
    /// <summary>
    /// Interaction logic for ETCheckBox.xaml
    /// </summary>
    public partial class ETCheckBox : CheckBox
    {


        public ETCheckBox()
        {
             InitializeComponent();
            UiSet.SaveSettings();
        }



    }
}
