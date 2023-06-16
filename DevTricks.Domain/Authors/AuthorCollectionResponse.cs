namespace DevTricks.Domain.Authors
{
    /// <summary>
    /// Коллекции для Авторов, полцчаемых с API
    /// </summary>
    public class AuthorCollectionResponse
    {
        /// <summary>
        /// Список авторов, получаемых с API
        /// </summary>
        public required IEnumerable<AuthorModelResponse> Items { get; init; }
    }
}
