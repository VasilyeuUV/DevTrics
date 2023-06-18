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
            var application = _bootstrapper.Createapplication();
            MainWindow = application.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper?.Dispose();

            base.OnExit(e);
        }
    }
}
