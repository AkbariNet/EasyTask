using EasyTask.Pages;
using EasyTask.Pages.PagesConnectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Class.SettingsConfiguration
{
    internal class UiSet
    {
        public static Configuration ETConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static ConfigurationSection UiSettingsSection;
        public static UiSettingsViewModel UiSettingsSectionPropertyes ;
        public static void UiSetStart()
        {
            if (ETConfiguration.Sections["UiSettingsViewModel"] is null)
            {
                ETConfiguration.Sections.Add("UiSettingsViewModel", new UiSettingsViewModel());
                

            }
            UiSettingsSection = ETConfiguration.GetSection("UiSettingsViewModel");
               UiSettingsSectionPropertyes = (UiSettingsViewModel)UiSet.ETConfiguration.Sections["UiSettingsViewModel"];

    }


    public static  void SaveSettings()
        {/*
            ETConfiguration.Sections.Clear();
            ETConfiguration.Sections.Add("UiSettingsViewModel", UiSettingsSection);
*/
            ETConfiguration.Save();
        }
    }


}
