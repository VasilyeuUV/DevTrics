using DevTricks.Domain.Factories;
using DevTricks.ViewModels.Authors;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.Windows.AboutWindow;
using DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel.DevToolsMenuViewModel;
using DevTricks.ViewModels.Windows.MainWindow.Menu;
using System.Windows.Input;

namespace DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel
{
    /// <summary>
    /// ViewModel меню главного окна
    /// </summary>
    public class MainWindowMenuViewModel : IMainWindowMenuViewModel
    {
        private readonly IWindowManager _windowManager;                                             // - менеджер окон

        // - вьюмодели
        private IAboutWindowViewModel? _aboutWindowViewModel;                                       // - вьюмодель окна "О программе"

        // - фабрики
        private readonly IFactory<IAboutWindowViewModel> _aboutWindowViewModelFactory;              // - фабрика для вьюмодели окна "О программе"
        private readonly IFactory<IAuthorCollectionViewModel> _authorCollectionViewModelFactory;    // - фабрика вьюмодели коллекции авторов

        // - команды
        private readonly Command _closeMainWindowCommand;                    // - команда закрытия главного окна
        private readonly Command _openAboutWindowCommand;                    // - команда открытия окна "О программе"
        private readonly AsyncCommand _openAuthorCollectionCommand;          // - команда для получения коллекции Авторов


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowMenuViewModel(
            IWindowManager windowManager,
            IFactory<IAboutWindowViewModel> aboutWindowViewModelFactory,
            IFactory<IAuthorCollectionViewModel> authorCollectionViewModelFactory,
            IFactory<IDevToolsMenuViewModel> devToolsMenuViewModelFactory,
            IFactory<IViewMenuViewModel> viewMenuViewModelFactory
            )
        {
            this._windowManager = windowManager;
            this._aboutWindowViewModelFactory = aboutWindowViewModelFactory;
            this._authorCollectionViewModelFactory = authorCollectionViewModelFactory;

            DevToolsMenuViewModel = devToolsMenuViewModelFactory.Create();
            ViewMenuViewModel = viewMenuViewModelFactory.Create();

            _closeMainWindowCommand = new Command(CloseMainWindow);
            _openAboutWindowCommand = new Command(OpenAboutWindow);
            _openAuthorCollectionCommand = new AsyncCommand(OpenAuthorCollectionAsync);

            DevToolsMenuViewModel.ContentViewModelChanged += OnContentViewModelChanged;
        }



        //######################################################################################################################
        #region EVENTS

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


        /// <summary>
        /// Обработчик события изменения контента главного окна
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnContentViewModelChanged(IMainWindowContentViewModel contentViewModel)
        {
            /*
            Запускаем собственное событие.
            Когда DevTools создаст контент и запустит событие, оно заставит MainVindowViewModel среагировать на это событие
            и запустить своё событие, на которое среогиро=ует вьюмодель главного окна и отобразит нужный контент.
            */
            ContentViewModelChanged?.Invoke(contentViewModel);
        }


        #endregion // EVENTS


        /// <summary>
        /// Закрытие главного окна
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CloseMainWindow()
        {
            MainWindowClosingRequested?.Invoke();
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


        /// <summary>
        /// Получение списка авторов книг
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task OpenAuthorCollectionAsync()
        {
            var authorCollectionViewModel = _authorCollectionViewModelFactory.Create();
            await authorCollectionViewModel.InitializeAsync();                          // - здесь отработает логика запроса данных от REST-сервиса

            ContentViewModelChanged?.Invoke(authorCollectionViewModel);
        }


        //######################################################################################################################
        #region IMainWindowMenuViewModel

        public event Action? MainWindowClosingRequested;
        public event Action<IMainWindowContentViewModel>? ContentViewModelChanged;


        public IDevToolsMenuViewModel DevToolsMenuViewModel { get; }
        public IViewMenuViewModel ViewMenuViewModel { get; }


        public ICommand CloseMainWindowCommand => _closeMainWindowCommand;
        public ICommand OpenAboutWindowCommand => _openAboutWindowCommand;
        public ICommand OpenAuthorCollectionCommand => _openAuthorCollectionCommand;


        public void CloseAboutWindow()
        {
            if (_aboutWindowViewModel != null)
                _windowManager.Close(_aboutWindowViewModel);        // - закрытие окна "О программе"
        }


        public void Dispose()
        {
            DevToolsMenuViewModel.ContentViewModelChanged -= OnContentViewModelChanged;

        }

        #endregion // IMainWindowMenuViewModel
    }
}
