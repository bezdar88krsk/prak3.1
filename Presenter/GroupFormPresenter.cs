using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class GroupFormPresenter
    {
        private readonly ILogic _logic;
        private readonly IGroupFormView _view;

        public GroupFormPresenter(ILogic logic, IGroupFormView view)
        {
            _logic = logic;
            _view = view;
            LoadGroups();
        }

        private void LoadGroups()
        {
            var players = _logic.LoadAllEntities();
            var groups = players
                .GroupBy(p => p.Position.ToString())
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(p => new PlayerDto
                    {
                        Id = p.ID,
                        Number = p.Number,
                        Name = p.Name,
                        Nation = p.Nation,
                        Position = p.Position.ToString(),
                        Height = p.Height,
                        Weight = p.Weight
                    }).ToList()
                );

            _view.ShowGroupedPlayers(groups);
        }
    }
}
