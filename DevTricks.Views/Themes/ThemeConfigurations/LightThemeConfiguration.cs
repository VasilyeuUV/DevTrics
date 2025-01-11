using System.Windows.Media;
using DevTricks.ViewModels.Themes;

namespace DevTricks.Views.Themes.ThemeConfigurations;

/// <summary>
/// Конфигурация темной темы.
/// </summary>
internal sealed class LightThemeConfiguration : ThemeConfiguration
{
    public override Theme Theme => Theme.Light;

    protected override SolidColorBrush PrimaryBackground => CreateSolidColorBrush(Color.FromRgb(0xF3, 0xF3, 0xF3));
}
