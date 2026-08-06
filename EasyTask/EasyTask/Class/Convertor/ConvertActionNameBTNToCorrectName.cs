using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Class.Convertor
{
    internal class ConvertActionNameBTNToCorrectName
    {
        public static string Convertor(string ActionRAW,TextBlock TextBlockNameChange,string pathFileForShow)
        {

            if (ActionRAW == "ShutDownBtn")
            {
                TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_ShutDown;
                return "Shut Down";
            }
            else if (ActionRAW == "RestartBtn")
            {
                TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_ReStart;
                return "Restart";
            }
            else if (ActionRAW == "SleepBtn")
            {
                TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_Sleep;
                return "Sleep";
            }
            else if (ActionRAW == "OpenFileBtn")
            {
                TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_OpenFile;
                TextBlockNameChange.ToolTip = pathFileForShow;
                return "Open File";
            }
            else if (ActionRAW == "KillAppBtn")
            {

                string[] array = pathFileForShow.Split('#');
                List<string> list = new List<string>();
                list.AddRange(array);
                TextBlockNameChange.ToolTip = String.Join(",", list);
                TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_KillApp; 
                if (list.Count > 1)
                {

                    TextBlockNameChange.Text = Properties.Languages.Lang.S3AddTaskWindow_KillApp ;
                }
                return "Kill Application";
            }
            else
            {
                return "null";
            }
        }
    }
}
