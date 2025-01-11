using DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel.DevToolsMenuViewModel;
using DevTricks.ViewModels.Windows.MainWindow.Menu;
using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel
{
    /// <summary>
    /// Контракт для меню главного окна
    /// </summary>
    public interface IMainWindowMenuViewModel : IDisposable
    {
        /// <summary>
        /// Для уведомления о закрытии главного окна
        /// </summary>
        event Action? MainWindowClosingRequested;

        /// <summary>
        /// Для уведомления о создании нового контента
        /// (интерфейс для контента для уведомления главного окна, что был создан контент)
        /// </summary>
        event Action<IMainWindowContentViewModel>? ContentViewModelChanged;


        /// <summary>
        /// Команда закрытия главного окна
        /// </summary>
        ICommand CloseMainWindowCommand { get; }

        /// <summary>
        /// Команда на открытие окна "О программе"
        /// </summary>
        ICommand OpenAboutWindowCommand { get; }

        /// <summary>
        /// Команда получения авторов книг от API
        /// </summary>
        ICommand OpenAuthorCollectionCommand { get; }



        /// <summary>
        /// Вьюмодель пунктов меню режима DevTools
        /// </summary>
        IDevToolsMenuViewModel DevToolsMenuViewModel { get; }

        /// <summary>
        /// Вьюмодель меню переключения тем приложения.
        /// </summary>
        IViewMenuViewModel ViewMenuViewModel { get; }



        /// <summary>
        /// Закрытие окна "О программе"
        /// </summary>
        void CloseAboutWindow();
    }
}
