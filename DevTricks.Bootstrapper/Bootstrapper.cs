using Autofac;
using DevTricks.Infrastructure;
using DevTricks.Infrastructure.Common.Services.PathService;
using DevTricks.Infrastructure.Settings;
using DevTricks.ViewModels;
using DevTricks.ViewModels.MainWindow;
using DevTricks.ViewModels.Windows;
using DevTricks.Views;
using DevTricks.Views.MainWindow;
using System.Windows;

namespace DevTricks.Bootstrapper
{
    public class Bootstrapper : IDisposable
    {
        private IContainer _container;      // - контейнер зависимостей


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

            //// С помощью контейнера зарезолвим главное окно
            //// т.к. создана зависимость окна от VM, перед созданием окна контейнер создаст VM главного окна
            //// и использует его инстанс для создания главного окна
            //var mainWindow = _container.Resolve<IMainWindow>();

            // - после создания Менеджера окна
            var windowManager = _container.Resolve<IWindowManager>();               // - резолв менеджера окна
            var mainWindowViewModel = _container.Resolve<IMainWindowViewModel>();   // - резолв вьюможели главного окна
            var mainWindow = windowManager.Show(mainWindowViewModel);               // - создание и показ окна

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
            _container?.Dispose();      // - освобождаем контейнер
        }

        #endregion // IDisposable
    }
}
