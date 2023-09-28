using DevTricks.Domain.Logging;

namespace DevTricks.Bootstrapper.Logging
{
    /// <summary>
    /// Контракт для логгера по отображению логов
    /// </summary>
    public interface ILogNotifier
    {
        void Notify(LogArgs args);
    }
}
