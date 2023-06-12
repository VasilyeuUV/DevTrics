﻿using Autofac;
using DevTricks.ViewModels.MainWindow;
using DevTricks.ViewModels.Windows;
using DevTricks.Views.Factories;
using DevTricks.Views.MainWindow;

namespace DevTricks.Bootstrapper.Factories
{
    /// <summary>
    /// Фабрика окон (отвечает за создание окна из ViewModel)
    /// </summary>
    internal class WindowFactory : IWindowFactory
    {
        private readonly IComponentContext _componentContext;       // - контекст Autofac

        // - карта соответсвия (словарь),  в котором ключ - Тип вьюмодели, значение - Тип окна
        // (по мере добавления окон в приложение, регистрировать их здесь)
        private readonly Dictionary<Type, Type> _map = new ()
        {
            { typeof(IMainWindowViewModel), typeof(IMainWindow) }
        };


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="componentContext">Контекст Autofac</param>
        public WindowFactory(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
        }


        //############################################################################################################
        #region IWindowFactory

        public IWindow Create<TWindowViewModel>(TWindowViewModel viewModel) 
            where TWindowViewModel : IWindowViewModel
        {
            // - проверка, существует ли тип, переданный в карте соответствия
            if (!_map.TryGetValue(typeof(TWindowViewModel, out var windowType))
                throw new InvalidOperationException($"There is no window registered for {typeof(TWindowViewModel)}");

            // по типу, извлекаем (резолвим) окно из контейнера
            // (т.к. конструктор окна зависит от вьюмодели, вторым параметром передаём её резолверу)
            var instance = _componentContext.Resolve(windowType, TypedParameter.From(viewModel));
            
            return (IWindow) instance;      // - мы гарантируем, что все окна приложения реализуют IWindow, поэтому явно приводим к этому типу
        }

        #endregion // IWindowFactory

    }
}