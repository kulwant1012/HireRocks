using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using PS.ActivityManagementStudio.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PS.ActivityManagementStudio.Messages;
using PS.ActivityManagementStudio.View;

namespace PS.ActivityManagementStudio.Helpers
{
    public class MessageHelpers
    {
        private static LoginWindow _loginWindow;
        private static MainWindow _mainWindow;
        private static AddUpdateQSpaceWindow _addUpdateQSpaceWindow;
        private static AddUpdateActivityWindow _addUpdateActivityWindow;
        private static ActivityVerificationWindow _activityVerificationWindow;
        private static UserWindow _userWindow;
        private static AddUpdateUsersWindow _addUpdateUsersWindow;
        private static QSpaceWindow _qSpaceWindow;
        private static ActivityWindow _activityWindow;
        private static DictionaryWindow _dictionaryWindow;
        private static ActivityToolWindow _activityToolWindow;
        private static AddDictionaryWindow _addDictionaryWindow;
        private static UpdateDictionaryWindow _updateDictionaryWindow;
        private static AddUpdateActivityToolWindow _addUpdateActivityToolWindow;
        private static ReportsWindow _reportsWindow;

        public void Register()
        {
            Messenger.Default.Register<MainWindowMessage>(this, OpenMainWindow);
            Messenger.Default.Register<AddUpdateQSpaceWindowMessage>(this, OpenAddQSpaceWindow);
            Messenger.Default.Register<AddUpdateActivityWindowMessage>(this, OpenAddActivityWindow);
            Messenger.Default.Register<ActivityVerificationWindowMessage>(this, OpenActivityVerificationWindow);
            Messenger.Default.Register<AddUpdateUserWindowMessage>(this, OpenAddUserWindow);
            Messenger.Default.Register<UserWindowMessage>(this, OpenUserWindow);
            Messenger.Default.Register<QSpaceWindowMessage>(this, OpenQSpaceWindow);
            Messenger.Default.Register<ActivityWindowMessage>(this, OpenActivityWindow);
            Messenger.Default.Register<DictionaryWindowMessage>(this, OpenDictionaryWindow);
            Messenger.Default.Register<AddDictionaryWindowMessage>(this, OpenAddDictionaryWindow);
            Messenger.Default.Register<UpdateDictionaryWindowMessage>(this, OpenUpdateDictionaryWindow);
            Messenger.Default.Register<ActivityToolWindowMessage>(this, OpenActivityToolWindow);
            Messenger.Default.Register<AddUpdateActivityToolWindowMessage>(this, OpenAddUpdateActivityToolWindow);
            Messenger.Default.Register<LoginMessage>(this, OpenLoginWindow);
            Messenger.Default.Register<ReportsWindowMessage>(this, OpenReportsWindow);
        }

        private void OpenMainWindow(MainWindowMessage msg)
        {
            _mainWindow = new MainWindow();
            _mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _mainWindow.Show();
        }

        private void OpenAddQSpaceWindow(AddUpdateQSpaceWindowMessage msg)
        {
            _addUpdateQSpaceWindow = new AddUpdateQSpaceWindow();
            _addUpdateQSpaceWindow.Owner = _qSpaceWindow;
            _addUpdateQSpaceWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _addUpdateQSpaceWindow.Show();
        }

        private void OpenAddActivityWindow(AddUpdateActivityWindowMessage msg)
        {
            _addUpdateActivityWindow = new AddUpdateActivityWindow();
            _addUpdateActivityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _addUpdateActivityWindow.Owner = _activityWindow;
            _addUpdateActivityWindow.Show();
        }

        private void OpenActivityVerificationWindow(ActivityVerificationWindowMessage msg)
        {
            _activityVerificationWindow = new ActivityVerificationWindow();
            _activityVerificationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _activityVerificationWindow.Owner = _mainWindow;
            _activityVerificationWindow.Show();
        }

        private void OpenAddUserWindow(AddUpdateUserWindowMessage msg)
        {
            _addUpdateUsersWindow = new AddUpdateUsersWindow();
            _addUpdateUsersWindow.Owner = _userWindow;
            _addUpdateUsersWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _addUpdateUsersWindow.Show();
        }

        private void OpenUserWindow(UserWindowMessage msg)
        {
            _userWindow = new UserWindow();
            _userWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //_userWindow.Owner = _mainWindow;
            _userWindow.Show();
        }

        private void OpenQSpaceWindow(QSpaceWindowMessage msg)
        {
            _qSpaceWindow = new QSpaceWindow();
            //_qSpaceWindow.Owner = _mainWindow;
            _qSpaceWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _qSpaceWindow.Show();
        }

        private void OpenActivityWindow(ActivityWindowMessage msg)
        {
            _activityWindow = new ActivityWindow();
            //_activityWindow.Owner = _mainWindow;
            _activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _activityWindow.Show();
        }

        private void OpenDictionaryWindow(DictionaryWindowMessage msg)
        {
            _dictionaryWindow = new DictionaryWindow();
            //window.Owner = _mainWindow;
            _dictionaryWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _dictionaryWindow.Show();
        }

        private void OpenAddDictionaryWindow(AddDictionaryWindowMessage msg)
        {
            _addDictionaryWindow = new AddDictionaryWindow();
            _addDictionaryWindow.Owner = _dictionaryWindow;
            _addDictionaryWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _addDictionaryWindow.Show();
        }

        private void OpenUpdateDictionaryWindow(UpdateDictionaryWindowMessage msg)
        {
            _updateDictionaryWindow = new UpdateDictionaryWindow();
            _updateDictionaryWindow.Owner = _dictionaryWindow;
            _updateDictionaryWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _updateDictionaryWindow.Show();
        }

        private void OpenActivityToolWindow(ActivityToolWindowMessage msg)
        {
            _activityToolWindow = new ActivityToolWindow();
            _activityToolWindow.Owner = _mainWindow;
            _activityToolWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _activityToolWindow.Show();
        }

        private void OpenAddUpdateActivityToolWindow(AddUpdateActivityToolWindowMessage msg)
        {
            _addUpdateActivityToolWindow = new AddUpdateActivityToolWindow();
            _addUpdateActivityToolWindow.Owner = _activityToolWindow;
            _addUpdateActivityToolWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _addUpdateActivityToolWindow.Show();
        }

        private void OpenLoginWindow(LoginMessage msg)
        {
            _loginWindow = new LoginWindow();
            _loginWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _loginWindow.Show();
        }

        private void OpenReportsWindow(ReportsWindowMessage msg)
        {
            _reportsWindow = new ReportsWindow();
            _reportsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _reportsWindow.Show();
        }
    }
}
