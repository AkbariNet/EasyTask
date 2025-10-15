using EasyTask.Class.SettingsConfiguration;
using EasyTask.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Windows.System;

namespace EasyTask.Class.Actions
{
    internal class OpenFileSystemAction
    {
        public static bool IsOpen(string PathAppPlace )

        {
            ProcessInProduct processInProduct = new ProcessInProduct();
            ApplyingProcessTask applyingProcessTask = new ApplyingProcessTask();

            if (UiSet.UiSettingsSectionPropertyes.SWPEnbTimerWindow)
            {
                applyingProcessTask.ChangeTitleAndSubtitle(SubtitleText: EasyTask.Properties.Languages.Lang.ApplyingProcessTask_Starting_process_of_open_your_exe_app + " ..", TitleText: EasyTask.Properties.Languages.Lang.ApplyingProcessTask_Opening_your_app);
                applyingProcessTask.ShowDialog();


            }
            else
            {
                applyingProcessTask.KillStart = true;
            }
            processInProduct.Show();
            if (applyingProcessTask.KillStart)
            { 

            try
            {
                Process.Start(PathAppPlace);
               
                processInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.DefaultTextName_Sucsses, EasyTask.Properties.Languages.Lang.ProcessInProduct_Your_program_has_been_opened);
                return true;


            }
            catch (Exception)
            {
                processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_The_file_does_not_open, EasyTask.Properties.Languages.Lang.ProcessInProduct_This_can_have_various_reasons__test_that_your_file_opens_or_that_the_file_has_not_been_moved_or_deleted_ );
                return false; throw;
            }

            }
            else
            {
                processInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.DefaultTextName_Sucsses, EasyTask.Properties.Languages.Lang.ProcessInProduct_Open_EXE_Succesfully_Canceled);
                return false; 

            }
               
        }
    }
}
