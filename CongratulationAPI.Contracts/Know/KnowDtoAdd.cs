using System;

namespace CongratulationAPI.Contracts.Know
{
    public class KnowDtoAdd
    {
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public int UserStatusId { get; set; }

        /// <summary>
        /// Идентификатор пользователя который добавляет в знакомых
        /// </summary>
        public Guid FromUserId { get; set; }

        /// <summary>
        /// Идентификатор пользователя занкомого
        /// </summary>
        public Guid KnowUserId { get; set; }

    }
}
