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

using PS.ActivityVerification.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace PS.ActivityVerification.Views
{
    public partial class SelectActivityWindow : Window
    {
        public SelectActivityWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => Messenger.Default.Register<CloseActivityWindow>(this, window => Close());
        }       
    }
}
