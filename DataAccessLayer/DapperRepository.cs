using Dapper;
using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    internal class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly IDbConnection _db;

        public DapperRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }

        public void Add(T entity)
        {
            var insertQuery = $"INSERT INTO {typeof(T).Name}s (/*columns*/) VALUES (/*values*/); SELECT CAST(SCOPE_IDENTITY() as int)";
            // Здесь нужно описать конкретный SQL для вставки по типу T, либо использовать динамическое построение SQL
            throw new System.NotImplementedException("Здесь необходимо реализовать вставку с Dapper");
        }

        public void Delete(int id)
        {
            var deleteQuery = $"DELETE FROM {typeof(T).Name}s WHERE ID = @Id";
            _db.Execute(deleteQuery, new { Id = id });
        }

        public IEnumerable<T> ReadAll()
        {
            var selectQuery = $"SELECT * FROM {typeof(T).Name}s";
            return _db.Query<T>(selectQuery).ToList();
        }

        public T ReadById(int id)
        {
            var selectQuery = $"SELECT * FROM {typeof(T).Name}s WHERE ID = @Id";
            return _db.QuerySingleOrDefault<T>(selectQuery, new { Id = id });
        }

        public void Update(T entity)
        {
            var updateQuery = $"UPDATE {typeof(T).Name}s SET /*columns = values*/ WHERE ID = @Id";
            
            throw new System.NotImplementedException("Здесь необходимо реализовать обновление с Dapper");
        }
    }
}
