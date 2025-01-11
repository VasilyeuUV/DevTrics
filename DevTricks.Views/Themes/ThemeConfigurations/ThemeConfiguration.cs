using System.Windows.Media;
using DevTricks.ViewModels.Themes;

namespace DevTricks.Views.Themes.ThemeConfigurations;

/// <summary>
/// Базовый конфигуратор темы.
/// </summary>
internal abstract class ThemeConfiguration : IThemeConfiguration
{
    //#############################################################################################################################
    #region IThemeConfiguration

    public abstract Theme Theme { get; }


    public void Apply()
    {
        ThemeResources.Properties.PrimaryBackground = PrimaryBackground;
    }

    #endregion // IThemeConfiguration


    /// <summary>
    /// Основной бэкграунд контрола.
    /// </summary>
    protected abstract SolidColorBrush PrimaryBackground { get; }


    /// <summary>
    /// Создание кисти.
    /// </summary>
    /// <param name="color">Цвет кисти.</param>
    /// <param name="opacity">Уровень прозрачности.</param>
    /// <param name="isFrosen">Флаг неизменяемости кисти. Т.е. после определения можно запретить ее изменять.</param>
    /// <returns></returns>
    protected static SolidColorBrush CreateSolidColorBrush(Color color, double opacity = 1, bool isFrosen = true)
    {
        SolidColorBrush solidColorBrush = new SolidColorBrush(color)
        {
            Opacity = opacity,
        };

        if (isFrosen)
        {
            solidColorBrush.Freeze();
        }

        return solidColorBrush;
    }
}
