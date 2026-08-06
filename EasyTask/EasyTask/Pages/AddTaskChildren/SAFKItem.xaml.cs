using System.Windows;
using System.Windows.Controls;

namespace EasyTask.Pages.AddTaskChildren
{
    /// <summary>
    /// Interaction logic for SAFKItem.xaml
    /// </summary>
    public partial class SAFKItem : UserControl
    {


        public bool CheckBoxForChackElementValue
        {
            get { return (bool)GetValue(CheckBoxForChackElementValueProperty); }
            set { SetValue(CheckBoxForChackElementValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxForChackElementValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxForChackElementValueProperty =
            DependencyProperty.Register("CheckBoxForChackElementValue", typeof(bool), typeof(SAFKItem), new PropertyMetadata(false));



        public string TitleValue
        {
            get { return (string)GetValue(TitleValueProperty); }
            set { SetValue(TitleValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleValueProperty =
            DependencyProperty.Register("TitleValue", typeof(string), typeof(SAFKItem), new PropertyMetadata("Title"));



        public string ProcessNameOfApp
        {
            get { return (string)GetValue(ProcessNameOfAppProperty); }
            set { SetValue(ProcessNameOfAppProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProcessNameOfApp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessNameOfAppProperty =
            DependencyProperty.Register("ProcessNameOfApp", typeof(string), typeof(SAFKItem), new PropertyMetadata(""));




        public string ImageSourceIconPath
        {
            get { return (string)GetValue(ImageSourceIconPathProperty); }
            set { SetValue(ImageSourceIconPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSourceIconPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceIconPathProperty =
            DependencyProperty.Register("ImageSourceIconPath", typeof(string), typeof(SAFKItem), new PropertyMetadata(@"\\files\\1080LOGO\\BlueTransparent80.png"));


        public SAFKItem()
        {
            InitializeComponent(); CheckIsHereOrNot();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked==false)
            {
                CheckBoxForChackElementValue = false;/*
                MessageBox.Show("UnClicked");*/
                SelectAppForKill.variablesPre.Remove(ProcessNameOfApp);/*
                MessageBox.Show(SelectAppForKill.variablesPre.Count.ToString());
                MessageBox.Show(String.Join(",", SelectAppForKill.variablesPre));*/


            }
            else 
            {
                CheckBoxForChackElementValue = true;/*
                MessageBox.Show("Clicked");*/
                SelectAppForKill.variablesPre.Add(ProcessNameOfApp);/*
                MessageBox.Show(SelectAppForKill.variablesPre.Count.ToString());
                MessageBox.Show(String.Join(",", SelectAppForKill.variablesPre));*/
            }
        }
        private void CheckIsHereOrNot()
        {


            if (SelectAppForKill.variablesPre.Exists(x => x == ProcessNameOfApp))
            {
                //MessageBox.Show("ParallelOk");
                CheckBoxForChackElementValue = true;
            }

            if (!SelectAppForKill.variablesPre.Exists(x => x == ProcessNameOfApp))
            {
                //MessageBox.Show("ParallelOk");
                CheckBoxForChackElementValue = false;
            }
        }
        private void SAFKItems_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CheckIsHereOrNot();
        }

        private void ETCheckBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
