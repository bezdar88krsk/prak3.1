using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Player> Entities { get; set; }

        public DBContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\Lab3.1\\DataAccessLayer\\Database1.mdf;Integrated Security=True")
        {
        }
    }
}
