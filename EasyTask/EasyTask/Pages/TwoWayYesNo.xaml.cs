using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for ProcessInProduct.xaml
    /// </summary>
    public partial class TwoWayYesNo : FluentWindow
    {
        public TwoWayYesNo()
        {
            InitializeComponent();
        }

        private void EXTButtonStart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        public void SetValuesOfTitles(string ProssesNameRevive , string ProssesAboutRevive ,string button1Value,string button2Value)
        {
            ProssesName.Text = ProssesNameRevive;
            ProssesAbout.Text = ProssesAboutRevive;
            BTN1.Content=button1Value; BTN2.Content=button2Value;
        }

        public void SetValuesOfTitles(string ProssesNameRevive, string ProssesAboutRevive, string button1Value, string button2Value , int Priority)
        {
            ProssesName.Text = ProssesNameRevive;
            ProssesAbout.Text = ProssesAboutRevive;
            BTN1.Content = button1Value; BTN2.Content = button2Value;
            if (Priority == 1) { BTN1.Background = StressButtonColor.Background; BTN1.Foreground = new SolidColorBrush(Colors.White); } else { BTN2.Background = StressButtonColor.Background; BTN2.Foreground = new SolidColorBrush(Colors.White); }
        }


       public ushort FinalValueOfYesOrNo;
        public int Prosses = 1;



        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            FinalValueOfYesOrNo = 1;
            this.Close();
        }

        private void BTN2_Click(object sender, RoutedEventArgs e)
        {

            FinalValueOfYesOrNo = 2;
            this.Close();
        }
    }
}
