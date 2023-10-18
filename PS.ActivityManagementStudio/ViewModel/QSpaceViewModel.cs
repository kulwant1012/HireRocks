using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PS.ActivityManagementStudio.CommonModel;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class QSpaceViewModel : BaseViewModel
    {
        public QSpaceViewModel()
        {
            try
            {
                QSpaceModel = new QSpaceModel();
                OpenAddQSpaceScreenCommand = new RelayCommand(OpenAddQSpaceScreenExecute);
                OpenUpdateQSpaceScreenCommand = new RelayCommand<QSpaceModel>(OpenUpdateQSpaceScreenExecute);
                AddUpdateQSpaceCommand = new RelayCommand(AddUpdateQSpaceExecute);
                GetViewData();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
            }
        }

        public RelayCommand OpenAddQSpaceScreenCommand { get; set; }
        public RelayCommand<QSpaceModel> OpenUpdateQSpaceScreenCommand { get; set; }
        public RelayCommand AddUpdateQSpaceCommand { get; set; }

        private ObservableCollection<QSpaceModel> _qSpaceList { get; set; }

        public ObservableCollection<QSpaceModel> QSpaceList
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

        private QSpaceModel _qSpaceModel { get; set; }

        public QSpaceModel QSpaceModel
        {
            get { return _qSpaceModel; }
            set
            {
                if (_qSpaceModel != value)
                {
                    _qSpaceModel = value;
                    RaisePropertyChanged(() => QSpaceModel);
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

        private bool _isAddNewQSpace { get; set; }

        public bool IsAddNewQSpace
        {
            get { return _isAddNewQSpace; }
            set
            {
                if (_isAddNewQSpace != value)
                {
                    _isAddNewQSpace = value;
                    RaisePropertyChanged(() => IsAddNewQSpace);
                }
            }
        }

        private void OpenAddQSpaceScreenExecute()
        {
            try
            {
                QSpaceModel = new QSpaceModel();
                QSpaceModel.DueDate = DateTime.Now;
                QSpaceModel.StartDate = DateTime.Now;
                ButtonText = "Add QSpace";
                WindowTitle = "Add QSpace";
                IsAddNewQSpace = true;
                Message = string.Empty;
                Messenger.Default.Send(new AddUpdateQSpaceWindowMessage());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void OpenUpdateQSpaceScreenExecute(QSpaceModel qSpaceModel)
        {
            try
            {
                IsAddUpdateView = true;
                QSpaceModel = qSpaceModel;
                ButtonText = "Update QSpace";
                WindowTitle = "Edit QSpace";
                IsAddNewQSpace = false;
                Message = string.Empty;
                Messenger.Default.Send(new AddUpdateQSpaceWindowMessage());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private async void GetViewData()
        {
            IsBusy = true;
            var response =
                await ActivityOptimizationSystemServiceClient.GetQSpacesAsync();
            if (!response.IsErrorReturned)
            {
                IEnumerable<QSpaceModel> qSpaces = from qSpace in response.Value
                    select new QSpaceModel
                    {
                        Id = qSpace.Id,
                        QSpaceName = qSpace.QSpaceName,
                        QSpaceType = qSpace.QSpaceType,
                        StartDate = qSpace.StartDate,
                        DueDate = qSpace.DueDate,
                        Description = qSpace.Description,
                        IsActive = qSpace.IsActive
                    };
                QSpaceList = new ObservableCollection<QSpaceModel>(qSpaces);
                IsBusy = false;
            }
        }

        private async void AddUpdateQSpaceExecute()
        {
            try
            {
                if (QSpaceModel.ValidateObject())
                {
                    IsBusy = true;
                    Message = string.Empty;
                    var aosQSpace = new AOSQSpace();
                    aosQSpace.Id = QSpaceModel.Id;
                    aosQSpace.QSpaceName = QSpaceModel.QSpaceName;
                    aosQSpace.QSpaceType = QSpaceModel.QSpaceType;
                    aosQSpace.StartDate = QSpaceModel.StartDate;
                    aosQSpace.DueDate = QSpaceModel.DueDate;
                    aosQSpace.IsActive = true;
                    aosQSpace.Description = QSpaceModel.Description;
                    var response =
                        await ActivityOptimizationSystemServiceClient.AddOrUpdateQSpaceAsync(aosQSpace);

                    if (!response.IsErrorReturned)
                    {
                        if (IsAddNewQSpace)
                        {
                            QSpaceModel.Id = response.Value.Id;
                            QSpaceList.Add(QSpaceModel);
                            QSpaceModel = new QSpaceModel();
                            QSpaceModel.StartDate = DateTime.Now;
                            QSpaceModel.DueDate = DateTime.Now;
                            Message = "QSpace added successfully";
                        }
                        else
                        {
                            Message = "QSpace updated successfully";
                        }
                        RaisePropertyChanged(() => QSpaceModel);
                        QSpaceList = new ObservableCollection<QSpaceModel>(QSpaceList);
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
    }
}