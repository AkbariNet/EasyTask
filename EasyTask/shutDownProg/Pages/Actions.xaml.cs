using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace shutDownProg.Pages
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class UserControl1 : UserControl
    {
        static int action;
        public uint NameOfAction;
        public uint ActionForSend;
        DateTime DateCreatedAction;
        static DateTime DateStartAction;
        public UserControl1()
        {
            InitializeComponent();
        }
      public static string database = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = actionDetails_Run.mdb;" + "User Id=admin; password=;";
        Int32 id;
      public static Int32 IDFORSHARE;
        public void settimePre(int ID, string TaskName, string ActionMod, DateTime dateAction, DateTime dateTimeCreated)
        {
            DateStartAction = dateAction;
            DateCreatedAction = dateTimeCreated;
            dateCreatedPreview.Content = dateTimeCreated.Date;
            id = ID;
            IDFORSHARE = ID;
            startDatePreview.Content = dateAction.Date;
            string MainString = dateAction.TimeOfDay.ToString();
            string[] Split = MainString.Split(new Char[] { ':' });
            startTimePreview.Content = Split[0] + ":" + Split[1];
            //SHOW RESULT

            actionPreview.Content = ActionMod;
            taskNamePreview.Content = TaskName + "  ID:" + ID;
            if (ActionMod == "Shut Down")
            {
                action = 1;
                ActionForSend = 1;
            }
            else if (ActionMod == "Restart")
            {
                action = 2;
                ActionForSend = 2;
            }
            else if (ActionMod == "Sleep")
            {
                action = 3;
                ActionForSend = 3;
            }
/*
            setActionAndTimers();*/
        }
        bool Refresh = false;
        public bool refresh { get { return Refresh; } set { } }
        private void deleteButtonTask_Click_1(object sender, RoutedEventArgs e)
        {
            deleteTask(id);
        }
        public void deleteTask(Int32 ID)
        {
            string queryString = "DELETE FROM action_saves WHERE ID=" + ID + ";";

            OleDbConnection connection = new OleDbConnection(database);
            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            dateCreatedPreview.Content = "#DELETED";
            startDatePreview.Content = "#DELETED";
            startTimePreview.Content = "##:##";
            actionPreview.Content = "#DELETED";
            taskNamePreview.Content = "#DELETED";
            this.Visibility = Visibility.Collapsed;

            Refresh = true;
            ActionForSend = 0;/*
            setActionAndTimers();*/
        }



/*        private void setActionAndTimers()
        {
            TimerSet.SetTimeForTick(NameOfAction, ActionForSend,DateStartAction,id);
        }*/
    }
}
