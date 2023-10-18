using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using PS.ActivityManagementStudio.Azure;
using PS.ActivityManagementStudio.CommonModel;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Logging;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Win32;
using System.Diagnostics;
using Task = System.Threading.Tasks.Task;
using Attachment = PS.ActivityManagementStudio.PSServiceReference.Attachment;
using Notification = PS.Data.Notification;
using ActivityOperationEnum = PS.Data.ActivityOperationEnum;
using System.Collections.Specialized;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class ActivityViewModel : BaseViewModel
    {
        private ObservableCollection<ActivityStatus> _activityStatusList;
        private ObservableCollection<ActivityTools> _activityToolList;
        private ObservableCollection<KeywordDictionaries> _dictionaryList;
        private ObservableCollection<ActivityPriority> _priorityList;
        private ObservableCollection<AOSQSpace> _qSpaceList;
        private ObservableCollection<User> _userList;
        private float actualDuration;
        private float additionalTime;
        private float percentCompleted;
        private float remainingDuration;

        public ActivityViewModel()
        {
            try
            {
                IsBusy = true;
                //NotificationHandler notificationHandler = new NotificationHandler();
                //InstanceContext = new InstanceContext(notificationHandler);
                //NotificationServiceClient = new NotificationService.NotificationServiceClient(InstanceContext);
                //NotificationServiceClient.Subscribe(ApplicationSession.User.Login);
                //UplaodCommand = new RelayCommand(UploadExecute);
                RemoveAttachmentCommand = new RelayCommand<string>(RemoveAttachment);
                
                OpenAddActivityWindow = new RelayCommand(OpenAddActivityScreenExecute);
                AddActivityCommand = new RelayCommand(AddUpdateActivityExecute);
                OpenEditActivityWindow = new RelayCommand<ActivityModel>(OpenEditActivityScreenExecute);
                DeleteActivityCommand = new RelayCommand<ActivityModel>(DeleteActivityCommandExecute);

                ActivityList = new ObservableCollection<ActivityModel>();
                //TimeCollectionAllowed = new TimeCollectionClass();
                //TimeCollectionAll = new TimeCollectionClass();
                GetViewData();
            }

            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
            IsBusy = false;
        }

        public RelayCommand OpenAddActivityWindow { get; set; }
        public RelayCommand AddActivityCommand { get; private set; }
        public RelayCommand<ActivityModel> OpenEditActivityWindow { get; set; }
        public RelayCommand<ActivityModel> DeleteActivityCommand { get; private set; }

        private ObservableCollection<ActivityModel> _activityList { get; set; }

        public ObservableCollection<ActivityModel> ActivityList
        {
            get { return _activityList; }
            set
            {
                if (_activityList != value)
                {
                    _activityList = value;
                    RaisePropertyChanged(() => ActivityList);
                }
            }
        }

        private ActivityModel _activityModel { get; set; }

        public ActivityModel ActivityModel
        {
            get { return _activityModel; }
            set
            {
                if (_activityModel != value)
                {
                    _activityModel = value;
                    RaisePropertyChanged(() => ActivityModel);
                }
            }
        }

        public ObservableCollection<AOSQSpace> QSpaceList
        {
            get { return _qSpaceList; }
            set
            {
                if (_qSpaceList != value)
                {
                    _qSpaceList = value;
                    RaisePropertyChanged(() => QSpaceList);
                }
            }
        }

        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set
            {
                if (_userList != value)
                {
                    _userList = value;
                    RaisePropertyChanged(() => UserList);
                }
            }
        }

        public ObservableCollection<KeywordDictionaries> DictionaryList
        {
            get { return _dictionaryList; }
            set
            {
                if (_dictionaryList != value)
                {
                    _dictionaryList = value;
                    RaisePropertyChanged(() => DictionaryList);
                }
            }
        }

        public ObservableCollection<ActivityStatus> ActivityStatusList
        {
            get { return _activityStatusList; }
            set
            {
                if (_activityStatusList != value)
                {
                    _activityStatusList = value;
                    RaisePropertyChanged(() => ActivityStatusList);
                }
            }
        }

        public ObservableCollection<ActivityTools> ActivityToolList
        {
            get { return _activityToolList; }
            set
            {
                if (_activityToolList != value)
                {
                    _activityToolList = value;
                    RaisePropertyChanged(() => ActivityToolList);
                }
            }
        }

        private TimeCollectionClass _timeCollectionAllowed { get; set; }

        public TimeCollectionClass TimeCollectionAllowed
        {
            get { return _timeCollectionAllowed; }
            set
            {
                if (_timeCollectionAllowed != value)
                {
                    _timeCollectionAllowed = value;
                    RaisePropertyChanged(() => TimeCollectionAllowed);
                }
            }
        }

        private TimeCollectionClass _timeCollectionAll { get; set; }

        public TimeCollectionClass TimeCollectionAll
        {
            get { return _timeCollectionAll; }
            set
            {
                if (_timeCollectionAll != value)
                {
                    _timeCollectionAll = value;
                    RaisePropertyChanged(() => TimeCollectionAll);
                }
            }
        }

        public ObservableCollection<ActivityPriority> PriorityList
        {
            get { return _priorityList; }
            set
            {
                if (_priorityList != value)
                {
                    _priorityList = value;
                    RaisePropertyChanged(() => PriorityList);
                }
            }
        }

        private string _windowTitle { get; set; }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    RaisePropertyChanged(() => WindowTitle);
                }
            }
        }

        private string _buttonText { get; set; }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                if (_buttonText != value)
                {
                    _buttonText = value;
                    RaisePropertyChanged(() => ButtonText);
                }
            }
        }

        public string OldAssignedToId { get; set; }

        private bool _isAddNewActivity { get; set; }

        public bool IsAddNewActivity
        {
            get { return _isAddNewActivity; }
            set
            {
                if (_isAddNewActivity != value)
                {
                    _isAddNewActivity = value;
                    RaisePropertyChanged(() => IsAddNewActivity);
                }
            }
        }

        ObservableCollection<string> _activityCaptureTypeList { get; set; }
        public ObservableCollection<string> ActivityCaptureTypeList
        {
            get { return _activityCaptureTypeList; }
            set
            {
                if (_activityCaptureTypeList != value)
                {
                    _activityCaptureTypeList = value;
                    RaisePropertyChanged(() => ActivityCaptureTypeList);
                }
            }
        }

        bool _isModificationButtonsVisible { get; set; }
        public bool IsModificationButtonVisibe
        {
            get { return _isModificationButtonsVisible; }
            set { _isModificationButtonsVisible = value; RaisePropertyChanged(() => IsModificationButtonVisibe); }
        }

        #region Attachments functionality / Oleg

        //public readonly BlobClient AttachmentsBlobClient = new BlobClient(AzureInitializer.AttachmentsBlobContainer,
        //    "base", new DebugLogger());

        private readonly ObservableCollection<string> _attachments = new ObservableCollection<string>();

        public ObservableCollection<string> Attachments
        {
            get { return _attachments; }
        }

        public RelayCommand UplaodCommand { get; private set; }
        public RelayCommand<string> RemoveAttachmentCommand { get; private set; }

        //private async void UploadExecute()
        //{
        //    //string attachmentLink = await UploadImage();
        //    if (!string.IsNullOrEmpty(attachmentLink))
        //        Attachments.Add(attachmentLink);
        //}

        private async void RemoveAttachment(string attachment)
        {
            string link = Attachments.FirstOrDefault(i => i == attachment);
            Attachments.Remove(link);
            //await AttachmentsBlobClient.DeleteAsync(attachment);
        }

        //private async Task<string> UploadImage()
        //{
        //    var fileDialog = new OpenFileDialog();
        //    if (!fileDialog.ShowDialog().GetValueOrDefault(false)) return null;

        //    //return await AttachmentsBlobClient.WriteFileAsync(fileDialog.FileName, FileMode.OpenOrCreate);
        //}

        #endregion

        private void OpenAddActivityScreenExecute()
        {
            try
            {
                OldAssignedToId = string.Empty;
                IsAddUpdateView = true;
                IsAddNewActivity = true;
                WindowTitle = "Add Activity";
                Message = string.Empty;
                ButtonText = "Add Activity";
                ActivityModel = new ActivityModel();
                ActivityModel.CompletionDate = DateTime.Now;
                ActivityModel.DueDate = DateTime.Now;
                ActivityModel.StartDate = DateTime.Now;
                DictionaryList.ToList().ForEach(x => { x.IsChecked = false; });
                ActivityToolList.ToList().ForEach(x => { x.IsChecked = false; });
                Messenger.Default.Send(new AddUpdateActivityWindowMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private void OpenEditActivityScreenExecute(ActivityModel activityModel)
        {
            try
            {
                OldAssignedToId = activityModel.AssignedToId;
                IsAddUpdateView = true;
                IsAddNewActivity = false;
                if (activityModel.KeywordDictionariesList != null)
                    DictionaryList.Where(x => activityModel.KeywordDictionariesList.Exists(y => y.Id == x.Id))
                        .ToList()
                        .ForEach(x => x.IsChecked = true);
                if (activityModel.ActivityToolsList != null)
                    ActivityToolList.Where(x => activityModel.ActivityToolsList.Exists(y => y.ToolId == x.ToolId))
                        .ToList()
                        .ForEach(x => x.IsChecked = true);
                WindowTitle = "Edit Activity";
                Message = string.Empty;
                ButtonText = "Update Activity";
                ActivityModel = activityModel;
                Attachments.Clear();
                foreach (string attachment in activityModel.Attachments)
                {
                    Attachments.Add(attachment);
                }
                Messenger.Default.Send(new AddUpdateActivityWindowMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void AddUpdateActivityExecute()
        {
            try
            {
                if (ActivityModel.ValidateObject())
                {
                    if (ActivityToolList.Where(x => x.IsChecked).Count() == 0)
                    {
                        Message = "Select activity tool";
                        return;
                    }

                    if (DictionaryList.Where(x => x.IsChecked).Count() == 0)
                    {
                        Message = "Select keyword dictionary";
                        return;
                    }
                    IsBusy = true;

                    if (DictionaryList.Count > 0)
                        ActivityModel.KeywordDictionariesList = DictionaryList.Where(x => x.IsChecked).ToList();
                    if (ActivityToolList.Count > 0)
                        ActivityModel.ActivityToolsList = ActivityToolList.Where(x => x.IsChecked).ToList();

                    AOSQSpace selectedQSpace = QSpaceList.FirstOrDefault(x => x.Id == ActivityModel.Project);
                    User assignedTo = UserList.FirstOrDefault(x => x.Id == ActivityModel.AssignedToId);
                    User reportedBy = UserList.FirstOrDefault(x => x.Id == ActivityModel.ReportedById);

                    var activity = new Activity();
                    activity.Id = ActivityModel.Id;
                    activity.ActivityName = ActivityModel.Name;
                    activity.ActivityStatusId = ActivityModel.ActivityStatusId;
                    activity.QSpaceID = selectedQSpace.Id;
                    activity.Attachments = Attachments.Select(i => new Attachment
                    {
                        Url = i,
                        Name = Path.GetFileName(i)
                    }).ToArray();
                    activity.IsDeleted = false;
                    var addActivityResult =
                        await ActivityOptimizationSystemServiceClient.AddOrUpdateActivityAsync(activity);

                    if (!addActivityResult.IsErrorReturned)
                    {
                        var activityComposition = new ActivityComposition();
                        activityComposition.Id = ActivityModel.ActivityCompositionId;
                        activityComposition.ActivityID = addActivityResult.Value.Id;
                        activityComposition.ActivityToolId =
                            ActivityModel.ActivityToolsList.Select(x => x.ToolId).ToArray();
                        activityComposition.ExternalActivityID = string.Empty;
                        activityComposition.KeywordDictionaryIds =
                            ActivityModel.KeywordDictionariesList.Select(x => x.Id).ToArray();
                        activityComposition.MaximumDuration = ActivityModel.EstimatedDuration.Value;
                        //activityComposition.MinimumDuration = ActivityModel.MinimumDuration.Value;
                        //activityComposition.OptimumDuration = ActivityModel.OptimumDuration.Value;
                        activityComposition.Sequence = ActivityModel.Sequence.Value;
                        activityComposition.CaptureInterval = ActivityModel.CaptureInterval.Value;
                        activityComposition.StartDate = ActivityModel.StartDate.Value;
                        activityComposition.DueDate = ActivityModel.DueDate.Value;
                        if (ActivityModel.ActualDuration.HasValue)
                            activityComposition.ActualDuration = ActivityModel.ActualDuration.Value;
                        activityComposition.CreatedById = ActivityModel.ReportedById;
                        activityComposition.PriorityId = ActivityModel.Priority;
                        activityComposition.Description = ActivityModel.Description;
                        activityComposition.ExpectedOutput = ActivityModel.ExpectedOutput;
                        activityComposition.ActualOutput = ActivityModel.ActualOutput;
                        activityComposition.VariationFactor = ActivityModel.VariationFactor;
                        activityComposition.CompletionDate = ActivityModel.CompletionDate.Value;
                        activityComposition.ActivityTypeId = ActivityModel.ActivityTypeId;
                        activityComposition.ActivityCaptureType = Enum.GetValues(typeof(ActivityCaptureType)).Cast<ActivityCaptureType>().FirstOrDefault(x=>x.ToString()==ActivityModel.ActivityCaptureType);
                        var addActivityCompositionResult =
                            await
                                ActivityOptimizationSystemServiceClient.AddOrUpdateActivityCompositionAsync(
                                    activityComposition);

                        if (!addActivityCompositionResult.IsErrorReturned)
                        {
                            bool isAssignedToChanged = false;
                            var activityUser = new ActivityUser();

                            if (!string.IsNullOrEmpty(ActivityModel.ActivityUserId) && OldAssignedToId != ActivityModel.AssignedToId)
                            {
                                isAssignedToChanged = true;
                                OldAssignedToId = ActivityModel.AssignedToId;
                            }
                            activityUser.Id = ActivityModel.ActivityUserId;
                            activityUser.ActivityId = addActivityResult.Value.Id;
                            activityUser.UserId = assignedTo.Id;
                            activityUser.IsActivityViewed = false;
                            var addActivityUserResult = await ActivityOptimizationSystemServiceClient.AddOrUpdateActivityUserAsync(activityUser, isAssignedToChanged);

                            if (!addActivityUserResult.IsErrorReturned)
                            {
                                string message = string.Empty;
                                string subject = string.Empty;
                                string to = assignedTo.Email;
                                string from = reportedBy.Email;
                                ActivityModel.ActivityToolsList = ActivityToolList.Where(x => x.IsChecked).ToList();
                                ActivityModel.KeywordDictionariesList = DictionaryList.Where(x => x.IsChecked).ToList();
                                ActivityModel.RemainingDuration = ActivityModel.EstimatedDuration - ActivityModel.ActualDuration;
                                if (isAssignedToChanged)
                                {
                                    await _notificationHub.Invoke<Notification>("SendNotification",
                                        new Notification
                                        {
                                            ActivityId = ActivityModel.Id,
                                            UserId = UserList.FirstOrDefault(x => x.Id == OldAssignedToId).Id,
                                            Message = "Activity " + ActivityModel.Name + " removed from AMS",
                                            Operation = ActivityOperationEnum.Delete
                                        });
                                }

                                if (IsAddNewActivity)
                                {
                                    ActivityModel.Id = addActivityResult.Value.Id;
                                    ActivityModel.ActivityCompositionId = addActivityCompositionResult.Value.Id;
                                    ActivityModel.ActivityUserId = addActivityUserResult.Value.Id;
                                    ActivityModel.ActivityStatusName =
                                        ActivityStatusList.FirstOrDefault(x => x.Id == activity.ActivityStatusId)
                                            .StatusName;
                                    ActivityModel.AssignedTo =
                                        UserList.FirstOrDefault(x => x.Id == ActivityModel.AssignedToId).FirstName;
                                    ActivityModel.ReportedBy =
                                        UserList.FirstOrDefault(x => x.Id == ActivityModel.ReportedById).FirstName;
                                    if (!string.IsNullOrEmpty(ActivityModel.Priority))
                                        ActivityModel.AssignedPriority =
                                            PriorityList.FirstOrDefault(x => x.Id == ActivityModel.Priority)
                                                .PriorityName;
                                    ActivityModel.QSpaceName =
                                        QSpaceList.FirstOrDefault(x => x.Id == ActivityModel.Project).QSpaceName;
                                    RaisePropertyChanged(() => ActivityModel);
                                    ActivityList.Add(ActivityModel);

                                    //Send Email notification to user
                                    subject = "New Activity assigned to you";
                                    await
                                        SendEmailNotification(to, from, subject,
                                            "Activity '" + ActivityModel.Name + "' assigned to you on AMS");
                                    await _notificationHub.Invoke<Notification>("SendNotification",
                                        new Notification
                                        {
                                            ActivityId = addActivityResult.Value.Id,
                                            UserId = assignedTo.Id,
                                            Message = "New activity assigned to you",
                                            Operation = ActivityOperationEnum.Add
                                        });
                                    ActivityModel = new ActivityModel();
                                    ActivityModel.CompletionDate = DateTime.Now;
                                    ActivityModel.DueDate = DateTime.Now;
                                    ActivityModel.StartDate = DateTime.Now;
                                    DictionaryList.ToList().ForEach(x => { x.IsChecked = false; });
                                    ActivityToolList.ToList().ForEach(x => { x.IsChecked = false; });
                                    Message = "Activity added successfully";
                                }
                                else
                                {
                                    subject = "Activity Updated on AMS";
                                    await
                                        SendEmailNotification(to, from, subject,
                                            "Activity '" + ActivityModel.Name + "' updated on AMS");
                                    await _notificationHub.Invoke<Notification>("SendNotification",
                                        new Notification
                                        {
                                            ActivityId = activity.Id,
                                            UserId = assignedTo.Id,
                                            Message = "Activity '" + activity.ActivityName + "' updated",
                                            Operation = ActivityOperationEnum.Update
                                        });

                                    Message = "Activity updated successfully";
                                }


                                RaisePropertyChanged(() => ActivityModel);
                                ActivityList = new ObservableCollection<ActivityModel>(ActivityList);
                                DictionaryList = new ObservableCollection<KeywordDictionaries>(DictionaryList);
                                ActivityToolList = new ObservableCollection<ActivityTools>(ActivityToolList);
                                IsBusy = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void GetViewData()
        {
            try
            {
                var users =
                    await ActivityOptimizationSystemServiceClient.GetUserAsync();
                IsBusy = true;

                if (!users.IsErrorReturned)
                {
                    if (!ApplicationSession.User.Roles.Contains(UserRole.Manager))
                    {
                        UserList = new ObservableCollection<User>();
                        UserList.Add(ApplicationSession.User);
                    }
                    else
                    {
                        UserList = new ObservableCollection<User>(users.Value);
                    }
                }

                ActivityCaptureTypeList = new ObservableCollection<string>();
                ActivityCaptureTypeList.Add(ActivityCaptureType.TimeInterval.ToString());
                ActivityCaptureTypeList.Add(ActivityCaptureType.KeywordMatch.ToString());
                var qspaces = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetQSpaces());
                var activityStatus = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetActivityStatus());
                var activityTools = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetAllActivityTools());
                var dictionaries = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetKeywordDictionaries());
                var priorityList = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetActivityPriorities());
                var activities = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetActivities());
                var activityCompositions = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetActivityCompositionsByActivityIds(activities.Result.Value.Select(x => x.Id).ToArray()));
                var activityUsers = Task.Factory.StartNew(() => ActivityOptimizationSystemServiceClient.GetActivityUsers());
                Task.WaitAll(qspaces, activityStatus, activityTools, dictionaries, priorityList, activities, activityCompositions, activityUsers);
                activityUsers.Result.Value = activityUsers.Result.Value.Where(x=>x.IsActive==true).ToArray();
                if (!qspaces.Result.IsErrorReturned)
                    QSpaceList = new ObservableCollection<AOSQSpace>(qspaces.Result.Value);

                if (!activityStatus.Result.IsErrorReturned)
                    ActivityStatusList = new ObservableCollection<ActivityStatus>(activityStatus.Result.Value);

                if (!activityTools.Result.IsErrorReturned)
                    ActivityToolList = new ObservableCollection<ActivityTools>(from activityTool in activityTools.Result.Value
                                                                               select new ActivityTools
                                                                               {
                                                                                   ToolId = activityTool.Id,
                                                                                   ToolName = activityTool.ToolName,
                                                                                   ToolDescription = activityTool.ToolDescription
                                                                               });

                if (!dictionaries.Result.IsErrorReturned)
                    DictionaryList = new ObservableCollection<KeywordDictionaries>(from dictionary in dictionaries.Result.Value
                                                                                   select new KeywordDictionaries
                                                                                   {
                                                                                       Id = dictionary.Id,
                                                                                       DictionaryName = dictionary.DictionaryName
                                                                                   });

                if (!priorityList.Result.IsErrorReturned)
                    PriorityList = new ObservableCollection<ActivityPriority>(priorityList.Result.Value);
                //PriorityList = OnTime.Get<DataResponse<ObservableCollection<Priority>>>(OtnUrl.GetPrioritiesUrl, new Dictionary<string, object>()).data;
                //WorkFlowSteps = OnTime.Get<DataResponse<WorkFlow>>(OtnUrl.GetWorkFlowStepsUrl + "2").data;
                //ReleaseList = OnTime.Get<DataResponse<ObservableCollection<Release>>>(OtnUrl.GetReleasesUrl, new Dictionary<string, object>()).data;
                //var otnActivities = OnTime.Get<DataResponse<ObservableCollection<OTNWithWorksnaps.OTNClasses.Item>>>(OtnUrl.GetTaskUrl, new Dictionary<string, object>());
                //var activities = await ActivityOptimizationSystemServiceClient.GetActivitiesByOTNActivityIdsAsync(otnActivities.data.Select(x => x.id.Value).ToArray());

                if (!activities.Result.IsErrorReturned)
                {
                    if (!activityCompositions.Result.IsErrorReturned)
                    {
                        if (!ApplicationSession.User.Roles.Contains(UserRole.Manager))
                        {
                            IsModificationButtonVisibe = false;
                            activityUsers.Result.Value = new[] { activityUsers.Result.Value.FirstOrDefault(i => i.UserId == ApplicationSession.User.Id) };
                        }
                        else
                            IsModificationButtonVisibe = true;

                        ActivityList = new ObservableCollection<ActivityModel>((from activity in activities.Result.Value
                                                                                join activityComposition in activityCompositions.Result.Value
                                                                                on activity.Id equals activityComposition.ActivityID
                                                                                join activityUser in activityUsers.Result.Value
                                                                                on activity.Id equals activityUser.ActivityId
                                                                                select new ActivityModel
                                                                                {
                                                                                    ActivityCaptureType=activityComposition.ActivityCaptureType.ToString(),
                                                                                    ActivityStatusId = activity.ActivityStatusId,
                                                                                    ActivityToolId = activityComposition.ActivityToolId,
                                                                                    //ActualDuration = activityComposition.ActualDuration,
                                                                                    ActualDuration =
                                                                                        GetActivityInformation(activity.Id, activityComposition.MaximumDuration),
                                                                                    RemainingDuration = remainingDuration,
                                                                                    Attachments =
                                                                                        activity.Attachments != null
                                                                                            ? activity.Attachments.Select(i => i.Url).ToArray()
                                                                                            : new string[0],
                                                                                    PercentCompleted = percentCompleted,
                                                                                    AdditionalTime = additionalTime,
                                                                                    AllCaptureTimeID = activityComposition.AllCaptureTimeId,
                                                                                    AllowedCaptureTimeId = activityComposition.AllowedTimeId,
                                                                                    Id = activity.Id,
                                                                                    AssignedToId = activityUser.UserId,
                                                                                    AssignedTo = UserList.FirstOrDefault(x => x.Id == activityUser.UserId).FirstName,
                                                                                    CompletionDate = activityComposition.CompletionDate,
                                                                                    Description = activityComposition.Description,
                                                                                    DueDate = activityComposition.DueDate,
                                                                                    EstimatedDuration = activityComposition.MaximumDuration,
                                                                                    KeywordDictionariesList =
                                                                                        GetAssignedKeywordDictionaries(activityComposition.KeywordDictionaryIds),
                                                                                    ActivityToolsList = GetAssignedActivityTools(activityComposition.ActivityToolId),
                                                                                    //MaximumDuration = activityComposition.MaximumDuration,
                                                                                    //MinimumDuration = activityComposition.MinimumDuration,
                                                                                    Name = activity.ActivityName,
                                                                                    //OptimumDuration = activityComposition.OptimumDuration,
                                                                                    Priority = activityComposition.PriorityId,
                                                                                    AssignedPriority = GetAssignedPriority(activityComposition.PriorityId),
                                                                                    Project = activity.QSpaceID,
                                                                                    ReportedById = activityComposition.CreatedById,
                                                                                    ReportedBy =
                                                                                        UserList.FirstOrDefault(x => x.Id == activityComposition.CreatedById) != null
                                                                                            ? UserList.FirstOrDefault(x => x.Id == activityComposition.CreatedById)
                                                                                                .FirstName
                                                                                            : string.Empty,
                                                                                    Sequence = activityComposition.Sequence,
                                                                                    StartDate = activityComposition.StartDate,
                                                                                    QSpaceName =
                                                                                        QSpaceList.FirstOrDefault(x => x.Id == activity.QSpaceID) != null
                                                                                            ? QSpaceList.FirstOrDefault(x => x.Id == activity.QSpaceID).QSpaceName
                                                                                            : string.Empty,
                                                                                    //AllCaptureTime = GetAllCaptureTime(activityComposition.AllCaptureTimeId),
                                                                                  //  AllowedTime = GetAllowedTime(activityComposition.AllowedTimeId),
                                                                                    ActivityStatusName =
                                                                                        ActivityStatusList.FirstOrDefault(x => x.Id == activity.ActivityStatusId) != null
                                                                                            ? ActivityStatusList.FirstOrDefault(x => x.Id == activity.ActivityStatusId)
                                                                                                .StatusName
                                                                                            : string.Empty,
                                                                                    ActivityCompositionId = activityComposition.Id,
                                                                                    ActivityUserId = activityUser.Id,
                                                                                    CaptureInterval = activityComposition.CaptureInterval,
                                                                                    ExpectedOutput = activityComposition.ExpectedOutput,
                                                                                    ActualOutput = activityComposition.ActualOutput,
                                                                                    VariationFactor = activityComposition.VariationFactor
                                                                                }).AsParallel());
                        IsBusy = false;
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void DeleteActivityCommandExecute(ActivityModel activityModel)
        {
            try
            {
                IsBusy = true;
                OperationResult result =
                    await ActivityOptimizationSystemServiceClient.DeleteActivityByActivityIdAsync(activityModel.Id);
                if (!result.IsErrorReturned)
                {
                    User user = UserList.FirstOrDefault(x => x.Id == activityModel.AssignedToId);
                    User ReportedByUser = UserList.FirstOrDefault(x=>x.Id==activityModel.ReportedById);
                    ActivityList.Remove(activityModel);
                    ActivityModel = activityModel;
                    if (user != null)
                    {
                        await
                            SendEmailNotification(user.Email, ReportedByUser.Email, "Activity '" + activityModel.Name + "' deleted from AMS",
                                "Activity '" + activityModel.Name + "' deleted from AMS");
                        await _notificationHub.Invoke<Notification>("SendNotification",
                            new Notification
                            {
                                ActivityId = activityModel.Id,
                                UserId = user.Id,
                                Message = "Activity " + activityModel.Name + " removed from AMS",
                                Operation = ActivityOperationEnum.Delete
                            });
                    }
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        private List<KeywordDictionaries> GetAssignedKeywordDictionaries(string[] dictionaryIds)
        {
            return (from dictionary in DictionaryList.Where(x => dictionaryIds.Contains(x.Id))
                select new KeywordDictionaries
                {
                    Id = dictionary.Id,
                    DictionaryName = dictionary.DictionaryName
                }).ToList();
        }

        private List<ActivityTools> GetAssignedActivityTools(string[] toolIds)
        {
            return (from tool in ActivityToolList.Where(x => toolIds.Contains(x.ToolId))
                select new ActivityTools
                {
                    ToolId = tool.ToolId,
                    ToolName = tool.ToolName,
                    ToolDescription = tool.ToolDescription
                }).ToList();
        }

        private List<ActivityTools> GetActivityTools(string[] toolIds)
        {
            return ActivityToolList.Where(x => toolIds.Contains(x.ToolId)).ToList();
        }

        private AllCaptureTime GetAllCaptureTime(string collectionId)
        {
            var result =
                ActivityOptimizationSystemServiceClient.GetAllTimeCollectionById(collectionId);
            if (!result.IsErrorReturned)
            {
                return result.Value;
            }
            return null;
        }

        private AllowedTime AllowedTime(string allowedTimeId)
        {
            var result =
                ActivityOptimizationSystemServiceClient.GetAllowedTimeCollectionById(allowedTimeId);
            if (!result.IsErrorReturned)
            {
                return result.Value;
            }
            return null;
        }

        private string GetAssignedPriority(string priorityId)
        {
            if (PriorityList != null && !string.IsNullOrEmpty(priorityId))
                return PriorityList.FirstOrDefault(x => x.Id == priorityId).PriorityName;
            return string.Empty;
        }

        private string GetActivityUserId(string activityId)
        {
            var result =
                ActivityOptimizationSystemServiceClient.GetActivityUserByActivityId(activityId);
            if (!result.IsErrorReturned)
                return result.Value.Id;

            return string.Empty;
        }

        private async System.Threading.Tasks.Task SendEmailNotification(string to,string from, string subject, string message)
        {
            try
            {
                var emailTemplate =
                    await ActivityOptimizationSystemServiceClient.GetEmailTemplateByIdAsync("ActivityEmailTemplate");
                string template = emailTemplate.Value.TemplateBody;
                template = template.Replace("#Message#", message);
                template = template.Replace("#ActivityName#", ActivityModel.Name);
                template = template.Replace("#QSpaceName#", ActivityModel.QSpaceName);
                template = template.Replace("#StartDate#", ActivityModel.StartDate.Value.ToShortDateString());
                template = template.Replace("#DueDate#", ActivityModel.DueDate.Value.ToShortDateString());
                template = template.Replace("#OriginalEstimate#", ActivityModel.EstimatedDuration.ToString());
                template = template.Replace("#Priority#", ActivityModel.AssignedPriority);
                template = template.Replace("#AssignedTo#", ActivityModel.AssignedTo);
                template = template.Replace("#RequestedBy#", ActivityModel.ReportedBy);
                template = template.Replace("#Description#", ActivityModel.Description);
                using (var smtpClient = new SmtpClient())
                {
                    var mailMessage = new MailMessage();
                    mailMessage.Body = template;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = subject;
                    mailMessage.To.Add(to);
                    mailMessage.CC.Add(from);
                    if (mailMessage.CC.FirstOrDefault(x => x.Address == ApplicationSession.User.Email) == null)
                        mailMessage.CC.Add(ApplicationSession.User.Email);
                    var ccSection = (NameValueCollection)ConfigurationManager.GetSection("CCForAssignActivity");
                    var bccSection = (NameValueCollection)ConfigurationManager.GetSection("BCCForAssignActivity");
                    foreach (var item in ccSection.AllKeys)
                    {
                        mailMessage.CC.Add(item);
                    }
                    foreach (var item in bccSection.AllKeys)
                    {
                        mailMessage.Bcc.Add(item);
                    }
                    ConfigurationManager.GetSection("BCCForAssignActivity");
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private float? GetActivityInformation(string activityId, float estimatedDuration)
        {
            try
            {
                actualDuration = 0;
                remainingDuration = 0;
                percentCompleted = 0;
                additionalTime = 0;
                var activityCaptures =
                    ActivityVerificationServiceClient.GetActivityCapturesByActivityId(activityId);
                if (!activityCaptures.IsErrorReturned)
                {
                    actualDuration =
                        (float)
                            activityCaptures.Value.Where(
                                x => x.VerificationStatus.IsValid && x.VerificationStatus.IsAccepted)
                                .Sum(x => x.TimeBurned.TotalHours);
                    remainingDuration = estimatedDuration - actualDuration;
                    percentCompleted = (actualDuration/estimatedDuration)*100;
                    additionalTime =
                        (float)
                            activityCaptures.Value.Where(
                                x => x.VerificationStatus.IsValid && x.VerificationStatus.IsAccepted == false)
                                .Sum(x => x.TimeBurned.TotalHours);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
            return actualDuration;
        }
    }
}