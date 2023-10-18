using PS.ActivityVerification.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Hardcodet.Wpf.TaskbarNotification;
using PS.ActivityVerification.ViewModel;
using Telerik.Windows.Controls;
using System.Threading;

namespace PS.ActivityVerification
{
    public partial class App : Application
    {
        private readonly static MessageHelpers _messageHelper;
        private TaskbarIcon _notifyIcon;
        private readonly static Mutex _mutex;

        static App()
        {
            _messageHelper = new MessageHelpers();
            _messageHelper.Register();
            bool isNewInstance = false;
            _mutex = new Mutex(true, "PS.ActivityVerification", out isNewInstance);
            if (!isNewInstance)
            {
                MessageBox.Show("Application already running...");
                Environment.Exit(0);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            //_notifyIcon.DataContext = NotifyIconViewModel.Instance;
            Session.taskbarIcon = _notifyIcon;
            StyleManager.ApplicationTheme = new Windows8Theme();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}
