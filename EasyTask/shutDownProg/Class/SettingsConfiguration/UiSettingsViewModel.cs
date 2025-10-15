using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyTask.Class.SettingsConfiguration
{
    internal class UiSettingsViewModel : ConfigurationSection
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // For Main Window


        public event Action<bool> isLockEvent;

        [ConfigurationProperty("IsLock", DefaultValue = false)]

        public bool IsLock
        {
            get { return (bool)this["IsLock"]; }
            set
            {
                this["IsLock"] = value;
                OnPropertyChanged(nameof(IsLock));
                isLockEvent?.Invoke(IsLock);

            }


        }

        public event Action<bool> isNotifyEvent;

        [ConfigurationProperty("isNotify", DefaultValue = true)]

        public bool IsNotify
        {
            get { return (bool)this["isNotify"]; }
            set
            {
                this["isNotify"] = value;
                OnPropertyChanged(nameof(IsNotify));
                isNotifyEvent?.Invoke(IsNotify);

            }


        }

        //SWP=SETTINGS WINDOW PROCESS
        [ConfigurationProperty("EnbTimerWindow", DefaultValue = true)]

        public bool SWPEnbTimerWindow
        {
            get { return (bool)this["EnbTimerWindow"]; }
            set
            {
                this["EnbTimerWindow"] = value;
                OnPropertyChanged(nameof(SWPEnbTimerWindow));
            }

        }


        [ConfigurationProperty("TimerWaitValue", DefaultValue = (sbyte)30)]

        public sbyte SWPTimerWaitValue
        {
            get { return (sbyte)this["TimerWaitValue"]; }
            set
            {
                this["TimerWaitValue"] = value;
                OnPropertyChanged(nameof(SWPTimerWaitValue));
            }

        }


        //SWC=SETTINGS WINDOW CONNECTION
        [ConfigurationProperty("AlwaysTry", DefaultValue = false)]

        public bool SWCAlwaysTry
        {
            get { return (bool)this["AlwaysTry"]; }
            set
            {
                this["AlwaysTry"] = value;
                OnPropertyChanged(nameof(SWCAlwaysTry));
            }

        }


        [ConfigurationProperty("EachTry", DefaultValue = (sbyte)30)]

        public sbyte SWCEachTry
        {
            get { return (sbyte)this["EachTry"]; }
            set
            {
                this["EachTry"] = value;
                OnPropertyChanged(nameof(SWCEachTry));
            }

        }



        public event Action<bool> SWSEnbLockAppEvent;

        //SWS=SETTINGS WINDOW SECURITY
        [ConfigurationProperty("EnbLockApp", DefaultValue = false)]

        public bool SWSEnbLockApp
        {
            get { return (bool)this["EnbLockApp"]; }
            set
            {
                this["EnbLockApp"] = value;
                OnPropertyChanged(nameof(SWSEnbLockApp));
                SWSEnbLockAppEvent?.Invoke(SWSEnbLockApp);
            }

        }

        [ConfigurationProperty("CantAddTaskWhenLocked", DefaultValue = true)]

        public bool SWSCantAddTaskWhenLocked
        {
            get { return (bool)this["CantAddTaskWhenLocked"]; }
            set
            {
                this["CantAddTaskWhenLocked"] = value;
                OnPropertyChanged(nameof(SWSCantAddTaskWhenLocked));
            }

        }



        [ConfigurationProperty("RunWhenSecurityAlert", DefaultValue = (sbyte)3)]

        public sbyte SWSRunWhenSecurityAlert
        {
            get { return (sbyte)this["RunWhenSecurityAlert"]; }
            set
            {
                this["RunWhenSecurityAlert"] = value;
                OnPropertyChanged(nameof(SWSRunWhenSecurityAlert));
            }

        }




        [ConfigurationProperty("SecurityPassword1", DefaultValue = (sbyte)0)]

        public sbyte SWSSecurityPassword1
        {
            get { return (sbyte)this["SecurityPassword1"]; }
            set
            {
                this["SecurityPassword1"] = value;
                OnPropertyChanged(nameof(SWSSecurityPassword1));
            }

        }


        [ConfigurationProperty("SecurityPassword2", DefaultValue = (sbyte)0)]

        public sbyte SWSSecurityPassword2
        {
            get { return (sbyte)this["SecurityPassword2"]; }
            set
            {
                this["SecurityPassword2"] = value;
                OnPropertyChanged(nameof(SWSSecurityPassword2));
            }

        }


        [ConfigurationProperty("SecurityPassword3", DefaultValue = (sbyte)0)]

        public sbyte SWSSecurityPassword3
        {
            get { return (sbyte)this["SecurityPassword3"]; }
            set
            {
                this["SecurityPassword3"] = value;
                OnPropertyChanged(nameof(SWSSecurityPassword3));
            }

        }


        [ConfigurationProperty("SecurityPassword4", DefaultValue = (sbyte)0)]

        public sbyte SWSSecurityPassword4
        {
            get { return (sbyte)this["SecurityPassword4"]; }
            set
            {
                this["SecurityPassword4"] = value;
                OnPropertyChanged(nameof(SWSSecurityPassword4));
            }

        }








        //SWT=SETTINGS WINDOW TASK

        [ConfigurationProperty("WarmToAddTask", DefaultValue = true)]

        public bool SWTWarmToAddTask
        {
            get { return (bool)this["WarmToAddTask"]; }
            set
            {
                this["WarmToAddTask"] = value;
                OnPropertyChanged(nameof(SWTWarmToAddTask));
            }

        }

        [ConfigurationProperty("WarmToClosingRunTask", DefaultValue = true)]

        public bool SWTWarmToClosingRunTask
        {
            get { return (bool)this["WarmToClosingRunTask"]; }
            set
            {
                this["WarmToClosingRunTask"] = value;
                OnPropertyChanged(nameof(SWTWarmToClosingRunTask));
            }

        }

        [ConfigurationProperty("MinuteWarningBeforeRunTask", DefaultValue = (sbyte)1)]

        public sbyte SWTMinuteWarningBeforeRunTask
        {
            get { return (sbyte)this["MinuteWarningBeforeRunTask"]; }
            set
            {
                this["MinuteWarningBeforeRunTask"] = value;
                OnPropertyChanged(nameof(SWTMinuteWarningBeforeRunTask));
            }

        }



        [ConfigurationProperty("WhenLockModeIsEnableWeCantDeleteTask", DefaultValue = true)]

        public bool SWTWhenLockModeIsEnableWeCantDeleteTask
        {
            get { return (bool)this["WhenLockModeIsEnableWeCantDeleteTask"]; }
            set
            {
                this["WhenLockModeIsEnableWeCantDeleteTask"] = value;
                OnPropertyChanged(nameof(SWTWhenLockModeIsEnableWeCantDeleteTask));
            }

        }


        [ConfigurationProperty("WhenLockModeIsEnableWeCantDeleteRecentTask", DefaultValue = true)]

        public bool SWTWhenLockModeIsEnableWeCantDeleteRecentTask
        {
            get { return (bool)this["WhenLockModeIsEnableWeCantDeleteRecentTask"]; }
            set
            {
                this["WhenLockModeIsEnableWeCantDeleteRecentTask"] = value;
                OnPropertyChanged(nameof(SWTWhenLockModeIsEnableWeCantDeleteRecentTask));
            }

        }



        //SWT=SETTINGS WINDOW TASK

        [ConfigurationProperty("ColorOfAppTheme", DefaultValue = "Default")]

        public string SWTheme_ColorOfAppTheme
        {
            get { return (string)this["ColorOfAppTheme"]; }
            set
            {
                this["ColorOfAppTheme"] = value;
                OnPropertyChanged(nameof(SWTheme_ColorOfAppTheme));
            }

        }



    }

}
