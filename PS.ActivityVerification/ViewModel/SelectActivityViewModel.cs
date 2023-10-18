using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using PS.ActivityVerification.PSServiceReference;
using PS.ActivityVerification.Messages;
using PS.ActivityVerification.Views;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.AspNet.SignalR.Client;
using MouseKeyboardLibrary;
using Application = System.Windows.Application;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Timer = System.Timers.Timer;
using Notification = PS.Data.Notification;
using ActivityOperationEnum = PS.Data.ActivityOperationEnum;

namespace PS.ActivityVerification.ViewModel
{
    public class SelectActivityViewModel : BaseViewModel
    {
        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };

        private readonly GetScreenCapture GetScreenCapture;
        private readonly bool _allocatedTimeCaptured;
        private readonly DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public KeyboardHook KeyboardHook;
        public MouseHook MouseHook;
        public Timer Timer;
        public Stopwatch stopWatch;

        public SelectActivityViewModel()
        {
            try
            {
                _allocatedTimeCaptured = false;

                Messenger.Default.Register<RemoveActivityMessage>(this, e =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ActivityModel activiy = ActivityList.SingleOrDefault(i => i.ActivityID == e.ActivityId);
                        if (activiy != null)
                        {
                            ActivityList.Remove(activiy);
                        }
                    });
                });
                
                _notificationHub.On<Notification>("NotifyMessage", NotifyMessage);
                SubmitOutputCommand = new RelayCommand<ActivityModel>(e =>
                {
                    var window = new SubmitOutputWindow
                    {
                        DataContext = new SubmitOutputViewModel(e)
                    };
                    window.Show();
                });
                AllCaptureTime = new AllCaptureTime();
                AllowedTime = new AllowedTime();
                GetScreenCapture = new GetScreenCapture();
                KeywordDictionaryList = new List<KeywordDictionary>();
                FilteredScreenImageCollection = new List<ActivityCapture>();
                MatchedKeywordIds = new List<string>();
                GetViewData();

                StartCommand = new RelayCommand(StartCommandExecute);
                SwitchQSpaceCommand = new RelayCommand(SwitchQSpaceCommandExecute);
                KeyboardHook = new KeyboardHook();
                //KeyboardHook.KeyDown += KeyboardHook_KeyDown;
                KeyboardHook.KeyPress += keyboardHook_KeyPress;
                MouseHook = new MouseHook();
                MouseHook.MouseUp += MouseHook_MouseUp;
                IsActivityListVisible = true;

                TaskbarIcon taskBarIcon = Session.taskbarIcon;
                taskBarIcon.TrayBalloonTipClicked += taskBarIcon_TrayBalloonTipClicked;
                Session.taskbarIcon = taskBarIcon;
                Timer = new Timer();
                Timer.Elapsed += Timer_Elapsed;
                stopWatch = new Stopwatch();
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 20, 0);

                Application.Current.MainWindow.IsVisibleChanged += MainWindow_IsVisibleChanged;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorMessage = ex.Message;
            }
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timeBurned = TimeSpan.FromSeconds(SelectedActivity.CaptureInterval);
            TakeImage(timeBurned);
        }

        public string lstLog = string.Empty;

        //void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        //{
        //    lstLog += (Convert.ToChar(e.KeyValue));
        //    string lower = lstLog.ToLower();
        //    foreach (var key in KeywordDictionaryList[0].Keywords)
        //    {
        //        if (lower.Contains(key))
        //        {
        //            lstLog = string.Empty;
        //            TakeImage();
        //        }
        //    }
        //}

        public RelayCommand StartCommand { get; set; }

        public RelayCommand SwitchQSpaceCommand { get; set; }

        private ObservableCollection<ActivityModel> _activityList { get; set; }

        public ObservableCollection<ActivityModel> ActivityList
        {
            get { return _activityList; }
            set
            {
                _activityList = value;
                RaisePropertyChanged(() => ActivityList);
            }
        }

        private ObservableCollection<Process> _toolsForActivityList { get; set; }

        public ObservableCollection<Process> ToolsForActivityList
        {
            get { return _toolsForActivityList; }
            set
            {
                _toolsForActivityList = value;
                RaisePropertyChanged(() => ToolsForActivityList);
            }
        }

        private string _selectedActivityId { get; set; }

        public string SelectedActivityId
        {
            get { return _selectedActivityId; }
            set
            {
                if (value != null)
                {
                    _selectedActivityId = value;
                    RaisePropertyChanged(() => SelectedActivityId);
                    StartCommandExecute();
                }
            }
        }

        private ActivityModel _selectedActivity { get; set; }

        public ActivityModel SelectedActivity
        {
            get { return _selectedActivity; }
            set
            {
                _selectedActivity = value;
                RaisePropertyChanged(() => SelectedActivity);
            }
        }

        private string _activityDetails { get; set; }

        public string ActivityDetails
        {
            get { return _activityDetails; }
            set
            {
                _activityDetails = value;
                RaisePropertyChanged(() => ActivityDetails);
            }
        }

        private bool _isActivityListVisible { get; set; }

        public bool IsActivityListVisible
        {
            get { return _isActivityListVisible; }
            set
            {
                _isActivityListVisible = value;
                RaisePropertyChanged(() => IsActivityListVisible);
            }
        }

        private bool _isErrorReturned { get; set; }

        public bool IsErrorReturned
        {
            get { return _isErrorReturned; }
            set
            {
                _isErrorReturned = value;
                RaisePropertyChanged(() => IsErrorReturned);
            }
        }

        private string KeyPresses { get; set; }
        private string MouseClicks { get; set; }
        private string CapturedKeyword { get; set; }
        private string FilteredData { get; set; }
        private int KeywordMatchCount { get; set; }
        private Int32 TimeInterval { get; set; }
        private AllCaptureTime AllCaptureTime { get; set; }
        private AllowedTime AllowedTime { get; set; }
        private List<KeywordDictionary> KeywordDictionaryList { get; set; }
        private List<ActivityCapture> FilteredScreenImageCollection { get; set; }
        private List<string> MatchedKeywordIds { get; set; }
        private DateTime? KeywordBeginTime { get; set; }
        private DateTime KeywordEndTime { get; set; }
        public RelayCommand<ActivityModel> SubmitOutputCommand { get; private set; }

        private void MainWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Application.Current.MainWindow.IsVisible)
                dispatcherTimer.Start();
        }

        private void taskBarIcon_TrayBalloonTipClicked(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.MainWindow.IsVisible)
                Application.Current.MainWindow.Show();
        }

        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            try
            {
                if (ActivityList != null)
                {
                    if (ActivityList.Where(x => !x.IsActivityViewed && !x.IaActivityRemovedFromAMS).Count() > 0)
                    {
                        OperationResult result =
                            await
                                ActivityOptimizationSystemServiceClient.UpdateActivityViewStatusAsync(
                                    ActivityList.Where(x => x.IsActivityViewed == false).Select(x => x.ActivityID).ToArray());
                        if (!result.IsErrorReturned)
                            ActivityList.Where(x => x.IsActivityViewed == false)
                                .ToList()
                                .ForEach(x => x.IsActivityViewed = true);
                    }
                    foreach (ActivityModel item in ActivityList.Where(x => x.IaActivityRemovedFromAMS).ToList())
                    {
                        ActivityList.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void MouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MouseClicks += 1;
            else
                MouseClicks += 0;
        }

        private void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!KeywordBeginTime.HasValue)
                    KeywordBeginTime = DateTime.Now;
                   KeyPresses += e.KeyChar.ToString();
                if (e.KeyChar == ' ')
                {
                    MatchKeyword();
                }
                else
                    CapturedKeyword += e.KeyChar.ToString();                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async void GetViewData()
        {
            try
            {
                IsBusy = true;
                var activityUsers =
                    await ActivityOptimizationSystemServiceClient.GetUserActivitiesByUserIdAsync(Session.User.Id);
                if (!activityUsers.IsErrorReturned)
                {
                    var statuses =
                        await ActivityOptimizationSystemServiceClient.GetActivityStatusAsync();
                    string completedStatusId = statuses.Value.Single(i => i.StatusName == "Completed").Id;
                    //var activities = await ActivityOptimizationSystemServiceClient.GetActivitiesByQSpaceIdAndActivityIdAsync(Session.QSpaceId, activityUsers.Value.Select(x => x.ActivityId).ToArray());
                    var activities =
                        await
                            ActivityOptimizationSystemServiceClient.GetActiveActivitiesByQSpaceIdAndActivityIdAsync(
                                Session.QSpaceId, activityUsers.Value.Select(x => x.ActivityId).ToArray());
                    var activityCompositions =
                        await
                            ActivityOptimizationSystemServiceClient.GetActivityCompositionsByActivityIdsAsync(
                                activities.Value.Select(x => x.Id).ToArray());

                    if (!activities.IsErrorReturned && !activityCompositions.IsErrorReturned)
                    {
                        float? remainingDuration = null;
                        ParallelQuery<ActivityModel> activityList =
                            (from activity in activities.Value.Where(i => i.ActivityStatusId != completedStatusId)
                             join activityComposition in activityCompositions.Value
                                 on activity.Id equals activityComposition.ActivityID
                             join activityUser in activityUsers.Value.Where(x => x.IsActive == true) on activity.Id equals activityUser.ActivityId
                             select new ActivityModel
                             {
                                 ActivityID = activity.Id,
                                 ActivityName = activity.ActivityName,
                                 ActivityUserId = activityUser.Id,
                                 Sequence = activityComposition.Sequence,
                                 MaximumDuration = activityComposition.MaximumDuration,
                                 MinimumDuration = activityComposition.MinimumDuration,
                                 OptimumDuration = activityComposition.OptimumDuration,
                                 ActivityTools = GetActivityTool(activityComposition.ActivityToolId),
                                 ActivityToolNames = GetActivityToolNames(activityComposition.ActivityToolId),
                                 ActivityPercentDone = GetActivityPercentCompleted(activityUser.Id, activityComposition.MaximumDuration, activityComposition.VariationFactor, out remainingDuration),
                                 BottomPanelcolor = Color.LightGray.Name,
                                 AllCaptureTimeId = activityComposition.AllCaptureTimeId,
                                 AllowedTimeId = activityComposition.AllowedTimeId,
                                 KeywordDictionaryIds = activityComposition.KeywordDictionaryIds,
                                 ActivityCurrentStatus = "Start",
                                 LearnButtonVisibility = true,
                                 RemainingDuration = remainingDuration,
                                 CaptureInterval = activityComposition.CaptureInterval,
                                 IsActivityViewed = activityUser.IsActivityViewed,
                                 ActivityCaptureType = activityComposition.ActivityCaptureType
                             }).AsParallel();

                        ActivityList = new ObservableCollection<ActivityModel>(activityList);
                        if (ActivityList.Count > 0)
                        {
                            IsActivityListVisible = true;
                        }
                        else
                        {
                            IsActivityListVisible = false;
                        }
                        IsBusy = false;
                        dispatcherTimer.Start();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private float GetActivityPercentCompleted(string activityUserId, float maximumDuration, float variationFactor, out float? remainingDuration)
        {
            remainingDuration = maximumDuration + (variationFactor * maximumDuration / 100);
            var result =
                ActivityVerificationServiceClient.GetActivityCaptures(null, null, activityUserId);
            if (!result.IsErrorReturned)
            {
                if (result.Value != null && result.Value.Any())
                {
                    remainingDuration = remainingDuration -
                                        (float)
                                            TimeSpan.FromSeconds(
                                                result.Value.Where(
                                                    x => x.VerificationStatus.IsAccepted && x.VerificationStatus.IsValid)
                                                    .Sum(x => x.TimeBurned.TotalSeconds)).TotalHours;
                    return
                        (float)
                            TimeSpan.FromSeconds(
                                result.Value.Where(x => x.VerificationStatus.IsAccepted && x.VerificationStatus.IsValid)
                                    .Sum(x => x.TimeBurned.TotalSeconds)).TotalHours * 100 / maximumDuration;
                }
            }
            return 0;
        }

        private string GetActivityToolNames(string[] activityToolsId)
        {
            var result =
                ActivityOptimizationSystemServiceClient.GetActivityToolsById(activityToolsId);
            if (!result.IsErrorReturned)
            {
                if (result.Value.Any())
                    return result.Value.Select(x => x.ToolName).Aggregate((i, j) => i + ", " + j);
            }
            return string.Empty;
        }

        private ActivityTool[] GetActivityTool(string[] activityToolsId)
        {
            var result =
                ActivityOptimizationSystemServiceClient.GetActivityToolsById(activityToolsId);
            if (!result.IsErrorReturned)
            {
                return result.Value;
            }

            return null;
        }

        private async void StartCommandExecute()
        {
            try
            {
                IsErrorReturned = false;
                if (!string.IsNullOrEmpty(SelectedActivityId))
                {
                    KeyPresses = string.Empty;
                    MouseClicks = string.Empty;
                    ErrorMessage = string.Empty;

                    if (SelectedActivity != null)
                        ActivityList.Where(x => x.ActivityUserId == SelectedActivity.ActivityUserId)
                            .ToList()
                            .ForEach(s =>
                            {
                                s.ActivityCurrentStatus = "Start";
                                s.BottomPanelcolor = Color.LightGray.Name;
                                s.LearnButtonVisibility = true;
                            });

                    SelectedActivity = ActivityList.FirstOrDefault(x => x.ActivityUserId == SelectedActivityId);
                    ActivityList.Where(x => x.ActivityUserId == SelectedActivity.ActivityUserId).ToList().ForEach(s =>
                    {
                        s.ActivityCurrentStatus = "In Progress";
                        s.BottomPanelcolor = Color.Gray.Name;
                        s.LearnButtonVisibility = false;
                    });

                    ToolsForActivityList = new ObservableCollection<Process>(Process.GetProcesses().Where(x => SelectedActivity.ActivityTools.Select(y => y.ToolName).Contains(x.ProcessName)));
                    //if (SelectedActivity != null)
                    //{
                    //    OperationResultOfAllCaptureTime223QE4Mp allCaptureTime =
                    //        await
                    //            ActivityOptimizationSystemServiceClient.GetAllTimeCollectionByIdAsync(
                    //                SelectedActivity.AllCaptureTimeId);
                    //    if (!allCaptureTime.IsErrorReturned)
                    //        AllCaptureTime = allCaptureTime.Value;
                    //    else
                    //    {
                    //        IsErrorReturned = true;
                    //        ErrorMessage = allCaptureTime.ErrorMessage;
                    //        return;
                    //    }
                    //}

                    //if (SelectedActivity != null)
                    //{
                    //    OperationResultOfAllowedTime223QE4Mp allowedTime =
                    //        await
                    //            ActivityOptimizationSystemServiceClient.GetAllowedTimeCollectionByIdAsync(
                    //                SelectedActivity.AllowedTimeId);
                    //    if (allowedTime.Value == null)
                    //    {
                    //    }
                    //    if (!allowedTime.IsErrorReturned)
                    //    {
                    //        AllowedTime = allowedTime.Value;
                    //    }
                    //    else
                    //    {
                    //        IsErrorReturned = true;
                    //        ErrorMessage = allowedTime.ErrorMessage;
                    //        return;
                    //    }
                    //}

                    if (SelectedActivity != null)
                    {
                        var keywordDictionaries =
                            await
                                ActivityOptimizationSystemServiceClient.GetKeywordDictionariesByIdsAsync(
                                    SelectedActivity.KeywordDictionaryIds);
                        if (!keywordDictionaries.IsErrorReturned)
                            KeywordDictionaryList = keywordDictionaries.Value.ToList();
                        else
                        {
                            IsErrorReturned = true;
                            ErrorMessage = keywordDictionaries.ErrorMessage;
                            return;
                        }
                    }

                    if (!IsErrorReturned)
                    {
                        if (!KeyboardHook.IsStarted)
                            KeyboardHook.Start();
                        if (!MouseHook.IsStarted)
                            MouseHook.Start();

                        Messenger.Default.Send(new CloseActivityWindow());
                        TaskbarIcon taskbarIcon = Session.taskbarIcon;
                        if (SelectedActivity != null)
                        {
                            taskbarIcon.ShowBalloonTip("Capture screen started",
                                "Activity name: " + SelectedActivity.ActivityName, taskbarIcon.Icon);
                            var dataContext = (NotifyIconViewModel)taskbarIcon.DataContext;
                            dataContext.IsSuspendResumeEnabled = true;
                            taskbarIcon.DataContext = dataContext;
                            Session.taskbarIcon = taskbarIcon;

                            if (SelectedActivity.ActivityCaptureType == ActivityCaptureType.TimeInterval)
                            {
                                Timer.Interval = SelectedActivity.CaptureInterval * 1000;
                                if (!Timer.Enabled)
                                    Timer.Enabled = true;
                            }

                            else if (SelectedActivity.ActivityCaptureType == ActivityCaptureType.KeywordMatch)
                            {
                                stopWatch.Start();
                            }
                        }
                        //var notifyIconViewModel = NotifyIconViewModel.Instance;
                        //notifyIconViewModel.IsSuspendResumeEnabled = true;
                    }
                }

                if (string.IsNullOrEmpty(SelectedActivityId))
                {
                    IsErrorReturned = true;
                    ErrorMessage = "Select Activity";
                }
            }
            catch (Exception ex)
            {
                IsErrorReturned = true;
                ErrorMessage = ex.Message;
            }
        }

        private void SwitchQSpaceCommandExecute()
        {
            try
            {
                TaskbarIcon taskbarIcon = Session.taskbarIcon;
                var dataContext = (NotifyIconViewModel) taskbarIcon.DataContext;
                dataContext.IsSuspendResumeEnabled = false;
                taskbarIcon.DataContext = dataContext;
                Session.taskbarIcon = taskbarIcon;
                Timer.Enabled = false;
                IsCloseButtonNotClicked = true;
                Messenger.Default.Send(new QSpaceMessage());
                Messenger.Default.Send(new CloseActivityWindow());
                IsCloseButtonNotClicked = false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async void TakeImage(TimeSpan timeBurned)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                {
                    string keyPress = KeyPresses;
                    KeyPresses = string.Empty;
                    string mouseClicks = MouseClicks;
                    MouseClicks = string.Empty;
                    List<string> matchedKeywordIds = MatchedKeywordIds.ToList();
                    MatchedKeywordIds.Clear();

                    IntPtr currentWindowHandle = CurrentProcess.CurrentActiveApplication();
                    ToolsForActivityList = new ObservableCollection<Process>(Process.GetProcesses().Where(x => SelectedActivity.ActivityTools.Select(y => y.ToolName).Contains(x.ProcessName)));
                    if (ToolsForActivityList.Select(x => x.MainWindowHandle).Contains(currentWindowHandle))
                    {
                        byte[] thumbnailImageBytes = null;
                        byte[] fullImageBytes = null;

                        var activityCapture = new ActivityCapture();
                        activityCapture.ActivityUserID = SelectedActivity.ActivityUserId;
                        activityCapture.Keyboard = keyPress;
                        activityCapture.Mouse = mouseClicks;
                        activityCapture.CaptureDateTime = DateTime.Now;
                        activityCapture.MatchedKeywordIds = matchedKeywordIds.ToArray();

                        var verificationStatus = new VerificationStatus();
                        verificationStatus.IsValid = true;
                        if (SelectedActivity.RemainingDuration > 0)
                        {
                            verificationStatus.IsAccepted = true;
                        }
                        else
                        {
                            activityCapture.IsSyncToOTN = true;
                            TaskbarIcon taskbarIcon = Session.taskbarIcon;
                            taskbarIcon.ShowBalloonTip("Maximum time limit reached",
                                "You have consumed allocated time but you can continue till the activity is finished",
                                taskbarIcon.Icon);
                        }

                        activityCapture.VerificationStatus = verificationStatus;
                        ImageToByteArray(GetScreenCapture.GetScreenImage(currentWindowHandle), out thumbnailImageBytes, out fullImageBytes);
                        if (fullImageBytes != null && thumbnailImageBytes != null)
                        {
                            string thumbnailImageName = Guid.NewGuid().ToString();
                            //push data to RavenDB server instance if nw available
                            var resultAddThumbnail = await MediaElementServiceClient.UploadMediaAsync(
                                new AddMediaFile
                                    {
                                        Id = thumbnailImageName,
                                        MediaFile = thumbnailImageBytes,
                                        ContentType = ImageFormat.Png.ToString()
                                    });
                            if (resultAddThumbnail.IsErrorReturned)
                                //In case nw not available store data in local RavenDB instance
                                OfflineDataBaseRepository.InsertAttachment(new AddMediaFile
                                {
                                    Id = thumbnailImageName,
                                    MediaFile = thumbnailImageBytes,
                                    ContentType = ImageFormat.Png.ToString()
                                });

                            activityCapture.ThumbnailImage = thumbnailImageName;
                            string fullImageName = Guid.NewGuid().ToString();
                            var resultAddFullImage = await MediaElementServiceClient.UploadMediaAsync(
                                new AddMediaFile
                                {
                                    Id = fullImageName,
                                    MediaFile = fullImageBytes,
                                    ContentType = ImageFormat.Png.ToString()
                                });
                            if (resultAddFullImage.IsErrorReturned)
                                OfflineDataBaseRepository.InsertAttachment(new AddMediaFile
                                {
                                    Id = fullImageName,
                                    MediaFile = fullImageBytes,
                                    ContentType = ImageFormat.Png.ToString()
                                });

                            activityCapture.FullImage = fullImageName;
                            activityCapture.TimeBurned = timeBurned;
                            //activityCapture.TimeBurned = new TimeSpan(0, 0, (int)Timer.Interval);
                            activityCapture.KeywordsMatchCount = matchedKeywordIds.Count;                          
                            var result = await ActivityVerificationServiceClient.AddCapturedInformationAsync(activityCapture);
                            if (result.IsErrorReturned)
                                OfflineDataBaseRepository.InsertOrUpdateAsync(activityCapture);

                            SelectedActivity.RemainingDuration = SelectedActivity.RemainingDuration - (float)timeBurned.TotalHours;
                            if (SelectedActivity.RemainingDuration > 0)
                                SelectedActivity.ActivityPercentDone = SelectedActivity.ActivityPercentDone + (float)timeBurned.TotalHours * 100 / SelectedActivity.MaximumDuration;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void MatchKeyword()
        {
            try
              {
                KeywordEndTime = DateTime.Now;
                 DateTime? keywordBeginTime = KeywordBeginTime;
                KeywordBeginTime = null;
                IntPtr currentWindowHandle = CurrentProcess.CurrentActiveApplication();
                ToolsForActivityList = new ObservableCollection<Process>(Process.GetProcesses().Where(x => SelectedActivity.ActivityTools.Select(y => y.ToolName).Contains(x.ProcessName)));
                if (ToolsForActivityList.Select(x => x.MainWindowHandle).Contains(currentWindowHandle))
                {
                    foreach (KeywordDictionary dictionary in KeywordDictionaryList)
                    {
                        if (dictionary.Keywords.Contains(CapturedKeyword))
                        {
                            string keywordId = Guid.NewGuid().ToString();
                            var matchedKeyword = new MatchedKeyword();
                            matchedKeyword.Id = keywordId;
                            matchedKeyword.CapturedData = CapturedKeyword;
                            matchedKeyword.KeywordDictionaryId = dictionary.Id;
                            matchedKeyword.BeginTime = keywordBeginTime.Value;
                            matchedKeyword.EndTime = KeywordEndTime;
                            var response = ActivityVerificationServiceClient.AddOrUpdateMatchedKeyword(matchedKeyword);
                            if (response.IsErrorReturned)
                                OfflineDataBaseRepository.InsertOrUpdateAsync(matchedKeyword);
                            MatchedKeywordIds.Add(keywordId);
                            if (SelectedActivity.ActivityCaptureType == ActivityCaptureType.KeywordMatch)
                            {
                                var timeBurned = TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds);
                                stopWatch.Reset();
                                TakeImage(timeBurned);
                            }
                        }
                    }
                }
                CapturedKeyword = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void ImageToByteArray(Image image, out byte[] thumbnailImageBytes, out byte[] fullImageBytes)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                fullImageBytes = ms.ToArray();
            }

            using (var ms = new MemoryStream())
            {
                image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero).Save(ms, ImageFormat.Png);
                thumbnailImageBytes = ms.ToArray();
            }
        }

        public static CompareResult Compare(Image bmp1, Image bmp2)
        {
            var cr = CompareResult.ciCompareOk;

            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
            }
            else
            {
                //Convert each image to a byte array
                var ic = new ImageConverter();
                var btImage1 = new byte[1];
                btImage1 = (byte[]) ic.ConvertTo(bmp1, btImage1.GetType());
                var btImage2 = new byte[1];
                btImage2 = (byte[]) ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image
                var shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values
                for (int i = 0; i < hash1.Length && i < hash2.Length && cr == CompareResult.ciCompareOk; i++)
                {
                    if (hash1[i] != hash2[i])
                        cr = CompareResult.ciPixelMismatch;
                }
            }
            return cr;
        }

        public async void NotifyMessage(Notification notification)
        {
            try
            {
                float? remainingDuration;
                TaskbarIcon taskbarIcon = Session.taskbarIcon;
                taskbarIcon.ShowBalloonTip("New notification", notification.Message, taskbarIcon.Icon);

                await Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    if (notification.Operation != ActivityOperationEnum.Delete)
                    {
                        var activityUser = ActivityOptimizationSystemServiceClient.GetActivityUserByActivityId(notification.ActivityId);
                        var activity = ActivityOptimizationSystemServiceClient.GetActivityByActivityId(notification.ActivityId);
                        var activityComposition =  ActivityOptimizationSystemServiceClient.GetActivityCompositionByActivityId(notification.ActivityId);
                        ActivityModel activityModel = ActivityList.FirstOrDefault(x => x.ActivityID == notification.ActivityId);
                        if (activityModel == null)
                            activityModel = new ActivityModel();
                        //else
                        //{
                        //    var selectedActivityId = activityModel.ActivityID;
                        //    ActivityList.Remove(activityModel);
                        //    if (activityModel.ActivityID == selectedActivityId)
                        //        SelectedActivityId = selectedActivityId;
                        //}
                        activityModel.ActivityID = activity.Value.Id;
                        activityModel.ActivityName = activity.Value.ActivityName;
                        activityModel.ActivityUserId = activityUser.Value.Id;
                        activityModel.Sequence = activityComposition.Value.Sequence;
                        activityModel.MaximumDuration = activityComposition.Value.MaximumDuration;
                        activityModel.MinimumDuration = activityComposition.Value.MinimumDuration;
                        activityModel.OptimumDuration = activityComposition.Value.OptimumDuration;
                        activityModel.ActivityTools = GetActivityTool(activityComposition.Value.ActivityToolId);
                        activityModel.ActivityToolNames =
                            GetActivityToolNames(activityComposition.Value.ActivityToolId);
                        activityModel.ActivityPercentDone = GetActivityPercentCompleted(activityUser.Value.Id,
                            activityComposition.Value.MaximumDuration,activityComposition.Value.VariationFactor, out remainingDuration);
                        activityModel.KeywordDictionaryIds = activityComposition.Value.KeywordDictionaryIds;
                        activityModel.RemainingDuration = remainingDuration;
                        activityModel.CaptureInterval = activityComposition.Value.CaptureInterval;
                        activityModel.IsActivityViewed = activityUser.Value.IsActivityViewed;
                        activityModel.IaActivityRemovedFromAMS = false;
                        if (ActivityList.FirstOrDefault(x => x.ActivityUserId == SelectedActivityId) == null)
                        {
                            activityModel.BottomPanelcolor = Color.LightGray.Name;
                            activityModel.ActivityCurrentStatus = "Start";
                            activityModel.LearnButtonVisibility = true;
                        }
                        else
                        {
                            activityModel.BottomPanelcolor = Color.Gray.Name;
                            activityModel.ActivityCurrentStatus = "In Progress";
                            activityModel.LearnButtonVisibility = false;
                        }
                        activityModel.ActivityCaptureType = activityComposition.Value.ActivityCaptureType;
                        if (activityModel.ActivityCaptureType == ActivityCaptureType.KeywordMatch)
                            Timer.Enabled = false;
                        else if (!Timer.Enabled)
                        {
                            Timer.Interval = activityComposition.Value.CaptureInterval*1000;
                            Timer.Enabled = true;
                        }

                        if (_allocatedTimeCaptured)
                        {
                            activityModel.BottomPanelcolor = "Red";
                        }

                        if (!ActivityList.Contains(activityModel))
                            ActivityList.Add(activityModel);

                        if (Application.Current.MainWindow.IsVisible)
                            dispatcherTimer.Start();
                    }
                    if (notification.Operation == ActivityOperationEnum.Delete)
                    {
                        ActivityModel activityDeleted = ActivityList.FirstOrDefault(x => x.ActivityID == notification.ActivityId);
                        activityDeleted.IaActivityRemovedFromAMS = true;
                        activityDeleted.IsActivityViewed = false;

                        if (SelectedActivity!=null && notification.ActivityId == SelectedActivity.ActivityID)
                        {
                            SelectedActivityId = null;
                            Timer.Enabled = false;
                            KeyboardHook.Stop();
                            MouseHook.Stop();
                        }
                        Application.Current.MainWindow.Show();
                    }

                    RaisePropertyChanged(() => ActivityList);
                });
            }
            catch (Exception)
            {
            }
        }

        #region Commented code may needs later

        //var info = FilteredCapturedTextCollection.FirstOrDefault(x => x.KeywordDictionaryId == dictionary.Id);
        //if (info != null)
        //    info.CapturedData += CapturedKeyword + " ";
        //else
        //{
        //    MatchedKeyword matchedKeyword = new MatchedKeyword();
        //    matchedKeyword.KeywordDictionaryId = dictionary.Id;
        //    matchedKeyword.CapturedData += CapturedKeyword + " ";
        //    FilteredCapturedTextCollection.Add(matchedKeyword);
        //}

        //var filteredCapturedTextCollection = FilteredCapturedTextCollection.ToList();
        //FilteredCapturedTextCollection.Clear();
        //var result = ActivityVerificationServiceClient.AddOrUpdateFilteredCapturedText(filteredCapturedTextCollection.ToArray());
        //if (!result.IsErrorReturned)
        //    activityCapture.FilteredCapturedTextIds = result.Value;

        #endregion
    }

    public class ActivityModel : BaseViewModel
    {
        public string ActivityID { get; set; }

        private string _activityName { get; set; }

        public string ActivityName
        {
            get { return _activityName; }
            set
            {
                _activityName = value;
                RaisePropertyChanged(() => ActivityName);
            }
        }
        public ActivityCaptureType ActivityCaptureType { get; set; }
        public string ActivityUserId { get; set; }
        public int CaptureInterval { get; set; }
        public Int32 Sequence { get; set; }
        public float MinimumDuration { get; set; }
        public float MaximumDuration { get; set; }
        public float OptimumDuration { get; set; }
        public ActivityTool[] ActivityTools { get; set; }
        private string _activityToolNames { get; set; }

        public string ActivityToolNames
        {
            get { return _activityToolNames; }
            set
            {
                _activityToolNames = value;
                RaisePropertyChanged(() => _activityToolNames);
            }
        }

        public ActivityCapture[] ActivityCapture { get; set; }
        public string AllCaptureTimeId { get; set; }
        public string AllowedTimeId { get; set; }
        public string[] KeywordDictionaryIds { get; set; }
        public float? RemainingDuration { get; set; }
        public bool IaActivityRemovedFromAMS { get; set; }

        private float _activityPercentDone { get; set; }

        public float ActivityPercentDone
        {
            get { return _activityPercentDone; }
            set
            {
                if (_activityPercentDone != value)
                {
                    _activityPercentDone = value;
                    RaisePropertyChanged(() => ActivityPercentDone);
                }
            }
        }

        private string _activityCurrentStatus { get; set; }

        public string ActivityCurrentStatus
        {
            get { return _activityCurrentStatus; }
            set
            {
                if (_activityCurrentStatus != value)
                {
                    _activityCurrentStatus = value;
                    RaisePropertyChanged(() => ActivityCurrentStatus);
                }
            }
        }

        private string _bottomPanelcolor { get; set; }

        public string BottomPanelcolor
        {
            get { return _bottomPanelcolor; }
            set
            {
                if (_bottomPanelcolor != value)
                {
                    _bottomPanelcolor = value;
                    RaisePropertyChanged(() => BottomPanelcolor);
                }
            }
        }

        private bool _learnButtonVisibility { get; set; }

        public bool LearnButtonVisibility
        {
            get { return _learnButtonVisibility; }
            set
            {
                if (_learnButtonVisibility != value)
                {
                    _learnButtonVisibility = value;
                    RaisePropertyChanged(() => LearnButtonVisibility);
                }
            }
        }

        private bool _isActivityViewed { get; set; }

        public bool IsActivityViewed
        {
            get { return _isActivityViewed; }
            set
            {
                if (_isActivityViewed != value)
                {
                    _isActivityViewed = value;
                    RaisePropertyChanged(() => IsActivityViewed);
                }
            }
        }
    }
}