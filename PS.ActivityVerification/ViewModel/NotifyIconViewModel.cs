using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System.Drawing;

namespace PS.ActivityVerification.ViewModel
{
    public class NotifyIconViewModel : BaseViewModel
    {
        private string _iconImage = "/Images/Red.ico";

        public NotifyIconViewModel()
        {
            CloseCommand = new RelayCommand<CancelEventArgs>(CloseCommandExecute);
            ExitCommand = new RelayCommand(ExitExecute);
            ShowHideCommand = new RelayCommand(ShowHideCommandExecute);
            SuspendResumeTimeTrackingCommand = new RelayCommand(SuspendResumeTimeTrackingCommandExecute);
            ShowHideCommandText = "Hide window";
            SuspendResumeTimeCommandText = "Suspend";
            IsSuspendResumeEnabled = false;
        }

        public RelayCommand<CancelEventArgs> CloseCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand ShowHideCommand { get; private set; }
        public RelayCommand SuspendResumeTimeTrackingCommand { get; private set; }

        public string IconImage
        {
            get { return _iconImage; }
            set
            {
                _iconImage = value;
                RaisePropertyChanged(() => IconImage);
            }
        }

        private string _showHideCommandText { get; set; }

        public string ShowHideCommandText
        {
            get { return _showHideCommandText; }

            set
            {
                _showHideCommandText = value;
                RaisePropertyChanged(() => ShowHideCommandText);
            }
        }

        private string _suspendResumeTimeCommandText { get; set; }

        public string SuspendResumeTimeCommandText
        {
            get { return _suspendResumeTimeCommandText; }

            set
            {
                _suspendResumeTimeCommandText = value;
                RaisePropertyChanged(() => SuspendResumeTimeCommandText);
            }
        }

        private bool _isSuspendResumeEnabled { get; set; }

        public bool IsSuspendResumeEnabled
        {
            get { return _isSuspendResumeEnabled; }

            set
            {
                _isSuspendResumeEnabled = value;
                RaisePropertyChanged(() => IsSuspendResumeEnabled);
            }
        }

        //static NotifyIconViewModel instance = null;
        //public static NotifyIconViewModel Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new NotifyIconViewModel();
        //        }
        //        return instance;
        //    }
        //}

        private void ShowHideCommandExecute()
        {
            if (Application.Current.MainWindow != null)
            {
                if (Application.Current.MainWindow.IsVisible)
                {
                    Application.Current.MainWindow.Hide();
                    ShowHideCommandText = "Show window";
                }
                else
                {
                    Application.Current.MainWindow.Show();
                    ShowHideCommandText = "Hide window";
                }
            }
        }

        private void CloseCommandExecute(CancelEventArgs e)
        {
            if (IsCloseButtonNotClicked == false)
            {
                if (e != null)
                    e.Cancel = true;

                if (Application.Current.MainWindow.IsVisible)
                {
                    Application.Current.MainWindow.Hide();
                    ShowHideCommandText = "Show window";
                }
                else
                {
                    Application.Current.MainWindow.Show();
                    ShowHideCommandText = "Hide window";
                }
            }
            else
                ShowHideCommandText = "Show window";
        }

        private void ExitExecute()
        {
            if (Application.Current.MainWindow != null)
            {
                IsCloseButtonNotClicked = true;
                Application.Current.MainWindow.Close();
                IsCloseButtonNotClicked = false;
            }
        }

        private void SuspendResumeTimeTrackingCommandExecute()
        {
            var selectActivityModel = ServiceLocator.Current.GetInstance<SelectActivityViewModel>();
            if (selectActivityModel != null)
            {
                if (selectActivityModel.Timer.Enabled)
                {
                    selectActivityModel.Timer.Enabled = false;
                    selectActivityModel.KeyboardHook.Stop();
                    selectActivityModel.MouseHook.Stop();
                    selectActivityModel.SelectedActivity.ActivityCurrentStatus = "Start";
                    selectActivityModel.SelectedActivity.BottomPanelcolor = Color.LightGray.Name;
                    selectActivityModel.SelectedActivity.LearnButtonVisibility = true;
                    selectActivityModel.SelectedActivityId = null;
                    SuspendResumeTimeCommandText = "Resume";
                }
                else
                {
                    selectActivityModel.Timer.Enabled = true;
                    selectActivityModel.KeyboardHook.Start();
                    selectActivityModel.MouseHook.Start();
                    selectActivityModel.SelectedActivity.ActivityCurrentStatus = "In Progress";
                    selectActivityModel.SelectedActivity.BottomPanelcolor = Color.Gray.Name;
                    selectActivityModel.SelectedActivity.LearnButtonVisibility = false;
                    SuspendResumeTimeCommandText = "Suspend";
                }
                RaisePropertyChanged(() => SuspendResumeTimeCommandText);
            }
        }
    }
}