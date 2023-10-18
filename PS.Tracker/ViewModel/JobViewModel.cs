using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls.Primitives;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using MouseKeyboardLibrary;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.Tracker.Helpers;
using PS.Tracker.Repository;
using PS.Tracker.View;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PS.Tracker.ViewModel
{
    public class JobViewModel : BaseViewModel
    {
        public RelayCommand<string> StartTaskCommand { get; private set; }
        public RelayCommand RefreshJobsCommand { get; private set; }

        long? _selectedContractId { get; set; }
        public long? SelectedContractId
        {
            get { return _selectedContractId; }
            set
            {
                _selectedContractId = value;
                RaisePropertyChanged(() => SelectedContractId);
                IsStartTaskButtonVisible = value != null ? true : false;
                StopActivity();
            }
        }

        bool _isStartTaskButtonVisible { get; set; }
        public bool IsStartTaskButtonVisible
        {
            get { return _isStartTaskButtonVisible; }
            set { _isStartTaskButtonVisible = value; RaisePropertyChanged(() => IsStartTaskButtonVisible); }
        }

        ObservableCollection<TrackerJobsViewModel> _WorkerJobList { get; set; }
        public ObservableCollection<TrackerJobsViewModel> WorkerJobList
        {
            get { return _WorkerJobList; }
            set { _WorkerJobList = value; RaisePropertyChanged(() => WorkerJobList); }
        }

        string _startButtonText { get; set; }
        public string StartButtonText
        {
            get { return _startButtonText; }
            set
            {
                _startButtonText = value;
                RaisePropertyChanged(() => StartButtonText);
            }
        }

        string _startButtonImage { get; set; }
        public string StartButtonImage
        {
            get { return _startButtonImage; }
            set
            {
                _startButtonImage = value;
                RaisePropertyChanged(() => StartButtonImage);
            }
        }

        Random _random;
        int _keyCount = 0;
        int _mouseCount = 0;
        string _keyboardCapture = string.Empty;
        string _mouseCapture = string.Empty;
        string _screenCapturePath = ConfigurationManager.AppSettings["ScreenCapturePath"];
        MainViewModel _mainViewModel;
        FancyBaloonViewModel _fancyBaloonViewModel;
        RavenRepository _ravenRepository;
        FancyBalloon _balloon;
        int _timeForPreview;
        CaptureViewModel _captureViewModel = null;
        Image _image = null;

        public JobViewModel()
        {
            _mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            _fancyBaloonViewModel = ServiceLocator.Current.GetInstance<FancyBaloonViewModel>();
            _mainViewModel.IsBusy = true;
            _ravenRepository = new RavenRepository();
            _random = new Random();
            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Elapsed += _timer_Elapsed;
            _keyboardHook = new KeyboardHook();
            _mouseHook = new MouseHook();
            _keyboardHook.KeyPress += _keyboardHook_KeyPress;
            _mouseHook.MouseUp += _mouseHook_MouseUp;
            StartTaskCommand = new RelayCommand<string>(StartTaskCommandExecute);
            RefreshJobsCommand = new RelayCommand(GetJobs);
            StartButtonText = "Start";
            GetJobs();
            _mainViewModel.IsBusy = false;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var result = new TrackerRepositories().GetWorkerJobs(ApplicationSession.UserId);
            WorkerJobList = new ObservableCollection<TrackerJobsViewModel>(result.Select(x => new TrackerJobsViewModel
            {
                ContractId = x.ContractId,
                HoursLimit = x.HoursLimit,
                JobStartDate = x.JobStartDate,
                JobTitle = x.JobTitle,
                JobTypeName = x.JobTypeName,
                TodayBurnedHours = x.TodayBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)x.TodayBurnedHours.Value).ToString("hh\\:mm") : string.Empty,
                TotalBurnedHours = x.TotalBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)x.TotalBurnedHours.Value).ToString("hh\\:mm") : string.Empty,
                WeeklyBurnedHours = x.WeeklyBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)x.WeeklyBurnedHours.Value).ToString("hh\\:mm") : string.Empty
            }));
        }



        private void GetJobs()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }



        void StartTaskCommandExecute(string buttonText)
        {
            if (buttonText == "Start")
                StartActivity();
            if (buttonText == "Stop")
                StopActivity();
        }

        void _mouseHook_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mouseCapture += e.Button == System.Windows.Forms.MouseButtons.Left ? 1 : 0;
            _mouseCount++;
        }

        void _keyboardHook_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            _keyboardCapture += e.KeyChar;
            _keyCount++;
        }

        void StopActivity()
        {
            _timer.Stop();
            _keyboardHook.Stop();
            _mouseHook.Stop();
            StartButtonText = "Start";
            StartButtonImage = "pack://application:,,,/Images/Play.png";
            _mainViewModel.IsSuspendButtonEnabled = false;
            _mainViewModel.SuspendButtonText = "Resume";
        }

        async void StartActivity()
        {
            _timer.Start();
            _keyboardHook.Start();
            _mouseHook.Start();
            StartButtonText = "Stop";
            StartButtonImage = "pack://application:,,,/Images/Pause.png";
            _mainViewModel.IsSuspendButtonEnabled = true;
            _mainViewModel.SuspendButtonText = "Suspend";
            _mainViewModel.ShowHideWindowCommandExecute();
            await App.Current.Dispatcher.InvokeAsync(() => { _balloon = new FancyBalloon(); _balloon.BalloonText = "Tracking job!"; });
            _fancyBaloonViewModel.IsCaptureNotification = false;
            _fancyBaloonViewModel.NotificationText = string.Format("Job '{0}' started", WorkerJobList.FirstOrDefault(x => x.ContractId == SelectedContractId).JobTitle);
            _mainViewModel._notificationIcon.ShowCustomBalloon(_balloon, PopupAnimation.Fade, 10000);
        }

        async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _captureViewModel = new CaptureViewModel();
            _captureViewModel.KeyboardCapture = _keyboardCapture;
            _captureViewModel.KeyCount = _keyCount;
            _captureViewModel.MouseCapture = _mouseCapture;
            _captureViewModel.MouseCount = _mouseCount;
            _captureViewModel.ContractId = SelectedContractId;
            _captureViewModel.TimeBurned = (decimal)_timer.Interval;
            _captureViewModel.CaptureDate = DateTime.UtcNow;
            _captureViewModel.ScreenCaptureThumbnailImage = Guid.NewGuid().ToString();
            _captureViewModel.ScreenCaptureFullImage = Guid.NewGuid().ToString();

            _keyCount = 0;
            _mouseCount = 0;
            _keyboardCapture = string.Empty;
            _mouseCapture = string.Empty;
            _timeForPreview = 15;
            _timer.Interval = _random.Next(420000, 600000);
            _image = GetScreenCapture.GetScreenImage();

            await App.Current.Dispatcher.InvokeAsync(() =>
            {
                _balloon = new FancyBalloon();
                _balloon.BalloonText = "Capture review!";
                _fancyBaloonViewModel.ScreenCaptureFullImage = _image.ToBitmapImage();
            });
            _fancyBaloonViewModel.IsCaptureNotification = true;
            _fancyBaloonViewModel.IsCaptureDiscarded = false;
            _fancyBaloonViewModel.IsPreviewButtonEnabled = true;
            _fancyBaloonViewModel.IsPreviewButtonClicked = false;
            _mainViewModel._notificationIcon.ShowCustomBalloon(_balloon, PopupAnimation.Fade, 60000);

            Timer timerForShowCapturePreview = new Timer();
            timerForShowCapturePreview.Interval = 1000;
            timerForShowCapturePreview.Enabled = true;
            timerForShowCapturePreview.Elapsed += timerForShowCapturePreview_Elapsed;

        }

        async void timerForShowCapturePreview_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeForPreview--;
            _fancyBaloonViewModel.TimeLeftForSubmission = string.Format("Submit in {0} sec.", _timeForPreview);
            if (_fancyBaloonViewModel.IsCaptureDiscarded)
            {
                ((Timer)sender).Enabled = false;
                _mainViewModel._notificationIcon.CloseBalloon();
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    var window = App.Current.Windows.OfType<PreviewCapture>().FirstOrDefault();
                    if (window != null)
                        window.Close();
                });
                return;
            }
            if (_fancyBaloonViewModel.IsPreviewButtonClicked)
            {
                _timeForPreview = 30;
                _fancyBaloonViewModel.IsPreviewButtonEnabled = false;
                _fancyBaloonViewModel.IsPreviewButtonClicked = false;
                await App.Current.Dispatcher.InvokeAsync(() =>
                      {
                          PreviewCaptureViewModel previewCaptureViewModel = new PreviewCaptureViewModel();
                          previewCaptureViewModel.KeyboardCapture = _captureViewModel.KeyboardCapture;
                          previewCaptureViewModel.MouseCapture = _captureViewModel.MouseCapture;
                          previewCaptureViewModel.TimeBurned = TimeSpan.FromMilliseconds((double)_captureViewModel.TimeBurned).ToString("hh\\:mm");
                          System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(_image);                         
                          BitmapSource bitSrc = null;
                          var hBitmap=bitmap.GetHbitmap();
                          bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
                          previewCaptureViewModel.ScreenCaptureFullImage1 = bitSrc;
                          PreviewCapture previewCaptureWindow = new PreviewCapture();
                          previewCaptureWindow.DataContext = previewCaptureViewModel;
                          previewCaptureWindow.Show();
                      });
                return;
            }
            if (_timeForPreview == 0)
            {
                ((Timer)sender).Enabled = false;
                _mainViewModel._notificationIcon.CloseBalloon();
                await UploadCapture();
                return;
            }
        }

        async Task UploadCapture()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                await Task.Factory.StartNew(() => _ravenRepository.UploadImage(_image, _captureViewModel.ScreenCaptureThumbnailImage, _captureViewModel.ScreenCaptureFullImage));
                var result = new TrackerRepositories().InsertCapture(_captureViewModel);

                var selectedJob = WorkerJobList.FirstOrDefault(x => x.ContractId == SelectedContractId);
                if (selectedJob != null)
                {
                    if (result.IsContractOpen.HasValue && !result.IsContractOpen.Value)
                    {
                        StopActivity();
                        await App.Current.Dispatcher.InvokeAsync(() => { WorkerJobList.Remove(selectedJob); });
                        SelectedContractId = null;
                        _mainViewModel._notificationIcon.ShowBalloonTip("Contract closed", selectedJob.JobTitle + " no more open for time logging.", _mainViewModel._notificationIcon.Icon);
                    }
                    else
                    {
                        selectedJob.TotalBurnedHours = result.TotalBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)result.TotalBurnedHours).ToString("hh\\:mm") : string.Empty;
                        selectedJob.WeeklyBurnedHours = result.WeeklyBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)result.WeeklyBurnedHours).ToString("hh\\:mm") : string.Empty;
                        selectedJob.TodayBurnedHours = result.TodayBurnedHours.HasValue ? TimeSpan.FromMilliseconds((double)result.TodayBurnedHours).ToString("hh\\:mm") : string.Empty;
                        selectedJob.LastCaptureUrl = _screenCapturePath + _captureViewModel.ScreenCaptureFullImage;
                        //if (selectedJob.HoursLimit <= result.WeeklyBurnedHours)
                        //    _mainViewModel._notificationIcon.ShowBalloonTip("Weekly hours limit reached", "You achieved weekly hours limit. You can continue working but client may be not pay for this!", _mainViewModel._notificationIcon.Icon);
                    }
                    RaisePropertyChanged(() => WorkerJobList);
                }
            }
            else
                StoreDataLocally(_captureViewModel, _image);
        }

        async void StoreDataLocally(CaptureViewModel captureViewModel, Image image)
        {
            await Task.Factory.StartNew(() =>
            {
                string storagePath = GetStoragePath.UserDataFolder;
                image.Save(storagePath + captureViewModel.ScreenCaptureFullImage + ".png");
                File.AppendAllText(storagePath + "CapturesData.txt", Newtonsoft.Json.JsonConvert.SerializeObject(captureViewModel).ToString() + ",");
            });
        }
    }
}
