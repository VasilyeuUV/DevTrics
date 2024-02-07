using DevTricks.Domain.Logging;
using System.Collections.ObjectModel;

namespace DevTricks.ViewModels.DevTools
{
    public class LogViewerViewModel : ILogViewerViewModel
    {
        private readonly ILogSubscriber _logSubscriber;
        private ObservableCollection<LogEntryViewModel> _logEntryViewModels;

        /// <summary>
        /// CTOR
        /// </summary>
        public LogViewerViewModel(ILogSubscriber logSubscriber)
        {
            this._logSubscriber = logSubscriber;
            this._logEntryViewModels = new ObservableCollection<LogEntryViewModel>();

            _logSubscriber.LogAdded += OnLogAdded;
        }


        /// <summary>
        /// Коллекция логов
        /// </summary>
        public IEnumerable<LogEntryViewModel> LogEntryViewModels => _logEntryViewModels;



        /// <summary>
        /// Обработчик события добавления лога
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnLogAdded(LogArgs args)
        {
            var logEntryViewModel = new LogEntryViewModel()
            { 
                LoggerName = args.LoggerName,
                Message = args.Message,
                LogLevel = args.LogLevel,
                Timestamp = $"{args.Timestamp.ToLongDateString()} {args.Timestamp.ToLongTimeString()}",
                StackTrace = args.StackTrace,
            };
            _logEntryViewModels.Add(logEntryViewModel);
        }




        //############################################################################################################
        #region ILogViewerViewModel

        public void Dispose()
        {
            _logSubscriber.LogAdded -= OnLogAdded;
        }

        #endregion // ILogViewerViewModel

    }
}
