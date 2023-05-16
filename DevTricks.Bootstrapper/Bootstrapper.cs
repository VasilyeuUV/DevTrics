using DevTricks.Views;
using System.Windows;

namespace DevTricks.Bootstrapper
{
    public class Bootstrapper : IDisposable
    {

        /// <summary>
        /// Создание главного окна
        /// </summary>
        /// <returns></returns>
        public Window Run()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            return mainWindow;
        }


        //#################################################################################################################
        #region IDisposable

        public void Dispose()
        {

        }

        #endregion // IDisposable
    }
}
