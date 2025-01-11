using DevTricks.Domain.Collections;
using DevTricks.Domain.Logging;

namespace DevTricks.ViewModels.DevTools;

/// <summary>
/// Независимое хранилище логов.
/// </summary>
internal class LogEntryViewModelRepository : ILogEntryViewModelRepository, IDisposable
{
    private readonly IRotatableCollection<LogEntryViewModel> _items;
    private readonly ILogSubscriber _logSubscriber;                                 // - для реагирования хранилища на появление новых логов.


    /// <summary>
    /// CTOR
    /// </summary>
    public LogEntryViewModelRepository(IRotatableCollectionFactory rotatableCollectionFactory,
        ILogSubscriber logSubscriber
        )
    {
        _items = rotatableCollectionFactory.Create<LogEntryViewModel>(capacity: 1000);

        _logSubscriber = logSubscriber;
        _logSubscriber.LogAdded += OnLogAdded;
    }



    //############################################################################################################
    #region ILogEntryViewModelRepository

    public IRotatebleReadOnlyCollection<LogEntryViewModel> Items => _items;

    public void Clear()
    {
        _items.Clear();
    }

    #endregion // ILogEntryViewModelRepository



    //############################################################################################################
    #region IDisposable

    public void Dispose()
    {
        _logSubscriber.LogAdded -= OnLogAdded;
    }

    #endregion // IDisposable


    /// <summary>
    /// Обработчик события добавления лога
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnLogAdded(LogArgs args)
    {
        LogEntryViewModel logEntryViewModel = new()
        {
            Timestamp = args.Timestamp,
            LoggerName = args.LoggerName,
            Message = args.Message,
            LogLevel = args.LogLevel,
            TimestampValue = args.Timestamp.ToString("F"),
            StackTrace = args.StackTrace,
        };
        _items.Add(logEntryViewModel);
    }
}

