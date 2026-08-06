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
    public partial class CreatePasswordWindow : FluentWindow
    {
        public CreatePasswordWindow()
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
        public static readonly DependencyProperty Num1Property =
            DependencyProperty.Register("Num1", typeof(string), typeof(CreatePasswordWindow), new PropertyMetadata());




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
            DependencyProperty.Register("Num2", typeof(string), typeof(CreatePasswordWindow), new PropertyMetadata());

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
            DependencyProperty.Register("Num3", typeof(string), typeof(CreatePasswordWindow), new PropertyMetadata());


        public string Num4
        {
            get { return (string)GetValue(Num4Property); }
            set { SetValue(Num4Property, value); }
        }

        // Using a DependencyProperty as the backing store for Num2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Num4Property =
            DependencyProperty.Register("Num4", typeof(string), typeof(CreatePasswordWindow), new PropertyMetadata());


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

                ProcessInProduct processInProduct = new ProcessInProduct();
                processInProduct.StartProssesing();

                try
                {

                    UiSet.UiSettingsSectionPropertyes.SWSEnbLockApp = true;
                       UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword1 = Convert.ToSByte(num1.Text);
                        UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword2 = Convert.ToSByte(num2.Text);
                        UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword3 = Convert.ToSByte(num3.Text);
                        UiSet.UiSettingsSectionPropertyes.SWSSecurityPassword4 = Convert.ToSByte(num4.Text);
                    UiSet.UiSettingsSectionPropertyes.IsLock = true;
                        processInProduct.GetRespond(true, Properties.Languages.Lang.DefaultTextName_Sucsses, Properties.Languages.Lang.CreatePasswordWindow_Your_password_has_been_successfully_created);
                        processInProduct.Show();
                    this.Close();


                    
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

        private void TitleBar_CloseClicked(TitleBar sender, RoutedEventArgs args)
        {
        }
    }
}
