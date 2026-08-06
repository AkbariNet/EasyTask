using EasyTask.Class.SettingsConfiguration;
using EasyTask.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Windows.Media.Devices;

namespace EasyTask.Class.Actions
{
    internal class KillFileSystemAction
    {
       
      static  bool successfull=false;
       static List<string> list = new List<string>();
        static List<string> listKilled = new List<string>();
        public static bool IsKilling(string PathAppPlace)
        {
            successfull = false; list.Clear(); listKilled.Clear();
            ApplyingProcessTask applyingProcessTask = new ApplyingProcessTask();
             ProcessInProduct processInProduct = new ProcessInProduct();
            applyingProcessTask.ChangeTitleAndSubtitle(null, null) ;
            processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Killing_your_app__, EasyTask.Properties.Languages.Lang.ProcessInProduct_Starting_process_of_Kill_your_file__);
            list.ForEach(delegate (string s)
            {
                foreach (Process proc in Process.GetProcessesByName(s))
                {

                }

            });
            list.Clear();
            string[] array = PathAppPlace.Split('#');
            list.AddRange(array);
            if (UiSet.UiSettingsSectionPropertyes.SWPEnbTimerWindow)
            {
                applyingProcessTask.ChangeTitleAndSubtitle(null, Properties.Languages.Lang.ApplyingProcessTask_start_process_of_kill + String.Join(",", list) + "..");
                applyingProcessTask.ShowDialog();

            }
            else
            {
                applyingProcessTask.KillStart = true;
            }
            if (applyingProcessTask.KillStart)
            {
                processInProduct.Show();

                try
                {
                    list.ForEach(delegate (string s)
                        {
                            foreach (Process proc in Process.GetProcessesByName(s))
                            {
                                proc.Kill();
                                listKilled.Add(s);
                                list.Remove(s);
                                if (list.Count == 0)
                                {
                                    successfull = true;
                                    processInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.ProcessInProduct_Your_program_has_been_Killed, EasyTask.Properties.Languages.Lang.ProcessInProduct_Programs_name + String.Join(",", listKilled));
                                   // processInProduct.ProssesAbout.Visibility = Visibility.Collapsed;
                                    break;
                                }

                            }

                        });

                
   
                    if (successfull)
                        return true;
                    else return false;
                }
                catch (Exception)
                {
                    if (list.Count != 0)
                    {
                        processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_Presence_of_disorder, EasyTask.Properties.Languages.Lang.ProcessInProduct_This_can_have_various_reasons__test_that_your_file_opens_or_that_the_file_has_not_been_moved_or_deleted_  +"\n"+ EasyTask.Properties.Languages.Lang.ProcessInProduct_Running_programs_that_were_not_found + String.Join(",", list) + EasyTask.Properties.Languages.Lang.ProcessInProduct_These_programs_were_successfully_killed + String.Join(",", listKilled));

                        return false;
                    }
                    else if (!successfull)
                    {
                        processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_Probably_there_is_a_problem, EasyTask.Properties.Languages.Lang.ProcessInProduct_This_can_be_for_a_number_of_reasons__test_that_your_file_is_closed_or_that_the_file_is_not_closed_or_frozen_ + EasyTask.Properties.Languages.Lang.ProcessInProduct_These_programs_were_successfully_killed + String.Join(",", listKilled));


                    }


                    if (successfull)
                        return true;
                    else
                        return false;
                    throw;
                }
            }
            else
            {
                processInProduct.Show();
                processInProduct.GetRespond(true, EasyTask.Properties.Languages.Lang.ProcessInProduct_Kill_Succesfully_Canceled,"");
                return false;
            }
        }

    }
}
