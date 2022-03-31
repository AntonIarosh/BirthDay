using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.Know;
using CongratulationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.AppServices.Services
{
    /// <summary>
    /// Сервис для работы со Знакомыми
    /// </summary>
    public interface IKnowService
    {
        /// <summary>
        /// Получение списка всех Знакомых
        /// </summary>
        /// <returns> Список сущностей Know</returns>
        Task<List<KnowDto>> GetAllKnows();

        /// <summary>
        /// Добавление в БД новую запись о Знакомых
        /// </summary>
        /// <param name="model"> Модель сущности Know</param>
        /// <returns> Результат добавления</returns>
        Task AddAsync(KnowDtoAdd model);

        /// <summary>
        /// Обновление в БД записи о Знакомых
        /// </summary>
        /// <param name="model"> Модель сущности Know</param>
        /// <returns>Обновлённая сущность Know</returns>
        Task<KnowDto> Update(KnowDtoUpdate model);

        /// <summary>
        /// Удаление в БД записи о Знакомых
        /// </summary>
        /// <param name="id">Идентификатор записи в БД</param>
        /// <returns>Результат удаления</returns>
        Task DeleteAsync(Guid id);



    }
}
