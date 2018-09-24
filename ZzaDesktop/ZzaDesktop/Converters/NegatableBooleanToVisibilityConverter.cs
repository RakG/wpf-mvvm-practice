using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZzaDesktop
{
    public class NegatableBooleanToVisibilityConverter : IValueConverter
    {
        public NegatableBooleanToVisibilityConverter()
        {
            this.Negate = false;
        }

        public bool Negate { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!bool.TryParse(value.ToString(), out bool boolValue))
            {
                return value;
            }

            return boolValue == this.Negate ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
