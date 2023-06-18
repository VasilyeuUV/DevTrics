using DevTricks.ViewModels.Windows.AboutWindow;

namespace DevTricks.Views.Windows.AboutWindow
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : IAboutWindow
    {

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="aboutWindowViewModel"></param>
        public AboutWindow(IAboutWindowViewModel aboutWindowViewModel)
        {
            InitializeComponent();

            DataContext = aboutWindowViewModel;
        }
    }
}
