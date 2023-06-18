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

        private string _currentDate = string.Empty;
        private string _currentTime = string.Empty;

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
            CurrentDate = DateTime.Now.ToShortDateString();
            CurrentTime = DateTime.Now.ToLongTimeString();
        }

        #endregion // EVENTS


        //############################################################################################################
        #region IMainWindowStatusBarViewModel

        public string Version { get; }

        public string CurrentDate
        {
            get => _currentDate;
            private set
            {
                _currentDate = value;
                InvokePropertyChanged(); // - имя свойства передаётся с помощью атрибута CallerMemberName в базовой вьюмодели
            }
        }

        public string CurrentTime
        {
            get => _currentTime;
            private set
            {
                _currentTime = value;
                InvokePropertyChanged();
            }
        }

        public void Dispose()
        {
            _dispatcherTimer.Tick -= OnDispatcherTimerTick;
        }

        #endregion // IMainWindowStatusBarViewModel
    }
}
