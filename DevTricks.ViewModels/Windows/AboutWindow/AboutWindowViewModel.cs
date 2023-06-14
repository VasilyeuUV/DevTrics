using DevTricks.Domain.Settings.AboutWindowSettings;

namespace DevTricks.ViewModels.Windows.AboutWindow
{
    /// <summary>
    /// Вьюмодель окна "О программе"
    /// </summary>
    public class AboutWindowViewModel : AWindowViewModelBase<IAboutWindowMementoWrapper>, IAboutWindowViewModel
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="windowMementoWrapper"></param>
        public AboutWindowViewModel(IAboutWindowMementoWrapper windowMementoWrapper) 
            : base(windowMementoWrapper)
        {
        }
    }
}
