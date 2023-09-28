using DevTricks.Domain.Logging;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DevTricks.Views.DevTools
{
    /// <summary>
    /// Конвертер уровня лога в цвет
    /// </summary>
    public class LogLevelToSolidColorBrushConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new LogLevelToSolidColorBrushConverter();

        //######################################################################################################################
        #region IValueConverter



        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LogLevel logLevel)
                return logLevel switch
                {
                    LogLevel.Info => new SolidColorBrush(Colors.LightGreen),
                    LogLevel.Warn => new SolidColorBrush(Colors.DarkOrange),
                    LogLevel.Error => new SolidColorBrush(Colors.Red),
                    LogLevel.Fatal => new SolidColorBrush(Colors.DarkRed),
                    _ => new SolidColorBrush(Colors.Transparent)
                };
                return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
            =>  Binding.DoNothing;

        #endregion // IValueConverter
    }
}
