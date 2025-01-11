using System.Windows;
using System.Windows.Media;

namespace DevTricks.Views.Themes;

/// <summary>
/// Хранилище для тем.
/// </summary>
internal sealed class ThemeProperties : DependencyObject        // - DependencyObject - чтобы определять свойства зависимостей.
{
    //#############################################################################################################################
    #region Свойство зависимостей PrimaryBackground

    /// <summary>
    /// Кисть для заполнения элементов сплошным цветом.
    /// </summary>
    public SolidColorBrush PrimaryBackground
    {
        get { return (SolidColorBrush)GetValue(PrimaryBackgroundProperty); }
        set { SetValue(PrimaryBackgroundProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PrimaryBackgroundProperty =
        DependencyProperty.Register(
            nameof(PrimaryBackground),
            typeof(SolidColorBrush),
            typeof(ThemeProperties),
            //new PropertyMetadata(default(SolidColorBrush))                // - решение по умолчанию
            new FrameworkPropertyMetadata(default(SolidColorBrush))         // - предполагаем, что контролы не будут изменять это свойство,
                                                                            // поэтому для экономии ресурсов отключаем двунаправленный биндинг, используем этот класс
            {
                BindsTwoWayByDefault = false,                               // - отключение двунаправленного биндинга
            }
            );

    #endregion // Свойство зависимостей PrimaryBackground
}
