using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;
using System;
using Windows.UI.Text; // Ajout de cette ligne

namespace CreditManagement100.Converters
{
    public class BoolToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                return boolValue ? FontWeights.SemiBold : FontWeights.Normal;
            }
            return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is FontWeight fontWeight)
            {
                return fontWeight == FontWeights.SemiBold;
            }
            return false;
        }
    }
}
