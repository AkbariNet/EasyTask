using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using _21_4_23;
using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace EasyTask.Class.NotificationSystem
{
    internal class NotiticationCore

    {
        private String imageFilePath = String.Empty;
        public NotiticationCore()
        {
            ToolBarTray toolBarTray = new ToolBarTray();


            try
            {
                SaveImageFilesToCommonFolder();
                // Create("Hello World!", "This is such a nice world!", "https://presuppositions.org");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void Create(string title, string description, string ButtonText, string url)
        {


            // https://learn.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
            Uri img = new Uri(imageFilePath);

            // Listen to notification activation
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
                // https://stackoverflow.com/questions/4580263/how-to-open-in-default-browser-in-c-sharp
                System.Diagnostics.Process.Start(args["url"]);
            };

            new ToastContentBuilder()
                .AddText(title)
                .AddText(description)
                .AddAppLogoOverride(img)
                .AddButton(new ToastButton()
                    .SetContent(ButtonText)
                    .AddArgument("action", "viewReport")
                    .AddArgument("url", url))
                .Show();

        }

        public void Create(string title, string description)
        {


            // https://learn.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
            Uri img = new Uri(imageFilePath);

            new ToastContentBuilder()
                .AddText(title)
                .AddText(description)
                .AddAppLogoOverride(img)
                .Show();

        }
        private string SaveDataUrlToFile(string dataUrl, string savePath)
        {
            // https://stackoverflow.com/questions/27710576/convert-from-a-dataurl-to-an-image-in-c-sharp-and-write-a-file-with-the-bytes
            var binData = Convert.FromBase64String(dataUrl);
            System.IO.File.WriteAllBytes(savePath, binData);
            return savePath;
        }

        public void SaveImageFilesToCommonFolder()
        {
            // https://stackoverflow.com/questions/27710576/convert-from-a-dataurl-to-an-image-in-c-sharp-and-write-a-file-with-the-bytes
            // Write images to common app data folder
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            // Uploaded PNG to this location to get the Data URI,
            // which is really much longer than displayed here:
            // https://www.opinionatedgeek.com/codecs/base64encoder
            String imageFileData = "iVBORw0KGgoAAAANUgAAAMAAAADRU5ErkJggg==";
            imageFilePath = Path.Combine(directory, "myimage.png");
            SaveDataUrlToFile(imageFileData, imageFilePath);
        }


    }
}
