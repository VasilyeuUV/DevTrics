using Autofac;
using DevTricks.Domain.Factories;
using DevTricks.Infrastructure;
using DevTricks.Infrastructure.Common.Services.PathService;
using DevTricks.Infrastructure.Settings;
using DevTricks.ViewModels;
using DevTricks.ViewModels.Windows;
using DevTricks.ViewModels.Windows.MainWindow;
using DevTricks.Views;
using System.Windows;

namespace DevTricks.Bootstrapper
{
    public class Bootstrapper : IDisposable
    {
        private IContainer _container;                          // - контейнер зависимостей

        private IMainWindowViewModel? _mainWindowViewModel;      // - вьюмодель клавного окна приложения

        /// <summary>
        /// CTOR
        /// </summary>
        public Bootstrapper()
        {
            var containerBuilder = new ContainerBuilder();

            // Регистрация существующих модулей
            containerBuilder
                .RegisterModule<RegistrationModuleInfrastructure>()
                .RegisterModule<RegistrationModuleBootstrapper>()
                .RegisterModule<RegistrationModuleViews>()
                .RegisterModule<RegistrationModuleViewModels>();

            _container = containerBuilder.Build();
        }


        /// <summary>
        /// Создание главного окна
        /// </summary>
        /// <returns></returns>
        public Window Run()
        {
            InitializeDependencies();                   // - инициализация зависимостей

            var windowManager = _container.Resolve<IWindowManager>();                   // - резолв менеджера окна

            // - резолвим фабрику для вьюмодели главного окна
            var mainWindowViewModelFactory = _container.Resolve<IFactory<IMainWindowViewModel>>();
            this._mainWindowViewModel = mainWindowViewModelFactory.Create();                            // - создаём вьюмодель главного окна с помощью фабрики
            var mainWindow = windowManager.Show(this._mainWindowViewModel);                             // - создание и показ окна

            // Проверим, кстится ли это к классу Window. Если нет, то exception
            if (mainWindow is not Window window)
                throw new NotImplementedException();

            return window;
        }


        /// <summary>
        /// Инициализация зависимостей
        /// </summary>
        private void InitializeDependencies()
        {
            _container.Resolve<IPathServiceInitializer>().Initialize();                 // - инициализация сервиса PathService

            // - получение коллекции Wrapper-ов
            var windowMementoWrapperInitializers = _container.Resolve<IEnumerable<IWindowMementoWrapperInitializer>>();
            foreach (var windowMementoWrapperInitializer in windowMementoWrapperInitializers)
                windowMementoWrapperInitializer.Initialize();                           // - инициализация Wrapper-а Memento окна приложения   
        }


        //#################################################################################################################
        #region IDisposable

        public void Dispose()
        {
            _mainWindowViewModel?.Dispose();    // - освобождаем вьюмодель главного окна
            _container?.Dispose();              // - освобождаем контейнер
        }

        #endregion // IDisposable
    }
}
