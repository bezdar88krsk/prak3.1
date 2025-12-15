using Dapper;
using ModelLogic1;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;
namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Player>
    {
        private readonly IDbConnection _db;

        public DapperRepository()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True;";
            _db = new SqlConnection(connectionString);
        }

        public void Add(Player player)
        {
            string insertQuery = $@"
        INSERT INTO Players (Number, Name, Nation, Position, Height, Weight) 
        VALUES (@Number, @Name, @Nation, @Position, @Height, @Weight);
        SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = _db.ExecuteScalar<int>(insertQuery, player);
            player.ID = id;
        }

        public void Delete(int id)
        {
            string deleteQuery = $"DELETE FROM {typeof(Player).Name}s WHERE ID = @Id";
            _db.Execute(deleteQuery, new { Id = id });
        }

        public IEnumerable<Player> ReadAll()
        {
            string selectQuery = $"SELECT * FROM {typeof(Player).Name}s";
            return _db.Query<Player>(selectQuery).ToList();
        }

        public Player ReadById(int id)
        {
            string selectQuery = $"SELECT * FROM {typeof(Player).Name}s WHERE ID = @Id";
            return _db.QuerySingleOrDefault<Player>(selectQuery, new { Id = id });
        }

        public void Update(Player player)
        {
            string updateQuery = @"
            UPDATE Players SET 
                Number = @Number,
                Name = @Name,
                Nation = @Nation,
                Position = @Position,
                Height = @Height,
                Weight = @Weight
            WHERE ID = @ID";

            _db.Execute(updateQuery, player);
        }
    }
}
