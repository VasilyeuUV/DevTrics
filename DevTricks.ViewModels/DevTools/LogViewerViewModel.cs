using DevTricks.Domain.Logging;

namespace DevTricks.ViewModels.DevTools
{
    public class LogViewerViewModel : ILogViewerViewModel
    {
        private readonly ILogEntryViewModelRepository _logEntryViewModelRepository;

        /// <summary>
        /// CTOR
        /// </summary>
        public LogViewerViewModel(ILogEntryViewModelRepository logEntryViewModelRepository)
        {
            _logEntryViewModelRepository = logEntryViewModelRepository;
        }


        /// <summary>
        /// Коллекция логов
        /// </summary>
        public IEnumerable<LogEntryViewModel> LogEntryViewModels => _logEntryViewModelRepository.Items;
    }
}
