using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с Пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns> Список сущностей User</returns>
        Task<List<UserDto>> GetAllUsers();

        /// <summary>
        /// Добавление в БД новую запись о пользователе
        /// </summary>
        /// <param name="model">Модель сущности User</param>
        /// <returns> Результат добавления</returns>
        Task AddAsync(UserDtoAdd model);

        /// <summary>
        /// Обновление в БД записи о Пользователе
        /// </summary>
        /// <param name="model"> Модель сущности User</param>
        /// <returns>Обновлённая сущность User</returns>
        Task<UserDto> Update(UserDtoUpdate model);

        /// <summary>
        /// Удаление в БД записи о Пользователе
        /// </summary>
        /// <param name="id">Идентификатор записи в БД</param>
        /// <returns>Результат удаления</returns>
        Task DeleteAsync(Guid id);



    }
}
