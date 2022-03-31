using CongratulationAPI.Contracts.Congratulation;
using CongratulationAPI.Contracts.User;
using System.Collections.Generic;

namespace CongratulationAPI.Contracts.BirthDay
{
    /// <summary>
    /// Модель представления сущности Дня рождения: BirthDay
    /// </summary>
    public class BirthDayDto: DtoBase
    {
        /// <summary>
        /// Клнкретный день даты Дня рождения
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Клнкретный месяц даты Дня рождения
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Флаг - прошёл ли День рождения сейчас или нет
        /// </summary>
        public bool IsPased { get; set; }

        /// <summary>
        /// Поздравления на этот День рождения 
        /// </summary>
        public virtual List<CongratulationDto> Congratulations { get; set; }

        /// <summary>
        /// Пользователи у которых День рождения в этот день
        /// </summary>
        public virtual List<UserDto> Users { get; set; }
    }
}
