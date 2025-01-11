using DevTricks.ViewModels.Themes;

namespace DevTricks.Views.Themes;

/// <summary>
/// Контракт для конфигурации тем.
/// </summary>
internal interface IThemeConfiguration
{
    /// <summary>
    /// Тема.
    /// </summary>
    Theme Theme { get; }

    /// <summary>
    /// Применить тему.
    /// </summary>
    void Apply();
}
