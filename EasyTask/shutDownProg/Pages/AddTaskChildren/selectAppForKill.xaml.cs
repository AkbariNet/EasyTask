using EasyTask.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace EasyTask.Pages.AddTaskChildren
{
    /// <summary>
    /// Interaction logic for selectAppForKill.xaml
    /// </summary>// CS1106.cs

    public partial class SelectAppForKill : FluentWindow
    {
        public static List<string> variablesPre = new List<string>();




        public bool AllItemsButtonBool
        {
            get { return (bool)GetValue(AllItemsButtonBoolProperty); }
            set { SetValue(AllItemsButtonBoolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllAllItemsButtonBool.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllItemsButtonBoolProperty =
            DependencyProperty.Register("AllItemsButtonBool", typeof(bool), typeof(SelectAppForKill), new PropertyMetadata(false));



        public bool SuggestItemsButtonBool
        {
            get { return (bool)GetValue(SuggestItemsButtonBoolProperty); }
            set { SetValue(SuggestItemsButtonBoolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SuggestItemsButtonBool.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuggestItemsButtonBoolProperty =
            DependencyProperty.Register("SuggestItemsButtonBool", typeof(bool), typeof(SelectAppForKill), new PropertyMetadata(false));

        public SelectAppForKill()
        {
            variablesPre.Clear();
            AddTaskWindow.variables.Clear();
            InitializeComponent();
            AllItemsButton.IsChecked = true;
        }
        public void StartFindApps()
        {
            SAFKItem[] sAFKItems = new SAFKItem[Process.GetProcesses().Length];
            SAFKItem[] sAFKItems2 = new SAFKItem[Process.GetProcesses().Length];
            int i = 0;
            foreach (SAFKItem aFKItem in sAFKItems)
            {
                sAFKItems[i] = new SAFKItem();
                sAFKItems2[i] = new SAFKItem();
                i++;
            }
            int sAFKValue = 0;
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName != "svchost")
                {
                    bool Handler = false;
                    foreach (SAFKItem sAFKItem in sAFKItems)
                    {
                        if (sAFKItem.TitleValue is null)
                        {

                        }
                        else if (sAFKItem.TitleValue == process.ProcessName)
                        {
                            Handler = true;
                        }
                    }
                    if (!Handler)
                    {
                        try
                        {

                            sAFKItems[sAFKValue].TitleValue = process.ProcessName;
                            sAFKItems2[sAFKValue].TitleValue = process.ProcessName;
                            sAFKItems[sAFKValue].ProcessNameOfApp = process.ProcessName;
                            sAFKItems2[sAFKValue].ProcessNameOfApp = process.ProcessName;

                            Icon ico = ProcessExtensions.GetIcon(process);
                            if (ico != null)
                            {
                                sAFKItems[sAFKValue].IconPng.Source = IconToPng.PngFromIcon(ico);
                                sAFKItems2[sAFKValue].IconPng.Source = IconToPng.PngFromIcon(ico);
                                StackOfSuggestAppsEnable.Items.Insert(0, sAFKItems2[sAFKValue]);

                            }
                            // sAFKItems[sAFKValue].ProcessNameOfApp = process.MainModule.FileName;

                            StackOfAllAppsEnable.Items.Insert(0, sAFKItems[sAFKValue]);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }


                }
                sAFKValue++;

            }

        }

        private void FluentWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow.variables.Clear();
            variablesPre.Clear();
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow.variables.Clear();
            AddTaskWindow.variables.AddRange(variablesPre);
            variablesPre.Clear();
            this.Close();
        }

        private void SuggestedItemsButton_Checked(object sender, RoutedEventArgs e)
        {
            StackOfAllAppsEnable.Visibility=Visibility.Collapsed;
            StackOfSuggestAppsEnable.Visibility = Visibility.Visible;
            AllItemsButton.IsChecked=false;
            AllItemsButton.IsTabStop = true;
            AllItemsButton.IsHitTestVisible = true;
            SuggestedItemsButton.IsTabStop = false;
            SuggestedItemsButton.IsHitTestVisible = false;
        }

        private void AllItemsButton_Checked(object sender, RoutedEventArgs e)
        {
            StackOfAllAppsEnable.Visibility = Visibility.Visible;
            StackOfSuggestAppsEnable.Visibility = Visibility.Collapsed;
            SuggestedItemsButton.IsChecked = false;
            AllItemsButton.IsTabStop = false;
            AllItemsButton.IsHitTestVisible = false;
            SuggestedItemsButton.IsTabStop = true;
            SuggestedItemsButton.IsHitTestVisible = true;
        }
    }

    public static class ProcessExtensions
    {
        [DllImport("Kernel32.dll")]
        private static extern uint QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);

        public static string GetMainModuleFileName(this Process process, int buffer = 1024)
        {
            var fileNameBuilder = new StringBuilder(buffer);
            uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
            return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) != 0 ?
                fileNameBuilder.ToString() :
                null;
        }

        public static Icon GetIcon(this Process process)
        {
            try
            {
                string mainModuleFileName = process.GetMainModuleFileName();
                return Icon.ExtractAssociatedIcon(mainModuleFileName);
            }
            catch
            {
                // Probably no access
                return null;
            }
        }
    }
}
