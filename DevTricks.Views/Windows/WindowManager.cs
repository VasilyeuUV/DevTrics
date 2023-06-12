using DevTricks.ViewModels.Windows;
using DevTricks.Views.Factories;

namespace DevTricks.Views.Windows
{
    /// <summary>
    /// Менеджер окон
    /// </summary>
    internal class WindowManager : IWindowManager
    {        
        private readonly Dictionary<IWindowViewModel, IWindow> _viewModelToWindowMap = new();   // - кэш окон
        private readonly IWindowFactory _windowFactory;                                         // - фабрика окон


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="windowFactory">Фабрика окон</param>
        public WindowManager(IWindowFactory windowFactory)
        {
            this._windowFactory = windowFactory;
        }



        //############################################################################################################
        #region IWindowManager

        public void Close<TWindowViewModel>(TWindowViewModel viewModel) 
            where TWindowViewModel : IWindowViewModel
        {
            // - проверить наличие искомого окна в кэше
            if (_viewModelToWindowMap.TryGetValue(viewModel, out var window))
            {
                window.Close();
                _viewModelToWindowMap.Remove(viewModel);
            }
        }


        public IWindow Show<TWindowViewModel>(TWindowViewModel viewModel) 
            where TWindowViewModel : IWindowViewModel
        {
            var window = _windowFactory.Create(viewModel);      // - создаём окно при помощи фабрики
            _viewModelToWindowMap.Add(viewModel, window);       // - добавляем его в кэш
            window.Show();                                      // - показываем

            return window;
        }

        #endregion // IWindowManager
    }
}
