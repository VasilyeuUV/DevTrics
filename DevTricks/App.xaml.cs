using System.Windows;

namespace DevTricks
{
    public partial class App
    {
        private Bootstrapper.ApplicationBootstrapper? _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _bootstrapper = new Bootstrapper.ApplicationBootstrapper();

            DispatcherUnhandledException += OnUnhandledExceptionRaised;

            var application = _bootstrapper.Createapplication();
            MainWindow = application.Run();
        }


        /// <summary>
        /// Обработка получения необработанной ошибки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUnhandledExceptionRaised(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (_bootstrapper is null)
                return;

            var unhandledExceptionHandler = _bootstrapper.CreateUnhandledExceptionHandler();
            unhandledExceptionHandler.Handle(e);
        }


        protected override void OnExit(ExitEventArgs e)
        {
            DispatcherUnhandledException -= OnUnhandledExceptionRaised;

            _bootstrapper?.Dispose();

            base.OnExit(e);
        }
    }
}
