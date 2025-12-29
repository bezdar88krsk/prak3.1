using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class AddFormPresenter
    {
        private readonly ILogic _logic;
        private readonly IAddFormView _view;

        public AddFormPresenter(ILogic logic, IAddFormView view)
        {
            _logic = logic;
            _view = view;

            _view.AddButtonClicked += OnAddButtonClicked;
            _view.SetPositions(_logic.GetPositions());
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.PlayerName) ||
                string.IsNullOrWhiteSpace(_view.PlayerNumber) ||
                string.IsNullOrWhiteSpace(_view.PlayerNation) ||
                string.IsNullOrWhiteSpace(_view.PlayerPosition) ||
                string.IsNullOrWhiteSpace(_view.PlayerHeight) ||
                string.IsNullOrWhiteSpace(_view.PlayerWeight))
            {
                return;
            }

            int number = Convert.ToInt32(_view.PlayerNumber);
            int height = Convert.ToInt32(_view.PlayerHeight);
            int weight = Convert.ToInt32(_view.PlayerWeight);
            var pos = _logic.ConvertPosition(_view.PlayerPosition);

            _logic.AddEntity(number, _view.PlayerName, _view.PlayerNation, pos, height, weight);
            _view.CloseView();
        }
    }
}
