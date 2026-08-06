using EasyTask.Pages;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using shutDownProg;
using Teimer = System.Timers.Timer;
using _21_4_23;

namespace EasyTask.Class.TaskProcessing
{
    class AddTaskProcess 
    {
        
        public bool AddTaskToDataBase(string taskNameFinal , DateTime dateCreatedtime,DateTime dateAndTimeFinalyStartAction, string finalAction, Window WINDOW,string pathFile)
        {

            ProcessInProduct prossesInProduct = new ProcessInProduct();
            prossesInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_AddTask, EasyTask.Properties.Languages.Lang.ProcessInProduct_Add_Your_Task_to_DataBase___);
            prossesInProduct.Show();
            WINDOW.IsEnabled = false;
            try
            {
               // string send = ("\n\n\n" + taskNameFinal+ "\n" + dateCreatedtime.ToString() + "\n" + dateAndTimeFinalyStartAction.ToString() + "\n" + finalAction);

             //   File.AppendAllText("tasks/AllTasks.txt", send);
                OleDbConnection conn = new OleDbConnection(App.database);
                conn.Open();
                string cmdstr = "insert into action_saves (action_Taskname,action_mode,year_action,month_action,day_action,hour_action,minute_action,year_action_created,month_action_created,day_action_created,hour_action_created,minute_action_created,filepath_or_name) values(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                OleDbCommand clmd = new OleDbCommand(cmdstr, conn);
                clmd.Parameters.AddWithValue("action_Taskname", taskNameFinal);
                clmd.Parameters.AddWithValue("action_mode", finalAction);
                clmd.Parameters.AddWithValue("year_action", (Int32)dateAndTimeFinalyStartAction.Year);
                clmd.Parameters.AddWithValue("month_action", (Int32)dateAndTimeFinalyStartAction.Month);
                clmd.Parameters.AddWithValue("day_action", (Int32)dateAndTimeFinalyStartAction.Day);
                clmd.Parameters.AddWithValue("hour_action", (Int32)dateAndTimeFinalyStartAction.Hour);
                clmd.Parameters.AddWithValue("minute_action", (Int32)dateAndTimeFinalyStartAction.Minute);
                clmd.Parameters.AddWithValue("year_action_created", (Int32)dateCreatedtime.Year);
                clmd.Parameters.AddWithValue("month_action_created", (Int32)dateCreatedtime.Month);
                clmd.Parameters.AddWithValue("day_action_created", (Int32)dateCreatedtime.Day);
                clmd.Parameters.AddWithValue("hour_action_created", (Int32)dateCreatedtime.Hour);
                clmd.Parameters.AddWithValue("minute_action_created", (Int32)dateCreatedtime.Minute);
                clmd.Parameters.AddWithValue("filepath_or_name", pathFile);

                clmd.ExecuteNonQuery();
                conn.Close();
                try
                {
                    prossesInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.DefaultTextName_Sucsses, EasyTask.Properties.Languages.Lang.ProcessInProduct_YourTask_Is_Added_To_Application);

                }
                catch
                {
                }
                WINDOW.IsEnabled = true;
                
                WINDOW.Close();
                return true;
            }
            catch (Exception ex) 
            {
             //   MessageBox.Show(ex.Message);
                prossesInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.DefaultTextName_Unsuccessful, EasyTask.Properties.Languages.Lang.ProcessInProduct_YourTask_Is_Not_Added_To_Application+ " \n EX:" +ex);


                WINDOW.Close();
                return false;
            }

        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    class AddTaskProcess_ForShowRecentTasks
    {
        string taskNameFinal; DateTime dateCreatedtime; DateTime dateAndTimeFinalyStartAction; string finalAction;  string pathFile;
        public void requestAndFillIdandValues(string TaskNameFinal, DateTime DateCreatedtime, DateTime DateAndTimeFinalyStartAction, string FinalAction, string PathFile)
        {
             
             taskNameFinal=TaskNameFinal;  dateCreatedtime=DateCreatedtime;  dateAndTimeFinalyStartAction=DateAndTimeFinalyStartAction;  finalAction=FinalAction;  pathFile=PathFile;
        }
        public bool AddRecentTaskToDataBase()
        {

            //WINDOW.IsEnabled = false;
            try
            {
                // string send = ("\n\n\n" + taskNameFinal+ "\n" + dateCreatedtime.ToString() + "\n" + dateAndTimeFinalyStartAction.ToString() + "\n" + finalAction);

                //   File.AppendAllText("tasks/AllTasks.txt", send);

                //set Database
                OleDbConnection conn = new OleDbConnection(App.databaseRecentActions);

                conn.Open();
                string cmdstr = "insert into action_saves (action_Taskname,action_mode,year_action,month_action,day_action,hour_action,minute_action,year_action_created,month_action_created,day_action_created,hour_action_created,minute_action_created,filepath_or_name) values(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                OleDbCommand clmd = new OleDbCommand(cmdstr, conn);
                clmd.Parameters.AddWithValue("action_Taskname", taskNameFinal);
                clmd.Parameters.AddWithValue("action_mode", finalAction);
                clmd.Parameters.AddWithValue("year_action", (Int32)dateAndTimeFinalyStartAction.Year);
                clmd.Parameters.AddWithValue("month_action", (Int32)dateAndTimeFinalyStartAction.Month);
                clmd.Parameters.AddWithValue("day_action", (Int32)dateAndTimeFinalyStartAction.Day);
                clmd.Parameters.AddWithValue("hour_action", (Int32)dateAndTimeFinalyStartAction.Hour);
                clmd.Parameters.AddWithValue("minute_action", (Int32)dateAndTimeFinalyStartAction.Minute);
                clmd.Parameters.AddWithValue("year_action_created", (Int32)dateCreatedtime.Year);
                clmd.Parameters.AddWithValue("month_action_created", (Int32)dateCreatedtime.Month);
                clmd.Parameters.AddWithValue("day_action_created", (Int32)dateCreatedtime.Day);
                clmd.Parameters.AddWithValue("hour_action_created", (Int32)dateCreatedtime.Hour);
                clmd.Parameters.AddWithValue("minute_action_created", (Int32)dateCreatedtime.Minute);
                clmd.Parameters.AddWithValue("filepath_or_name", pathFile);

                clmd.ExecuteNonQuery();
                conn.Close();
               
                return true;
            }
            catch (Exception ex)
            {
                ProcessInProduct prossesInProduct = new ProcessInProduct();
                prossesInProduct.ShowDialog();
                prossesInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_AddTask, EasyTask.Properties.Languages.Lang.ProcessInProduct_Add_Your_Task_to_DataBase___);
                prossesInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.DefaultTextName_Unsuccessful, EasyTask.Properties.Languages.Lang.ProcessInProduct_Your_task_is_not_add_to_recent_tasks+ " \n EX:" + ex.Message);


                
                return false;
            }

        }
    }
}
