﻿using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.Congratulation;
using CongratulationAPI.Contracts.Know;
using System;
using System.Collections.Generic;

namespace CongratulationAPI.Contracts.User
{
    public class UserDto : DtoBase
    {
        /// <summary>
        /// Пол пользователя. 
        /// </summary>
        public string Gender { get; set; }

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
        /// День рождения пользователя
        /// </summary>
        public BirthDayDto BirthDay { get; set; }

        /// <summary>
        /// Идентификатор Дня рождения
        /// </summary>
        public Guid BirthDayId { get; set; }

        /// <summary>
        /// Поздравляения пользователя
        /// </summary>
        public virtual List<CongratulationDto> Congratulations { get; set; }

        /// <summary>
        /// Знакомые пользователя
        /// </summary>
        public virtual List<KnowDto> Knows { get; set; }

        /// <summary>
        /// Пользователи у которых я знакомый
        /// </summary>
        public virtual List<KnowDto> KnowsToMe { get; set; }
    }
}
