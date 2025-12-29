using ConsoleApp1;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ConsolePresenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new SimpleConfigModule());
            var logic = kernel.Get<ILogic>();

            var view = new ConsoleView();
            var presenter = new PresenterConsole(logic, view);
            presenter.Run();
        }
    }
}
