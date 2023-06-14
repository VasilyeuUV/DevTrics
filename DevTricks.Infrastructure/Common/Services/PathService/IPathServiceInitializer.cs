namespace DevTricks.Infrastructure.Common.Services.PathService
{
    /// <summary>
    /// Контракт для инициализации сервиса работы с путями к файлам и каталогам (для Bootstrapper-а)
    /// </summary>
    public interface IPathServiceInitializer
    {
        /// <summary>
        /// Инициализировать сервис
        /// </summary>
        void Initialize();
    }
}
