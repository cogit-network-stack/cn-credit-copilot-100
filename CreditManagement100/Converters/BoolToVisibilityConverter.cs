using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace CreditManagement100.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                if (parameter != null && parameter.ToString() == "Invert")
                {
                    return boolValue ? Visibility.Collapsed : Visibility.Visible;
                }
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
            {
                if (parameter != null && parameter.ToString() == "Invert")
                {
                    return visibility == Visibility.Collapsed;
                }
                return visibility == Visibility.Visible;
            }
            return false;
        }
    }
}
