using Autofac;
using DevTricks.ViewModels;
using DevTricks.Views;
using DevTricks.Views.MainWindow;
using System.Windows;

namespace DevTricks.Bootstrapper
{
    public class Bootstrapper : IDisposable
    {
        private IContainer _container;      // - контейнер зависимостей

        public Bootstrapper()
        {
            var containerBuilder = new ContainerBuilder();

            // Регистрация существующих модулей
            containerBuilder
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
            // С помощью контейнера зарезолвим главное окно
            // т.к. создана зависимость окна от VM, перед созданием окна контейнер создаст VM главного окна
            // и использует его инстанс для создания главного окна
            var mainWindow = _container.Resolve<IMainWindow>();

            // Проверим, кстится ли это к классу Window. Если нет, то exception
            if (mainWindow is not Window window)
                throw new NotImplementedException();

            window.Show();
            return window;
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
