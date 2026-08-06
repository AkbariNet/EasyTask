using System;
using System.Windows;
using System.Windows.Controls;
using Timer = System.Timers.Timer;
using System.Timers;
using _21_4_23;
using EasyTask.Class.Actions;
using EasyTask.Class.TaskProcessing;
using EasyTask.Class.Convertor;
using EasyTask.Class.SettingsConfiguration;
using EasyTask.Class.ReadingDatabase;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for ShortAction.xaml
    /// </summary>
    public partial class ShortActionpro : UserControl
    {
        DeleteTaskProcess deleteTaskProcess = new DeleteTaskProcess();
        AddTaskProcess_ForShowRecentTasks addTaskProcess_ForShowRecentTasks = new AddTaskProcess_ForShowRecentTasks();
        public ShortActionpro()
        {
            InitializeComponent();

        }
        public string TASKNAME_ForShare;
        public sbyte ActionForSend;
        public string pathFile;
        DateTime DateCreatedAction;
         DateTime DateStartAction;

        public Int32 IDFORSHARE;



        /// <summary>
        /// Use Sync Variables for use for Save to recentActions 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TaskName"></param>
        /// <param name="ActionMod"></param>
        /// <param name="dateAction"></param>
        /// <param name="dateTimeCreated"></param>
        /// <param name="FilePath"></param>
       int iD; string taskName; string actionMod; DateTime dateAction; DateTime dateTimeCreated; string filePath;

        public void settimePre(int ID, string TaskName, string ActionMod, DateTime DateAction, DateTime DateTimeCreated,string FilePath)
        {
            ///Set Values for sync to all of windows
             iD=ID;  taskName=TaskName;  actionMod=ActionMod;  dateAction=DateAction;  dateTimeCreated=DateTimeCreated; filePath = FilePath;
            ///Set Values for sync to all of windows


            string MainStringCreated = DateTimeCreated.TimeOfDay.ToString();
            string[] SplitCreated = MainStringCreated.Split(new Char[] { ':' });

            ///Set Values for sync to Action Reminder
            TASKNAME_ForShare = TaskName;
            DateStartAction = DateAction;
            DateCreatedAction = DateTimeCreated;
            pathFile = FilePath; IDFORSHARE = ID;
            ///Set Values for sync to Action Reminder
            dateCreatedPreview.Text = DateTimeCreated.Year.ToString() + "/" + DateTimeCreated.Month.ToString() + "/" + DateTimeCreated.Day.ToString() + "   " + SplitCreated[0] + ":" + SplitCreated[1];
            
             string MainString = DateAction.TimeOfDay.ToString();
            string[] Split = MainString.Split(new Char[] { ':' });
            startDatePreview.Text = DateAction.Year.ToString()+"/"+ DateAction.Month.ToString()+ "/" + DateAction.Day.ToString()+"   " + Split[0] + ":" + Split[1]; 
        
            startTimePreview.Text = Split[0] + ":" + Split[1];
            //SHOW RESULT

            actionPreview.Text = ActionMod;
            taskNamePreview.Text = TaskName;
            string CorrectNameAction = ConvertActionNameBTNToCorrectName.Convertor(ActionMod, actionPreview, pathFile);
            RefreshAllActionIcons();
            VisibleThreeActionIcons();
            if (CorrectNameAction == "Shut Down")
            {
                ActionForSend = 1; 
                
                ShutDownIconPic.Visibility = Visibility.Collapsed;
                ShutDownIconTruePic.Visibility = Visibility.Visible;
            }
            else if (CorrectNameAction == "Restart")
            {
                ActionForSend = 2; 
               
                RestartIconPic.Visibility = Visibility.Collapsed;
                RestartIconTruePic.Visibility = Visibility.Visible;
            }
            else if (CorrectNameAction == "Sleep")
            {
                ActionForSend = 3; 
                SleepIconPic.Visibility = Visibility.Collapsed;
                SleepIconTruePic.Visibility = Visibility.Visible;
            }
            else if (CorrectNameAction == "Open File")
            {
                actionPreview.ToolTip = pathFile;

                ActionForSend = 4;
            }
            else if (CorrectNameAction == "Kill Application")
            {
                ActionForSend = 5; 
            }
            else
            {
                actionPreview.Text = "null"; actionPreview.Text = "null";
            }
            addTaskProcess_ForShowRecentTasks.requestAndFillIdandValues(taskName,dateTimeCreated,dateAction,actionMod,filePath);
            CheckingTime();
        }
        private void RefreshAllActionIcons()
        {
            RestartIconTruePic.Visibility = Visibility.Collapsed;
            ShutDownIconTruePic.Visibility = Visibility.Collapsed;
            SleepIconTruePic.Visibility = Visibility.Collapsed;
            RestartIconPic.Visibility = Visibility.Collapsed;
            ShutDownIconPic.Visibility = Visibility.Collapsed;
            SleepIconPic.Visibility = Visibility.Collapsed;
        }
        private void VisibleThreeActionIcons()
        {
            RestartIconTruePic.Visibility = Visibility.Collapsed;
            ShutDownIconTruePic.Visibility = Visibility.Collapsed;
            SleepIconTruePic.Visibility = Visibility.Collapsed;
            RestartIconPic.Visibility = Visibility.Visible;
            ShutDownIconPic.Visibility = Visibility.Visible;
            SleepIconPic.Visibility = Visibility.Visible;
        }
        bool Refresh = false;
        public bool refresh { get { return Refresh; } set { } }
        private void deleteButtonTask_Click_1(object sender, RoutedEventArgs e)
        {
             bool result=deleteTaskProcess.deleteMainTask(this, IDFORSHARE);
            if (result) { ReadingDatabaseTasks.TASKS_Names.Remove(taskName); ReadingDatabaseTasks.TASKS_Times.Remove(dateAction.Hour+":"+ dateAction.Minute); }
        }


        public void  ClearThis()
        {
                ActionForSend = 0;
                checkedTimer.AutoReset = false;
                checkedTimer.Enabled = false;
                checkedTimer.Dispose();

                checkedTimer.Stop();

        }


      
        public Timer checkedTimer;
        public void CheckingTime()
        {
            checkedTimer = new Timer(1000);
            checkedTimer.Elapsed += checkProsses;
            checkedTimer.AutoReset = true;
            checkedTimer.Enabled = true;
        }
        sbyte remindershow=1;
        private void checkProsses(object sender, ElapsedEventArgs e)
        {
           

            if (ActionForSend != 0)
            {
                if (UiSet.UiSettingsSectionPropertyes.SWTWarmToClosingRunTask)
                {

                    if (DateStartAction.Year == DateTime.Now.Year && DateStartAction.Month == DateTime.Now.Month
                        && DateStartAction.Day == DateTime.Now.Day && DateStartAction.Hour == DateTime.Now.Hour
                        &&( DateTime.Now.Minute == (DateStartAction.Minute - UiSet.UiSettingsSectionPropertyes.SWTMinuteWarningBeforeRunTask)) && remindershow!=0)
                    {
                        remindershow = 0;
                        App.STARTNOTIF(UiSet.UiSettingsSectionPropertyes.SWTMinuteWarningBeforeRunTask+" " + Properties.Languages.Lang.ShortActionPro_X_minute_to_start_action, Properties.Languages.Lang.ShortActionPro_You_can_control_your_Task_in_the_app_);
                    }
                }
                    if (DateStartAction.Year == DateTime.Now.Year && DateStartAction.Month == DateTime.Now.Month && DateStartAction.Day == DateTime.Now.Day && DateStartAction.Hour == DateTime.Now.Hour && DateStartAction.Minute == DateTime.Now.Minute )
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        
                        if (ActionForSend==0)
                        {
                            ProcessInProduct processInProduct = new ProcessInProduct();
                            processInProduct.Show();
                            processInProduct.StartProssesing();
                            processInProduct.GetRespond(false, Properties.Languages.Lang.ProcessInProduct_The_action_id_was_invalided , Properties.Languages.Lang.ProcessInProduct_We_haven_t_your_action_id);
                            ActionForSend = 0;
                        }
                        else if (ActionForSend!=4&& ActionForSend != 5)
                        {

                            if (UiSet.UiSettingsSectionPropertyes.SWPEnbTimerWindow)
                            {

                                ActionStartReminder actionStartReminder = new ActionStartReminder();
                                actionStartReminder.GetValueForAddTaskProcess_ForShowRecentTasks(taskName, dateTimeCreated, dateAction, actionMod, filePath);
                                actionStartReminder.setpr(ActionForSend);
                                actionStartReminder.Show();
                                ActionForSend = 0;
                            }
                            else
                            {
                                AddTaskProcess_ForShowRecentTasks FORFASTRECORD_addTaskProcess_ForShowRecentTasks = new AddTaskProcess_ForShowRecentTasks();
                                FORFASTRECORD_addTaskProcess_ForShowRecentTasks.requestAndFillIdandValues(taskName, dateTimeCreated, dateAction, actionMod, filePath);

                                CommanderForStartAction.StartCommand(ActionForSend, FORFASTRECORD_addTaskProcess_ForShowRecentTasks,null);
                            }
                        }
                        else 
                        {
                            if (ActionForSend==4)
                            {
                                ActionForSend = 0;
                                OpenFileSystemAction.IsOpen(pathFile);
                                addTaskProcess_ForShowRecentTasks.AddRecentTaskToDataBase();
                              }
                           else if (ActionForSend==5)
                            {
                                ActionForSend = 0;
                                KillFileSystemAction.IsKilling(pathFile);
                                addTaskProcess_ForShowRecentTasks.AddRecentTaskToDataBase();
                            }
                        }
                        deleteTaskProcess.deleteMainTask(this,IDFORSHARE , Role:"Admin");

                    }));


                    checkedTimer.AutoReset = false;
                    checkedTimer.Enabled = false;
                    checkedTimer.Dispose();

                    checkedTimer.Stop();


                }
            }

                if (ActionForSend == 0)
            {
                checkedTimer.Dispose();
                checkedTimer.Stop();
                checkedTimer.AutoReset = false;
                checkedTimer.Enabled = false;

                try
                {
                    deleteTaskProcess.deleteMainTask(this, IDFORSHARE);

                }
                catch (Exception s)
                {
                    // MessageBox.Show(s.ToString()+"!!!ShortActionPro");

                }

            }
        }

        private void MoreIconPic_Click(object sender, RoutedEventArgs e)
        {

            MoreContentGrid.Visibility = Visibility.Visible;
            MoreIconPic.Visibility = Visibility.Collapsed;
            MoreIconTruePic.Visibility = Visibility.Visible;
            
        }

        private void MoreIconTruePic_Click(object sender, RoutedEventArgs e)
        {

            MoreIconPic.Visibility = Visibility.Visible;
            MoreIconTruePic.Visibility = Visibility.Collapsed;
        }

        private void RemovingThis_Accepted(object sender, EventArgs e)
        {
            
            this.RemoveLogicalChild(this);
            this.ClearThis();

            Refresh = true;
            refresh = true;
            ActionForSend = 0;

        }
    }
}
