using _21_4_23;
using EasyTask.Class.SettingsConfiguration;
using EasyTask.Pages;
using System;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EasyTask.Class.TaskProcessing
{
    class DeleteTaskProcess 
    {

        public bool deleteMainTask(UserControl shortActionPro,Int32 ID, string Role = "user")
        {
            ProcessInProduct processInProduct = new ProcessInProduct();
            processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Deleting___, EasyTask.Properties.Languages.Lang.ProcessInProduct_Trying_to_conntect_to_database___);
            if (UiSet.UiSettingsSectionPropertyes.IsLock)
            {


                if (!UiSet.UiSettingsSectionPropertyes.SWTWhenLockModeIsEnableWeCantDeleteTask || Role=="Admin")
                {
                   bool result= StartDeleteTask(shortActionPro, ID, Role);
                    return result;
                }
                else
                {
                    
                    processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_Lock_Enabled, EasyTask.Properties.Languages.Lang.ProcessInProduct_When_lock_is_Enabled_you_can_t_Delete_a_task);
                    processInProduct.ShowDialog();
                    return false;
                }
            }
            else
            {
                bool result = StartDeleteTask(shortActionPro, ID, Role);
                return result;
            }
        }
        public bool StartDeleteTask(UserControl shortActionPro, Int32 ID, string Role = "user" )
        {
            ProcessInProduct processInProduct = new ProcessInProduct();
            try
            {
                string queryString = "DELETE FROM action_saves WHERE ID=" + ID + ";";

                OleDbConnection connection = new OleDbConnection(App.database);
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Storyboard sbForRemove = shortActionPro.FindResource("RemovingThis") as Storyboard;
                Storyboard.SetTarget(sbForRemove, shortActionPro);
                sbForRemove.Begin();
                processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Deleting___, EasyTask.Properties.Languages.Lang.ProcessInProduct_Trying_to_conntect_to_database___);

                processInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.ProcessInProduct_Delete_Sucsess, EasyTask.Properties.Languages.Lang.ProcessInProduct_The_Task_is_deleted);
                return true;


            }
            catch (Exception ex)
            {
                processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Deleting___, EasyTask.Properties.Languages.Lang.ProcessInProduct_Trying_to_conntect_to_database___);

                processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.DefaultTextName_Unsuccessful, ex.Message);
                processInProduct.ShowDialog();
                return false;
            }
        }
    }
    class DeleteTaskProcess_Recent
    {

        public bool deleteRecentTask(Int32 ID)
        {
            ProcessInProduct processInProduct = new ProcessInProduct();
            processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Deleting___, EasyTask.Properties.Languages.Lang.ProcessInProduct_Trying_to_conntect_to_database___);
           

                try
                {
                    string queryString = "DELETE FROM action_saves WHERE ID=" + ID + ";";

                    OleDbConnection connection = new OleDbConnection(App.databaseRecentActions);
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();/*
                    Storyboard sbForRemove = this.FindResource("RemovingThis") as Storyboard;
                    Storyboard.SetTarget(sbForRemove, ShortActionPro);
                    sbForRemove.Begin();*/
                    return true;


                }
                catch (Exception ex)
                {
                    processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.DefaultTextName_Unsuccessful, ex.Message);
                    processInProduct.ShowDialog();
                    return false;
                }
           
        }
    }
}
