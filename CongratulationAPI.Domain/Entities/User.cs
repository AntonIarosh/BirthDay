using CongratulationAPI.Contracts.Enums;
using CongratulationAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Domain.Entities
{
    /// <summary>
    /// Сущность пользователя
    /// </summary>
    public class User: EntityBase
    {
        /// <summary>
        /// Пол пользователя. 
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата Дня рождения
        /// </summary>
        [Required(ErrorMessage = "Укажите конкретную дату Дня рождения")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль для входа в систему
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// День рождения пользователя
        /// </summary>
        public BirthDay BirthDay { get; set; }

        /// <summary>
        /// Идентификатор Дня рождения
        /// </summary>
        public Guid BirthDayId { get; set; }

        /// <summary>
        /// Поздравляения пользователя
        /// </summary>
        public virtual ICollection<Congratulation> Congratulations { get; set; }

        /// <summary>
        /// Поздравляения пользователя
        /// </summary>
        public virtual ICollection<Congratulation> MyCongratulations { get; set; }

        /// <summary>
        /// Знакомые пользователя
        /// </summary>
        public virtual ICollection<Know> Knows { get; set; }

        /// <summary>
        /// Пользователи у которых я знакомый
        /// </summary>
        public virtual ICollection<Know> KnowsToMe { get; set; }
    }
}
