using EasyTask.Class.SettingsConfiguration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace EasyTask.Pages.PagesConnectors.PageElement
{
    /// <summary>
    /// Interaction logic for ETCheckBox.xaml
    /// </summary>
    public partial class ETComboBox : UserControl
    {

        private void CheckBoxElm_Loaded(object sender, RoutedEventArgs e)
        {
            if (btnContent1 != null)
            {
                visiblity1 = true;
            }
            else
            {
                visiblity1 = false;
            }
            if (btnContent2 != null)
            {
                visiblity2 = true;
            }
            else
            {
                visiblity2 = false;
            }
            if (btnContent3 != null)
            {
                visiblity3 = true;
            }
            else
            {
                visiblity3 = false;
            }
            if (btnContent4 != null)
            {
                visiblity4 = true;
            }
            else
            {
                visiblity4 = false;
            }
            if (btnContent5 != null)
            {
                visiblity5 = true;
            }
            else
            {
                visiblity5 = false;
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MoreCombo_Click(sender, e);
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MoreCombo_Click(sender, e);

        }
        public string ContentOfMainLabel
        {
            get { return (string)GetValue(ContentOfMainLabelProperty); }
            set { SetValue(ContentOfMainLabelProperty, value); }
        }
          public static readonly DependencyProperty ContentOfMainLabelProperty =
            DependencyProperty.Register("ContentOfMainLabel", typeof(string), typeof(ETComboBox), new PropertyMetadata("Content Of Combobox"));



        public static bool GetComboClicked(DependencyObject obj)
        {
            return (bool)obj.GetValue(ComboClickedProperty);
        }

        public static void SetComboClicked(DependencyObject obj, bool value)
        {
            obj.SetValue(ComboClickedProperty, value);
            UiSet.SaveSettings();
        }

        // Using a DependencyProperty as the backing store for ComboClicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboClickedProperty =
            DependencyProperty.RegisterAttached("ComboClicked", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));








        public void ReturnBack()
        {
            Combo1.Visibility = Visibility.Collapsed;
            Combo2.Visibility = Visibility.Collapsed;
            Combo3.Visibility = Visibility.Collapsed;
            Combo4.Visibility = Visibility.Collapsed;
            Combo5.Visibility = Visibility.Collapsed;
        }


        public string btnContent1
        {
            get { return (string)GetValue(btnContent1Property); }
            set
            {
                SetValue(btnContent1Property, value);
            }

        }

        public static readonly DependencyProperty btnContent1Property =
            DependencyProperty.Register("btnContent1", typeof(string), typeof(ETComboBox), new PropertyMetadata(null));



        public string btnContent2
        {
            get { return (string)GetValue(btnContent2Property); }
            set { SetValue(btnContent2Property, value); 
            }
        }

         public static readonly DependencyProperty btnContent2Property =
            DependencyProperty.Register("btnContent2", typeof(string), typeof(ETComboBox), new PropertyMetadata(null));



        public string btnContent3
        {
            get { return (string)GetValue(btnContent3Property); }
            set { SetValue(btnContent3Property, value); 
            }
        }

         public static readonly DependencyProperty btnContent3Property =
            DependencyProperty.Register("btnContent3", typeof(string), typeof(ETComboBox), new PropertyMetadata(null));



        public string btnContent4
        {
            get { return (string)GetValue(btnContent4Property); }
            set { SetValue(btnContent4Property, value);
            }
        }

         public static readonly DependencyProperty btnContent4Property =
            DependencyProperty.Register("btnContent4", typeof(string), typeof(ETComboBox), new PropertyMetadata(null));



        public string btnContent5
        {
            get { return (string)GetValue(btnContent5Property); }
            set { SetValue(btnContent5Property, value);
            }
        }

         public static readonly DependencyProperty btnContent5Property =
            DependencyProperty.Register("btnContent5", typeof(string), typeof(ETComboBox), new PropertyMetadata(null));






        public bool visiblity1
        {
            get { return (bool)GetValue(visiblity1Property); }
            set { SetValue(visiblity1Property, value); }
        }

        // Using a DependencyProperty as the backing store for visiblity1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visiblity1Property =
            DependencyProperty.Register("visiblity1", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool visiblity2
        {
            get { return (bool)GetValue(visiblity2Property); }
            set { SetValue(visiblity2Property, value); }
        }

        // Using a DependencyProperty as the backing store for visiblity2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visiblity2Property =
            DependencyProperty.Register("visiblity2", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));



        public bool visiblity3
        {
            get { return (bool)GetValue(visiblity3Property); }
            set { SetValue(visiblity3Property, value); }
        }

        // Using a DependencyProperty as the backing store for visiblity3.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visiblity3Property =
            DependencyProperty.Register("visiblity3", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));



        public bool visiblity4
        {
            get { return (bool)GetValue(visiblity4Property); }
            set { SetValue(visiblity4Property, value); }
        }

        // Using a DependencyProperty as the backing store for visiblity4.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visiblity4Property =
            DependencyProperty.Register("visiblity4", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool visiblity5
        {
            get { return (bool)GetValue(visiblity5Property); }
            set { SetValue(visiblity5Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visiblity5Property =
            DependencyProperty.Register("visiblity5", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));





        public bool isFilling1
        {
            get { return (bool)GetValue(isFilling1Property); }
            set { SetValue(isFilling1Property, value); }
        }
       public static readonly DependencyProperty isFilling1Property = 
            DependencyProperty.Register("isFilling1", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool isFilling2
        {
            get { return (bool)GetValue(isFilling2Property); }
            set { SetValue(isFilling2Property, value); }
        }
        public static readonly DependencyProperty isFilling2Property =
             DependencyProperty.Register("isFilling2", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool isFilling3
        {
            get { return (bool)GetValue(isFilling3Property); }
            set { SetValue(isFilling3Property, value); }
        }
        public static readonly DependencyProperty isFilling3Property =
             DependencyProperty.Register("isFilling3", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool isFilling4
        {
            get { return (bool)GetValue(isFilling4Property); }
            set { SetValue(isFilling4Property, value); }
        }
        public static readonly DependencyProperty isFilling4Property =
             DependencyProperty.Register("isFilling4", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));




        public bool isFilling5
        {
            get { return (bool)GetValue(isFilling5Property); }
            set { SetValue(isFilling5Property, value); }
        }
        public static readonly DependencyProperty isFilling5Property =
             DependencyProperty.Register("isFilling5", typeof(bool), typeof(ETComboBox), new PropertyMetadata(false));





        public ETComboBox()
        {
             InitializeComponent();
            ComboFill();
        }
        
        private void MoreCombo_Click(object sender, RoutedEventArgs e)
        {
            if (StackOfBTNS.Visibility==Visibility.Collapsed)
            {
                
                Storyboard sb = this.FindResource("MoreOn") as Storyboard;
                Storyboard.SetTarget(sb, this.StackOfBTNS);
                sb.Begin();
                Storyboard ssb = this.FindResource("MoreOnElm") as Storyboard;
                Storyboard.SetTarget(ssb, this.MoreCombo);
                ssb.Begin();
            }
            else if (StackOfBTNS.Visibility == Visibility.Visible)
            {

                Storyboard sb = this.FindResource("MoreOff") as Storyboard;
                Storyboard.SetTarget(sb, this.StackOfBTNS);
                sb.Begin();
                Storyboard ssb = this.FindResource("MoreOffElm") as Storyboard;
                Storyboard.SetTarget(ssb, this.MoreCombo);
                ssb.Begin();
            }
        }


        public int ComboIntExport
        {
            get {
                return (int)GetValue(ComboIntExportProperty);
                ComboFill();

            }
            set { SetValue(ComboIntExportProperty, value);
                ComboFill();
            }
        }

        // Using a DependencyProperty as the backing store for ComboIntExport.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboIntExportProperty =
            DependencyProperty.Register("ComboIntExport", typeof(int), typeof(ETComboBox), new PropertyMetadata(1));



        public void ComboFill()
        {
            if (ComboIntExport == 1)
            {
                isFilling1 = true;

            }
            if (ComboIntExport == 2)
            {
                isFilling2 = true;

            }
            if (ComboIntExport == 3)
            {
                isFilling3 = true;

            }
            if (ComboIntExport == 4)
            {
                isFilling4 = true;

            }
            if (ComboIntExport == 5)
            {
                isFilling5 = true;

            }
        }

        public void ResetAllCombo(int mm)
        {
            if (mm == 1)
            {
                ComboIntExport = 1;
                isFilling2 = false;
                isFilling3 = false;
                isFilling4 = false;
                isFilling5 = false;
            }
            if (mm == 2)
            {
                ComboIntExport = 2;
                isFilling1 = false;
                isFilling3 = false;
                isFilling4 = false;
                isFilling5 = false;
            }
            if (mm == 3)
            {
                ComboIntExport = 3;
                isFilling1 = false;
                isFilling2 = false;
                isFilling4 = false;
                isFilling5 = false;
            }
            if (mm == 4)
            {
                ComboIntExport = 4;
                isFilling1 = false;
                isFilling2 = false;
                isFilling3 = false;
                isFilling5 = false;
            }
            if (mm == 5)
            {
                ComboIntExport = 5;
                isFilling1 = false;
                isFilling2 = false;
                isFilling3 = false;
                isFilling4 = false;
            }
        }


        private void Combo1_Checked(object sender, RoutedEventArgs e)
        {
            ResetAllCombo(1);
        }

        private void Combo2_Checked(object sender, RoutedEventArgs e)
        {

            ResetAllCombo(2);
        }

        private void Combo3_Checked(object sender, RoutedEventArgs e)
        {
            ResetAllCombo(3);

        }

        private void Combo4_Checked(object sender, RoutedEventArgs e)
        {
            ResetAllCombo(4);

        }

        private void Combo5_Checked(object sender, RoutedEventArgs e)
        {
            ResetAllCombo(5);

        }

  
    }

}
