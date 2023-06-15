namespace DevTricks.Domain.Rest
{
    /// <summary>
    /// Контракт для взаимодействия с RestApi
    /// </summary>
    public interface IApiRequestExecutor
    {
        /// <summary>
        /// Получение данных с Api
        /// </summary>
        /// <typeparam name="TResponce">Generic-тип</typeparam>
        /// <param name="request">Адрес endpoint</param>
        /// <returns>Generic-тип</returns>
        Task<TResponce> GetAsync<TResponce>(string request);
    }
}
