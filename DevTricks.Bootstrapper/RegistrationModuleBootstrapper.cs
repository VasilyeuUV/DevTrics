using Autofac;
using DevTricks.Bootstrapper.Factories;
using DevTricks.Domain.Factories;
using DevTricks.Views.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace DevTricks.Bootstrapper
{
    /// <summary>
    /// Регистрационный модуль 
    /// </summary>
    public class RegistrationModuleBootstrapper : Module
    {

        //############################################################################################################
        #region Module

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // - Регистрация фабрики окон
            builder.RegisterType<WindowFactory>()
                .As<IWindowFactory>()
                .SingleInstance();

            // - Регистрация фабрики generic-объектов
            builder.RegisterGeneric(typeof(Factory<>))      // - в качестве параметра - тип класса фабрики без указания generic-типа
                .As(typeof(IFactory<>))                     // - интерфейсная часть
                .SingleInstance();

            // - Создание и регистрации фабрики Клиента для работы с RestApi (для использования http-запросов)
            builder.Register( _ =>
                {
                    var serviceProvider = new ServiceCollection()
                        .AddHttpClient()
                        .BuildServiceProvider();
                    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                    return httpClientFactory;
                })
                .SingleInstance();
        }

        #endregion // Module
    }
}
