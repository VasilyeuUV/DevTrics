using Autofac;
using DevTricks.ViewModels.Windows;
using DevTricks.Views.MainWindow;
using DevTricks.Views.Windows;

namespace DevTricks.Views
{
    /// <summary>
    /// Класс регистрации в контейнере вью-сборки
    /// </summary>
    public class RegistrationModuleViews : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<WindowManager>()           // - регистрация менеджера окна
                .As<IWindowManager>()
                .SingleInstance();

            // Контейнер для регистрации
            builder.RegisterType<MainWindow.MainWindow>()   // - регистрируемый тип (главное окно)
                .As<IMainWindow>()                          // - контракт вьюшки (интерфейс, под которым регистрируем тип)
                .InstancePerDependency();                   // - время жизни вьюшки (такой же как и для вьюмодели)


        }
    }
}
