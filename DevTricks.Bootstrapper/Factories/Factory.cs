using Autofac;
using DevTricks.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.Bootstrapper.Factories
{
    /// <summary>
    /// Класс кастомной фабрики, которая может создавать любой объект, зарегистрированный в контейнере зависимостей
    /// </summary>
    internal class Factory<TResult> : IFactory<TResult>
    {
        private readonly IComponentContext _componentContext;       // - контекст контейнера зависимостей


        /// <summary>
        /// CTOR
        /// </summary>
        public Factory(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
        }


        //#############################################################################################################
        #region IFactory<TResult>

        public TResult Create()
        {
            var factory = _componentContext.Resolve<Func<TResult>>();
            return factory.Invoke();
        }

        #endregion // IFactory<TResult>

    }
}
