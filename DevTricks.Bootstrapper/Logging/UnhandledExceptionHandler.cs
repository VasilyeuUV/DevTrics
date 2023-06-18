using NLog;
using System.Windows.Threading;

namespace DevTricks.Bootstrapper.Logging
{
    internal class UnhandledExceptionHandler : IUnhandledExceptionHandler
    {
        private static readonly ILogger Logger = LogManager.GetLogger(nameof(UnhandledExceptionHandler));       // - логгер


        //######################################################################################################################
        #region IUnhandledExceptionHandler

        public void Handle(DispatcherUnhandledExceptionEventArgs args)
        {
            args.Handled = true;                // - сообщаем подсистеме WPF, что обработали возникшее исключение
            Logger.Error(args.Exception);       // - логирование ошибки и передача Exception
        }

        #endregion // IUnhandledExceptionHandler

    }
}
