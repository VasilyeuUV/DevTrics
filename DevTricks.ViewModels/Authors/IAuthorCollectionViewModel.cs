using DevTricks.ViewModels.Windows.MainWindow;

namespace DevTricks.ViewModels.Authors
{
    /// <summary>
    /// Интерфейс для коллекции Авторов книг (для регистрации в контейнере)
    /// </summary>
    public interface IAuthorCollectionViewModel : IMainWindowContentViewModel          // - это контентная вьюмодель
    {

        /// <summary>
        /// Отвечает за инициализацию данных
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}
