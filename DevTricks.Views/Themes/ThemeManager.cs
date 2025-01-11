using System.Collections.Frozen;
using DevTricks.ViewModels.Themes;

namespace DevTricks.Views.Themes;

/// <summary>
/// Менеджер, который отвечает за переключение цветовых тем.
/// </summary>
internal sealed class ThemeManager : IThemeManager
{
    /// <summary>
    /// Словарь конфигураций тем.
    /// </summary>
    private FrozenDictionary<Theme, IThemeConfiguration> _themeConfigurations;

    /// <summary>
    /// CTOR
    /// </summary>
    public ThemeManager(IEnumerable<IThemeConfiguration> themeConfigurations)
    {
        _themeConfigurations = themeConfigurations.ToFrozenDictionary(configuration => configuration.Theme);
    }

    //#############################################################################################################################
    #region IThemeManager

    public void SwitchTo(Theme theme)
    {
        // - при наличии конфигурации, переключаемся на нее.
        if (_themeConfigurations.TryGetValue(theme, out IThemeConfiguration? themeConfiguration))
        {
            themeConfiguration.Apply();
        }
    }

    #endregion // IThemeManager
}
