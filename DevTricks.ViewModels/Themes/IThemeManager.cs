namespace DevTricks.ViewModels.Themes;

/// <summary>
/// Контракт менеджера, который отвечает за переключение цветовых тем.
/// </summary>
public interface IThemeManager      // - переключение тем будет осуществляться на viewmodel-ном слое, поэтому интерфейс здесь.
{
    /// <summary>
    /// Переключить тему.
    /// </summary>
    /// <param name="theme"></param>
    void SwitchTo(Theme theme);
}
