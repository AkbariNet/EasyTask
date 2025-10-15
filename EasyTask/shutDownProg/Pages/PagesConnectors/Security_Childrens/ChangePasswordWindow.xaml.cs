
using EasyTask.Class;
using EasyTask.Class.Default_Storyboards;
using EasyTask.Class.SettingsConfiguration;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;


namespace EasyTask.Pages.PagesConnectors
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : FluentWindow
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
            RunStoryboard.Run("In", df, null, Step1); num1.Focus();
        }

        public string Num1
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
        public static  readonly DependencyProperty Num1Property =
            DependencyProperty.Register("Num1", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());




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
            DependencyProperty.Register("Num2", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());

        public string Num3
        {
            get
            {
                return (string)GetValue(Num3Property);
            }
            set
            {
                SetValue(Num3Property, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num3Property =
            DependencyProperty.Register("Num3", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());


        public string Num4
        {
            get { return (string)GetValue(Num4Property); }
            set { SetValue(Num4Property, value); }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num4Property =
            DependencyProperty.Register("Num4", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());


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
        
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {


            Num1 = num1.Text; Num2 = num2.Text; Num3 = num3.Text; Num4 = num4.Text;
            if (num1.Text != "" && num2.Text != "" && num3.Text != "" && num4.Text != "")
            {


                try
                {

                    if (UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword1 == Convert.ToInt32(Num1) && UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword2 == Convert.ToInt32(Num2) &&
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword3 == Convert.ToInt32(Num3) && UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword4 == Convert.ToInt32(Num4))
                    {
                        EnterCorrectPassword.Visibility = Visibility.Collapsed;
                        DefaultStoryboardsByWindow df2 = new DefaultStoryboardsByWindow();
                        if (RunStoryboard.Run("In", df2, null, Step2))
                        {

                            DefaultStoryboardsByWindow df = new DefaultStoryboardsByWindow();
                            RunStoryboard.Run("OutMove", df, null, Step1);
                            num1new.Focus();
                        } 
                        
                    }


                    else
                    {

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

        //for new password


        public string Num1new
        {
            get
            {
                return (string)GetValue(Num1newProperty);
            }
            set
            {
                SetValue(Num1newProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num1newProperty =
            DependencyProperty.Register("Num1new", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());




        public string Num2new
        {
            get { return (string)GetValue(Num2newProperty); }
            set
            {
                SetValue(Num2newProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num2newProperty =
            DependencyProperty.Register("Num2new", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());

        public string Num3new
        {
            get
            {
                return (string)GetValue(Num3newProperty);
            }
            set
            {
                SetValue(Num3newProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num3newProperty =
            DependencyProperty.Register("Num3new", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());


        public string Num4new
        {
            get { return (string)GetValue(Num4newProperty); }
            set { SetValue(Num4newProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num4newProperty =
            DependencyProperty.Register("Num4new", typeof(string), typeof(ChangePasswordWindow), new PropertyMetadata());


        private void TextBoxnew_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            TextBox _sender = (TextBox)sender;
            if (e.Key == Key.Back && (_sender.Text == ""))
            {
                if (_sender.Name == num4new.Name) num3new.Focus();
                else if (_sender.Name == num3new.Name) num2new.Focus();
                else if (_sender.Name == num2new.Name) num1new.Focus();

            }

            onlyNum.onlyNumKeyPreviewDown(sender, e);

        }

        private void TextBoxnew_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            onlyNum.onlyNumPreviewTextInput(sender, e);



        }


        private void numnew_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox _sender = (TextBox)sender;
            if (_sender.Name == num1new.Name && _sender.Text != "") num2new.Focus();
            else if (_sender.Name == num2new.Name && _sender.Text != "") num3new.Focus();
            else if (_sender.Name == num3new.Name && _sender.Text != "") num4new.Focus();


        }

        private void TextBoxnew_KeyUp(object sender, KeyEventArgs e)
        {


            Num1new = num1new.Text; Num2new = num2new.Text; Num3new = num3new.Text; Num4new = num4new.Text;
            if (num1new.Text != "" && num2new.Text != "" && num3new.Text != "" && num4new.Text != "")
            {

                ProcessInProduct processInProduct = new ProcessInProduct();
                processInProduct.StartProssesing();
                try
                {

                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword1 = Convert.ToSByte(Num1new);
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword2 = Convert.ToSByte(Num2new);
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword3 = Convert.ToSByte(Num3new);
                    UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword4 = Convert.ToSByte(Num4new);

                    processInProduct.GetRespond(true, Properties.Languages.Lang.DefaultTextName_Sucsses, Properties.Languages.Lang.ChangePasswordWindow_Your_password_has_been_successfully_changed_);
                    processInProduct.Show();
                }
                catch (Exception)
                {

                    processInProduct.GetRespond(true, Properties.Languages.Lang.DefaultTextName_Unsuccessful, Properties.Languages.Lang.ChangePasswordWindow_There_was_a_problem__your_password_was_not_changed_);
                    processInProduct.Show();
                    throw;
                }


                ChangePasswordWindowX.Close();




            }
        }
    }
}
