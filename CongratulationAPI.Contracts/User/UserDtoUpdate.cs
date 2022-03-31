using CongratulationAPI.Contracts.Enums;
using System;

namespace CongratulationAPI.Contracts.User
{
    public class UserDtoUpdate : DtoBase
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
        /// Идентификатор Дня рождения
        /// </summary>
        public Guid BirthDayId { get; set; }
    }
}
