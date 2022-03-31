using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Contracts.Enums
{
    public enum UserStatus
    {
        /// <summary>
        /// Друг
        /// </summary>
        Friend,

        /// <summary>
        /// Член семьи
        /// </summary>
        Family,

        /// <summary>
        /// Сотрудник/работник
        /// </summary>
        Employee,

        /// <summary>
        /// Одноклассиник
        /// </summary>
        Classmate,

        /// <summary>
        /// Студент
        /// </summary>
        Student,

        /// <summary>
        /// Работодатель
        /// </summary>
        Employer,

        /// <summary>
        /// Родственник
        /// </summary>
        Relative,

        /// <summary>
        /// Участник клуба
        /// </summary>
        Club_member,

        /// <summary>
        /// Неопределённый статус
        /// </summary>
        Undefined
    }
}
