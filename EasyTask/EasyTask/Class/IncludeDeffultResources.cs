using _21_4_23;
using System;
using System.Windows;

namespace EasyTask.Class
{
    internal class IncludeDefaultResources
    {
     public static void  Include()
        {

            if (Properties.Languages.Lang.Language == "EN")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "FA")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.RightToLeft;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Vazirmatn.ttf #Vazirmatn");
            }

            else if(Properties.Languages.Lang.Language == "AR")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.RightToLeft;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Vazirmatn.ttf #Vazirmatn");
            }
            else if(Properties.Languages.Lang.Language == "es-419")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "fr-FR")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "de-DE")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "zh-CN")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "ru-RU")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
            else if (Properties.Languages.Lang.Language == "pt-PT")
            {
                App.Current.Resources["FlowAll"] = FlowDirection.LeftToRight;
                App.Current.Resources["MainFont"] = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./files/Fonts/Inter.ttf #Inter");
            }
        }


    }
}
