using System.Windows.Threading;

namespace DevTricks.Bootstrapper.Logging
{
    /// <summary>
    /// Контракт обработки необработанных исключений
    /// </summary>
    public interface IUnhandledExceptionHandler
    {
        void Handle(DispatcherUnhandledExceptionEventArgs args);
    }
}
