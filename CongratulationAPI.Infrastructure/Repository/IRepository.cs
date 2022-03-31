using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CongratulationAPI.Infrastructure.Repository
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity:class
    {
        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Получение сущностей через фильтр
        /// </summary>
        /// <param name="predicat"> Фильтр по которму будут отбиарть сущности из БД</param>
        /// <returns></returns>
        IQueryable<TEntity> GeByAllFiltered(Expression<Func<TEntity, bool>> predicat);

        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор сущности поиска</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Добавление новой записи сущности в БД
        /// </summary>
        /// <param name="model"> Данные добавляемой сущности</param>
        Task AddAsync(TEntity model);

        /// <summary>
        /// Добавление новой записи сущности в БД и возвращает идентификатор
        /// </summary>
        /// <param name="model"> Данные добавляемой сущности</param>
        /// /// <returns> Идентификатор добавленной сущности</returns>
       // Guid AddAsyncAndReturnId(TEntity model);

        /// <summary>
        /// ДОбновление записи сущности в БД
        /// </summary>
        /// <param name="model"> Данные обновляемой сущности</param>
        Task UpdateAsync(TEntity model);

        /// <summary>
        /// Удаление записи сущности из БД
        /// </summary>
        /// <param name="model"> Данные удаляемой сущности</param>
        Task DeleteAsync(TEntity model);

        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
