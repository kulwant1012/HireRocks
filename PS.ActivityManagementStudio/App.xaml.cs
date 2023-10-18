using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using PS.ActivityManagementStudio.Helpers;
using Telerik.Windows.Controls;
using System.Threading;

namespace PS.ActivityManagementStudio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly static MessageHelpers _messageHelper;
        private readonly static Mutex _mutex;
        static App()
        {
            StyleManager.ApplicationTheme = new Windows8Theme();
            _messageHelper = new MessageHelpers();
            _messageHelper.Register();
            bool isNewInstance = false;
            _mutex = new Mutex(true, "PS.ActivityManagementStudio", out isNewInstance);
            if (!isNewInstance)
            {
                MessageBox.Show("Application already running...");
                Environment.Exit(0);
            }
        }
    }
}
