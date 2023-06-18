using System.Windows;

namespace DevTricks.Bootstrapper
{
    /// <summary>
    /// Контракт для регистрации в контейнере
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Создание главного окна
        /// </summary>
        Window Run();
    }
}
