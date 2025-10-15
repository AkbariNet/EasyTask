using _21_4_23;
using EasyTask.Class;
using EasyTask.Class.ReadingDatabase;
using EasyTask.Class.SettingsConfiguration;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.MainWindowElement
{
    /// <summary>
    /// Interaction logic for MainWindow_MainPage.xaml
    /// </summary>
    public partial class MainWindow_MainPage : UserControl
    {
        public MainWindow_MainPage()
        {

            InitializeComponent(); ReadData();
        }
        
        private void ReadData()
        {

            ReadingDatabaseTasks.ReadData(App.database, gridForActions);

            RunStoryboard.Run("ShortActionProIn", null, this, this.gridForActions);
        }


        // StoryBoards


        private void AddTaskIcon_Click(object sender, RoutedEventArgs e)
        {
            if (UiSet.UiSettingsSectionPropertyes.SWSCantAddTaskWhenLocked)
            {

                if (UiSet.UiSettingsSectionPropertyes.IsLock)
                {
                    ProcessInProduct processInProduct = new ProcessInProduct();
                    processInProduct.StartProssesing();
                    processInProduct.GetRespond(false, Properties.Languages.Lang.ProcessInProduct_Lock_Enabled, Properties.Languages.Lang.Security_CantAddTaskWhenLockedAppProperty);
                    processInProduct.ShowDialog();
                    ReadData();

                }
                else
                {
                    AddTaskWindow addTaskWindow = new AddTaskWindow();
                    addTaskWindow.ShowDialog();
                    ReadData();

                }
            }
            else
            {

                AddTaskWindow addTaskWindow = new AddTaskWindow();
                addTaskWindow.ShowDialog();
                ReadData();
            }
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ReadData();

        }

    }
}
