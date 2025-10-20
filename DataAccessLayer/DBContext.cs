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
    internal class DBContext : DbContext
    {
        public DbSet<Player> Entities { get; set; }

        public DBContext() : base("DbConnection")
        {
        }
    }
}
