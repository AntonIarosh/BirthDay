using CongratulationAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongratulationAPI.Domain.Entities
{
    /// <summary>
    /// Сущность поздравления
    /// </summary>
    public class Congratulation: EntityBase
    {
        /// <summary>
        ///  Текст поздравления
        /// </summary>
        public string CongratulationText { get; set; }

        /// <summary>
        /// Идентификатор Дня рождения
        /// </summary>
        public Guid BirthDayId { get; set; }

        /// <summary>
        /// День рождения для поздравления
        /// </summary>
        public BirthDay BirthDay { get; set; }

        /// <summary>
        /// Пользователь которому предназначено это поздравление. 
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Идентификатор пользователя которому предназначено это поздравление. 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь который отправил поздравление
        /// </summary>
        public User FromUser { get; set; }

        /// <summary>
        /// Идентификатор пользователя который отправил поздравление. 
        /// </summary>
        public Guid FromUserId { get; set; }
    }
}
