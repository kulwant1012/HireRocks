using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using PS.ActivityManagementStudio.PSServiceReference;
using GalaSoft.MvvmLight.Command;

namespace PS.ActivityManagementStudio.ViewModel
{
    public  class ReportsViewModel : BaseViewModel
    {
        private ObservableCollection<AOSQSpace> _qSpaceList;
        private ObservableCollection<RangeType> _rangeTypeList;
        private ObservableCollection<Reports> _reportList;
        private ObservableCollection<User> _userList;

        public ReportsViewModel()
        {
            QSpaceList = new ObservableCollection<AOSQSpace>();
            UserList = new ObservableCollection<User>();
            ReportList = new ObservableCollection<Reports>();
            CreateReportCommand = new RelayCommand(CreateReport);
            NextButtonClickCommand = new RelayCommand(NextButtonClicked);
            PreviousButtonClickCommand = new RelayCommand(PreviousButtonClicked);
            SelectedStartDate = DateTime.Today;
            SelectedEndDate = DateTime.Today;
            SelectedRange = "Day";
            GetViewData();
            CreateReport();
        }

        public RelayCommand CreateReportCommand { get; set; }
        public RelayCommand NextButtonClickCommand { get; set; }
        public RelayCommand PreviousButtonClickCommand { get; set; }

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

        public ObservableCollection<Reports> ReportList
        {
            get { return _reportList; }


            set
            {
                if (_reportList != value)
                {
                    _reportList = value;
                    RaisePropertyChanged(() => ReportList);
                }
            }
        }

        public ObservableCollection<RangeType> RangeTypeList
        {
            get { return _rangeTypeList; }
            set
            {
                if (_rangeTypeList != value)
                {
                    _rangeTypeList = value;
                    RaisePropertyChanged(() => RangeTypeList);
                }
            }
        }

        private string _selectedQSpace { get; set; }

        public string SelectedQSpace
        {
            get { return _selectedQSpace; }
            set
            {
                _selectedQSpace = value;
                RaisePropertyChanged(() => SelectedQSpace);
                UserList.Clear();
                GetUsers();
                CreateReport();
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
                CreateReport();
            }
        }

        private string _selectedRangeDisplayText { get; set; }

        public string SelectedRangeDisplayText
        {
            get { return _selectedRangeDisplayText; }
            set
            {
                _selectedRangeDisplayText = value;
                RaisePropertyChanged(() => SelectedRangeDisplayText);
            }
        }

        private bool _isCustomDateRangeSelected { get; set; }

        public bool IsCustomDateRangeSelected
        {
            get { return _isCustomDateRangeSelected; }
            set
            {
                _isCustomDateRangeSelected = value;
                RaisePropertyChanged(() => IsCustomDateRangeSelected);
            }
        }

        private string _selectedRange { get; set; }

        public string SelectedRange
        {
            get { return _selectedRange; }
            set
            {
                _selectedRange = value;
                RaisePropertyChanged(() => SelectedRange);
                IsCustomDateRangeSelected = false;
                SelectedRangeTypeChanged();
            }
        }

        private DateTime _selectedStartDate { get; set; }

        public DateTime SelectedStartDate
        {
            get { return _selectedStartDate; }
            set
            {
                _selectedStartDate = value;
                RaisePropertyChanged(() => SelectedStartDate);
                CreateReport();
            }
        }

        private DateTime _selectedEndDate { get; set; }

        public DateTime SelectedEndDate
        {
            get { return _selectedEndDate; }
            set
            {
                _selectedEndDate = value;
                RaisePropertyChanged(() => SelectedEndDate);
                CreateReport();
            }
        }

        private async void GetViewData()
        {
            try
            {
                IsBusy = true;
                RangeTypeList = new ObservableCollection<RangeType>();
                RangeTypeList.Add(new RangeType {RangeName = "Day"});
                RangeTypeList.Add(new RangeType {RangeName = "Week"});
                RangeTypeList.Add(new RangeType {RangeName = "Two Weeks"});
                RangeTypeList.Add(new RangeType {RangeName = "Month"});
                RangeTypeList.Add(new RangeType {RangeName = "Custom"});

                var qSpaceList =  await ActivityOptimizationSystemServiceClient.GetQSpacesAsync();
                if (!qSpaceList.IsErrorReturned)
                    QSpaceList = new ObservableCollection<AOSQSpace>(qSpaceList.Value);

                if (ApplicationSession.User.Roles.Contains(UserRole.Manager))
                {
                    var userList = await ActivityOptimizationSystemServiceClient.GetUserAsync();
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
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void GetUsers()
        {
            try
            {
                IsBusy = true;
                if (!string.IsNullOrEmpty(SelectedQSpace))
                {
                    var users =
                        await ActivityOptimizationSystemServiceClient.GetUsersByQSpaceIdAsync(SelectedQSpace);
                    if (!users.IsErrorReturned)
                        UserList = new ObservableCollection<User>(users.Value);
                }
                else
                {
                    var users =
                        await ActivityOptimizationSystemServiceClient.GetUserAsync();
                    if (!users.IsErrorReturned)
                        UserList = new ObservableCollection<User>(users.Value);
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void CreateReport()
        {
            try
            {
                IsBusy = true;
                var reportList =
                    await
                        ActivityOptimizationSystemServiceClient.GetReportDataAsync(SelectedQSpace, SelectedUser,
                            string.Empty, SelectedStartDate, SelectedEndDate);
                if (!reportList.IsErrorReturned)
                {
                    reportList.Value.ToList().ForEach(x => x.TimeLogged = Math.Round(x.TimeLogged, 2));
                    ReportList = new ObservableCollection<Reports>(reportList.Value);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private void SelectedRangeTypeChanged()
        {
            int currentDay = Convert.ToInt32(DateTime.Today.DayOfWeek - 1);
            switch (SelectedRange)
            {
                case "Day":
                    SelectedStartDate = DateTime.Today;
                    SelectedEndDate = DateTime.Today;
                    break;

                case "Week":
                    SelectedStartDate = DateTime.Today.AddDays(-currentDay);
                    SelectedEndDate = DateTime.Today.AddDays(6 - currentDay);
                    break;

                case "Two Weeks":
                    SelectedStartDate = DateTime.Today.AddDays(-currentDay - 7);
                    SelectedEndDate = DateTime.Today.AddDays(6 - currentDay);
                    break;

                case "Month":
                    SelectedStartDate = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                    SelectedEndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddDays(-1);
                    break;

                case "Custom":
                    SelectedStartDate = DateTime.Now;
                    SelectedEndDate = DateTime.Now;
                    IsCustomDateRangeSelected = true;
                    break;
            }
            SelectedRangeDisplayText = SelectedStartDate.ToShortDateString() + " to " +
                                       SelectedEndDate.ToShortDateString();
        }

        private void NextButtonClicked()
        {
            if (SelectedRange == "Day")
            {
                SelectedStartDate = SelectedStartDate.AddDays(1);
                SelectedEndDate = SelectedEndDate.AddDays(1);
            }
            if (SelectedRange == "Week")
            {
                SelectedStartDate = SelectedStartDate.AddDays(7);
                SelectedEndDate = SelectedEndDate.AddDays(7);
            }
            if (SelectedRange == "Two Weeks")
            {
                SelectedStartDate = SelectedStartDate.AddDays(14);
                SelectedEndDate = SelectedEndDate.AddDays(14);
            }
            if (SelectedRange == "Month")
            {
                SelectedStartDate = SelectedEndDate.AddDays(1);
                SelectedEndDate = new DateTime(SelectedStartDate.Year, SelectedStartDate.Month,
                    DateTime.DaysInMonth(SelectedStartDate.Month, SelectedStartDate.Month));
            }
            SelectedRangeDisplayText = SelectedStartDate.ToShortDateString() + " to " +
                                       SelectedEndDate.ToShortDateString();
        }

        private void PreviousButtonClicked()
        {
            if (SelectedRange == "Day")
            {
                SelectedStartDate = SelectedStartDate.AddDays(-1);
                SelectedEndDate = SelectedEndDate.AddDays(-1);
            }
            if (SelectedRange == "Week")
            {
                SelectedStartDate = SelectedStartDate.AddDays(-7);
                SelectedEndDate = SelectedEndDate.AddDays(-7);
            }
            if (SelectedRange == "Two Week")
            {
                SelectedStartDate = SelectedStartDate.AddDays(-14);
                SelectedEndDate = SelectedEndDate.AddDays(-14);
            }
            if (SelectedRange == "Month")
            {
                SelectedEndDate = SelectedStartDate.AddDays(-1);
                SelectedStartDate = new DateTime(SelectedEndDate.Year, SelectedEndDate.Month, 1);
            }
            SelectedRangeDisplayText = SelectedStartDate.ToShortDateString() + " to " +
                                       SelectedEndDate.ToShortDateString();
        }
    }

    public class RangeType
    {
        public string RangeName { get; set; }
    }
}