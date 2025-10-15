using EasyTask.Class.TaskProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyTask.Class.Actions
{
    internal class CommanderForStartAction
    {
        public static void StartCommand(sbyte Action , AddTaskProcess_ForShowRecentTasks addTaskProcess_ForShowRecentTasks,Window windowforClose)
        {

                if (Action == 0)
                {
                    MessageBox.Show("ERROR :: Action Name Is Invalid! ");
               
                }
                else if (Action == 1)
                {
                    addTaskProcess_ForShowRecentTasks.AddRecentTaskToDataBase();
                    ShutDownSystemAction.StartShutDown();
                
                }
                else if (Action == 2)
                {

                    addTaskProcess_ForShowRecentTasks.AddRecentTaskToDataBase();
                    RestartSystemAction.StartRestart();
               
                }
                else if (Action == 3)
                {

                    addTaskProcess_ForShowRecentTasks.AddRecentTaskToDataBase();
                    SleepSystemAction.StartSleep();
                
                }
                if (windowforClose is null) { } else windowforClose.Close();


        }
    }
}
