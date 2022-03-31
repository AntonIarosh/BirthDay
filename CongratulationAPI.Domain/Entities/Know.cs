using CongratulationAPI.Contracts.Enums;
using CongratulationAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Domain.Entities
{
    /// <summary>
    /// Сущность Know - пользователи которых я знаю, за которыми будет происходить наблюдение
    /// </summary>
    public class Know: EntityBase
    {
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus UserStatus { get; set; }

        /// <summary>
        /// Идентификатор пользователя который добавляет в знакомых
        /// </summary>
        public Guid FromUserId { get; set; }

        /// <summary>
        /// Пользователь  который добавляет в знакомых
        /// </summary>
        public User FromUser { get; set; }

        /// <summary>
        /// Идентификатор пользователя занкомого
        /// </summary>
        public Guid KnowUserId { get; set; }

        /// <summary>
        /// Пользователь знакомый 
        /// </summary>
        public User KnowUser { get; set; }
    }
}
