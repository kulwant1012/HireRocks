using System;
using System.Collections.ObjectModel;
using System.Windows;
using PS.ActivityManagementStudio.PSServiceReference;
using GalaSoft.MvvmLight;
using Microsoft.AspNet.SignalR.Client;
using System.Configuration;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        public static HubConnection _hubConnection;
        public static IHubProxy _notificationHub;

        protected static InitializationServiceClient InitializationServiceClient { get; set; }

        protected static ActivityOptimizationSystemServiceClient ActivityOptimizationSystemServiceClient { get; set; }

        protected static ActivityVerificationServiceClient ActivityVerificationServiceClient { get; set; }

        protected static bool IsCloseButtonNotClicked { get; set; }

        private bool _isBusy { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged(() => IsBusy);
                }
            }
        }

        private static bool _isAddUpdateView { get; set; }

        public static bool IsAddUpdateView
        {
            get { return _isAddUpdateView; }
            set
            {
                if (_isAddUpdateView != value)
                {
                    _isAddUpdateView = value;
                }
            }
        }

        private string _message { get; set; }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        private ObservableCollection<string> _errorList { get; set; }

        public ObservableCollection<string> ErrorList
        {
            get { return _errorList; }
            set
            {
                if (_errorList != value)
                {
                    _errorList = value;
                    RaisePropertyChanged(() => ErrorList);
                }
            }
        }

        static BaseViewModel()
        {
            ActivityOptimizationSystemServiceClient = new ActivityOptimizationSystemServiceClient();
            ActivityVerificationServiceClient = new ActivityVerificationServiceClient();
        }
    }
}