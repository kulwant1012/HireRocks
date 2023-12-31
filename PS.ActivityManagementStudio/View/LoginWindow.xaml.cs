﻿using PS.ActivityManagementStudio.Messages;
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

namespace PS.ActivityManagementStudio.View
{
    public partial class LoginWindow : Window 
    {
        public LoginWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => Messenger.Default.Register<CloseLoginWindow>(this, window => Close());
        }      
    }
}
