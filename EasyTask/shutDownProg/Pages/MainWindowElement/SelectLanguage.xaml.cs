using EasyTask.Class;
using EasyTask.Class.YesOrNoClass;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyTask.Pages.MainWindowElement
{
    /// <summary>
    /// Interaction logic for SelectLanguage.xaml
    /// </summary>
    public partial class SelectLanguage : UserControl
    {
       
        public SelectLanguage()
        {
            InitializeComponent();
            RunStoryboard.Run("In", null, this, this);
            AN.PlayAnimation();

            //set fill for deffult seclected button
            if (Properties.Settings.Default.LanguageCode == "en-US")
            {
                EnglighLang.BorderBrush = MainBorder.Background;
                EnglighLang.Foreground = new SolidColorBrush(Colors.White);
            }

            else if (
             Properties.Settings.Default.LanguageCode == "fa-IR")
            {

                PersianLang.BorderBrush = MainBorder.Background;
                PersianLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "ar-SA")
            {

                ArabicLang.BorderBrush = MainBorder.Background;
                ArabicLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "es-419")
            {

                SpanishLang.BorderBrush = MainBorder.Background;
                SpanishLang.Foreground = new SolidColorBrush(Colors.White);
            }
            
            else if (
             Properties.Settings.Default.LanguageCode == "fr-FR")
            {

                FrenchLang.BorderBrush = MainBorder.Background;
                FrenchLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "de-DE")
            {

                GermanLang.BorderBrush = MainBorder.Background;
                GermanLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "zh-CN")
            {

                ChineseLang.BorderBrush = MainBorder.Background;
                ChineseLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "ru-RU")
            {

                RussianLang.BorderBrush = MainBorder.Background;
                RussianLang.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (
             Properties.Settings.Default.LanguageCode == "pt-PT")
            {

                PortugueseLang.BorderBrush = MainBorder.Background;
                PortugueseLang.Foreground = new SolidColorBrush(Colors.White);
            }
            //
        }
        public Grid Grid;
        public void GetGrid(Grid GridMan)
        {
            Grid=GridMan;
        }
        private void EnglighLang_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.LanguageCode == "en-US")
            {
                RunStoryboard.Run("Out", null, this, this);
            }
            else
            {
                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "en-US";
                    RestartAppAndChangeLanguage();

                }

            }
        }
        private void PersianLang_Click(object sender, RoutedEventArgs e)
        {

            if (
            Properties.Settings.Default.LanguageCode == "fa-IR")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "fa-IR";
                    RestartAppAndChangeLanguage();

                }
            }
        }

        private void ArabicLang_Click(object sender, RoutedEventArgs e)
        {


            if (
            Properties.Settings.Default.LanguageCode == "ar-SA")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "ar-SA";
                    RestartAppAndChangeLanguage();

                }
            }
        }

        private void SpanishLang_Click(object sender, RoutedEventArgs e)
        {



            if (
            Properties.Settings.Default.LanguageCode == "es-419")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "es-419";
                    RestartAppAndChangeLanguage();

                }
            }
        }

        private void FrenchLang_Click(object sender, RoutedEventArgs e)
        {


            if (
            Properties.Settings.Default.LanguageCode == "fr-FR")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "fr-FR";
                    RestartAppAndChangeLanguage();

                }
            }
        }
        private void GermanLang_Click(object sender, RoutedEventArgs e)
        {

            if (
            Properties.Settings.Default.LanguageCode == "de-DE")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "de-DE";
                    RestartAppAndChangeLanguage();

                }
            }

        }
        private void ChineseLang_Click(object sender, RoutedEventArgs e)
        {

            if (
            Properties.Settings.Default.LanguageCode == "zh-CN")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "zh-CN";
                    RestartAppAndChangeLanguage();

                }
            }

        }
        private void RussianLang_Click(object sender, RoutedEventArgs e)
        {

            if (
            Properties.Settings.Default.LanguageCode == "ru-RU")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "ru-RU";
                    RestartAppAndChangeLanguage();

                }
            }

        }
        private void PortugueseLang_Click(object sender, RoutedEventArgs e)
        {


            if (
            Properties.Settings.Default.LanguageCode == "pt-PT")
            {
                RunStoryboard.Run("Out", null, this, this);

            }
            else
            {

                if (CallToTwoWayYesNo.startYesOrNoWindowProcess(EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title_AreYouSure, EasyTask.Properties.Languages.Lang.TwoWayYesNo_Title2_By_performing_this_operation__the_program_will_be_restarted_, EasyTask.Properties.Languages.Lang.DefaultTextName_No, EasyTask.Properties.Languages.Lang.DefaultTextName_Yes, 1) == 2)
                {
                    Properties.Settings.Default.LanguageCode = "pt-PT";
                    RestartAppAndChangeLanguage();

                }
            }
        }








        private void Out_Completed(object sender, EventArgs e)
        {

            Grid.Children.Clear();
        }
        private void RestartAppAndChangeLanguage()
        {
            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();

        }

    }
}
