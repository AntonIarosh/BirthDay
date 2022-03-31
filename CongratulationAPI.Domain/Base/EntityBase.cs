using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Domain.Base
{
    /// <summary>
    /// Базовый класс для всех сущностей
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
