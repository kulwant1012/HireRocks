using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PS.ActivityManagementStudio.Helpers;
using PS.ActivityManagementStudio.PSServiceReference;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class ActivityModel : ValidableObject
    {
        public ActivityModel()
        {
            KeywordDictionariesList = new List<KeywordDictionaries>();
            //ActivityCaptureType = null;
            AllCaptureTime = new AllCaptureTime();
            AllowedTime = new AllowedTime();
            Attachments = new string[0];
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public int VariationFactor { get; set; }
        public string ExpectedOutput { get; set; }
        public string ActualOutput { get; set; }
        public string Notes { get; set; }
        public string QSpaceName { get; set; }
        public string AssignedTo { get; set; }
        public string ReportedBy { get; set; }
        public string AssignedPriority { get; set; }
        public float PercentCompleted { get; set; }
        public Boolean PubliclyViewable { get; set; }
        public Boolean IsCompleted { get; set; }
        public string WorkFlowStepName { get; set; }
        public string ReleaseName { get; set; }
        public string AllCaptureTimeID { get; set; }
        public string AllowedCaptureTimeId { get; set; }
        public AllCaptureTime AllCaptureTime { get; set; }
        public AllowedTime AllowedTime { get; set; }
        public string ActivityCompositionId { get; set; }
        public string ActivityUserId { get; set; }
        public int? OtnActivityId { get; set; }
        public string ActivityStatusName { get; set; }
        public int? Release { get; set; }
        public string[] ActivityToolId { get; set; }
        public string ActivityTypeId { get; set; }
        public List<KeywordDictionaries> KeywordDictionariesList { get; set; }
        public List<ActivityTools> ActivityToolsList { get; set; }
        string _activityCaptureType { get; set; }
        [Required(ErrorMessage="Required")]
        public string ActivityCaptureType
        {
            get { return _activityCaptureType; }
            set { SetPropertyAndValidate(() => _activityCaptureType, x => _activityCaptureType = x, value); }
        }

        private string _name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name
        {
            get { return _name; }
            set { SetPropertyAndValidate(() => _name, x => _name = x, value); }
        }

        private string _assignedToId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string AssignedToId
        {
            get { return _assignedToId; }
            set { SetPropertyAndValidate(() => _assignedToId, x => _assignedToId = x, value); }
        }

        private string _reportedById { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ReportedById
        {
            get { return _reportedById; }
            set { SetPropertyAndValidate(() => _reportedById, x => _reportedById = x, value); }
        }

        private string _priority { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Priority
        {
            get { return _priority; }
            set { SetPropertyAndValidate(() => _priority, x => _priority = x, value); }
        }

        private DateTime? _startDate { get; set; }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value.Value;
                RaisePropertyChanged(() => StartDate);
            }
        }

        private DateTime? _dueDate { get; set; }

        public DateTime? DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value.Value;
                RaisePropertyChanged(() => DueDate);
            }
        }

        private DateTime? _completionDate { get; set; }

        public DateTime? CompletionDate
        {
            get { return _completionDate; }
            set
            {
                _completionDate = value.Value;
                RaisePropertyChanged(() => CompletionDate);
            }
        }

        private float? _estimatedDuration { get; set; }

        [Required(ErrorMessage = "Required")]
        public float? EstimatedDuration
        {
            get { return _estimatedDuration; }
            set { SetPropertyAndValidate(() => _estimatedDuration, x => _estimatedDuration = x, value); }
        }

        private float? _actualDuration { get; set; }

        public float? ActualDuration
        {
            get { return _actualDuration; }
            set
            {
                _actualDuration = value;
                RaisePropertyChanged(() => ActualDuration);
            }
        }

        private float? _additionalTime { get; set; }

        public float? AdditionalTime
        {
            get { return _additionalTime; }
            set
            {
                _additionalTime = value;
                RaisePropertyChanged(() => AdditionalTime);
            }
        }

        private float? _remainingDuration { get; set; }

        public float? RemainingDuration
        {
            get { return _remainingDuration; }
            set
            {
                _remainingDuration = value;
                RaisePropertyChanged(() => RemainingDuration);
            }
        }

        private string _project { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Project
        {
            get { return _project; }
            set { SetPropertyAndValidate(() => _project, x => _project = x, value); }
        }

        private float? _minimumDuration { get; set; }
        //[Required(ErrorMessage = "Required")]
        public float? MinimumDuration
        {
            get { return _minimumDuration; }
            set { SetPropertyAndValidate(() => _minimumDuration, x => _minimumDuration = x, value); }
        }

        private float? _maximumDuration { get; set; }
        //[Required(ErrorMessage = "Required")]
        public float? MaximumDuration
        {
            get { return _maximumDuration; }
            set { SetPropertyAndValidate(() => _maximumDuration, x => _maximumDuration = x, value); }
        }

        private float? _optimumDuration { get; set; }
        //[Required(ErrorMessage = "Required")]
        public float? OptimumDuration
        {
            get { return _optimumDuration; }
            set { SetPropertyAndValidate(() => _optimumDuration, x => _optimumDuration = x, value); }
        }

        private int? _workFlowStep { get; set; }
        //[Required(ErrorMessage = "Required")]
        public int? WorkFlowStep
        {
            get { return _workFlowStep; }
            set { SetPropertyAndValidate(() => _workFlowStep, x => _workFlowStep = x, value); }
        }

        private string _activityStatusId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ActivityStatusId
        {
            get { return _activityStatusId; }
            set { SetPropertyAndValidate(() => _activityStatusId, x => _activityStatusId = x, value); }
        }

        private int? _sequence { get; set; }

        [Required(ErrorMessage = "Required")]
        public int? Sequence
        {
            get { return _sequence; }
            set { SetPropertyAndValidate(() => _sequence, x => _sequence = x, value); }
        }

        private int? _captureInterval { get; set; }

        [Required(ErrorMessage = "Required")]
        public int? CaptureInterval
        {
            get { return _captureInterval; }
            set { SetPropertyAndValidate(() => _captureInterval, x => _captureInterval = x, value); }
        }

        public string[] Attachments { get; set; }
    }


    public class KeywordDictionaries
    {
        public string Id { get; set; }
        public string DictionaryName { get; set; }
        public bool IsChecked { get; set; }
    }

    public class TimeCollectionClass
    {
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public int? Seconds { get; set; }
    }

    public class ActivityTools
    {
        public string ToolId { get; set; }
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
        public bool IsChecked { get; set; }
    }
}