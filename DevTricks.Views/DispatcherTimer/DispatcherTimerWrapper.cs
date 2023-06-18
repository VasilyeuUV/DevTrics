using DevTricks.Domain.DispatcherTimer;

namespace DevTricks.Views.DispatcherTimer
{
    /// <summary>
    /// Оболочка для Таймера
    /// </summary>
    internal class DispatcherTimerWrapper : System.Windows.Threading.DispatcherTimer, IDispatcherTimer
    {
    }
}
