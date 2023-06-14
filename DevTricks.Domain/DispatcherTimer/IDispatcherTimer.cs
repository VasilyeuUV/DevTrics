namespace DevTricks.Domain.DispatcherTimer
{
    /// <summary>
    /// Контракт таймера
    /// </summary>
    public interface IDispatcherTimer
    {
        /// <summary>
        /// Событие счета времени таймера 
        /// </summary>
        event EventHandler Tick;


        /// <summary>
        /// Старт отсчета времени
        /// </summary>
        void Start();
    }
}
