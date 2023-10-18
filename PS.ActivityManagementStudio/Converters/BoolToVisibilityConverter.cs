﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PS.ActivityManagementStudio.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ("Collapsed" == value.ToString())
            {
                return false;
            }
            return true;
        }
    }
}