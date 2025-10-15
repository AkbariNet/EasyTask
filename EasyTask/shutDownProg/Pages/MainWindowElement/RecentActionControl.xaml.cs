using EasyTask.Class;
using EasyTask.Class.Convertor;
using EasyTask.Class.SettingsConfiguration;
using EasyTask.Class.TaskProcessing;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyTask.Pages.MainWindowElement
{
    /// <summary>
    /// Interaction logic for RecentActionControl.xaml
    /// </summary>
    public partial class RecentActionControl : UserControl
    {
        DeleteTaskProcess_Recent deleteTaskProcess_Recent = new DeleteTaskProcess_Recent();
        public RecentActionControl()
        {
            InitializeComponent();
        }
        public  int id;
        public  string pathFile;
        public void settimePre(int ID, string TaskName, string ActionMod, DateTime dateAction, 
            DateTime dateTimeCreated, string FilePath)
        {

            string MainStringCreated = dateTimeCreated.TimeOfDay.ToString();
            string[] SplitCreated = MainStringCreated.Split(new Char[] { ':' });

          //  dateCreatedPreview.Text = dateTimeCreated.Year.ToString() + "/" + dateTimeCreated.Month.ToString() + "/" + dateTimeCreated.Day.ToString() + "   " + SplitCreated[0] + ":" + SplitCreated[1];
            id = ID;
            string MainString = dateAction.TimeOfDay.ToString();
            string[] Split = MainString.Split(new Char[] { ':' });
            startDatePreview.Text = dateAction.Year.ToString() + "/" + dateAction.Month.ToString() + "/" + dateAction.Day.ToString() + "   " + Split[0] + ":" + Split[1];

            
            //SHOW RESULT


            //taskNamePreview.Text = TaskName;
            pathFile = FilePath;

            string CorrectNameAction = ConvertActionNameBTNToCorrectName.Convertor(ActionMod, actionPreview, pathFile);
          

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {

            RunStoryboard.Run("DeleteButtonSmoothIn", null, this, DeleteRecentTaskBTN);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            RunStoryboard.Run("DeleteButtonSmoothOut", null, this, DeleteRecentTaskBTN);
        }

        private void DeleteRecentTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            if (UiSet.UiSettingsSectionPropertyes.IsLock)
            {


                if (!UiSet.UiSettingsSectionPropertyes.SWTWhenLockModeIsEnableWeCantDeleteRecentTask)
                {

                    try
                    {
                        if (deleteTaskProcess_Recent.deleteRecentTask(id))
                        {

                            RunStoryboard.Run("Out", null, this, this);
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    ProcessInProduct processInProduct = new ProcessInProduct();
                    processInProduct.Show();
                    processInProduct.StartProssesing();
                    processInProduct.GetRespond(false, Properties.Languages.Lang.ProcessInProduct_Lock_Enabled, Properties.Languages.Lang.ProcessInProduct_When_lock_is_Enabled_you_can_t_Delete_a_task);
                }
            }
            else
            {


                try
                {
                    if (deleteTaskProcess_Recent.deleteRecentTask(id))
                    {

                        RunStoryboard.Run("Out", null, this, this);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
