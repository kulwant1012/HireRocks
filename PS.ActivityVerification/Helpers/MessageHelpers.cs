using System.Windows;
using PS.ActivityVerification.Messages;
using PS.ActivityVerification.Views;
using GalaSoft.MvvmLight.Messaging;

namespace PS.ActivityVerification.Helpers
{
    public class MessageHelpers
    {
        public void Register()
        {
            Messenger.Default.Register<QSpaceMessage>(this, OpenQSpaceWindow);
            Messenger.Default.Register<ActivityMessage>(this, OpenActivityWindow);
        }

        private void OpenQSpaceWindow(QSpaceMessage msg)
        {
            var window = new SelectQSpaceWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void OpenActivityWindow(ActivityMessage msg)
        {
            var window = new SelectActivityWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
    }
}