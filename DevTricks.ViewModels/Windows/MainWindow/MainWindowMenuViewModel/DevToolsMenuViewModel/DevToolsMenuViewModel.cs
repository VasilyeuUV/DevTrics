using DevTricks.Domain.DevTools;
using DevTricks.Domain.Factories;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.DevTools;
using NLog;
using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel.DevToolsMenuViewModel
{
    /// <summary>
    /// Вьюмодель пунктов меню режима DevTools
    /// </summary>
    public class DevToolsMenuViewModel : IDevToolsMenuViewModel
    {
        private static readonly ILogger _logger = LogManager.GetLogger(nameof(DevToolsMenuViewModel));

        private readonly IDevToolsStatusProvider _devToolsStatusProvider;
        private readonly IFactory<ILogViewerViewModel> _logViewverViewModelFactory;

        private readonly Command _throwExceptionCommand;                     // - команда имитации исключительной ситуации
        private readonly Command _openLogViewerCommand;                      // - команда открытия логвьювера


        /// <summary>
        /// CTOR
        /// </summary>
        public DevToolsMenuViewModel(
            IDevToolsStatusProvider devToolsStatusProvider,
            IFactory<ILogViewerViewModel> logViewerViewModelFactory,
            ILogEntryViewModelRepository logEntryViewModelRepository
            )
        {
            this._devToolsStatusProvider = devToolsStatusProvider;
            this._logViewverViewModelFactory = logViewerViewModelFactory;

            _throwExceptionCommand = new Command(() => throw new Exception("Test exception"));
            _openLogViewerCommand = new Command(OpenLogViewer);

            WriteInfoLogCommand = new Command(() => _logger.Info("Testing info log"));
            WriteWarnLogCommand = new Command(() => _logger.Warn("Testing warning log"));
            WriteErrorLogCommand = new Command(() => _logger.Error("Testing error log"));
            WriteFatalLogCommand = new Command(() => _logger.Fatal("Testing fatal log"));
            ClearLogsLogCommand = new Command(logEntryViewModelRepository.Clear);
        }


        /// <summary>
        /// Открыть LogViewer
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OpenLogViewer()
        {
            var logViewerViewModel = _logViewverViewModelFactory.Create();
            ContentViewModelChanged?.Invoke(logViewerViewModel);
        }


        //############################################################################################################
        #region IDevToolsMenuViewModel

        public event Action<IMainWindowContentViewModel>? ContentViewModelChanged;

        public bool IsVisible => _devToolsStatusProvider.IsEnabled;

        public ICommand ThrowExceptionCommand => _throwExceptionCommand;
        public ICommand OpenLogViewerCommand => _openLogViewerCommand;
        public ICommand WriteInfoLogCommand { get; }
        public ICommand WriteWarnLogCommand { get; }
        public ICommand WriteErrorLogCommand { get; }
        public ICommand WriteFatalLogCommand { get; }
        public ICommand ClearLogsLogCommand { get; }

        #endregion // IDevToolsMenuViewModel
    }
}
