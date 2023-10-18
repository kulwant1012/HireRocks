using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace PS.HireRocks.Model
{
    public class TrackerJobsViewModel : ViewModelBase
    {
        string _todayBurnedHours { get; set; }
        string _weeklyBurnedHours { get; set; }
        string _totalBurnedHours { get; set; }
        string _lastCaptureUrl { get; set; }

        public long? ContractId { get; set; }
        public string JobTitle { get; set; }
        public string JobTypeName { get; set; }
        public string LastCaptureUrl
        {
            get { return _lastCaptureUrl; }
            set { _lastCaptureUrl = value; RaisePropertyChanged(() => LastCaptureUrl); }
        }

        public string TotalBurnedHours
        {
            get { return _totalBurnedHours; }
            set { _totalBurnedHours = value; RaisePropertyChanged(() => TotalBurnedHours); }
        }

        public string WeeklyBurnedHours
        {
            get { return _weeklyBurnedHours; }
            set { _weeklyBurnedHours = value; RaisePropertyChanged(() => WeeklyBurnedHours); }
        }

        public string TodayBurnedHours
        {
            get { return _totalBurnedHours; }
            set { _totalBurnedHours = value; RaisePropertyChanged(() => TodayBurnedHours); }
        }

        public DateTime? JobStartDate { get; set; }
        public decimal? HoursLimit { get; set; }
    }
}
