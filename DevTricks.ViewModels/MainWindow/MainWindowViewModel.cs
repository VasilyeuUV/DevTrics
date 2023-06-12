using DevTricks.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DevTricks.ViewModels.MainWindow
{
    /// <summary>
    /// Класс вьюмодели главного окна приложения
    /// </summary>
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IMainWindowMementoWrapper _mainWindowMementoWrapper;       // - Wrapper, откуда свойства будут получать значения


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(IMainWindowMementoWrapper mainWindowMementoWrapper)
        {
            this._mainWindowMementoWrapper = mainWindowMementoWrapper;
        }


        //############################################################################################################
        #region Свойства окна

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title => "DevTriks";


        // Следуюшие будут читать и писать из Memento

        /// <summary>
        /// Координата окна по горизонтали
        /// </summary>
        public double Left
        {
            get => _mainWindowMementoWrapper.Left;
            set => _mainWindowMementoWrapper.Left = value; 
        }

        /// <summary>
        /// Координата окна по вертикали
        /// </summary>
        public double Top
        {
            get => _mainWindowMementoWrapper.Top;
            set => _mainWindowMementoWrapper.Top = value;
        }

        /// <summary>
        /// Ширина окна
        /// </summary>
        public double Width
        {
            get => _mainWindowMementoWrapper.Width;
            set => _mainWindowMementoWrapper.Width = value;
        }

        /// <summary>
        /// Высота окна
        /// </summary>
        public double Height
        {
            get => _mainWindowMementoWrapper.Height;
            set => _mainWindowMementoWrapper.Height = value;
        }

        /// <summary>
        /// Флаг состояния окна развёрнутого в полный экран (true)
        /// </summary>
        public bool IsMaximized
        {
            get => _mainWindowMementoWrapper.IsMaximized;
            set => _mainWindowMementoWrapper.IsMaximized = value;
        }

        #endregion // Свойства окна


        //############################################################################################################
        #region IMainWindowViewModel

        #endregion // IMainWindowViewModel
    }
}
