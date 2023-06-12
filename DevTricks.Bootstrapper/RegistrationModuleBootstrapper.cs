using Autofac;
using DevTricks.Bootstrapper.Factories;
using DevTricks.Views.Factories;

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

            builder.RegisterType<WindowFactory>()
                .As<IWindowFactory>()
                .SingleInstance();
        }

        #endregion // Module
    }
}
