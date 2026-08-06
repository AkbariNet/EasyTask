using _21_4_23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;
namespace EasyTask.Class
{
    class AppTheme
    {
        public static void ChangeTheme(Uri uritheme)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = uritheme };
            
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            IncludeDefaultResources.Include();
        }
    }
}
