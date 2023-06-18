using DevTricks.Domain.Authors;
using DevTricks.Domain.Rest;

namespace DevTricks.ViewModels.Authors
{
    /// <summary>
    /// Вьюмодель для коллекции Авторов книг
    /// </summary>
    public class AuthorCollectionViewModel : IAuthorCollectionViewModel
    {
        private readonly IApiRequestExecutor _apiRequestExecutor;       // - для выполнения Rest-запросов


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="apiRequestExecutor">для выполнения REST-запросов</param>
        public AuthorCollectionViewModel(IApiRequestExecutor apiRequestExecutor)
        {
            this._apiRequestExecutor = apiRequestExecutor;
        }


        /// <summary>
        /// Свойство для элементов коллекции (только перебор)
        /// </summary>
        public IEnumerable<AuthorCollectionItemViewModel> Items { get; private set; }
            = Enumerable.Empty<AuthorCollectionItemViewModel>();


        //############################################################################################################
        #region IAuthorCollectionViewModel

        public async Task InitializeAsync()
        {
            // - запрос авторов с эндпоинта, получим десериализованный response
            var authorCollectionResponse = await _apiRequestExecutor.GetAsync<AuthorCollectionResponse>("author/all");

            // - трансляция получeнных элементов в массив вьюмодели в свойство Items (временно)
            this.Items = authorCollectionResponse.Items
                .Select(response => new AuthorCollectionItemViewModel(response.FirstName, response.LastName, response.BirthDate))
                .ToArray();
        }

        #endregion // IAuthorCollectionViewModel

    }
}
