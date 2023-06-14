namespace DevTricks.Domain.DispatcherTimer
{
    /// <summary>
    /// Контракт для фабрики Таймера
    /// </summary>
    public interface IDispatcherTimerFactory
    {
        /// <summary>
        /// Создание таймера
        /// </summary>
        /// <param name="interval">Интервал для таймера</param>
        /// <returns></returns>
        IDispatcherTimer Create(TimeSpan interval);
    }
}
