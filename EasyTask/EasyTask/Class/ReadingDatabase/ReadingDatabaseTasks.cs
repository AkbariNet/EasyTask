using _21_4_23;
using EasyTask.Pages;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Class.ReadingDatabase
{
    internal class ReadingDatabaseTasks
    {
        public static List<string> TASKS_Names = new();
        public static List<string> TASKS_Times = new();


        static Int32 variableOfValue;
        static DateTime[] ActionTimes;
        static int[] ActionActions; static int NumOfIndex = 0;
        public static void ReadData(string connectionString, StackPanel gridForActions)
        {
            TASKS_Names.Clear();
            TASKS_Times.Clear();
            if (connectionString == null) { connectionString = App.database; }

            resetSettings(gridForActions);
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
                shortActionpros = new ShortActionpro[variableOfValue];
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
                    reader.GetInt16(10), reader.GetInt16(11), reader.GetInt16(12), NumOfIndex, reader.GetString(13), gridForActions);

                }
                //Update DateTime Timer
                NumOfIndex = 0;
                // Always call Close when done reading.
                reader.Close();
                connection.Close();
            }
        }

        public static void resetSettings(StackPanel gridForActions)
        {/*
            gridForActions.Children.Clear();*/
            try
            {
                if (shortActionpros != null)
                {
                    foreach (ShortActionpro actionpro in shortActionpros)
                    {
                        //actionpro.ClearThis();
                        actionpro.ClearThis();
                        gridForActions.Children.Clear();



                    }

                }
            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.ToString() + "!!!Main");
            }

        }







        public static ShortActionpro[] shortActionpros;
        private static uint RepeaterForDoubleNums = 1;
        public static void boxes(int ID, string TaskName, string ActionMod, int YearAction, int MonthAction, int DayAction,
            int HourAction, int MinAction, int YearActionCreated, int MonthActionCreated, int DayActionCreated,
            int HourActionCreated, int MinActionCreated, int i, string PathFile, StackPanel gridForActions)
        {


            DateTime dateTimeCreated = new DateTime(YearActionCreated, MonthActionCreated, DayActionCreated, HourActionCreated, MinActionCreated, 01);
            DateTime dateAction = new DateTime(YearAction, MonthAction, DayAction, HourAction, MinAction, 01);
            shortActionpros[i] = new ShortActionpro();
            shortActionpros[i].settimePre(ID, TaskName, ActionMod, dateAction, dateTimeCreated, PathFile);
           

            TASKS_Names.Add(TaskName );
            TASKS_Times.Add( HourAction + ":" + MinAction);
            
            shortActionpros[i].Visibility = Visibility.Visible;
            //gridForActions.Children.Add(shortActionpros[i]);
            gridForActions.Children.Insert(0, shortActionpros[i]);


            NumOfIndex++;
        }

    }
}
