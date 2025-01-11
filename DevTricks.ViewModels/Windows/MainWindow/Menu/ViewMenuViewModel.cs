using DevTricks.Domain.Factories;

namespace DevTricks.ViewModels.Windows.MainWindow.Menu;

/// <summary>
/// Вьюмодель для Menu View
/// </summary>
public sealed class ViewMenuViewModel : IViewMenuViewModel
{
    /// <summary>
    /// CTOR
    /// </summary>
    public ViewMenuViewModel(IFactory<IThemesMenuViewModel> themesMenuViewModelFactory)
    {
        ThemesMenuViewModel = themesMenuViewModelFactory.Create();
    }



    //#############################################################################################################################
    #region IViewMenuViewModel

    public IThemesMenuViewModel ThemesMenuViewModel { get; }

    #endregion // IViewMenuViewModel
}
