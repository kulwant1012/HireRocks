using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using BytescoutImageToVideo;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Helpers;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using AviFile;
using System.IO;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class ActivityVerificationViewModel : BaseViewModel
    {
        private TimeSpan minSelectionRange;
        private DateTime periodEnd;
        private DateTime periodStart;
        private DateTime selectedEndDate;
        private DateTime selectedStartDate;
        private DateTime visiblePeriodEnd;
        private DateTime visiblePeriodStart;

        public ActivityVerificationViewModel()
        {
            try
            {
                CreateVideoCommand = new RelayCommand(CreateVideoFromCapturedImages);
                RefreshCapturesListCommand = new RelayCommand(RefreshCapturesListCommandExecute);
                ChangeVerificationStatusCommand = new RelayCommand(ChangeVerificationStatusCommandExecute);
                ShowAcceptCheckBoxCommand = new RelayCommand(ShowAcceptCheckBoxCommandExecute);
                ShowValidityCheckBoxCommand = new RelayCommand(ShowValidityCheckBoxCommandExecute);
                UpdateStatusOfCaptureCommand = new RelayCommand<string>(UpdateStatusOfCaptureCommandExecute);
                DeleteActivityCommand = new RelayCommand<string>(DeleteActivityExecute);

                ActivityList = new ObservableCollection<Activity>();
                //ActivityCaptureList = new ObservableCollection<ActivityCaptureModel>();
                ActivityCaptureFilteredList = new ObservableCollection<ActivityCaptureModel>();
                ActivityCaptureList = new List<ActivityCaptureModel>();
                DateTime startDate = DateTime.Now.AddYears(-1);
                DateTime endDate = DateTime.Now;
                AllowedTime = new AllowedTime();
                PeriodStart = startDate;
                PeriodEnd = endDate;

                VisiblePeriodStart = startDate;
                VisiblePeriodEnd = DateTime.Now;
                //SelectedStartDate = DateTime.Now.AddMonths(-1);
                SelectedEndDate = DateTime.Now;
                MinSelectionRange = TimeSpan.FromHours(1);
                GetViewData();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        public RelayCommand CreateVideoCommand { get; set; }
        public RelayCommand RefreshCapturesListCommand { get; set; }
        public RelayCommand ChangeVerificationStatusCommand { get; set; }
        public RelayCommand ShowAcceptCheckBoxCommand { get; set; }
        public RelayCommand ShowValidityCheckBoxCommand { get; set; }
        public RelayCommand<string> DeleteActivityCommand { get; private set; }
        public RelayCommand<string> UpdateStatusOfCaptureCommand { get; set; }

        private List<ActivityCaptureModel> _activityCaptureList { get; set; }

        public List<ActivityCaptureModel> ActivityCaptureList
        {
            get { return _activityCaptureList; }
            set
            {
                _activityCaptureList = value;
                RaisePropertyChanged(() => ActivityCaptureList);
            }
        }

        private ObservableCollection<ActivityCaptureModel> _activityCaptureFilteredList { get; set; }

        public ObservableCollection<ActivityCaptureModel> ActivityCaptureFilteredList
        {
            get { return _activityCaptureFilteredList; }
            set
            {
                _activityCaptureFilteredList = value;
                RaisePropertyChanged(() => ActivityCaptureFilteredList);
            }
        }

        private ObservableCollection<User> _userList { get; set; }

        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                RaisePropertyChanged(() => UserList);
            }
        }

        private ObservableCollection<Activity> _activityList { get; set; }

        public ObservableCollection<Activity> ActivityList
        {
            get { return _activityList; }
            set
            {
                _activityList = value;
                RaisePropertyChanged(() => ActivityList);
            }
        }

        private ObservableCollection<ActivityUser> _activityUserList { get; set; }

        public ObservableCollection<ActivityUser> ActivityUserList
        {
            get { return _activityUserList; }
            set
            {
                _activityUserList = value;
                RaisePropertyChanged(() => ActivityUserList);
            }
        }

        public DateTime PeriodStart
        {
            get { return periodStart; }

            set
            {
                if (periodStart != value)
                {
                    periodStart = value;
                    RaisePropertyChanged("PeriodStart");
                }
            }
        }

        public DateTime PeriodEnd
        {
            get { return periodEnd; }

            set
            {
                if (periodEnd != value)
                {
                    periodEnd = value;
                    RaisePropertyChanged("PeriodEnd");
                }
            }
        }

        public DateTime VisiblePeriodEnd
        {
            get { return visiblePeriodEnd; }

            set
            {
                if (visiblePeriodEnd != value)
                {
                    visiblePeriodEnd = value;
                    RaisePropertyChanged("VisiblePeriodEnd");
                }
            }
        }

        public DateTime VisiblePeriodStart
        {
            get { return visiblePeriodStart; }

            set
            {
                if (visiblePeriodStart != value)
                {
                    visiblePeriodStart = value;
                    RaisePropertyChanged("VisiblePeriodStart");
                }
            }
        }

        public DateTime SelectedStartDate
        {
            get { return selectedStartDate; }

            set
            {
                if (selectedStartDate != value)
                {
                    selectedStartDate = value;
                    FilterActivityCaptureList();
                }
            }
        }

        public DateTime SelectedEndDate
        {
            get { return selectedEndDate; }

            set
            {
                if (selectedEndDate != value)
                {
                    selectedEndDate = value;
                    FilterActivityCaptureList();
                }
            }
        }

        public TimeSpan MinSelectionRange
        {
            get { return minSelectionRange; }

            set
            {
                if (minSelectionRange != value)
                {
                    minSelectionRange = value;
                    RaisePropertyChanged("MinSelectionRange");
                }
            }
        }

        private string _selectedUser { get; set; }

        public string SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                RaisePropertyChanged(() => SelectedUser);
                UserListChange();
                ActivityCaptureFilteredList.Clear();
                ActivityCaptureList.Clear();
            }
        }

        private string _selectedActivity { get; set; }

        public string SelectedActivity
        {
            get { return _selectedActivity; }
            set
            {
                if (_selectedActivity != value)
                {
                    _selectedActivity = value;
                    RaisePropertyChanged(() => SelectedActivity);
                    ActivityListChange();
                }
            }
        }

        private string _selectedActivityCapture { get; set; }

        public string SelectedActivityCapture
        {
            get { return _selectedActivityCapture; }
            set
            {
                if (_selectedActivityCapture != value)
                {
                    _selectedActivityCapture = value;
                    RaisePropertyChanged(() => SelectedActivityCapture);
                }
            }
        }

        private bool viewAllowedCaptures { get; set; }

        public bool ViewAllowedCaptures
        {
            get { return viewAllowedCaptures; }
            set
            {
                if (viewAllowedCaptures != value)
                {
                    viewAllowedCaptures = value;
                    RaisePropertyChanged(() => ViewAllowedCaptures);
                    if (value)
                    {
                        GetAllowedCaptures();
                    }
                    else
                    {
                        FilterActivityCaptureList();
                    }
                }
            }
        }

        private bool viewFilteredText { get; set; }

        public bool ViewFilteredText
        {
            get { return viewFilteredText; }
            set
            {
                if (viewFilteredText != value)
                {
                    viewFilteredText = value;
                    RaisePropertyChanged(() => ViewFilteredText);
                    //ViewAllowedCaptures = false;

                    if (value)
                    {
                        GetAllFilteredText();
                    }
                    else
                    {
                        FilterActivityCaptureList();
                    }
                }
            }
        }

        private bool compressRepeatKeywords { get; set; }

        public bool CompressRepeatKeywords
        {
            get { return compressRepeatKeywords; }
            set
            {
                if (compressRepeatKeywords != value)
                {
                    compressRepeatKeywords = value;
                    RaisePropertyChanged(() => CompressRepeatKeywords);
                    if (value)
                        GetCompressedRepeatKeywords();
                    else
                        CompressedFilteredText = string.Empty;
                }
            }
        }

        private string _allKeyboardText { get; set; }

        public string AllKeyboardText
        {
            get { return _allKeyboardText; }
            set
            {
                if (_allKeyboardText != value)
                {
                    _allKeyboardText = value;
                    RaisePropertyChanged(() => AllKeyboardText);
                }
            }
        }

        private string _allFilteredText { get; set; }

        public string AllFilteredText
        {
            get { return _allFilteredText; }
            set
            {
                if (_allFilteredText != value)
                {
                    _allFilteredText = value;
                    RaisePropertyChanged(() => AllFilteredText);
                }
            }
        }

        private string _compressedFilteredText { get; set; }

        public string CompressedFilteredText
        {
            get { return _compressedFilteredText; }
            set
            {
                if (_compressedFilteredText != value)
                {
                    _compressedFilteredText = value;
                    RaisePropertyChanged(() => CompressedFilteredText);
                }
            }
        }

        private string _totalTimeConsumed { get; set; }

        public string TotalTimeConsumed
        {
            get { return _totalTimeConsumed; }
            set
            {
                if (_totalTimeConsumed != value)
                {
                    _totalTimeConsumed = value;
                    RaisePropertyChanged(() => TotalTimeConsumed);
                }
            }
        }

        private int _totalKeywordsCreated { get; set; }

        public int TotalKeywordsCreated
        {
            get { return _totalKeywordsCreated; }
            set
            {
                if (_totalKeywordsCreated != value)
                {
                    _totalKeywordsCreated = value;
                    RaisePropertyChanged(() => TotalKeywordsCreated);
                }
            }
        }

        private TimeSpan _totalCreationTimeConsumed { get; set; }

        public TimeSpan TotalCreationTimeConsumed
        {
            get { return _totalCreationTimeConsumed; }
            set
            {
                if (_totalCreationTimeConsumed != value)
                {
                    _totalCreationTimeConsumed = value;
                    RaisePropertyChanged(() => TotalCreationTimeConsumed);
                }
            }
        }

        private bool _isChangingValidity { get; set; }

        public bool IsChangingValidity
        {
            get { return _isChangingValidity; }
            set
            {
                if (_isChangingValidity != value)
                {
                    _isChangingValidity = value;
                    RaisePropertyChanged(() => IsChangingValidity);
                }
            }
        }

        private bool _isChangingAcceptance { get; set; }

        public bool IsChangingAcceptance
        {
            get { return _isChangingAcceptance; }
            set
            {
                if (_isChangingAcceptance != value)
                {
                    _isChangingAcceptance = value;
                    RaisePropertyChanged(() => IsChangingAcceptance);
                }
            }
        }

        private bool _isUpdateButtonVisible { get; set; }

        public bool IsUpdateButtonVisible
        {
            get { return _isUpdateButtonVisible; }
            set
            {
                if (_isUpdateButtonVisible != value)
                {
                    _isUpdateButtonVisible = value;
                    RaisePropertyChanged(() => IsUpdateButtonVisible);
                }
            }
        }

        public AllowedTime AllowedTime { get; set; }

        public bool IsRoleManager
        {
            get { return ApplicationSession.User.Roles.Contains(UserRole.Manager); }
        }

        private void DeleteActivityExecute(string id)
        {
            ActivityCaptureModel filteredActivity = ActivityCaptureFilteredList.SingleOrDefault(i => i.Id == id);
            if (filteredActivity != null)
            {
                ActivityCaptureFilteredList.Remove(filteredActivity);
            }

            ActivityCaptureModel activity = ActivityCaptureList.SingleOrDefault(i => i.Id == id);
            if (activity != null)
            {
                ActivityCaptureList.Remove(activity);
            }
            ActivityVerificationServiceClient.DeleteCapturedInformation(id);
        }

        private async void GetViewData()
        {
            IsBusy = true;
            if (IsRoleManager)
            {
                var userList =
                    await ActivityOptimizationSystemServiceClient.GetUserAsync();
                if (!userList.IsErrorReturned)
                    UserList = new ObservableCollection<User>(userList.Value);
            }
            else
            {
                UserList = new ObservableCollection<User>();
                UserList.Add(ApplicationSession.User);
            }

            IsBusy = false;
        }

        private async void UserListChange()
        {
            try
            {
                IsBusy = true;
                var activityUsers =
                    await ActivityOptimizationSystemServiceClient.GetUserActivitiesByUserIdAsync(SelectedUser);
                if (!activityUsers.IsErrorReturned)
                {
                    ActivityUserList = new ObservableCollection<ActivityUser>(activityUsers.Value);
                    IEnumerable<string> actvityIds = activityUsers.Value.Select(x => x.ActivityId);
                    var activities =
                        await ActivityOptimizationSystemServiceClient.GetActivitiesByIdAsync(actvityIds.ToArray());
                    if (!activities.IsErrorReturned)
                        ActivityList = new ObservableCollection<Activity>(activities.Value);

                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        private async void ActivityListChange()
        {
            try
            {
                IsBusy = true;
                ActivityCaptureList.Clear();
                ActivityCaptureFilteredList.Clear();
                IEnumerable<ActivityUser> user =
                    ActivityUserList.Where(x => x.ActivityId == SelectedActivity && x.UserId == SelectedUser);
                if (user.Count() > 0 && user != null)
                {
                    var activityCaptures =
                        await
                            ActivityVerificationServiceClient.GetActivityCapturesAsync(VisiblePeriodStart,
                                visiblePeriodEnd,
                                ActivityUserList.Where(x => x.ActivityId == SelectedActivity && x.UserId == SelectedUser)
                                    .FirstOrDefault()
                                    .Id);
                    if (!activityCaptures.IsErrorReturned)
                    {
                        string storagePath = ConfigurationManager.AppSettings.Get("Storage");
                        List<ActivityCaptureModel> activityCaptureList = (from activity in activityCaptures.Value
                            select new ActivityCaptureModel
                            {
                                Id = activity.Id,
                                ActivityUserID = activity.ActivityUserID,
                                ThumbnailImage = activity.ThumbnailImage,
                                FullImage = activity.FullImage,
                                Keyboard = activity.Keyboard,
                                Mouse = activity.Mouse,
                                CaptureDateTime = activity.CaptureDateTime,
                                ActivityDetails = activity.ActivityDetails,
                                KeywordsMatchCount = activity.KeywordsMatchCount,
                                FilteredCapturedTextIds = activity.MatchedKeywordIds,
                                TimeBurned = activity.TimeBurned,
                                MatchedKeywordList =
                                    activity.MatchedKeywordIds.Count() > 0
                                        ? new ObservableCollection<MatchedKeyword>(
                                            GetFilteredCapturedText(activity.MatchedKeywordIds))
                                        : new ObservableCollection<MatchedKeyword>(),
                                VerificationStatus = activity.VerificationStatus,
                                IsSyncToOTN = activity.IsSyncToOTN,
                                MatchedKeywordIds = activity.MatchedKeywordIds,
                                CaptureColor =
                                    !activity.VerificationStatus.IsAccepted
                                        ? !activity.VerificationStatus.IsValid ? "#808080" : "#FF0000"
                                        : !activity.VerificationStatus.IsValid ? "#808080" : "#25A0DA",
                            }).AsParallel().ToList();

                        var activityComposition =
                            await
                                ActivityOptimizationSystemServiceClient.GetActivityCompositionsByActivityIdsAsync(
                                    new[] {SelectedActivity});
                        if (!activityComposition.IsErrorReturned)
                        {
                            var allowedTime =
                                await
                                    ActivityOptimizationSystemServiceClient.GetAllowedTimeCollectionByIdAsync(
                                        activityComposition.Value.FirstOrDefault().AllowedTimeId);
                            if (!allowedTime.IsErrorReturned)
                                AllowedTime = allowedTime.Value;
                        }

                        activityCaptureList = activityCaptureList.Take(15).ToList();

                        activityCaptureList.ForEach(
                            activityCapture => ActivityCaptureList.Add(new ActivityCaptureModel(activityCapture)));
                        FilterActivityCaptureList();
                    }
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        private void FilterActivityCaptureList()
        {
            try
            {
                ActivityCaptureFilteredList.Clear();
                ActivityCaptureList.ForEach(item => { ActivityCaptureFilteredList.Add(new ActivityCaptureModel(item)); });
            }

            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private List<MatchedKeyword> GetFilteredCapturedText(string[] capturesId)
        {
            var keywordList = new List<MatchedKeyword>();
            RemoteCaller.CallSync(() => ActivityVerificationServiceClient.GetMatchedKeywordByIdsAsync(capturesId),
                (response, exception) =>
                {
                    if (!response.IsFaulted)
                        keywordList = response.Result.Value.ToList();
                });
            return keywordList;
        }

        private void GetAllowedCaptures()
        {
            try
            {
                ActivityCaptureFilteredList =
                    new ObservableCollection<ActivityCaptureModel>(
                        ActivityCaptureFilteredList.Where(
                            x =>
                                x.CaptureDateTime.TimeOfDay >= Convert.ToDateTime(AllowedTime.TimeFrom).TimeOfDay &&
                                x.CaptureDateTime.TimeOfDay <= Convert.ToDateTime(AllowedTime.TimeTo).TimeOfDay));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void GetAllFilteredText()
        {
            try
            {
                CreateReport();
                AllFilteredText = string.Empty;
                AllKeyboardText = string.Empty;
                if (ActivityCaptureFilteredList.Count > 0 && ActivityCaptureFilteredList != null)
                {
                    AllKeyboardText = ActivityCaptureFilteredList.Select(x => x.Keyboard).Aggregate((i, j) => i + j);
                    foreach (ActivityCaptureModel item in ActivityCaptureFilteredList)
                    {
                        foreach (MatchedKeyword filteredCaptureList in item.MatchedKeywordList)
                        {
                            AllFilteredText += filteredCaptureList.CapturedData + " ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void GetCompressedRepeatKeywords()
        {
            try
            {
                CompressedFilteredText = string.Empty;
                if (!string.IsNullOrEmpty(AllFilteredText))
                {
                    IOrderedEnumerable<IGrouping<string, string>> result =
                        Regex.Split(AllFilteredText, @"\W+")
                            .GroupBy(s => s)
                            .Where(x => x.Key != string.Empty)
                            .OrderByDescending(g => g.Count());
                    foreach (var item in result)
                    {
                        CompressedFilteredText += item.Key + " (" + item.Count() + ")\r";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void CreateReport()
        {
            try
            {
                TotalCreationTimeConsumed = TimeSpan.Zero;
                TotalKeywordsCreated = 0;
                //TotalTimeConsumed = TimeSpan.FromMinutes(ActivityCaptureFilteredList.Select(x => x.TimeBurned).Aggregate((i, j) => i + j)).TotalHours.ToString();
                if (ActivityCaptureFilteredList != null && ActivityCaptureFilteredList.Count > 0)
                    TotalKeywordsCreated =
                        ActivityCaptureFilteredList.Select(x => x.KeywordsMatchCount).Aggregate((i, j) => i + j);
                foreach (ActivityCaptureModel activityCapture in ActivityCaptureFilteredList)
                {
                    foreach (MatchedKeyword keywordMatched in activityCapture.MatchedKeywordList)
                    {
                        TotalCreationTimeConsumed += keywordMatched.EndTime - keywordMatched.BeginTime;
                        //TotalCreationTimeConsumed +=TimeSpan.FromSeconds(Convert.ToDouble(keywordMatched.EndTime - keywordMatched.BeginTime));
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private async void CreateVideoFromCapturedImages()
        {
            await System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                try
                {
                    IsBusy = true;
                    var saveFileDialog = new SaveFileDialog();

                    bool? result = saveFileDialog.ShowDialog();
                    if (result == true)
                    {
                        //AviManager aviManager = new AviManager(saveFileDialog.FileName + ".avi", false);
                        //VideoStream aviStream = null;

                        //var webClient = new WebClient();
                        //webClient.BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];
                        //webClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                        //foreach (ActivityCaptureModel item in ActivityCaptureFilteredList)
                        //{
                        //    using (var memoryStream = new MemoryStream(webClient.DownloadData(ConfigurationManager.AppSettings["Storage"] + item.FullImage)))
                        //    {
                        //        if (aviStream == null)
                        //            aviStream = aviManager.AddVideoStream(false, .3, (Bitmap)Image.FromStream(memoryStream));
                        //        else
                        //            aviStream.AddFrame((Bitmap)Image.FromStream(memoryStream));
                        //    }
                        //}
                        //aviManager.Close();
                        var converter = new ImageToVideo();
                        converter.RegistrationName = "demo";
                        converter.RegistrationKey = "demo";
                        Slide slide;
                        var webClient = new WebClient();
                        webClient.BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];
                        webClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                        foreach (ActivityCaptureModel item in ActivityCaptureFilteredList)
                        {
                            slide = converter.AddImageFromBuffer(webClient.DownloadData(ConfigurationManager.AppSettings["Storage"] + item.FullImage));
                            slide.Duration = 3000;
                            //slide.AutoFit = true;
                        }
                        converter.OutputVideoFileName = saveFileDialog.FileName + ".wmv";
                        converter.RunAndWait();
                        IsBusy = false;
                    }
                }
                catch (Exception ex)
                {
                    IsBusy = false;
                    Message = ex.Message;
                    MessageBox.Show(Message);
                }
            });
        }

        private void RefreshCapturesListCommandExecute()
        {
            SelectedEndDate = DateTime.Now;
            VisiblePeriodEnd = DateTime.Now;
            ActivityListChange();
        }

        private void ShowAcceptCheckBoxCommandExecute()
        {
            if (ActivityCaptureFilteredList.FirstOrDefault(x => x.IsModified) != null)
                FilterActivityCaptureList();
            if (IsChangingAcceptance)
                IsChangingAcceptance = false;
            else
                IsChangingAcceptance = true;

            IsUpdateButtonVisible = IsChangingAcceptance;
            IsChangingValidity = false;
        }

        private void ShowValidityCheckBoxCommandExecute()
        {
            if (ActivityCaptureFilteredList.FirstOrDefault(x => x.IsModified) != null)
                FilterActivityCaptureList();
            if (IsChangingValidity)
                IsChangingValidity = false;
            else
                IsChangingValidity = true;

            IsUpdateButtonVisible = IsChangingValidity;
            IsChangingAcceptance = false;
        }

        private async void ChangeVerificationStatusCommandExecute()
        {
            try
            {
                IsBusy = true;
                IEnumerable<ActivityCaptureModel> updatedCaptures = ActivityCaptureFilteredList.Where(x => x.IsModified);
                foreach (ActivityCaptureModel activityCapture in updatedCaptures.ToList())
                {
                    var verificationStatus = new VerificationStatus();
                    verificationStatus.IsAccepted = activityCapture.VerificationStatus.IsAccepted;
                    verificationStatus.VerifierId = ApplicationSession.User.Id;
                    verificationStatus.VerifierComments = string.Empty;
                    verificationStatus.DateTime = DateTime.Now;
                    verificationStatus.IsValid = activityCapture.VerificationStatus.IsValid;
                    verificationStatus.IsOverdue = activityCapture.VerificationStatus.IsOverdue;
                    OperationResult result =
                        await
                            ActivityVerificationServiceClient.UpdateVerificationStatusAsync(activityCapture.Id,
                                verificationStatus, IsChangingAcceptance);
                    if (!result.IsErrorReturned)
                    {
                        ActivityCaptureModel info = ActivityCaptureList.FirstOrDefault(x => x.Id == activityCapture.Id);
                        info.VerificationStatus = verificationStatus;
                        info.CaptureColor = !verificationStatus.IsAccepted
                            ? !verificationStatus.IsValid ? "#808080" : "#FF0000"
                            : !verificationStatus.IsValid ? "#808080" : "#25A0DA";
                    }
                }
                IsChangingAcceptance = false;
                IsChangingValidity = false;
                IsUpdateButtonVisible = false;
                FilterActivityCaptureList();
                IsBusy = false;
            }

            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private void UpdateStatusOfCaptureCommandExecute(string captureId)
        {
            ActivityCaptureFilteredList.FirstOrDefault(x => x.Id == captureId).IsModified = true;
        }
    }

    public class ActivityCaptureModel : BaseViewModel
    {
        public ActivityCaptureModel()
        {
        }

        public ActivityCaptureModel(ActivityCaptureModel activityCaptureModel)
        {
            Id = activityCaptureModel.Id;
            ActivityUserID = activityCaptureModel.ActivityUserID;
            ThumbnailImage = activityCaptureModel.ThumbnailImage;
            FullImage = activityCaptureModel.FullImage;
            Keyboard = activityCaptureModel.Keyboard;
            Mouse = activityCaptureModel.Mouse;
            CaptureDateTime = activityCaptureModel.CaptureDateTime;
            ActivityDetails = activityCaptureModel.ActivityDetails;
            KeywordsMatchCount = activityCaptureModel.KeywordsMatchCount;
            FilteredCapturedTextIds = activityCaptureModel.FilteredCapturedTextIds;
            TimeBurned = activityCaptureModel.TimeBurned;
            MatchedKeywordList = activityCaptureModel.MatchedKeywordList;
            VerificationStatus = new VerificationStatus
            {
                DateTime = activityCaptureModel.VerificationStatus.DateTime,
                IsValid = activityCaptureModel.VerificationStatus.IsValid,
                IsAccepted = activityCaptureModel.VerificationStatus.IsAccepted,
                IsOverdue = activityCaptureModel.VerificationStatus.IsOverdue,
                VerifierComments = activityCaptureModel.VerificationStatus.VerifierComments,
                VerifierId = activityCaptureModel.VerificationStatus.VerifierId
            };
            IsSyncToOTN = activityCaptureModel.IsSyncToOTN;
            IsModified = activityCaptureModel.IsModified;
            MatchedKeywordIds = activityCaptureModel.MatchedKeywordIds;
            CaptureColor = activityCaptureModel.CaptureColor;
            ImageBytes = activityCaptureModel.ImageBytes;
        }

        public string Id { get; set; }
        public string ActivityUserID { get; set; }
        public string ThumbnailImage { get; set; }
        public string FullImage { get; set; }
        public string Keyboard { get; set; }
        public string Mouse { get; set; }
        public DateTime CaptureDateTime { get; set; }
        public string ActivityDetails { get; set; }
        public int KeywordsMatchCount { get; set; }
        public string[] FilteredCapturedTextIds { get; set; }
        public TimeSpan TimeBurned { get; set; }
        public ObservableCollection<MatchedKeyword> MatchedKeywordList { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public bool IsSyncToOTN { get; set; }
        public string[] MatchedKeywordIds { get; set; }
        public string CaptureColor { get; set; }
        public bool IsModified { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}