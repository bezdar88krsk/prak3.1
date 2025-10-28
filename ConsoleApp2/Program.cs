using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBContext())
            {
                // Это автоматически создаст базу и таблицу (если база пуста)
                db.Database.Initialize(force: false);
            }
        }
    }
}
