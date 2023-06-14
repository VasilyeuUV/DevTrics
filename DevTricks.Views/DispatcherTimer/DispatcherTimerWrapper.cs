using DevTricks.Domain.DispatcherTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.Views.DispatcherTimer
{
    /// <summary>
    /// Оболочка для Таймера
    /// </summary>
    internal class DispatcherTimerWrapper : System.Windows.Threading.DispatcherTimer, IDispatcherTimer
    {
    }
}
