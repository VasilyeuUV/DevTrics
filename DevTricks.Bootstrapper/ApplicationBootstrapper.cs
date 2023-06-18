using Autofac;
using DevTricks.Bootstrapper.Logging;
using DevTricks.Bootstrapper.Services.PathService;

namespace DevTricks.Bootstrapper
{
    public class ApplicationBootstrapper : IDisposable
    {
        private readonly IContainer _container;


        /// <summary>
        /// CTOR
        /// </summary>
        public ApplicationBootstrapper()
        {            
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);

            this._container = containerBuilder.Build();

            InitializeDependencies();
        }


        /// <summary>
        /// Получение instanse класса Application
        /// </summary>
        /// <returns>зарезолвленный instance</returns>
        public IApplication Createapplication()
        {
            return _container.Resolve<IApplication>();
        }


        /// <summary>
        /// Создань обработчик необработанных ошибок
        /// </summary>
        /// <returns></returns>
        public IUnhandledExceptionHandler CreateUnhandledExceptionHandler()
        {
            return _container.Resolve<IUnhandledExceptionHandler>();
        }



        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <param name="containerBuilder"></param>
        private void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Application>().As<IApplication>().SingleInstance();
            containerBuilder.RegisterType<PathService>().As<IPathService>().As<IPathServiceInitializer>().SingleInstance();
            containerBuilder.RegisterType<UnhandledExceptionHandler>().As<IUnhandledExceptionHandler>().SingleInstance();       // - для системы логгирования
            containerBuilder.RegisterType<LogManagerInitializer>().As<ILogManagerInitializer>().SingleInstance();               // - система логгирования
        }


        /// <summary>
        /// Инициализация зависимостей
        /// </summary>
        private void InitializeDependencies()
        {
            _container.Resolve<IPathServiceInitializer>().Initialize();                 // - инициализация сервиса PathService
            _container.Resolve<ILogManagerInitializer>();                               // - инициализация Логгера
        }


        //############################################################################################################
        #region IDisposable

        public void Dispose()
        {
            _container?.Dispose();
        }

        #endregion // IDisposable

    }
}
