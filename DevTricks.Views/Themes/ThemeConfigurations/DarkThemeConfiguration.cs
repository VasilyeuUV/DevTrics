using System.Windows.Media;
using DevTricks.ViewModels.Themes;

namespace DevTricks.Views.Themes.ThemeConfigurations;

/// <summary>
/// Конфигурация темной темы.
/// </summary>
internal sealed class DarkThemeConfiguration : ThemeConfiguration
{
    public override Theme Theme => Theme.Dark;

    protected override SolidColorBrush PrimaryBackground => CreateSolidColorBrush(Color.FromRgb(0x1A, 0x1A, 0x1A));
}
