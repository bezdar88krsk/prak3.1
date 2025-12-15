using DataAccessLayer;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBContext())
            {
                db.Database.Initialize(force: false);
            }
        }
    }
}
