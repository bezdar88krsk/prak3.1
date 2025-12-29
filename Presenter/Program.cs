using Lab3._1;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Text;
using System.Threading.Tasks;
using Shared;
using System.Windows.Forms;

namespace Presenter
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new SimpleConfigModule());
            ILogic logic = kernel.Get<ILogic>();

            Form1 view = new Form1();
            FormPresenter presenter = new FormPresenter(logic, view);

            Starter.StartForm(view); 
        }
    }
}
