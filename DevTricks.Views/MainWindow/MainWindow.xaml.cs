using DevTricks.ViewModels.MainWindow;

namespace DevTricks.Views.MainWindow
{
    public partial class MainWindow : IMainWindow
    {

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="mainWindowViewModel">Контракт главного окна. 
        /// Экземляр окна нельзя будет создать, не передав вьюмодель. 
        /// Т.е. главное окно зависит от вьюмодели главного окна
        /// </param>
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            // Переданная вьюмодель является контекстом данных для окна.
            DataContext = mainWindowViewModel;
        }


        //################################################################################################
        #region IMainWindow

        #endregion // IMainWindow
    }
}
