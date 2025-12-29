using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class ChangeFormPresenter
    {
        private readonly ILogic _logic;
        private readonly IChangeFromView _view;

        public ChangeFormPresenter(ILogic logic, IChangeFromView view)
        {
            _logic = logic;
            _view = view;
            _view.SaveButtonClicked += OnSaveButtonClicked;
            _view.SetPositions(_logic.GetPositions());
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            int id = _view.PlayerId;
            int number = Convert.ToInt32(_view.PlayerNumber);
            int height = Convert.ToInt32(_view.PlayerHeight);
            int weight = Convert.ToInt32(_view.PlayerWeight);
            var pos = _logic.ConvertPosition(_view.PlayerPosition);
            _logic.ChangeEntityByID(id, number, _view.PlayerName, _view.PlayerNation, pos, height, weight);
            Console.WriteLine("abababababab");
            _view.CloseView();
        }
    }
}
