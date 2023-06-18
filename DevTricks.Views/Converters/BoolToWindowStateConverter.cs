using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DevTricks.Views.Converters
{
    /// <summary>
    /// Конвертер bool в WindowState и обратно
    /// </summary>
    public class BoolToWindowStateConverter : IValueConverter
    {
        // Instance для использования конвертера во View
        // позволит потребителям использовать единственный инстанс этого конвертера 
        // (т.к. конвертер не содержит никакого состояния, нет смысла каждый раз создавать новый конвертер, экономнее использовать существующий)
        // Будет выступать в роли фабрики, и при первом обращении инстанс будет создан автоматически
        public static readonly IValueConverter Instance = new BoolToWindowStateConverter(); 


        //######################################################################################################################
        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isMaximized)
                return isMaximized
                    ? WindowState.Maximized
                    : WindowState.Normal;
            return WindowState.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState windowState)
                return windowState == WindowState.Maximized;
            return false;
        }

        #endregion // IValueConverter

    }
}
