using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.Infrastructure
{
    public class Person : IDisposable
    {
        private const int JULIAN_CALENDAR_DIFFERENCE_DAYS = 13;     // - разница между юлианским и григорианским календарём

        private readonly DateOnly? _dateOfBirtn;

        private string _name;
        private string _sename;


        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get => _name; private set => _name = value; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Sename { get => _sename; set => _sename = value; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public DateOnly? DateOfBirtn => _dateOfBirtn;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="sename">Фамилия</param>
        /// <param name="dateOfBirn">Дата рождения</param>
        public Person(string name, string sename, string dateOfBirn)
        {
            _name = name;
            _sename = sename;
            _dateOfBirtn = InitDate(dateOfBirn);
        }


        //########################################################################################################
        #region INIT

        // инициализация полей и свойств класса (если необходимо)

        #endregion // INIT


        //########################################################################################################
        #region EVENTS

        // инициализация собфтий класса (если необходимо)

        #endregion // EVENTS


        #region MyRegion

        #endregion

        /// <summary>
        /// Получить дату
        /// </summary>
        /// <param name="dateOfBirn"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private DateOnly? InitDate(string dateOfBirn)
        {
            DateTime dateTime;
            return DateTime.TryParse(dateOfBirn, out dateTime)
                ? DateOnly.FromDateTime(dateTime)
                : null;
        }


        // РЕАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
        //########################################################################################################
        #region IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion // IDisposable



    }
}
