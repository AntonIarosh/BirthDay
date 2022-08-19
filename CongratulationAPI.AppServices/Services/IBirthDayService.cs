using CongratulationAPI.Contracts.BirthDay;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с Днём рождения
    /// </summary>
    public interface IBirthDayService
    {
        /// <summary>
        /// Получение списка всех Дней рождения
        /// </summary>
        /// <returns> Список сущностей BirthDay</returns>
        Task<List<BirthDayDto>> GetAllBirthDays();

        /// <summary>
        /// Получить День Рождения по конкретному дню и месяцу рождения
        /// </summary>
        /// <returns> ДТО дня рождения</returns>
        Task<List<BirthDayDto>> GetByDayAndMonth(int day, int month);

        /// <summary>
        /// Добавление в БД новую запись о Дне рождения
        /// </summary>
        /// <param name="model">Модель сущности BirthDay</param>
        /// <returns> Результат добавления</returns>
        Task AddAsync(BirthDayDtoAdd model);

        /// <summary>
        /// Обновление в БД записи о Дне рождении
        /// </summary>
        /// <param name="model"> Модель сущности BirthDay</param>
        /// <returns>Обновлённая сущность BirthDay</returns>
        Task<BirthDayDto> Update(BirthDayDtoUpdate model);

        /// <summary>
        /// Удаление в БД записи о Дне рождении
        /// </summary>
        /// <param name="id">Идентификатор записи в БД</param>
        /// <returns>Результат удаления</returns>
        Task DeleteAsync(Guid id);



    }
}
