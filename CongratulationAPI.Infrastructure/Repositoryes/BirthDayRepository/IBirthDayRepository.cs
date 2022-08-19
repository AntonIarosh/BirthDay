using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.BirthDayRepository
{
    public interface IBirthDayRepository : IRepository<BirthDay>
    {
        Task<List<BirthDay>> GetAllBirthDaysWithCongratulations();

        /// <summary>
        /// Поиск сущности в бд по дню и месяцу Дня Рождения
        /// </summary>
        /// <param name="day"> День праздника</param>
        /// <param name="month"> Месяц праздника</param>
        /// <returns>Найденную сущность или null</returns>
        public BirthDay FindByDayAndMonth(int day, int month);

        /// <summary>
        /// Асинхронный поиск сущности в бд по дню и месяцу Дня Рождения
        /// </summary>
        /// <param name="day"> День праздника</param>
        /// <param name="month"> Месяц праздника</param>
        /// <returns>Найденную сущность или null</returns>
        public Task<List<BirthDay>> FindByDayAndMonthAsync(int day, int month);

        /// <summary>
        /// Добавление новой записи сущности в БД и возвращает идентификатор
        /// </summary>
        /// <param name="model"> Данные добавляемой сущности</param>
        /// /// <returns> Идентификатор добавленной сущности</returns>
        Guid AddAsyncAndReturnId(BirthDay model);

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        public void SaveChanges();
    }
}
