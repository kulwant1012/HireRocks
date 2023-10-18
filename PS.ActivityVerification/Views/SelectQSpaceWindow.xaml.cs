using PS.ActivityVerification.Messages;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PS.ActivityVerification.Views
{
    public partial class SelectQSpaceWindow : Window
    {
        public SelectQSpaceWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => Messenger.Default.Register<CloseQSpaceWindow>(this, window => Close());
        }
    }
}
