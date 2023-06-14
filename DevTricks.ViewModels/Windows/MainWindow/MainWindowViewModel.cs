﻿using DevTricks.Domain.DispatcherTimer;
using DevTricks.Domain.Factories;
using DevTricks.Domain.Settings.MainWindowSettings;
using DevTricks.Domain.Version;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.Windows.AboutWindow;
using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow
{
    /// <summary>
    /// Класс вьюмодели главного окна приложения
    /// </summary>
    public class MainWindowViewModel : AWindowViewModelBase<IMainWindowMementoWrapper>, IMainWindowViewModel
    {
        private readonly IWindowManager _windowManager;                                 // - менеджер окон
        private readonly IFactory<IAboutWindowViewModel> _aboutWindowViewModelFactory;  // - фабрика для вьюмодели окна "О программе"
        private readonly IDispatcherTimer _dispatcherTimer;                             // - таймер

        private IAboutWindowViewModel? _aboutWindowViewModel;                           // - вьюмодель окна "О программе"

        private Command _closeMainWindowCommand;
        private Command _openAboutWindowCommand;
        private string _currentDate;
        private string _currentTime;


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(
            IMainWindowMementoWrapper mainWindowMementoWrapper,
            IWindowManager windowManager,
            IApplicationVersionProvider applicationVersionProvider,
            IDispatcherTimerFactory dispatcherTimerFactory,
            IFactory<IAboutWindowViewModel> aboutWindowViewModelFactory
            )
            : base(mainWindowMementoWrapper)
        {
            _windowManager = windowManager;
            this._aboutWindowViewModelFactory = aboutWindowViewModelFactory;

            this._dispatcherTimer = dispatcherTimerFactory.Create(TimeSpan.FromSeconds(1));
            this._dispatcherTimer.Tick += OnDispatcherTimerTick;
            this._dispatcherTimer.Start();

            // - Команды
            _closeMainWindowCommand = new Command(CloseMainWindow);
            _openAboutWindowCommand = new Command(OpenAboutWindow);

            Version = $"Version {applicationVersionProvider.Version.ToString(3)}";
        }


        //############################################################################################################
        #region AWindowViewModelBase

        public override void WindowClosing()
        {
            base.WindowClosing();

            if (_aboutWindowViewModel != null)
                _windowManager.Close(_aboutWindowViewModel);        // - закрытие окна "О программе"
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
                InvokePropertyChanged(nameof(CurrentDate));
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
                InvokePropertyChanged(nameof(CurrentTime));
            }
        }


        //############################################################################################################
        #region Команды

        /// <summary>
        /// Свойство для команды закрытия главного окна
        /// </summary>
        public ICommand CloseMainWindowCommand => _closeMainWindowCommand;


        /// <summary>
        /// Свойство для открытия окна "О программе"
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public ICommand OpenAboutWindowCommand => _openAboutWindowCommand;


        #endregion // Команды


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
        /// Действия на событие закрытия окна "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnAboutWindowClosed(object? sender, EventArgs e)
        {
            // - отписываемся от события и обнуляем текущщий экземпдяр вьюмодел
            if (sender is IWindow window)
            {
                window.Closed -= OnAboutWindowClosed;
                _aboutWindowViewModel = null;
            }
        }

        #endregion // EVENTS


        /// <summary>
        /// Закрыть главное окно
        /// </summary>
        /// <param name=""></param>
        private void CloseMainWindow()
        {
            _windowManager.Close(this);
        }


        /// <summary>
        /// Открыть окно "О программе"
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OpenAboutWindow()
        {
            if (_aboutWindowViewModel == null)
            {
                _aboutWindowViewModel = _aboutWindowViewModelFactory.Create();
                var aboutWindow = _windowManager.Show(_aboutWindowViewModel);
                aboutWindow.Closed += OnAboutWindowClosed;
                return;
            }
            else
            {
                _windowManager.Show(_aboutWindowViewModel);
            }

        }


        //############################################################################################################
        #region IMainWindowViewModel


        public void Dispose()
        {
            _dispatcherTimer.Tick -= OnDispatcherTimerTick;
        }

        #endregion // IMainWindowViewModel

    }
}