using Autofac;
using DevTricks.Domain.Settings;
using DevTricks.Infrastructure.Settings;

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
                .As<IMainWindowMementoWrapperInitializer>()
                .SingleInstance();
            // это значит, что контейнер сможет зарезолвить оба интерфейса и для обоих вернет один и тот же инстанс враппера,
            // но инстанс будет ограничен теми членами, которые описаны в интерфейсах  
        }
    }
}
