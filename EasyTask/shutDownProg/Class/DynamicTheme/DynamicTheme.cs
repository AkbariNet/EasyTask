using _21_4_23;
using EasyTask.Class;
using EasyTask.Class.SettingsConfiguration;
using Microsoft.Win32;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyTask.Class.DynamicTheme
{
    internal class DynamicTheme
    {
        public static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            switch (e.Category)
            {
                case UserPreferenceCategory.General:
                    setTheme();
                    break;
            }
        }

        public static bool SystemEvents_UserPreferenceChangedBool(object sender, UserPreferenceChangedEventArgs e)
        {
            switch (e.Category)
            {
                case UserPreferenceCategory.General:
                    return IsLight();
                    break;
            }
            return IsLight();
        }
        private static bool ThemeIsLight()
        {
            RegistryKey registry =
                Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            return (int)registry.GetValue("SystemUsesLightTheme") == 1;
        }
        public static void setTheme()
        {
            if (ThemeIsLight())
            {
                LightMode_Click();
                App.LightMode = true;
            }
            else
            {
                DarkMode_Click();
                App.LightMode = false;
            }
        }


        public static bool IsLight()
        {
            if (ThemeIsLight())
            {
                App.LightMode = true;
                return true;
            }
            else
            {
                App.LightMode = false;
                return false;
            }
        }
         static string ThemeColor;
        private static void LightMode_Click()
        {
            ThemeColor = null;
            ThemeColor = UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme=="Default"?null: UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme;
            AppTheme.ChangeTheme(new Uri("../Themes/"+ThemeColor+ "LightMode.xaml", UriKind.Relative));
            ThemeColor = null;

        }

        private static void DarkMode_Click()
        {
            ThemeColor = null;
            ThemeColor = UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme == "Default" ? null : UiSet.UiSettingsSectionPropertyes.SWTheme_ColorOfAppTheme;
            AppTheme.ChangeTheme(new Uri("../Themes/" + ThemeColor + "DarkMode.xaml", UriKind.Relative));
            ThemeColor = null;
        }


    }
}
