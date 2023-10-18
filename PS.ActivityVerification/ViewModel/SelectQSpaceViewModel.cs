using System;
using System.Collections.ObjectModel;
using PS.ActivityVerification.PSServiceReference;
using PS.ActivityVerification.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace PS.ActivityVerification.ViewModel
{
    public class SelectQSpaceViewModel : BaseViewModel
    {
        public SelectQSpaceViewModel()
        {
            GetViewData();
            if (AOSQSpaceList.Count == 0 || AOSQSpaceList == null)
                IsQSpaceListVisible = false;
            else
                IsQSpaceListVisible = true;
        }

        private ObservableCollection<AOSQSpace> _aosQSpaceList { get; set; }

        public ObservableCollection<AOSQSpace> AOSQSpaceList
        {
            get { return _aosQSpaceList; }
            set
            {
                _aosQSpaceList = value;
                RaisePropertyChanged(() => AOSQSpaceList);
            }
        }

        private string _selectedQSpace { get; set; }

        public string SelectedQSpace
        {
            get { return _selectedQSpace; }
            set
            {
                if (_selectedQSpace != value)
                {
                    _selectedQSpace = value;
                    RaisePropertyChanged(() => SelectedQSpace);
                    if (value != null)
                        OpenSelectActivityScreen();
                }
            }
        }

        private bool _isQSpaceListVisible { get; set; }

        public bool IsQSpaceListVisible
        {
            get { return _isQSpaceListVisible; }
            set
            {
                _isQSpaceListVisible = value;
                RaisePropertyChanged(() => IsQSpaceListVisible);
            }
        }

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

        private void GetViewData()
        {
            var result = ActivityOptimizationSystemServiceClient.GetQSpaces();
            if (!result.IsErrorReturned)
                AOSQSpaceList = new ObservableCollection<AOSQSpace>(result.Value);
        }

        private void OpenSelectActivityScreen()
        {
            try
            {
                IsBusy = true;
                if (SelectedQSpace != null)
                {
                    ErrorMessage = string.Empty;
                    Session.QSpaceId = SelectedQSpace;
                    Messenger.Default.Send(new ActivityMessage());
                    IsBusy = false;
                    Messenger.Default.Send(new CloseQSpaceWindow());
                }
                else
                    ErrorMessage = "Select QSpace";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}