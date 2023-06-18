using DevTricks.Domain.DispatcherTimer;
using DevTricks.Domain.Version;

namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowStatusBarViewModel
{
    /// <summary>
    /// Вьюмодель строки состояния главного окна
    /// </summary>
    public class MainWindowStatusBarViewModel : AViewModelBase, IMainWindowStatusBarViewModel
    {
        private readonly IDispatcherTimer _dispatcherTimer;             // - таймер

        //private string _currentDate = string.Empty;
        //private string _currentTime = string.Empty;

        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowStatusBarViewModel(
            IApplicationVersionProvider applicationVersionProvider,
            IDispatcherTimerFactory dispatcherTimerFactory
            )
        {
            Version = $"Version {applicationVersionProvider.Version.ToString(3)}";

            this._dispatcherTimer = dispatcherTimerFactory.Create(TimeSpan.FromSeconds(1));
            this._dispatcherTimer.Tick += OnDispatcherTimerTick;
            this._dispatcherTimer.Start();
        }


        //############################################################################################################
        #region EVENTS

        /// <summary>
        /// Действия на счёт таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnDispatcherTimerTick(object? sender, EventArgs e)
        {
            InvokePropertyChanged(nameof(CurrentDate));
            InvokePropertyChanged(nameof(CurrentTime));
        }

        #endregion // EVENTS


        //############################################################################################################
        #region IMainWindowStatusBarViewModel

        public string Version { get; }
        public string CurrentDate => DateTime.Now.ToShortDateString();
        public string CurrentTime => DateTime.Now.ToLongTimeString();


        public void Dispose()
        {
            _dispatcherTimer.Tick -= OnDispatcherTimerTick;
        }

        #endregion // IMainWindowStatusBarViewModel
    }
}
