using ModelLogic1;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет сущность в базу данных
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// Удаляет сущность из базы данных по её айди
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Возвращает список сущностей
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// возвращает сущность по введенному id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T ReadById(int id);
        /// <summary>
        /// Обновляет сущность в базе данных
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
