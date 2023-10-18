using System;
using System.Collections.ObjectModel;
using System.Linq;
using PS.ActivityManagementStudio.CommonModel;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class ActivityToolViewModel : BaseViewModel
    {
        public ActivityToolViewModel()
        {
            try
            {
                IsBusy = true;
                OpenAddToolWindowCommand = new RelayCommand(OpenAddToolWindow);
                OpenUpdateToolWindowCommand = new RelayCommand<ActivityToolModel>(OpenUpdateToolWindow);
                AddUpdateToolCommand = new RelayCommand(AddUpdateCommandExecute);
                GetViewData();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        public RelayCommand OpenAddToolWindowCommand { get; private set; }
        public RelayCommand<ActivityToolModel> OpenUpdateToolWindowCommand { get; private set; }
        public RelayCommand AddUpdateToolCommand { get; private set; }

        private ObservableCollection<ActivityToolModel> _activityToolsList { get; set; }

        public ObservableCollection<ActivityToolModel> ActivityToolsList
        {
            get { return _activityToolsList; }
            set
            {
                _activityToolsList = value;
                RaisePropertyChanged(() => ActivityToolsList);
            }
        }

        private ActivityToolModel _activityToolModel { get; set; }

        public ActivityToolModel ActivityToolModel
        {
            get { return _activityToolModel; }
            set
            {
                _activityToolModel = value;
                RaisePropertyChanged(() => ActivityToolModel);
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

        private bool _isAddNewTool { get; set; }

        public bool IsAddNewTool
        {
            get { return _isAddNewTool; }
            set
            {
                if (_isAddNewTool != value)
                {
                    _isAddNewTool = value;
                    RaisePropertyChanged(() => IsAddNewTool);
                }
            }
        }

        private void OpenAddToolWindow()
        {
            try
            {
                ActivityToolModel = new ActivityToolModel();
                Message = string.Empty;
                WindowTitle = "Add activity tool";
                ButtonText = "Add activity tool";
                IsAddNewTool = true;
                Messenger.Default.Send(new AddUpdateActivityToolWindowMessage());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void OpenUpdateToolWindow(ActivityToolModel model)
        {
            try
            {
                ActivityToolModel = model;
                Message = string.Empty;
                WindowTitle = "Edit activity tool";
                ButtonText = "Update activity tool";
                IsAddNewTool = false;
                Messenger.Default.Send(new AddUpdateActivityToolWindowMessage());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private async void AddUpdateCommandExecute()
        {
            try
            {
                if (ActivityToolModel.ValidateObject())
                {
                    IsBusy = true;
                    var activityTool = new ActivityTool();
                    activityTool.Id = ActivityToolModel.ID;
                    activityTool.ToolName = ActivityToolModel.ToolName;
                    activityTool.ToolDescription = ActivityToolModel.ToolDescription;
                    var result =
                        await ActivityOptimizationSystemServiceClient.AddOrUpdateActivityToolAsync(activityTool);
                    if (!result.IsErrorReturned)
                    {
                        if (IsAddNewTool)
                        {
                            ActivityToolModel.ID = result.Value.Id;
                            ActivityToolsList.Add(ActivityToolModel);
                            ActivityToolModel = new ActivityToolModel();
                            Message = "New tool added";
                        }
                        else
                        {
                            ActivityToolsList = new ObservableCollection<ActivityToolModel>(ActivityToolsList);
                            Message = "Tool updated successfully";
                        }
                        IsBusy = false;
                    }
                }
            }

            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        private async void GetViewData()
        {
            var activityTools =
                await ActivityOptimizationSystemServiceClient.GetActivityToolsAsync();
            if (!activityTools.IsErrorReturned)
            {
                ActivityToolsList = new ObservableCollection<ActivityToolModel>(
                    from activityTool in activityTools.Value
                    select new ActivityToolModel
                    {
                        ID = activityTool.Id,
                        ToolName = activityTool.ToolName,
                        ToolDescription = activityTool.ToolDescription
                    });
            }
        }
    }
}