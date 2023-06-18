namespace DevTricks.Domain.Authors
{
    /// <summary>
    /// Модель Автора, получаемая из API
    /// </summary>
    public class AuthorModelResponse
    {
        /// <summary>
        /// Идентификатор Автора
        /// </summary>
        public required int Id { get; init; }


        /// <summary>
        /// Имя Автора
        /// </summary>
        public required string FirstName { get; init; }


        /// <summary>
        /// Фамилия Автора
        /// </summary>
        public required string LastName { get; init; }


        /// <summary>
        /// Год рождения Автора
        /// </summary>
        public required DateOnly BirthDay{ get; init; }

    }
}
