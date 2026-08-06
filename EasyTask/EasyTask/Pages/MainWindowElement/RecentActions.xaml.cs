using _21_4_23;
using EasyTask.Class;
using EasyTask.Class.Convertor;
using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

namespace EasyTask.Pages.MainWindowElement
{
    /// <summary>
    /// Interaction logic for RecentActions.xaml
    /// </summary>
    public partial class RecentActions : UserControl
    {
        public RecentActions()
        {
            InitializeComponent(); 
             ReadData();
        }

        private void RecentActions_Loaded(object sender, RoutedEventArgs e)
        {

            RunStoryboard.Run("In", null, this, this);
           ReadData();

        }
        Int32 variableOfValue;
        DateTime[] ActionTimes;
        int[] ActionActions; int NumOfIndex = 0;
        public void ReadData()
        {
            string connectionString = App.databaseRecentActions;
            
            resetSettings();
            string queryAll = "SELECT COUNT(*) FROM action_saves";
            string queryString = "SELECT ID,action_Taskname,action_mode,year_action,month_action" +
                ",day_action,hour_action,minute_action,year_action_created,month_action_created" +
                ",day_action_created,hour_action_created,minute_action_created,FilePath_Or_Name FROM action_saves";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                NumOfIndex = 0;
                OleDbCommand command = new OleDbCommand(queryString, connection);
                OleDbCommand Allcmd = new OleDbCommand(queryAll, connection);
                connection.Open();
                OleDbDataReader sreader;
                sreader = Allcmd.ExecuteReader();
                while (sreader.Read())
                {
                    variableOfValue = sreader.GetInt32(0);
                }
                OleDbDataReader reader;
                reader = command.ExecuteReader();
                recentActionControl = new RecentActionControl[variableOfValue];
                ActionTimes = new DateTime[variableOfValue];
                ActionActions = new int[variableOfValue];

                //MessageBox.Show(variableOfValue.ToString());
                // Always call Read before accessing data.

                while (reader.Read())
                {/*
                    MessageBox.Show(Convert.ToString(reader.GetInt32(0)));*/
                    boxes(reader.GetInt32(0)
                    , reader.GetString(1), reader.GetString(2), reader.GetInt16(3)
                    , reader.GetInt16(4), reader.GetInt16(5), reader.GetInt16(6),
                    reader.GetInt16(7), reader.GetInt16(8), reader.GetInt16(9),
                    reader.GetInt16(10), reader.GetInt16(11), reader.GetInt16(12), NumOfIndex, reader.GetString(13));

                }
                //Update DateTime Timer
                NumOfIndex = 0;
                // Always call Close when done reading.
                reader.Close();
                connection.Close();
            }
        }

        public void resetSettings()
        {/*
            gridForActions.Children.Clear();*/
            try
            {
                ContentsOfRecentActions.Children.Clear();
              /*  foreach (RecentActionControl recentAction in recentActionControl)
                    {
                        //actionpro.ClearThis();
                        ContentsOfRecentActions.Children.Clear();


                    }*/
                
            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.ToString() + "!!!Main");
            }

        }







        public RecentActionControl[] recentActionControl;
        public void boxes(int ID, string TaskName, string ActionMod, int YearAction, int MonthAction, int DayAction,
            int HourAction, int MinAction, int YearActionCreated, int MonthActionCreated, int DayActionCreated,
            int HourActionCreated, int MinActionCreated, int i, string PathFile)
        {

            LastTaskName.Text = TaskName;
            ConvertActionNameBTNToCorrectName.Convertor(ActionMod, LastTaskActions, PathFile);
            DateTime dateTimeCreated = new DateTime(YearActionCreated, MonthActionCreated, DayActionCreated, HourActionCreated, MinActionCreated, 01);
            DateTime dateAction = new DateTime(YearAction, MonthAction, DayAction, HourAction, MinAction, 01);
            recentActionControl[i] = new RecentActionControl();
            recentActionControl[i].settimePre(ID, TaskName, ActionMod, dateAction, dateTimeCreated, PathFile);
            recentActionControl[i].Visibility = Visibility.Visible;
            //ContentsOfRecentActions.Children.Add(recentActionControl[i]);
            ContentsOfRecentActions.Children.Insert(0, recentActionControl[i]);


            NumOfIndex++;
        }
    }
}
