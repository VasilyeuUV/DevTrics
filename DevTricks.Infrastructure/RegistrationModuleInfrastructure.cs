using Autofac;
using DevTricks.Domain.Collections;
using DevTricks.Domain.DevTools;
using DevTricks.Domain.Rest;
using DevTricks.Domain.Settings.AboutWindowSettings;
using DevTricks.Domain.Settings.MainWindowSettings;
using DevTricks.Domain.Version;
using DevTricks.Infrastructure.Collections;
using DevTricks.Infrastructure.DevTools;
using DevTricks.Infrastructure.Rest;
using DevTricks.Infrastructure.Settings;
using DevTricks.Infrastructure.Settings.AboutWindowSettings;
using DevTricks.Infrastructure.Settings.MainWindowSettings;
using DevTricks.Infrastructure.Version;

namespace DevTricks.Infrastructure
{
    /// <summary>
    /// Регистрационный модуль контейнера зависимостей в Информтруктуре
    /// </summary>
    public class RegistrationModuleInfrastructure : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // - Регистрация Wrapper главного окна под двумя интерфейсами
            builder.RegisterType<MainWindowMementoWrapper>()
                .As<IMainWindowMementoWrapper>()
                .As<IWindowMementoWrapperInitializer>()
                .SingleInstance();
            // это значит, что контейнер сможет зарезолвить оба интерфейса и для обоих вернет один и тот же инстанс враппера,
            // но инстанс будет ограничен теми членами, которые описаны в интерфейсах  

            // - Регистрация Оболочки окна "О программе"
            builder.RegisterType<AboutWindowMementoWrapper>()
                .As<IAboutWindowMementoWrapper>()
                .As<IWindowMementoWrapperInitializer>()
                .SingleInstance();

            // - Регистрация провайдера версии приложения
            builder.RegisterType<ApplicationVersionProvider>()
                .As<IApplicationVersionProvider>()
                .SingleInstance();

            // - Регистрация RestApiExecutor
            builder.RegisterType<ApiRequestExecutor>()
                .As<IApiRequestExecutor>()
                .SingleInstance();

            // - Регистрация провайдера режима DevTools
            builder.RegisterType<DevToolsStatusProvider>()
                .As<IDevToolsStatusProvider>()
                .SingleInstance();

            // - Регистрация перезаписываемой коллекции
            builder.RegisterType<RotatableCollectionFactory>()
                .As<IRotatableCollectionFactory>()
                .SingleInstance();

        }
    }
}
