using DevTricks.Domain.Logging;

namespace DevTricks.Bootstrapper.Logging
{
    /// <summary>
    /// Модель посредника для логгера
    /// </summary>
    internal class LogNotifier : ILogNotifier, ILogSubscriber
    {

        //#################################################################################################################
        #region ILogNotifier

        public void Notify(LogArgs args)
        {
            LogAdded?.Invoke(args);
        }

        #endregion // ILogNotifier


        //#################################################################################################################
        #region ILogSubscriber

        public event Action<LogArgs>? LogAdded;


        #endregion // ILogSubscriber

    }
}
