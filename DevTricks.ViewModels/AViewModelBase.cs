using System.ComponentModel;

namespace DevTricks.ViewModels
{
    /// <summary>
    /// Базовый класс вьюмодели
    /// </summary>
    public abstract class AViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Метод для удобства использования Потребителями 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //############################################################################################################
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion // INotifyPropertyChanged
    }
}
