using System;

namespace CongratulationAPI.Contracts.Know
{
    public class KnowDto: DtoBase
    {
        /// <summary>
        /// Статус пользователя название
        /// </summary>
        public string UserStatusName { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public int UserStatusId { get; set; }

        /// <summary>
        /// Идентификатор пользователя который добавляет в знакомых
        /// </summary>
        public Guid FromUserId { get; set; }

        /// <summary>
        /// Пользователь который добавляет в знакомых
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// Пользователь который добавляет в знакомых
        /// </summary>
        public string FromUserSecondName { get; set; }

        /// <summary>
        /// Пользователь который добавляет в знакомых
        /// </summary>
        public string FromUserLastName { get; set; }

        /// <summary>
        /// Идентификатор пользователя занкомого
        /// </summary>
        public Guid KnowUserId { get; set; }

        /// <summary>
        /// Имя пользователя знакомогу
        /// </summary>
        public string KnowUserName { get; set; }

        /// <summary>
        /// Фамилия пользователя знакомогу
        /// </summary>
        public string KnowUserSecondName { get; set; }

        /// <summary>
        /// Отчество пользователя знакомогу
        /// </summary>
        public string KnowUserLastName { get; set; }

    }
}
