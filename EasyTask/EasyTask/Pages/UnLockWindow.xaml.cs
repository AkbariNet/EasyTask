using _21_4_23;
using EasyTask.Class;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using EasyTask.Class.DynamicTheme;
using EasyTask.Class.SettingsConfiguration;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for UnLockWindow.xaml
    /// </summary>
    public partial class UnLockWindow : Window
    {
        public bool ParentIsMainWindow;
        public UnLockWindow()
        {
            InitializeComponent();
            num1.Focus();
            if (App.LightMode)
            {

                LockAnimate.Visibility = Visibility.Collapsed;
                LockBlackAnimate.Visibility = Visibility.Visible;
            }
            else
            {

                LockAnimate.Visibility = Visibility.Visible;
                LockBlackAnimate.Visibility = Visibility.Collapsed;

            }
            SystemEvents.UserPreferenceChanged += (s, e) =>
            {
                bool IsLight=DynamicTheme.SystemEvents_UserPreferenceChangedBool(s, e);
                if (IsLight)
                {
                    LockAnimate.Visibility = Visibility.Collapsed;
                    LockBlackAnimate.Visibility = Visibility.Visible;

                }
                else
                {

                    LockAnimate.Visibility = Visibility.Visible;
                    LockBlackAnimate.Visibility = Visibility.Collapsed;
                }
            };

            IncludeDefaultResources.Include();
        }



        public  string Num1
        {
            get
            {
                return (string)GetValue(Num1Property);
            }
            set
            {
                SetValue(Num1Property, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num1Property =
            DependencyProperty.Register("Num1", typeof(string), typeof(UnLockWindow), new PropertyMetadata());

        


        public string Num2
        {
            get { return (string)GetValue(Num2Property); }
            set
            {
                SetValue(Num2Property, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num2Property =
            DependencyProperty.Register("Num2", typeof(string), typeof(UnLockWindow), new PropertyMetadata());

        public string Num3
        {
            get { return (string)GetValue(Num3Property);
            }
            set
            {
                SetValue(Num3Property, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num3Property =
            DependencyProperty.Register("Num3", typeof(string), typeof(UnLockWindow), new PropertyMetadata());
        

        public string Num4
        {
            get { return (string)GetValue(Num4Property); }
            set { SetValue(Num4Property, value); }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num4Property =
            DependencyProperty.Register("Num4", typeof(string), typeof(UnLockWindow), new PropertyMetadata());


        public bool EnbLockValue
        {
            get { return (bool)GetValue(EnbLockValueProperty); }
            set { SetValue(EnbLockValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isAutoStart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnbLockValueProperty =
            DependencyProperty.Register("EnbLockValue", typeof(bool), typeof(UnLockWindow), new PropertyMetadata(false));



        public bool isAutoStart
        {
            get { return (bool)GetValue(isAutoStartProperty); }
            set { SetValue(isAutoStartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isAutoStart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isAutoStartProperty =
            DependencyProperty.Register("isAutoStart", typeof(bool), typeof(UnLockWindow), new PropertyMetadata(false));





        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ParentIsMainWindow)
            {
            RunStoryboard.Run("OutFocusElementOut", MainWindow, null, MainWindowOutFocusBorder);


            }
            //out of unlock window
            RunStoryboard.Run("Out", this, null, this.AllContent);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            TextBox _sender = (TextBox)sender;
            if (e.Key == Key.Back && (_sender.Text == ""))
            {
                if (_sender.Name == num4.Name) num3.Focus();
                else if (_sender.Name == num3.Name) num2.Focus();
                else if (_sender.Name == num2.Name) num1.Focus();

            }

            onlyNum.onlyNumKeyPreviewDown(sender, e);

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            onlyNum.onlyNumPreviewTextInput(sender, e);



        }


        private void num_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox _sender = (TextBox)sender;
            if (_sender.Name == num1.Name && _sender.Text != "") num2.Focus();
            else if (_sender.Name == num2.Name && _sender.Text != "") num3.Focus();
            else if (_sender.Name == num3.Name && _sender.Text != "") num4.Focus();


        }



        private void TrueProssesGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            Storyboard sb = this.FindResource("TrueProsses") as Storyboard;
            Storyboard.SetTarget(sb, this.TrueProssesGrid);
            sb.Begin();
        }

        private void TrueProsses_Completed(object sender, EventArgs e)
        {
            if (ParentIsMainWindow)
            {
            RunStoryboard.Run("OutFocusElementOut", MainWindow, null, MainWindowOutFocusBorder);



            }
            RunStoryboard.Run("OutW", this, null, this.AllContent);
        }
        private void Out_Completed(object sender, EventArgs e)
        {

            this.Close();
        }

        public bool movingOn = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Storyboard InAnimate = this.FindResource("In") as Storyboard;
            Storyboard.SetTarget(InAnimate, this.AllContent);
            InAnimate.Begin();
            if (movingOn)
            {
                
                var location =  this.FlowDirection == FlowDirection.LeftToRight ? UnlockWindow.PointToScreen(new Point(500, 0) ) : UnlockWindow.PointToScreen(new Point(-500, 0));

                this.Left = location.X;
                this.Top = location.Y;
            }

        }
        private void LockAnimate_Completed(object sender, EventArgs e)
        {


        }


        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {


            Num1 = num1.Text; Num2 = num2.Text; Num3 = num3.Text; Num4 = num4.Text;
            if (num1.Text != "" && num2.Text != "" && num3.Text != "" && num4.Text != "")
            {


                try
                {

                    if (UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword1 == Convert.ToSByte(Num1) && UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword2 == Convert.ToSByte(Num2) &&
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword3 == Convert.ToSByte(Num3) && UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword4 == Convert.ToSByte(Num4))
                    {
                        OK.Visibility = Visibility.Visible;
                        EnbLockValue = true;
                        UiSet.UiSettingsSectionPropertyes.IsLock = false;

                    }


                    else
                    {
                        
                        LockAnimate.PlayAnimation();
                        LockBlackAnimate.PlayAnimation();
                        Num1 = "";
                        Num2 = "";
                        Num3 = "";
                        Num4 = ""; num1.Focus();
                    }
                }
                catch (Exception)
                {
                    Num1 = "";
                    Num2 = "";
                    Num3 = "";
                    Num4 = ""; num1.Focus();
                    throw;
                }

            }
        }
        Border MainWindowOutFocusBorder = new Border();
        Window MainWindow = new Window();
        public void GetMainWindowOutFocusBorder(Border MainWindowBorder,Window MainWindowGet)
        {
            MainWindow = MainWindowGet;
            MainWindowOutFocusBorder = MainWindowBorder;

        }


    }
}
