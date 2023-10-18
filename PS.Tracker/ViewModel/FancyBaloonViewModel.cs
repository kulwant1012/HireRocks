using System.Drawing;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;

namespace PS.Tracker.ViewModel
{
    public class FancyBaloonViewModel:BaseViewModel
    {
        public RelayCommand DiscardCaptureCommand { get; private set; }
        public RelayCommand PreviewCaptureCommand { get; private set; }

        string _notificationText { get; set; }
        public string NotificationText
        {
            get { return _notificationText; }
            set { _notificationText = value; RaisePropertyChanged(() => NotificationText); }
        }

        bool _isCaptureNotification { get; set; }
        public bool IsCaptureNotification
        {
            get { return _isCaptureNotification; }
            set { _isCaptureNotification = value; RaisePropertyChanged(() => IsCaptureNotification); }
        }

        public bool _isCaptureDiscarded { get; set; }
        public bool IsCaptureDiscarded
        {
            get { return _isCaptureDiscarded; }
            set { _isCaptureDiscarded = value; RaisePropertyChanged(() => IsCaptureDiscarded); }
        }

        public bool _isPreviewButtonClicked { get; set; }
        public bool IsPreviewButtonClicked
        {
            get { return _isPreviewButtonClicked; }
            set { _isPreviewButtonClicked = value; RaisePropertyChanged(() => IsPreviewButtonClicked); }
        }

        public bool _isPreviewButtonEnabled { get; set; }
        public bool IsPreviewButtonEnabled
        {
            get { return _isPreviewButtonEnabled; }
            set { _isPreviewButtonEnabled = value; RaisePropertyChanged(() => IsPreviewButtonEnabled); }
        }

        string _timeLeftForSubmission { get; set; }
        public string TimeLeftForSubmission
        {
            get { return _timeLeftForSubmission; }
            set { _timeLeftForSubmission = value; RaisePropertyChanged(() => TimeLeftForSubmission); }
        }

        public FancyBaloonViewModel()
        {
            DiscardCaptureCommand = new RelayCommand(DiscardCaptureCommandExecute);
            PreviewCaptureCommand = new RelayCommand(PreviewCaptureCommandExecute);
        }

        BitmapImage _screenCaptureFullImage { get; set; }
        public BitmapImage ScreenCaptureFullImage
        {
            get { return _screenCaptureFullImage; }
            set { _screenCaptureFullImage = value; RaisePropertyChanged(() => ScreenCaptureFullImage); }
        } 

        void DiscardCaptureCommandExecute()
        {
            IsCaptureDiscarded = true;
        }

        void PreviewCaptureCommandExecute()
        {
            IsPreviewButtonClicked = true;
        }
    }
}
