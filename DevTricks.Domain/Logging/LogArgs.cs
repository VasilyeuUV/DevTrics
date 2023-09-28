namespace DevTricks.Domain.Logging
{
    /// <summary>
    /// Модель характеристик лога
    /// </summary>
    public class LogArgs
    {
        /// <summary>
        /// Время создания лога
        /// </summary>
        public required DateTime Timestamp { get; init; }

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
    }
}
