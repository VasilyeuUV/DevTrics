using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel.DevToolsMenuViewModel
{
    /// <summary>
    /// Контракт для пунктов меню режима DevTools
    /// </summary>
    public interface IDevToolsMenuViewModel
    {
        /// <summary>
        /// Событие изменения контента главного окна
        /// </summary>
        event Action<IMainWindowContentViewModel> ContentViewModelChanged;

        /// <summary>
        /// Флаг видимости пункта меню
        /// </summary> 
        bool IsVisible { get; }


        /// <summary>
        /// Команда для вызова исключительной ситуации (для тестирования)
        /// </summary>
        ICommand ThrowExceptionCommand { get; }

        /// <summary>
        /// Команда открытия Логвьювера
        /// </summary>
        ICommand OpenLogViewerCommand { get; }

        /// <summary>
        /// Команда записи информационного лога
        /// </summary>
        ICommand WriteInfoLogCommand { get; }

        /// <summary>
        /// Команда записи лога Внимание
        /// </summary>
        ICommand WriteWarnLogCommand { get; }

        /// <summary>
        /// Команда записи лога Ошибка
        /// </summary>
        ICommand WriteErrorLogCommand { get; }

        /// <summary>
        /// Команда записи лога Фатальная ошибка
        /// </summary>
        ICommand WriteFatalLogCommand { get; }

    }
}
