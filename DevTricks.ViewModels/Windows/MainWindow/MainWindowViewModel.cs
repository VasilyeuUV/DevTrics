using DevTricks.Domain.Settings.MainWindowSettings;
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
        private readonly IWindowManager _windowManager;                 // - менеджер окон
        private readonly IAboutWindowViewModel _aboutWindowViewModel;   // - вьюмодель окна "О программе"

        private Command _closeMainWindowCommand;
        private Command _openAboutWindowCommand;

        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(
            IMainWindowMementoWrapper mainWindowMementoWrapper,
            IWindowManager windowManager,
            IAboutWindowViewModel aboutWindowViewModel
            )
            : base(mainWindowMementoWrapper)
        {
            _windowManager = windowManager;
            this._aboutWindowViewModel = aboutWindowViewModel;

            // - Команды
            _closeMainWindowCommand = new Command(CloseMainWindow);
            _openAboutWindowCommand = new Command(OpenAboutWindow);
        }


        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title => "DevTriks";



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
        #region AWindowViewModelBase

        public override void WindowClosing()
        {
            _windowManager.Close(_aboutWindowViewModel);        // - закрытие окна "О программе"
        }

        #endregion // AWindowViewModelBase


        //############################################################################################################
        #region IMainWindowViewModel

        #endregion // IMainWindowViewModel


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
            _windowManager.Show(_aboutWindowViewModel);
        }
    }
}
