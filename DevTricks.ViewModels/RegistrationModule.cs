using Autofac;
using DevTricks.ViewModels.MainWindow;

namespace DevTricks.ViewModels
{
    public class RegistrationModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Контейнер для регистрации
            builder.RegisterType<MainWindowViewModel>()     // - регистрируемый тип
                .As<IMainWindowViewModel>()                 // - контрак вьюмодели (интерфейс, под которым регистрируем тип)
                .InstancePerDependency();                   // - время жизни вьюмодели (для каждого запроса будет создаваться новый экземпляр вьюмодели)
        }
    }
}
