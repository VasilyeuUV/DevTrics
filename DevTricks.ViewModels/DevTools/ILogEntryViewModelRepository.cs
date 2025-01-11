using DevTricks.Domain.Collections;

namespace DevTricks.ViewModels.DevTools;

/// <summary>
/// Контракт для независимого хранилища логов.
/// </summary>
public interface ILogEntryViewModelRepository
{
    /// <summary>
    /// Наполнение хранилища логов.
    /// </summary>
    IRotatebleReadOnlyCollection<LogEntryViewModel> Items { get; }

    /// <summary>
    /// Очистить хранилище логов.
    /// </summary>
    void Clear();
}
