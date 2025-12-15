using ModelLogic1;
using System.Data.Entity;

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
