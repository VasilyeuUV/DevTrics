namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowStatusBarViewModel
{
    /// <summary>
    /// Контракт для строки состояния главного окна
    /// </summary>
    public interface IMainWindowStatusBarViewModel : IDisposable
    {

        /// <summary>
        /// Версия приложения
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Текущая дата
        /// </summary>
        string CurrentDate { get; }

        /// <summary>
        /// Текущее время
        /// </summary>
        string CurrentTime { get; }
    }
}
