using System;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LoginCommandExecute);
            User = new User();
        }

        public RelayCommand LoginCommand { get; private set; }

        private User _user { get; set; }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        private async void LoginCommandExecute()
        {
            try
            {
                if (!string.IsNullOrEmpty(User.Login) && !string.IsNullOrEmpty(User.Password))
                {
                    IsBusy = true;
                    var result =
                        await ActivityOptimizationSystemServiceClient.AOSSignInAsync(User.Login, User.Password);
                    if (!result.IsErrorReturned && result.Value != null)
                    {
                        Message = string.Empty;
                        ApplicationSession.User = result.Value;
                        string connectionString = ConfigurationManager.AppSettings["NotificationServer"];
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        dictionary.Add("userId", ApplicationSession.User.Id);
                        dictionary.Add("groupName", "AMS");
                        _hubConnection = new HubConnection(connectionString, dictionary);
                        _notificationHub = _hubConnection.CreateHubProxy("NotificaitonHub");
                        await _hubConnection.Start();

                        Messenger.Default.Send(new MainWindowMessage());
                        Messenger.Default.Send(new CloseLoginWindow());
                    }
                    else
                        Message = result.ErrorMessage;
                }

                if (string.IsNullOrEmpty(User.Login))
                {
                    Message = "Enter login id";
                    return;
                }

                if (string.IsNullOrEmpty(User.Password))
                {
                    Message = "Enter password";
                    return;
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.ToString();
            }
        }
    }
}