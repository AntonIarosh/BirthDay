using CongratulationAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CongratulationAPI.Domain.Entities
{
    /// <summary>
    /// Сущность Дня рождения пользователя 
    /// </summary>
    public class BirthDay: EntityBase
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
        public virtual ICollection<Congratulation> Congratulations { get; set; }

        /// <summary>
        /// Пользователи у которых День рождения в этот день
        /// </summary>
        public virtual ICollection<User> Users { get; set; }


    }
}
