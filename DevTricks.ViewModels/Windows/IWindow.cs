using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.ViewModels.Windows
{
    /// <summary>
    /// Контракт для работы с окнами
    /// </summary>
    public interface IWindow
    {

        /// <summary>
        /// Показ окна
        /// </summary>
        void Show();


        /// <summary>
        /// Закрытие окна
        /// </summary>
        void Close();
    }
}
