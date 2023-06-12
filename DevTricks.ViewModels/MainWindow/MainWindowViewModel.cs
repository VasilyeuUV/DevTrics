using DevTricks.Domain.Settings;
using DevTricks.ViewModels.Commands;
using DevTricks.ViewModels.Windows;
using System.Windows.Input;

namespace DevTricks.ViewModels.MainWindow
{
    /// <summary>
    /// Класс вьюмодели главного окна приложения
    /// </summary>
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IMainWindowMementoWrapper _mainWindowMementoWrapper;       // - Wrapper, откуда свойства будут получать значения
        private readonly IWindowManager _windowManager;                             // - менеджер окон

        private Command _closeMainWindowCommand;

        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(
            IMainWindowMementoWrapper mainWindowMementoWrapper,
            IWindowManager windowManager
            )
        {
            this._mainWindowMementoWrapper = mainWindowMementoWrapper;
            this._windowManager = windowManager;

            this._closeMainWindowCommand = new Command(CloseMainWindow);
        }


        //############################################################################################################
        #region Свойства окна

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title => "DevTriks";


        // Следуюшие будут читать и писать из Memento

        /// <summary>
        /// Координата окна по горизонтали
        /// </summary>
        public double Left
        {
            get => _mainWindowMementoWrapper.Left;
            set => _mainWindowMementoWrapper.Left = value; 
        }

        /// <summary>
        /// Координата окна по вертикали
        /// </summary>
        public double Top
        {
            get => _mainWindowMementoWrapper.Top;
            set => _mainWindowMementoWrapper.Top = value;
        }

        /// <summary>
        /// Ширина окна
        /// </summary>
        public double Width
        {
            get => _mainWindowMementoWrapper.Width;
            set => _mainWindowMementoWrapper.Width = value;
        }

        /// <summary>
        /// Высота окна
        /// </summary>
        public double Height
        {
            get => _mainWindowMementoWrapper.Height;
            set => _mainWindowMementoWrapper.Height = value;
        }

        /// <summary>
        /// Флаг состояния окна развёрнутого в полный экран (true)
        /// </summary>
        public bool IsMaximized
        {
            get => _mainWindowMementoWrapper.IsMaximized;
            set => _mainWindowMementoWrapper.IsMaximized = value;
        }

        #endregion // Свойства окна



        //############################################################################################################
        #region Команды

        /// <summary>
        /// Свойство для команды закрытия главного окна
        /// </summary>
        public ICommand CloseMainWindowCommand => _closeMainWindowCommand;

        #endregion // Команды


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
    }
}
