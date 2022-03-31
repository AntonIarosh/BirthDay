using System;

namespace CongratulationAPI.Contracts.Congratulation
{
    /// <summary>
    /// Модель представляения сущности Поздравления: Congratulation
    /// </summary>
    public class CongratulationDto: DtoBase
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
        /// Имя пользователя которому предназначено это поздравление. 
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// Фамилия пользователя которому предназначено это поздравление. 
        /// </summary>
        public string ToUserSecondName { get; set; }

        /// <summary>
        /// Отчество пользователя которому предназначено это поздравление. 
        /// </summary>
        public string ToUserLastName { get; set; }

        /// <summary>
        /// Идентификатор пользователя которому предназначено это поздравление. 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор Пользователя который отправил поздравление
        /// </summary>
        public Guid FromUser { get; set; }

        /// <summary>
        /// Имя пользователя оставивший поздравляение
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// Фамилия пользователя оставивший поздравляение
        /// </summary>
        public string FromUserSecondName { get; set; }

        /// <summary>
        /// Отчество пользователя оставивший поздравляение
        /// </summary>
        public string FromUserLastName { get; set; }
    }
}
