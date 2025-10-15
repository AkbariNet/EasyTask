using EasyTask.Class.SettingsConfiguration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Wpf.Ui.Controls;
using Timer = System.Timers.Timer;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for ApplyingProcessTask.xaml
    /// </summary>
    public partial class ApplyingProcessTask : FluentWindow
    {
        
        Timer timer = new Timer(1000);
        public ApplyingProcessTask()
        {
            InitializeComponent();
            StopKillBorder.Visibility= Visibility.Collapsed;
            timer.Elapsed += Timer_Elapsed;
            TimerStart();

        }
        int ValueOfElaped= 0;
        public void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (ValueOfElaped >= UiSet.UiSettingsSectionPropertyes.SWPTimerWaitValue)
            {
                KillStart = true;
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
                thisclose();
            }
            else
            ValueOfElaped++;

        }
        string DefaultTitleText = Properties.Languages.Lang.ApplyingProcessTask_Start_Kill_Apps;
        string DefaultSubtitleText = Properties.Languages.Lang.ApplyingProcessTask_start_process_of_kill_apps__;
        public void ChangeTitleAndSubtitle(string TitleText, string SubtitleText)
        {
            if (TitleText is null)
            {
                TitleText = DefaultTitleText;
            }
            if (SubtitleText is null)
            {
                SubtitleText = DefaultSubtitleText;
            }
            Title.Text =TitleText;
            Subtitle.Text=SubtitleText;
        }
        public void TimerStart()
        {
            timer.Start();
            timer.Enabled = true;

        }
        private void FluentWindow_MouseEnter(object sender, MouseEventArgs e)
        {


            Storyboard sbForInKillBorder = this.FindResource("SmoothIn") as Storyboard;
            Storyboard.SetTarget(sbForInKillBorder, this.StopKillBorder);
            sbForInKillBorder.Begin();
        }

        private void FluentWindow_MouseLeave(object sender, MouseEventArgs e)
        {

            Storyboard sbForOutKillBorder = this.FindResource("SmoothOut") as Storyboard;
            Storyboard.SetTarget(sbForOutKillBorder, this.StopKillBorder);
            sbForOutKillBorder.Begin();

        }
      public  bool KillStart=false;

        private void thisclose()
        {
            Application.Current.Dispatcher
                .Invoke(() => { this.Close(); });
      
        }
        private void StopKillButton_Click(object sender, RoutedEventArgs e)
        {
            KillStart = false; thisclose();
        }
    }
}
