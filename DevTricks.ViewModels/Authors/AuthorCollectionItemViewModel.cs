namespace DevTricks.ViewModels.Authors
{

    /// <summary>
    /// Вьюмодель элемента коллекции авторов книг
    /// </summary>
    public class AuthorCollectionItemViewModel
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public AuthorCollectionItemViewModel(
            string firstName,
            string lastName,
            DateOnly birthDay
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = $"({birthDay.ToShortDateString()})";
        }


        /// <summary>
        /// Имя Автора
        /// </summary>
        public string FirstName { get; }


        /// <summary>
        /// Фамилия Автора
        /// </summary>
        public string LastName { get; }


        /// <summary>
        /// Год рождения Автора
        /// </summary>
        public string BirthDay { get; }
    }
}
