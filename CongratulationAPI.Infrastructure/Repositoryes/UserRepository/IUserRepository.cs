using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.UserRepository
{
    public interface IUserRepository: IRepository<User>
    {
        /// <summary>
        /// Получить всех пользователей с их знакомымы, людьми которые их знают и поздравлениями этого пользователя
        /// </summary>
        /// <returns> Список пользователей</returns>
        Task<List<User>> GetAllUsersWithUsersKnowsKnowsToMeAndCongratulations();

        /// <summary>
        /// Получить всех пользователей в диапазоне дней
        /// </summary>
        /// <param name="days"> Диапазон дней</param>
        /// <returns> Список пользователей</returns>
        Task<List<User>> FindBirthDayPlusAndMinusDaysAsync(int days);

        /// <summary>
        /// Получить всех пользователей по ФИО
        /// </summary>
        /// <param name="name">Имя для поиска </param>
        /// <param name="secondName">Фамилия для поиска</param>
        /// <param name="lastName">Отчество для поиска</param>
        /// <returns></returns>
        Task<List<User>> FindByFIO (string name, string secondName, string lastName);

        /// <summary>
        /// Получить всех пользователей по эмейлу
        /// </summary>
        /// <param name="email"> Эмейл для поиска</param>
        /// <returns></returns>
        Task<List<User>> FindByEmail(string email);
    }

}
