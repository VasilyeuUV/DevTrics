using DevTricks.ViewModels.Windows.AboutWindow;

namespace DevTricks.Views.Windows.AboutWindow
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : IAboutWindow
    {
        public AboutWindow(AboutWindowViewModel aboutWindowViewModel)
        {
            InitializeComponent();

            DataContext = aboutWindowViewModel;
        }
    }
}
