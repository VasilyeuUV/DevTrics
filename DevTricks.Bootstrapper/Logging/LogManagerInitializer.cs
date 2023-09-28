using DevTricks.Infrastructure.Common;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace DevTricks.Bootstrapper.Logging
{
    /// <summary>
    /// Инициализатор логгера
    /// </summary>
    internal class LogManagerInitializer : ILogManagerInitializer, IDisposable
    {
        private readonly IPathService _pathService;
        private readonly ILogNotifier _logNotifier;

        /// <summary>
        /// CTOR
        /// </summary>
        public LogManagerInitializer(
            IPathService pathService,
            ILogNotifier logNotifier
            )
        {
            this._pathService = pathService;
            this._logNotifier = logNotifier;
            var loggingConfiguration = CreateLoggingConfiguration();
            LogManager.Configuration = loggingConfiguration;
        }


        /// <summary>
        /// Настройка конфигурации логгера
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private LoggingConfiguration CreateLoggingConfiguration()
        {
            var logginConfiguration = new LoggingConfiguration();

            var appLoggingRule = CreateAppLogingRule();
            logginConfiguration.AddRule(appLoggingRule);

            var notificationLoggingRule = CreateNotificationLoggingRule();
            logginConfiguration.AddRule(notificationLoggingRule);

            return logginConfiguration;
        }


        /// <summary>
        /// Правила конфигурации 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private LoggingRule CreateAppLogingRule()
        {
            // - файловый таргет, отвечает за запись логов в файл
            var appLogFileTarget = new FileTarget()
            {
                FileName = Path.Combine(_pathService.ApplicationFolder, "Logs", "app.log")      // - путь к файлу
            };

            // - асинхронный target, позволяет накапливать и асинхронно записывать пакет логов
            var asyncTargetWrapper = new AsyncTargetWrapper(appLogFileTarget)
            {
                TimeToSleepBetweenBatches = 1000                                                // - задержка между записями в лог-файл
            };

            // - "*" - правило применяется ко всем логгерам в приложении
            // - Info - минимальный уровень логов для этого правила
            var loggingRule = new LoggingRule("*", LogLevel.Info, asyncTargetWrapper);
            return loggingRule;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private LoggingRule CreateNotificationLoggingRule()
        {
            var notificationTarget = new NotificationTarget(_logNotifier);
            var notificationLoggingRule = new LoggingRule("*", LogLevel.Info, notificationTarget);
            return notificationLoggingRule;
        }



        //######################################################################################################################
        #region IDisposable

        public void Dispose()
        {
            LogManager.Flush();         // - сбросит все закэшированные логи в файл
            LogManager.Shutdown();
        }

        #endregion // IDisposable
    }
}
