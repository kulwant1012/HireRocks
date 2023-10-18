using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GalaSoft.MvvmLight;
using MouseKeyboardLibrary;

namespace PS.Tracker.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        public static Timer _timer;
        public static KeyboardHook _keyboardHook;
        public static MouseHook _mouseHook;
    }
}
