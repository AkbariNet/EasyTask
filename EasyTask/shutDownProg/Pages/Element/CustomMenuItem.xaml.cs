using _21_4_23;
using EasyTask.Class.YesOrNoClass;
using EasyTask.Class.ReadingDatabase;
using System.Windows;
using System.Windows.Controls;
using EasyTask.Class.SettingsConfiguration;

namespace EasyTask.Pages.Element
{
    /// <summary>
    /// Interaction logic for CustomMenuItem.xaml
    /// </summary>
    public partial class CustomMenuItem : UserControl
    {
        public CustomMenuItem()
        {
            InitializeComponent();
        }

        private void EXTButton_Click(object sender, RoutedEventArgs e)
        {


            if (!UiSet.UiSettingsSectionPropertyes.IsLock)
            {
                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.DefaultTextName_AreYouSure, EasyTask.Properties.Languages.Lang.App_xaml_By_doing_this__all_created_tasks_will_be_stopped_,
                    EasyTask.Properties.Languages.Lang.DefaultTextName_Cancel, EasyTask.Properties.Languages.Lang.DefaultTextName_Exit, 1) == 2)
                {

                    Application.Current.Shutdown(); App.exitOn = true;
                }

            }
            else
            {
                ProcessInProduct processInProduct = new ProcessInProduct();
                processInProduct.StartProssesing(ProcessNameRevive: EasyTask.Properties.Languages.Lang.ProcessInProduct_Exiting, ProcessAboutRevive: EasyTask.Properties.Languages.Lang.ProcessInProduct_TryingToExit__);
                processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_The_App_is_Locked, EasyTask.Properties.Languages.Lang.ProcessInProduct_For_Exit_this_app_and_disable_tasks__you_must_unlock_application);
                processInProduct.ShowDialog();

            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            
            App.Current.MainWindow.ShowInTaskbar = true;
            App.Current.MainWindow.WindowState = WindowState.Normal;
            App.Current.MainWindow.Activate();
            App.Current.MainWindow.Show();

           


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PlaceForTasks.Children.Clear();

            int i = 0;
                ReadingDatabaseTasks.TASKS_Names.ForEach(x => { 
                    TasksShort tasksShort = new TasksShort();
                    tasksShort.TaskName = x;
                    tasksShort.TaskTime = ReadingDatabaseTasks.TASKS_Times[i];
                    PlaceForTasks.Children.Add(tasksShort);
                    i++;
                
                });
        }
    }
}
