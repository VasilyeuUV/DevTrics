using DevTricks.ViewModels.Windows;
using DevTricks.Views.Factories;

namespace DevTricks.Views.Windows
{
    /// <summary>
    /// Менеджер окон
    /// - отвечает за:
    /// -- жизненный цикл окна
    /// </summary>
    internal class WindowManager : IWindowManager
    {        
        private readonly Dictionary<IWindowViewModel, IWindow> _viewModelToWindowMap = new();   // - карта соответствия вьюмоделей окнам (кэш окон)
        private readonly Dictionary<IWindow, IWindowViewModel> _windowToViewModelMap = new();   // - карта соответствия окон вьюмоделям (кэш вьюмоделей)


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


        /// <summary>
        /// Инициация закрытия окна
        /// </summary>
        /// <typeparam name="TWindowViewModel"></typeparam>
        /// <param name="viewModel"></param>
        public void Close<TWindowViewModel>(TWindowViewModel viewModel) 
            where TWindowViewModel : IWindowViewModel
        {
            // - проверить наличие искомого окна в кэше
            if (_viewModelToWindowMap.TryGetValue(viewModel, out var window))
                window.Close();

        }


        public IWindow Show<TWindowViewModel>(TWindowViewModel viewModel) 
            where TWindowViewModel : IWindowViewModel
        {
            var window = _windowFactory.Create(viewModel);      // - создаём окно при помощи фабрики

            _viewModelToWindowMap.Add(viewModel, window);       // - добавляем его в кэш
            _windowToViewModelMap.Add(window, viewModel);       // - и в обратный кэш

            window.Closing += OnWindowClosing;                  // - подписываемся на событие перед закрытием окна
            window.Closed += OnWindowClosed;                    // - подписываемся на событие при закрытии окна

            window.Show();                                      // - показываем

            return window;
        }


        #endregion // IWindowManager


        /// <summary>
        /// Действия перед закрытием окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnWindowClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is IWindow window                                            // - проверка, что sender реализует IWindow
                && _windowToViewModelMap.TryGetValue(window, out var viewModel)     // - находим вьюмодель
                )
                viewModel.WindowClosing();
        }


        /// <summary>
        /// Действия при закрытии окна (должен отвечать за отписку и удаление данных из кэша)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnWindowClosed(object? sender, EventArgs e)
        {
            if (sender is IWindow window                                            // - проверка, что sender реализует IWindow
                && _windowToViewModelMap.TryGetValue(window, out var viewModel)     // - находим вьюмодель
                )
            {
                window.Closing -= OnWindowClosing;              // - отписываемся от события окна перед закрытием
                window.Closed -= OnWindowClosed;                // - отписываемся от события при закрытии окна

                // - удаление данных из кэша
                _viewModelToWindowMap.Remove(viewModel);        
                _windowToViewModelMap.Remove(window);
            }
        }
    }
}
