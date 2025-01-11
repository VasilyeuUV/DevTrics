using System.Windows.Input;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.Themes;

namespace DevTricks.ViewModels.Windows.MainWindow.Menu;

/// <summary>
/// Вьюмодель меню переключения тем.
/// </summary>
public sealed class ThemesMenuViewModel : IThemesMenuViewModel
{
    private readonly IThemeManager _themeManager;               // - менеджер тем.


    /// <summary>
    /// CTOR
    /// </summary>
    public ThemesMenuViewModel(IThemeManager themeManager)
    {
        _themeManager = themeManager;

        SetLightThemeCommand = new Command(SetLightTheme);
        SetDarkThemeCommand = new Command(SetDarkTheme);
    }



    //#############################################################################################################################
    #region IThemesMenuViewModel

    public ICommand SetLightThemeCommand { get; }

    public ICommand SetDarkThemeCommand { get; }

    #endregion // IThemesMenuViewModel


    /// <summary>
    /// Установить светлую тему приложения.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void SetLightTheme()
        => _themeManager.SwitchTo(Theme.Light);


    /// <summary>
    /// Установить темную тему приложения.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void SetDarkTheme()
        => _themeManager.SwitchTo(Theme.Dark);
}
