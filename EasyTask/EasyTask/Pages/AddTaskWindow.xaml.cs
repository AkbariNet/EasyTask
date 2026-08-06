using EasyTask.Class;
using EasyTask.Class.TaskProcessing;
using EasyTask.Pages.AddTaskChildren;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : FluentWindow
    {
        // CREATE CLASS OF METHODS
        GetVariablesSteps GetVariablesSteps = new GetVariablesSteps();
        string pathFile="null";
       public static List<string> variables = new List<string>();
        public AddTaskWindow()
        {
            InitializeComponent();
            Start();

        }
        private void Start()
        {
            variables.Clear();
            pathFile = "null";
            resetAllpages();
            processofpages();
            StarterCreator();
            GetVariablesSteps.TypeOfAction = ShutDownBtn.Name.ToString();

        }

        private void StarterCreator()
        {

            TrueProssesGridStep1.Visibility = Visibility.Collapsed;
            TrueProssesGridStep2.Visibility = Visibility.Collapsed;
            TrueProssesGridStep3.Visibility = Visibility.Collapsed;
            TrueProssesGridStep4.Visibility = Visibility.Collapsed;
            DateTime FirstDateStart = GetVariablesSteps.FirstSet();
            
            //set Now date on boxes

            yearBoxS1.Text = FirstDateStart.Year.ToString();
            monthBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(FirstDateStart.Month);
            dayBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(FirstDateStart.Day);
            hourBoxS2.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(FirstDateStart.Hour);
            minuteBoxS2.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(FirstDateStart.Minute);



        }

        // Item Events {

                // BACK & NEXT BUTTON "
                private void btn_Click(object sender, RoutedEventArgs e)
                        {
                            processofpages();
                        }
   private void Button_Click(object sender, RoutedEventArgs e)
                        {
                            backProcessofPages();
                        }
   // " BACK & NEXT BUTTON
   //Close Button
   private void BTNTEMPLATEClicked_Copy_Click(object sender, RoutedEventArgs e)
                        {
                            this.Close();
                        }
        //Close Button


        //Step 1 "
        private void yearBoxS1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                bool yearTrue = GetVariablesSteps.checkYear(Convert.ToInt32(yearBoxS1.Text));
                if (!yearTrue)
                {
                    yearBoxS1.Text = GetVariablesSteps.year.ToString();
                }
            }
            catch
            {
                yearBoxS1.Text = GetVariablesSteps.year.ToString();
            }

        }
        private void monthBoxS1_LostFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                bool monthTrue = GetVariablesSteps.checkMonth(Convert.ToInt32(monthBoxS1.Text));

                monthBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.month);
            }
            catch
            {
                monthBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.month);
            }

        }
        private void dayBoxS1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                bool dayTrue = GetVariablesSteps.checkDay(Convert.ToInt32(dayBoxS1.Text));

                dayBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.day);
            }
            catch { dayBoxS1.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.day); }

        }
        //" Step 1

        //Step 2 "
        private void hourBoxS2_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                bool hourTrue = GetVariablesSteps.checkHour(Convert.ToInt32(hourBoxS2.Text));
                GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.hour);
            }
            catch
            {
                hourBoxS2.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.hour);
            }

        }
        private void minuteBoxS2_LostFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                bool minuteTrue = GetVariablesSteps.checkMinute(Convert.ToInt32(minuteBoxS2.Text));
                minuteBoxS2.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.minute);


            }
            catch
            {
                minuteBoxS2.Text = GetVariablesSteps.CheckHaveZeroForOnetoTen(GetVariablesSteps.minute);
            }
        }
        //" Step 2

        //  Step 3 & 4 "
        private void ActionsButtonChecked(object sender, RoutedEventArgs e)
        {
            bool Getway=true;
            ToggleButton Abutton = sender as ToggleButton;

            if (Abutton.Name == "ShutDownBtn")
            {
                RestartBtnBool = false;
                OpenFileBtnBool = false;
                SleepBtnBool = false;
                KillAppBtnBool = false;
                Abutton.IsTabStop = false;
                Abutton.IsHitTestVisible = false;
            }

            else if (Abutton.Name == "RestartBtn")
            {
                ShutDownBtnBool = false;
                OpenFileBtnBool = false;
                SleepBtnBool = false;
                KillAppBtnBool = false;
                Abutton.IsTabStop = false;
                Abutton.IsHitTestVisible = false;
            }

            else if (Abutton.Name == "SleepBtn")
            {
                RestartBtnBool = false;
                ShutDownBtnBool = false;
                OpenFileBtnBool = false;
                KillAppBtnBool = false;
                Abutton.IsTabStop = false;
                Abutton.IsHitTestVisible = false;
            }
            else if (Abutton.Name == "OpenFileBtn")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "\"EXE files (*.EXE, *.MSI)|*.EXE;*.MSI\"'";
                openFileDialog.FilterIndex = 0;
                openFileDialog.ShowDialog();
                pathFile = openFileDialog.FileName;
                pathFile = pathFile.Replace(@"\", @"\\");
                if (openFileDialog.FileName.Length <= 0)
                {
                    Getway = false;
                    OpenFileBtnBool = false;
                    Abutton.IsTabStop = true;
                    Abutton.IsHitTestVisible = true;
                }
                else
                {
                    Getway = true;
                    RestartBtnBool = false;
                    ShutDownBtnBool = false;
                    SleepBtnBool = false;
                    KillAppBtnBool = false;
                    Abutton.IsTabStop = false;
                    Abutton.IsHitTestVisible = false;
                }
            }

            else if (Abutton.Name == "KillAppBtn")
            {
                SelectAppForKill selectAppForKill = new SelectAppForKill();
                selectAppForKill.StartFindApps();
                selectAppForKill.ShowDialog();
                if (variables.Count <= 0)
                {
                    Getway = false;
                    KillAppBtnBool = false;

                    Abutton.IsTabStop = true;
                    Abutton.IsHitTestVisible = true;
                }
                else
                {
                    Getway = true;
                    pathFile = String.Join("#", variables);
                    RestartBtnBool = false;
                    ShutDownBtnBool = false;
                    SleepBtnBool = false;
                    OpenFileBtnBool = false;

                    Abutton.IsTabStop = false;
                    Abutton.IsHitTestVisible = false;

                }
            }


            if (!Getway )
            { }
            else
            {
                GetVariablesSteps.TypeOfAction = Abutton.Name.ToString();

            }

        }
        // " Step 3 & 4 



        //Create Vareable Of BTNS


        public bool ShutDownBtnBool
        {
            get { return (bool)GetValue(ShutDownBtnBoolProperty); }
            set { SetValue(ShutDownBtnBoolProperty, value); }
        }

        public static readonly DependencyProperty ShutDownBtnBoolProperty =
            DependencyProperty.Register("ShutDownBtnBool", typeof(bool), typeof(AddTaskWindow), new PropertyMetadata(true));



        public bool RestartBtnBool
        {
            get { return (bool)GetValue(RestartBtnBoolProperty); }
            set { SetValue(RestartBtnBoolProperty, value); }
        }

        public static readonly DependencyProperty RestartBtnBoolProperty =
            DependencyProperty.Register("RestartBtnBool", typeof(bool), typeof(AddTaskWindow), new PropertyMetadata(false));




        public bool SleepBtnBool
        {
            get { return (bool)GetValue(SleepBtnBoolProperty); }
            set { SetValue(SleepBtnBoolProperty, value); }
        }

        public static readonly DependencyProperty SleepBtnBoolProperty =
            DependencyProperty.Register("SleepBtnBool", typeof(bool), typeof(AddTaskWindow), new PropertyMetadata(false));



        public bool OpenFileBtnBool
        {
            get { return (bool)GetValue(OpenFileBtnBoolProperty); }
            set { SetValue(OpenFileBtnBoolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenFileBtnBool.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenFileBtnBoolProperty =
            DependencyProperty.Register("OpenFileBtnBool", typeof(bool), typeof(AddTaskWindow), new PropertyMetadata(false));



        public bool KillAppBtnBool
        {
            get { return (bool)GetValue(KillAppBtnBoolProperty); }
            set { SetValue(KillAppBtnBoolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KillFileBtnBool.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KillAppBtnBoolProperty =
            DependencyProperty.Register("KillAppBtnBool", typeof(bool), typeof(AddTaskWindow), new PropertyMetadata(false));








        // Item Events }



        //Page Assistent {
        private void processofpages()
        {
            if (Step1.Visibility == Visibility.Visible)
            {
                TrueProssesGridStep1.Visibility = Visibility.Visible;
                resetAllpages(); ResetAllLabels();
                SetBoldLabels(2);
                Step2.Visibility = Visibility.Visible;
            }
            else if (Step2.Visibility == Visibility.Visible)
            {
                resetAllpages(); ResetAllLabels();
                SetBoldLabels(3);
                Step3.Visibility = Visibility.Visible;
            }
            else if (Step3.Visibility == Visibility.Visible)
            {
                resetAllpages(); ResetAllLabels();
                SetBoldLabels(4);
                Step4.Visibility = Visibility.Visible;
            }
            else if (Step4.Visibility == Visibility.Visible)
            {
                GetVariablesSteps.TaskName = TaskNameBoxS4.Text;
                GetVariablesSteps.FinalSaveToDataBase(this,pathFile);
            }
           else if (Step1.Visibility == Visibility.Collapsed)
            {
                TrueProssesGridStep1.Visibility = Visibility.Visible;
                resetAllpages(); ResetAllLabels();
                SetBoldLabels(1);
                Step1.Visibility = Visibility.Visible;
            }

        }
        private void backProcessofPages()
        {
             if (Step1.Visibility == Visibility.Visible)
            {
                resetAllpages();
                ResetAllLabels();
                SetBoldLabels(1);
                this.Close();
            }
            else if (Step2.Visibility == Visibility.Visible)
            {
                resetAllpages();
                ResetAllLabels();
                SetBoldLabels(1);
                Step1.Visibility = Visibility.Visible;
            }
            else if (Step3.Visibility == Visibility.Visible)
            {
                resetAllpages();
                ResetAllLabels();
                SetBoldLabels(2);
                Step2.Visibility = Visibility.Visible;
            }
            else if (Step4.Visibility == Visibility.Visible)
            {
                resetAllpages();
                ResetAllLabels();
                SetBoldLabels(3);
                Step3.Visibility = Visibility.Visible;
            }



        }
        private void resetAllpages()
        {

            Step1.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Collapsed;
            Step3.Visibility = Visibility.Collapsed;
            Step4.Visibility = Visibility.Collapsed;
        }


        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            EnterActionScroll.ScrollToEnd();
        }

        private void ActionsButtonUnChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton Abutton = sender as ToggleButton;

            
            Abutton.IsTabStop = true;
            Abutton.IsHitTestVisible = true;
        }
        // Page Assistent }


        // Steps Label Assistent {
        private void ResetAllLabels()
        {
            SolidColorBrush nullbrush = new SolidColorBrush(Colors.Transparent);
            SetActionElp.Fill = nullbrush;
            SetDateElp.Fill = nullbrush;
            SetTaskNameElp.Fill = nullbrush;
            SetTimeElp.Fill = nullbrush;
            //
            SetActionLabel.FontWeight = FontWeights.Normal;
            SetDateLabel.FontWeight = FontWeights.Normal;
            SetTaskNameLabel.FontWeight = FontWeights.Normal;
            SetTimeLabel.FontWeight = FontWeights.Normal;
        }
        private void SetBoldLabels(int key)
        {
        
            if (key==1)
            {
                TrueProssesGridStep1.Visibility = Visibility.Visible;
                SetDateElp.Fill = SetDateElp.Stroke;
                SetDateLabel.FontWeight = FontWeights.SemiBold;
            }
            else if (key == 2)
            {
                TrueProssesGridStep2.Visibility = Visibility.Visible;
                SetTimeElp.Fill = SetTimeElp.Stroke;
                SetTimeLabel.FontWeight = FontWeights.SemiBold;
            }
            else if (key == 3)
            {
                TrueProssesGridStep3.Visibility = Visibility.Visible;
                SetActionElp.Fill = SetActionElp.Stroke;
                SetActionLabel.FontWeight = FontWeights.SemiBold;
            }
           else  if (key == 4)
            {
                TrueProssesGridStep4.Visibility = Visibility.Visible;
                SetTaskNameElp.Fill = SetActionElp.Stroke;
                SetTaskNameLabel.FontWeight = FontWeights.SemiBold;
            }
        }
        bool isTaskRibbonHide = false;
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width<860)
            {

                if (!isTaskRibbonHide)
                {
                    RunStoryboard.Run("Out", this, null, TasksRibbon);
                    isTaskRibbonHide = true;

                }
            }
            else
            {

                TasksRibbon.Visibility = Visibility.Visible;
                if (isTaskRibbonHide)
                {
                    TasksRibbon.Visibility = Visibility.Visible;
                    Allsteps.HorizontalAlignment = HorizontalAlignment.Stretch;
                    Allsteps.VerticalAlignment = VerticalAlignment.Stretch;
                    Allsteps.Margin = new Thickness(30, 30, 30, 150);
                    RunStoryboard.Run("In", this, null, TasksRibbon);
                    isTaskRibbonHide =false;

                }

            }
        }
        private void In_Completed(object sender, EventArgs e)
        {

        }

        private void Out_Completed(object sender, EventArgs e)
        {
            TasksRibbon.Visibility = Visibility.Collapsed; isTaskRibbonHide = true;
            Allsteps.Margin = new Thickness(30, 30, 30, 150);
            if (this.WindowState == WindowState.Maximized)
            {

                TasksRibbon.Visibility = Visibility.Visible;
                Allsteps.HorizontalAlignment = HorizontalAlignment.Stretch;
                Allsteps.VerticalAlignment = VerticalAlignment.Stretch;
                Allsteps.Margin = new Thickness(30, 30, 30, 150);

            }

        }


        private void AddTaskWindows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Back)
            {
                backProcessofPages();

            }
        }


        private void AllTextBoxesKeyUp(object sender, KeyEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            if (e.Key == Key.Back)
            {

            }
        
            else if (e.Key == Key.Enter)
            {
                //processofpages();
                //btn.Focus();

            }

            else if (textBox.Name == "hourBoxS2" && hourBoxS2.Text.Length == 2)
            {
                minuteBoxS2.Focus();
            }
        }


        // Steps Label Assistent }
    }
}
