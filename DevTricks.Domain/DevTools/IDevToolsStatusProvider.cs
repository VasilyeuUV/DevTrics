using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.Domain.DevTools
{
    /// <summary>
    /// Контракт для уведомления об использовании режима DevTools 
    /// (в режиме DEBUG - включен, иначе - выключен)
    /// При включенном режиме отображается дополнительный функционал для отладки приложения
    /// </summary>
    public interface IDevToolsStatusProvider
    {
        /// <summary>
        /// Флаг использования режима DevTools
        /// </summary>
        bool IsEnabled { get; }
    }
}
