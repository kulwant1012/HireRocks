using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using Hardcodet.Wpf.TaskbarNotification;
using Newtonsoft.Json;
using PS.Tracker.Helpers;
using PS.Tracker.Model;
using PS.Tracker.Repository;

namespace PS.Tracker.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand SuspendResumeTaskCommand { get; set; }
        public RelayCommand ExitApplicationCommand { get; set; }

        bool _isTopNavigationVisible { get; set; }
        public bool IsTopNavigationVisible
        {
            get { return _isTopNavigationVisible; }
            set { _isTopNavigationVisible = value; RaisePropertyChanged(() => IsTopNavigationVisible); }
        }

        bool _isBackButtonVisible { get; set; }
        public bool IsBackButtonVisible
        {
            get { return _isBackButtonVisible; }
            set { _isBackButtonVisible = value; RaisePropertyChanged(() => IsBackButtonVisible); }
        }

        bool _isBusy { get; set; }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        string _suspendButtonText { get; set; }
        public string SuspendButtonText
        {
            get { return _suspendButtonText; }
            set { _suspendButtonText = value; RaisePropertyChanged(() => SuspendButtonText); }
        }

        bool _isSuspendButtonEnabled { get; set; }
        public bool IsSuspendButtonEnabled
        {
            get { return _isSuspendButtonEnabled; }
            set { _isSuspendButtonEnabled = value; RaisePropertyChanged(() => IsSuspendButtonEnabled); }
        }

        public TaskbarIcon _notificationIcon;
        RavenRepository _ravenRepository;
        // Repository.Repository _repository;
        bool _isSyncingData;
        public bool IsSyncingData
        {
            get { return _isSyncingData; }
            set { _isSyncingData = value; RaisePropertyChanged(() => IsSyncingData); }
        }

        string _firstName { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        string _lastName { get; set; }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        string _profilePic { get; set; }
        public string ProfilePic
        {
            get { return _profilePic; }
            set { _profilePic = value; RaisePropertyChanged(() => ProfilePic); }
        }

        bool _isNetworkAvailable;

        public MainViewModel()
        {
            SuspendButtonText = "Suspend";
            IsSuspendButtonEnabled = false;
            LogoutCommand = new RelayCommand(LogoutCommandExecute);
            BackCommand = new RelayCommand(BackCommandExecute);
            CloseWindow = new RelayCommand(CloseWindowCommandExecute);
            SuspendResumeTaskCommand = new RelayCommand(SuspendResumeTaskCommandExecute);
            ExitApplicationCommand = new RelayCommand(ExitApplicationCommandExecute);
            _notificationIcon = (TaskbarIcon)Application.Current.Properties["TaskbarIcon"];
            _notificationIcon.DoubleClickCommand = new RelayCommand(ShowHideWindowCommandExecute);
            _notificationIcon.DataContext = this;
            _isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            IsSyncingData = false;
            if (_isNetworkAvailable)
                SyncOfflineData();
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }

        #region Commands

        void LogoutCommandExecute()
        {
            ApplicationSession.UserId = null;
            ApplicationSession.ProjectId = null;
            new NavigationService().NavigateTo(new Uri(PageUrls.LoginPageUrl, UriKind.RelativeOrAbsolute));
        }

        void BackCommandExecute()
        {
            //new NavigationService().GoBack();
            new NavigationService().NavigateTo(new Uri(PageUrls.ProjectsPageUrl,UriKind.RelativeOrAbsolute));
        }

        void CloseWindowCommandExecute()
        {
            Application.Current.MainWindow.Hide();
            _notificationIcon.ShowBalloonTip("Running here!", "Double click icon to view Tracker window", _notificationIcon.Icon);
        }

        public void ShowHideWindowCommandExecute()
        {
            var mainWindow = Application.Current.MainWindow;
            if (mainWindow.IsVisible)
                mainWindow.Hide();
            else
                mainWindow.Show();
        }

        void SuspendResumeTaskCommandExecute()
        {
            if (SuspendButtonText == "Suspend")
            {
                _timer.Stop();
                _keyboardHook.Stop();
                _mouseHook.Stop();
                SuspendButtonText = "Resume";
            }
            else
            {
                _timer.Start();
                _keyboardHook.Start();
                _mouseHook.Start();
                SuspendButtonText = "Suspend";
            }
        }

        void ExitApplicationCommandExecute()
        {
            Application.Current.Shutdown();
        }
        #endregion

        void NetworkChange_NetworkAvailabilityChanged(object sender, System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                _isNetworkAvailable = true;
                SyncOfflineData();
            }
            else
                _isNetworkAvailable = false;
        }

        async void SyncOfflineData()
        {
            await Task.Factory.StartNew(() =>
            {
                IsSyncingData = true;
                _ravenRepository = _ravenRepository ?? new RavenRepository();
                string offlineDataPath = GetStoragePath.UserDataFolder;
                string offlineDataFilePath = offlineDataPath + "CapturesData.txt";
                if (File.Exists(offlineDataFilePath))
                {
                    var offlineData = JsonConvert.DeserializeObject<List<CaptureModel>>("[" + File.ReadAllText(offlineDataFilePath) + "]");
                    while (_isNetworkAvailable)
                    {
                        foreach (var item in offlineData.ToList())
                        {
                            try
                            {
                                var imagePath = offlineDataPath + item.ScreenCaptureFullImage + ".png";
                                if (!item.IsSynced)
                                {
                                    if (File.Exists(imagePath))
                                    {
                                        var image = Image.FromFile(imagePath);
                                        _ravenRepository.UploadImage(image, item.ScreenCaptureThumbnailImage, item.ScreenCaptureFullImage);
                                        image.Dispose();
                                    }
                                    // _repository.InsertCapture(item);
                                    item.IsSynced = true;
                                }
                                if (item.IsSynced)
                                {
                                    File.Delete(imagePath);
                                    offlineData.Remove(item);
                                }
                            }
                            catch (Exception)
                            {
                                if (!_isNetworkAvailable)
                                    break;
                                continue;
                            }
                        }
                        break;
                    }
                    var offlineTextData = offlineData.Count > 0 ?JsonConvert.SerializeObject(offlineData).Replace("[", "").Replace("]", "") + "," : "";
                    File.WriteAllText(offlineDataFilePath, offlineTextData);
                    return;
                }
                IsSyncingData = false;
            });
        }
    }
}