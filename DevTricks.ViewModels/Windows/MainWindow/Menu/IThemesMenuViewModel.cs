using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow.Menu;

/// <summary>
/// Контракт для вьюмодели меню переключения тем.
/// </summary>
public interface IThemesMenuViewModel
{
    /// <summary>
    /// Команда для установления светлой темы приложения.
    /// </summary>
    ICommand SetLightThemeCommand { get; }

    /// <summary>
    /// Команда для установления темной темы приложения.
    /// </summary>
    ICommand SetDarkThemeCommand { get; }
}
