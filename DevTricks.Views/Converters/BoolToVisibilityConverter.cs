using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DevTricks.Views.Converters
{
    /// <summary>
    /// Конвертер bool to Visibilyty 
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {

        public static readonly IValueConverter Instance = new BoolToVisibilityConverter();

        //############################################################################################################
        #region IValueConverter

        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture) =>
            value is true
            ? Visibility.Visible
            : Visibility.Collapsed;

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Visibility visibility)
                return false;

            return visibility switch
            {
                Visibility.Visible => true,
                Visibility.Collapsed => false,
                Visibility.Hidden => false,
                _ => false
            }; 
        }

        #endregion // IValueConverter

    }
}
