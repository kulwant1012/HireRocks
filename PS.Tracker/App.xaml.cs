using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using PS.Tracker.View;
using Telerik.Windows.Controls;

namespace PS.Tracker
{
    public partial class App : Application
    {
        private readonly static Mutex _mutex;
        private TaskbarIcon _taskbarIcon;
        
        static App()
        {
            bool isNewInstance = false;
            _mutex = new Mutex(true, "PS.Tracker", out isNewInstance);
            if (!isNewInstance)
            {
                MessageBox.Show("Application already running...");
                Environment.Exit(0);
            }
            StyleManager.ApplicationTheme = new Expression_DarkTheme();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _taskbarIcon = (TaskbarIcon)FindResource("TaskbarIcon");
            this.Properties.Add("TaskbarIcon", _taskbarIcon);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}
