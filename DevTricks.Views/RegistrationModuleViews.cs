using Autofac;
using DevTricks.Views.MainWindow;

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

            // Контейнер для регистрации
            builder.RegisterType<MainWindow.MainWindow>()   // - регистрируемый тип
                .As<IMainWindow>()                          // - контракт вьюшки (интерфейс, под которым регистрируем тип)
                .InstancePerDependency();                   // - время жизни вьюшки (такой же как и для вьюмодели)
        }
    }
}
