using DevTricks.Domain.Rest;
using Newtonsoft.Json;

namespace DevTricks.Infrastructure.Rest
{
    /// <summary>
    /// Сервис для взаимодействия с RestApi
    /// </summary>
    internal class ApiRequestExecutor : IApiRequestExecutor
    {
        private readonly IHttpClientFactory _httpClientFactory;             // - фабрика Http-клиента
        private readonly Uri _baseAdress = new("http://localhost:5000");    // - базовый адрес Rest-сервиса (хостится из Docker-контейнера)


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="httpClientFactory">Фабрика Http-клиента</param>
        public ApiRequestExecutor(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }


        //##################################################################################################################
        #region IApiRequestExecutor

        public async Task<TResponce> GetAsync<TResponce>(string request)
        {
            using var httpClient = _httpClientFactory.CreateClient();               // - создать Http-клиент
            httpClient.BaseAddress = _baseAdress;
            
            var httpResponseMessage = await httpClient.GetAsync(request);           // - выполнение запроса
            var content = await httpResponseMessage.Content.ReadAsStringAsync();    // - читаем контент (json-документ)
            var response = JsonConvert.DeserializeObject<TResponce>(content);       // - десериализация в generic-тип

            if (response != null)
                return response;

            throw new InvalidOperationException("Response can't be null");
        }

        #endregion // IApiRequestExecutor
    }
}
