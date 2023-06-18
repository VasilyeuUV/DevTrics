using Autofac;
using DevTricks.Domain.Factories;
using DevTricks.Infrastructure;
using DevTricks.Infrastructure.Settings;
using DevTricks.ViewModels;
using DevTricks.ViewModels.Windows;
using DevTricks.ViewModels.Windows.MainWindow;
using DevTricks.Views;
using NLog;
using System.Windows;

namespace DevTricks.Bootstrapper
{
    internal class Application : IApplication, IDisposable
    {
        private static readonly ILogger Logger = LogManager.GetLogger(nameof(Application));       // - логгер

        private readonly ILifetimeScope _applicationLifetimeScope;      // - в качестве контейнера зависимостей, определяет время жизни объектов в контейнере
        private IMainWindowViewModel? _mainWindowViewModel;             // - вьюмодель главного окна приложения


        /// <summary>
        /// CTOR
        /// </summary>
        public Application(ILifetimeScope lifetimeScope)
        {
            Logger.Info("Created");

            // - этот класс будет зависеть от root-ового LifetimeScope (все остальные зависимости приложения будут создаваться в дочернем)
            this._applicationLifetimeScope = lifetimeScope.BeginLifetimeScope(RegisterDependencies);
        }


        /// <summary>
        /// Регистрация модулей в контейнере зависимостей
        /// </summary>
        /// <param name="containerBuilder"></param>
        private static void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            // Регистрация существующих модулей
            containerBuilder
                .RegisterModule<RegistrationModuleInfrastructure>()
                .RegisterModule<RegistrationModuleBootstrapper>()
                .RegisterModule<RegistrationModuleViews>()
                .RegisterModule<RegistrationModuleViewModels>();
        }


        /// <summary>
        /// Инициализация зависимостей
        /// </summary>
        private void InitializeDependencies()
        {
            // - получение коллекции Wrapper-ов
            var windowMementoWrapperInitializers = _applicationLifetimeScope.Resolve<IEnumerable<IWindowMementoWrapperInitializer>>();
            foreach (var windowMementoWrapperInitializer in windowMementoWrapperInitializers)
                windowMementoWrapperInitializer.Initialize();                           // - инициализация Wrapper-а Memento окна приложения   
        }


        //#################################################################################################################
        #region IApplication

        public Window Run()
        {
            InitializeDependencies();                                                                   // - инициализация зависимостей

            var windowManager = _applicationLifetimeScope.Resolve<IWindowManager>();                    // - резолв менеджера окна

            // - резолвим фабрику для вьюмодели главного окна
            var mainWindowViewModelFactory = _applicationLifetimeScope.Resolve<IFactory<IMainWindowViewModel>>();
            this._mainWindowViewModel = mainWindowViewModelFactory.Create();                            // - создаём вьюмодель главного окна с помощью фабрики
            
            var mainWindow = windowManager.Show(this._mainWindowViewModel);                             // - создание и показ окна

            // Проверим, кстится ли это к классу Window. Если нет, то exception
            if (mainWindow is not Window window)
                throw new NotImplementedException();

            return window;
        }

        #endregion // IApplication


        //#################################################################################################################
        #region IDisposable

        public void Dispose()
        {
            _mainWindowViewModel?.Dispose();            // - освобождаем вьюмодель главного окна
            _applicationLifetimeScope?.Dispose();       // - освобождаем контейнер

            Logger.Info("Disposed");
        }

        #endregion // IDisposable
    }
}
