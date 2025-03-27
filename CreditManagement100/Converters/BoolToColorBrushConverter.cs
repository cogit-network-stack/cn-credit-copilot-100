using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;

namespace CreditManagement100.Converters
{
    public class BoolToColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue && parameter is string colors)
            {
                // Parameter format: "TrueColor,FalseColor"
                string[] colorValues = colors.Split(',');
                if (colorValues.Length == 2)
                {
                    // Parse to solid color brush
                    if (boolValue)
                    {
                        // Return the first color for true
                        return ParseColor(colorValues[0]);
                    }
                    else
                    {
                        // Return the second color for false
                        return ParseColor(colorValues[1]);
                    }
                }
            }
            return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)); // Default white
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private SolidColorBrush ParseColor(string colorString)
        {
            try
            {
                // Handle HTML-style color codes
                if (colorString.StartsWith("#") && (colorString.Length == 7 || colorString.Length == 9))
                {
                    byte a = 255;
                    int startIndex = 1;

                    if (colorString.Length == 9)
                    {
                        a = byte.Parse(colorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                        startIndex = 3;
                    }

                    byte r = byte.Parse(colorString.Substring(startIndex, 2), System.Globalization.NumberStyles.HexNumber);
                    byte g = byte.Parse(colorString.Substring(startIndex + 2, 2), System.Globalization.NumberStyles.HexNumber);
                    byte b = byte.Parse(colorString.Substring(startIndex + 4, 2), System.Globalization.NumberStyles.HexNumber);

                    return new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
                }
                // Handle color names
                else
                {
                    return new SolidColorBrush(Windows.UI.Colors.White);
                }
            }
            catch
            {
                return new SolidColorBrush(Windows.UI.Colors.White);
            }
        }
    }
}
