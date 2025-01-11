using Autofac;
using DevTricks.ViewModels.Authors;
using DevTricks.ViewModels.DevTools;
using DevTricks.ViewModels.Extensions;
using DevTricks.ViewModels.Windows.AboutWindow;
using DevTricks.ViewModels.Windows.MainWindow;
using DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel;
using DevTricks.ViewModels.Windows.MainWindow.MainWindowMenuViewModel.DevToolsMenuViewModel;
using DevTricks.ViewModels.Windows.MainWindow.MainWindowStatusBarViewModel;
using DevTricks.ViewModels.Windows.MainWindow.Menu;

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

            // - регистрация вьюмоделей главного окна
            builder.RegisterViewModel<AuthorCollectionViewModel, IAuthorCollectionViewModel>();             // - контент главного окна
            builder.RegisterViewModel<MainWindowMenuViewModel, IMainWindowMenuViewModel>();                 // - меню главного окна
            builder.RegisterViewModel<MainWindowStatusBarViewModel, IMainWindowStatusBarViewModel>();       // - строка состояния главного окна
            builder.RegisterViewModel<DevToolsMenuViewModel, IDevToolsMenuViewModel>();                     // - пункты меню DevTools
            builder.RegisterViewModel<LogViewerViewModel, ILogViewerViewModel>();                           // - отображение логов в контентной части
            builder.RegisterViewModel<ThemesMenuViewModel, IThemesMenuViewModel>();                         // - вьюмодель меню переключения темы приложения
            builder.RegisterViewModel<ViewMenuViewModel, IViewMenuViewModel>();                             // - вьюмодель меню

        }
    }
}
