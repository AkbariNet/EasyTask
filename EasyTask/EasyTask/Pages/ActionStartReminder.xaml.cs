
using EasyTask.Class.Actions;
using EasyTask.Class.SettingsConfiguration;
using EasyTask.Class.TaskProcessing;
using System;
using System.Timers;
using System.Windows;
using Timer = System.Timers.Timer;
namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for ActionStartReminder.xaml
    /// </summary>
    /// 
    public partial class ActionStartReminder : Window
    {
        
        public sbyte Action;
        public sbyte secOfStartAction = UiSet.UiSettingsSectionPropertyes.SWPTimerWaitValue;
       public string ActionToString;
        private  Timer StartActionTimer;
        AddTaskProcess_ForShowRecentTasks addTaskProcess_ForShowRecentTasks = new AddTaskProcess_ForShowRecentTasks();
        public ActionStartReminder()
        {
            InitializeComponent();
            TimeStartActionText.Text = UiSet.UiSettingsSectionPropertyes.SWPTimerWaitValue.ToString();
        }

        public void setpr(sbyte action )
        {
            Action = action;
            setPreviewProsses();
        }
        public void GetValueForAddTaskProcess_ForShowRecentTasks(string TaskNameFinal, DateTime DateCreatedtime, DateTime DateAndTimeFinalyStartAction, string FinalAction, string PathFile)
        {
            addTaskProcess_ForShowRecentTasks.requestAndFillIdandValues(TaskNameFinal, DateCreatedtime, DateAndTimeFinalyStartAction, FinalAction, PathFile);
        }
        private void setPreviewProsses()
        {
            if (Action == 0)
            {

                ActionToString = "!!ERROR!!";
            }

            if (Action == 1)
            {
                ActionToString = Properties.Languages.Lang.ActionStartReminder_ShutsDown;
                this.Title = "Start Of Shut Down";
            }
            if (Action == 2)
            {
                ActionToString = Properties.Languages.Lang.ActionStartReminder_WillRestart;
                this.Title = "Start Of Restart";
            }
            if (Action == 3)
            {
                ActionToString = Properties.Languages.Lang.ActionStartReminder_GoesToSleep;
                this.Title = "Start Of Sleep";
            }
            mainMessage.Text = Properties.Languages.Lang.ActionStartReminder_TitlePart1+" " + ActionToString +" "+ Properties.Languages.Lang.ActionStartReminder_TitlePart2 ;

            CheckingTime();
        }

        private void CheckingTime()
        {
            StartActionTimer = new Timer(1000);
            StartActionTimer.Elapsed += prossesOfStartTimeValue;
            StartActionTimer.AutoReset = true;
            StartActionTimer.Enabled = true;
        }
        public void prossesOfStartTimeValue(object sender, ElapsedEventArgs e)
        {
            secOfStartAction--;
            this.Dispatcher.Invoke(() =>
            {

                TimeStartActionText.Text = secOfStartAction.ToString();

                if (secOfStartAction == 0)
                {
                    StartActionTimer.Enabled = false;
                    StartActionTimer.Dispose();
                    StartActionTimer.Stop();
                    CommanderForStartAction.StartCommand(Action, addTaskProcess_ForShowRecentTasks, this);
                }
            });
        }

        private void cancelAction_Click(object sender, RoutedEventArgs e)
        {
            if (UiSet.UiSettingsSectionPropertyes.IsLock)
            {
                AllContentOfAction.Margin=new Thickness(0,0,300,0);
                UnLockWindow unLockWindow = new UnLockWindow();
                unLockWindow.movingOn = true;
                unLockWindow.ShowDialog();
                AllContentOfAction.Margin = new Thickness(0, 0, 0, 0);
                if (unLockWindow.EnbLockValue)
                {
                    AllContentOfAction.Margin = new Thickness(0, 0, 0, 0);
                    CancelAction();
                }
            }
            else
            {

                AllContentOfAction.Margin = new Thickness(0, 0, 0, 0);
                CancelAction();

            }


        }
        private void CancelAction()
        {


            StartActionTimer.Stop(); StartActionTimer.Enabled = false;
            StartActionTimer.Dispose();
            this.Close();

        }
    }

}
