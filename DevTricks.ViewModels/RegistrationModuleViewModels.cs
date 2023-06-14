using Autofac;
using DevTricks.ViewModels.MainWindow;
using DevTricks.ViewModels.Windows.AboutWindow;
using DevTricks.ViewModels.Windows.MainWindow;

namespace DevTricks.ViewModels
{
    public class RegistrationModuleViewModels : Module
    {

        /// <summary>
        /// Регистрация модулей при загрузке
        /// </summary>
        /// <param name="builder">Контейнер для регистрации</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MainWindowViewModel>()     // - регистрируемый тип
                .As<IMainWindowViewModel>()                 // - контрак вьюмодели (интерфейс, под которым регистрируем тип)
                .InstancePerDependency();                   // - время жизни вьюмодели (для каждого запроса будет создаваться новый экземпляр вьюмодели)

            builder.RegisterType<AboutWindowViewModel>()     
                .As<IAboutWindowViewModel>()                 
                .InstancePerDependency();                   
        }
    }
}
