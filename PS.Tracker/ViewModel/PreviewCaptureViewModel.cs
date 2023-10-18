using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PS.Tracker.ViewModel
{
    public class PreviewCaptureViewModel : BaseViewModel
    {
        string _keyboardCapture { get; set; }
        public string KeyboardCapture
        {
            get { return _keyboardCapture; }
            set { _keyboardCapture = value; RaisePropertyChanged(() => KeyboardCapture); }
        }
        string _mouseCapture { get; set; }
        public string MouseCapture
        {
            get { return _mouseCapture; }
            set { _mouseCapture = value; RaisePropertyChanged(() => MouseCapture); }
        }
        string _timeBurned { get; set; }
        public string TimeBurned
        {
            get { return _timeBurned; }
            set { _timeBurned = value; RaisePropertyChanged(() => TimeBurned); }
        }

        BitmapImage _screenCaptureFullImage { get; set; }
        public BitmapImage ScreenCaptureFullImage
        {
            get { return _screenCaptureFullImage; }
            set { _screenCaptureFullImage = value; RaisePropertyChanged(() => ScreenCaptureFullImage); }
        }

        BitmapSource _screenCaptureFullImage1 { get; set; }
        public BitmapSource ScreenCaptureFullImage1
        {
            get { return _screenCaptureFullImage1; }
            set { _screenCaptureFullImage1 = value; RaisePropertyChanged(() => ScreenCaptureFullImage1); }
        }
    }
}
