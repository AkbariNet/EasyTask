using EasyTask.Class;
using System;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace EasyTask.Pages
{
    /// <summary>
    /// Interaction logic for ProcessInProduct.xaml
    /// </summary>
    public partial class ProcessInProduct : FluentWindow
    {
        public ProcessInProduct()
        {
            InitializeComponent();
            RunStoryboard.Run("Prossesing", this, null, this.gridProsses);
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
        public void StartProssesing(string ProcessNameRevive = "Processing...", string ProcessAboutRevive = "Processing your work...")
        {
            ProssesName.Text = ProcessNameRevive;
            ProssesAbout.Text = ProcessAboutRevive;
        }
        public void GetRespond(bool ProcessRespond, String ProcessNameRespond, String ProcessAboutRespond)
        {
            if (ProcessAboutRespond is null)
            {
                ProssesAbout.Visibility=Visibility.Collapsed;
            }
            try
            {

                ProssesName.Text = ProcessNameRespond;
                ProssesAbout.Text = ProcessAboutRespond;
            }
            catch (Exception)
            {

                throw;
            }
            if (ProcessRespond)
            {
                Prossesing.Visibility = Visibility.Collapsed;
                TrueProssesGrid.Visibility = Visibility.Visible;
                RunStoryboard.Run("TrueProsses", this, null, this.TrueProssesGrid);
            }
            else
            {
                Prossesing.Visibility = Visibility.Collapsed;
                falseProssesGrid.Visibility = Visibility.Visible;
                RunStoryboard.Run("FalseProsses", this, null, this.falseProssesGrid);
            }

        }


        public int Prosses = 1;




        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void falseProssesGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {


        }

        private void TrueProssesGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {


        }

        private void FluentWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (TrueProssesGrid.Visibility == Visibility.Visible || falseProssesGrid.Visibility == Visibility.Visible)

            {
                if (e.Key == Key.Enter || e.Key == Key.Escape)
                {
                    this.Close();
                }
            }
        }
    }
}
