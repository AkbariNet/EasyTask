using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyTask.Class.Actions
{
    class ShutDownSystemAction
    {

        public static void StartShutDown()
        {
            Process.Start(new ProcessStartInfo("shutdown", "/s /t 0 /f")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }

    }
}
