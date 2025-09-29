using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLogic1;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine(logic.Players[0].Name);
        }
    }
}
