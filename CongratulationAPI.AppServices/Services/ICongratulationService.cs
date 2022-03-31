using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.Congratulation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с Поздравлением
    /// </summary>
    public interface ICongratulationService
    {
        /// <summary>
        /// Получение списка всех Поздравление
        /// </summary>
        /// <returns> Список сущностей Congratulation</returns>
        Task<List<CongratulationDto>> GetAllCongratulations();

        /// <summary>
        /// Добавление в БД новую запись о Поздравление
        /// </summary>
        /// <param name="model">Модель сущности Congratulation</param>
        /// <returns> Результат добавления</returns>
        Task AddAsync(CongratulationDtoAdd model);

        /// <summary>
        /// Обновление в БД записи о Поздравлении
        /// </summary>
        /// <param name="model"> Модель сущности Congratulation</param>
        /// <returns>Обновлённая сущность Congratulation</returns>
        Task<CongratulationDto> Update(CongratulationDtoUpdate model);

        /// <summary>
        /// Удаление в БД записи о Поздравлении
        /// </summary>
        /// <param name="id">Идентификатор записи в БД</param>
        /// <returns>Результат удаления</returns>
        Task DeleteAsync(Guid id);



    }
}
