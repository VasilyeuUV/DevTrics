using DevTricks.Domain.DispatcherTimer;
using DevTricks.Domain.Factories;
using DevTricks.Domain.Settings.MainWindowSettings;
using DevTricks.Domain.Version;
using DevTricks.ViewModels.Authors;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.Windows.AboutWindow;
using DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel;
using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow
{
    /// <summary>
    /// Класс вьюмодели главного окна приложения
    /// </summary>
    public class MainWindowViewModel : AWindowViewModelBase<IMainWindowMementoWrapper>, IMainWindowViewModel
    {
        private readonly IWindowManager _windowManager;                                             // - менеджер окон

        private readonly IDispatcherTimer _dispatcherTimer;                                         // - таймер

        private IMainWindowContentViewModel? _contentViewModel;

        private string _currentDate = string.Empty;
        private string _currentTime = string.Empty;


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(
            IMainWindowMementoWrapper mainWindowMementoWrapper,
            IWindowManager windowManager,
            IApplicationVersionProvider applicationVersionProvider,
            IDispatcherTimerFactory dispatcherTimerFactory,
            IFactory<IMainWindowMenuViewModel> mainWindowMenuViewModelFactory
            )
            : base(mainWindowMementoWrapper)
        {
            this._windowManager = windowManager;

            this._dispatcherTimer = dispatcherTimerFactory.Create(TimeSpan.FromSeconds(1));
            this._dispatcherTimer.Tick += OnDispatcherTimerTick;
            this._dispatcherTimer.Start();

            Version = $"Version {applicationVersionProvider.Version.ToString(3)}";

            MenuViewModel = mainWindowMenuViewModelFactory.Create();
            MenuViewModel.MainWindowClosingRequested += OnMainWindowClosingRequested;
            MenuViewModel.ContentViewModelChanged += OnContentViewModelChanged;
        }


        //############################################################################################################
        #region AWindowViewModelBase

        public override void WindowClosing()
        {
            base.WindowClosing();

            MenuViewModel.CloseAboutWindow();       // - закрытие окна "О программе"
        }

        #endregion // AWindowViewModelBase


        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title => "DevTriks";


        public string Version { get; }


        /// <summary>
        /// Текущая дата
        /// </summary>
        public string CurrentDate
        {
            get => _currentDate;
            private set
            {
                _currentDate = value;
                InvokePropertyChanged(); // - имя свойства передаётся с помощью атрибута CallerMemberName в базовой вьюмодели
            }
        }


        /// <summary>
        /// Текущее время
        /// </summary>
        public string CurrentTime
        {
            get => _currentTime;
            private set
            {
                _currentTime = value;
                InvokePropertyChanged();
            }
        }


        /// <summary>
        /// Вьюмодель контента главного окна
        /// </summary>
        public IMainWindowContentViewModel? ContentViewModel
        {
            get => _contentViewModel;
            private set
            {
                _contentViewModel = value;
                InvokePropertyChanged();
            }
        }


        /// <summary>
        /// Вьюмодель меню главного окна
        /// </summary>
        public IMainWindowMenuViewModel MenuViewModel { get; }


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


        /// <summary>
        /// Действия на событие закрытия главного окна
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OnMainWindowClosingRequested()
        {
            _windowManager.Close(this);
        }


        /// <summary>
        /// Действие на изменение контента главного окна
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnContentViewModelChanged(IMainWindowContentViewModel contentViewModel)
        {
            ContentViewModel = contentViewModel;
        }

        #endregion // EVENTS


        //############################################################################################################
        #region IMainWindowViewModel


        public void Dispose()
        {
            MenuViewModel.MainWindowClosingRequested -= OnMainWindowClosingRequested;
            MenuViewModel.ContentViewModelChanged -= OnContentViewModelChanged;

            _dispatcherTimer.Tick -= OnDispatcherTimerTick;
        }

        #endregion // IMainWindowViewModel

    }
}
