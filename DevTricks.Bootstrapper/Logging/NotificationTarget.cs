using DevTricks.Domain.Logging;
using NLog;
using NLog.Targets;
using LogLevel = DevTricks.Domain.Logging.LogLevel;

namespace DevTricks.Bootstrapper.Logging
{
    /// <summary>
    /// Target, который уведомляет Notifier щ появлении новых логов
    /// </summary>
    internal class NotificationTarget : Target
    {
        private readonly ILogNotifier _logNotifier;

        /// <summary>
        /// CTOR
        /// </summary>
        public NotificationTarget(ILogNotifier logNotifier)
        {
            this._logNotifier = logNotifier;
        }


        //############################################################################################################
        #region Target

        /// <summary>
        /// Будет вызываться при каждом логгировании
        /// </summary>
        /// <param name="logEvent">Информация о логе</param>
        protected override void Write(LogEventInfo logEvent)
        {
            var logArgs = new LogArgs()
            {
                LogLevel = ToLocal(logEvent.Level),
                LoggerName = logEvent.LoggerName ?? "noname",
                Message = logEvent.FormattedMessage,
                Timestamp = logEvent.TimeStamp,
                StackTrace = logEvent.Exception?.StackTrace
            };
            _logNotifier.Notify(logArgs);
        }


        #endregion // Target


        private static LogLevel ToLocal(NLog.LogLevel logLevel) =>
            logLevel.Name switch
            {
                "Fatal" => LogLevel.Fatal,
                "Error" => LogLevel.Error,
                "Warn" => LogLevel.Warn,
                _ => LogLevel.Info,
            };

    }
}
