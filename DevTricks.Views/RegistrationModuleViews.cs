using Autofac;
using DevTricks.Domain.DispatcherTimer;
using DevTricks.ViewModels.Windows;
using DevTricks.Views.DispatcherTimer;
using DevTricks.Views.Windows;
using DevTricks.Views.Windows.AboutWindow;
using DevTricks.Views.Windows.MainWindow;

namespace DevTricks.Views
{
    /// <summary>
    /// Класс регистрации в контейнере вью-сборки
    /// </summary>
    public class RegistrationModuleViews : Module
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder">Контейнер для регистрации</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<WindowManager>()           // - регистрация менеджера окна
                .As<IWindowManager>()
                .SingleInstance();

            builder.RegisterType<MainWindow>()              // - регистрируемый тип (главное окно)
                .As<IMainWindow>()                          // - контракт вьюшки (интерфейс, под которым регистрируем тип)
                .InstancePerDependency();                   // - время жизни вьюшки (такой же как и для вьюмодели)
            builder.RegisterType<AboutWindow>()             // - регистрация окна "О программе" 
                .As<IAboutWindow>()                          
                .InstancePerDependency();
            builder.RegisterType<DispatcherTimerWrapperFactory>()  // - регистрация фабрики Таймера
                .As<IDispatcherTimerFactory>()
                .SingleInstance();

        }
    }
}
