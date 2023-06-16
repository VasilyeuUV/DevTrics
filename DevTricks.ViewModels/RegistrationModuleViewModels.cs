using Autofac;
using DevTricks.ViewModels.Authors;
using DevTricks.ViewModels.Extensions;
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

            // - регистрация окон
            builder.RegisterViewModel<MainWindowViewModel, IMainWindowViewModel>();
            builder.RegisterViewModel<AboutWindowViewModel, IAboutWindowViewModel>();

            // - регистрация контекста главного окна
            builder.RegisterViewModel<AuthorCollectionViewModel, IAuthorCollectionViewModel>();
        }
    }
}
