using DevTricks.Domain.Logging;

namespace DevTricks.ViewModels.DevTools
{
    /// <summary>
    /// Вьюмодель для отображения информации элемента лога
    /// </summary>
    public class LogEntryViewModel
    {
        /// <summary>
        /// Для сортировки логов по времени создания.
        /// </summary>
        public required DateTime Timestamp { get; init; }

        /// <summary>
        /// Время создания лога
        /// </summary>
        public required string TimestampValue { get; init; }

        /// <summary>
        /// Тип лога
        /// </summary>
        public required LogLevel LogLevel { get; init; }

        /// <summary>
        /// Имя логгера
        /// </summary>
        public required string LoggerName { get; init; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public required string Message { get; init; }

        /// <summary>
        /// Возможный стектрайс, если лог был об ошибке
        /// </summary>
        public string? StackTrace { get; init; }

        /// <summary>
        /// Флаг отображения информации из StackTrace
        /// </summary>
        public bool IsStackTraceVisible => StackTrace is not null;
    }
}
