using System;

namespace CongratulationAPI.Contracts.Congratulation
{
    /// <summary>
    /// Модель представляения сущности Поздравления: Congratulation
    /// </summary>
    public class CongratulationDtoAdd
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
        /// Идентификатор пользователя которому предназначено это поздравление. 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор пользователя который отправил поздравление. 
        /// </summary>
        public Guid FromUserId { get; set; }
    }
}
