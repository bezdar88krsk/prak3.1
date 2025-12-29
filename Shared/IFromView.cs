using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Shared
{
    public interface IFormView
    {
        event EventHandler ButtonAddClicked;
        event EventHandler ButtonDeleteClicked;
        event EventHandler ButtonEditClicked;
        event EventHandler ButtonGroupPositionClicked;
        event EventHandler ButtonGroupNationClicked;
        event EventHandler ButtonGroupFormClicked;
        event EventHandler CheckBoxPositionChanged;
        event EventHandler CheckBoxNationChanged;

        void ShowPlayers(IEnumerable<PlayerDto> players);
        void ResetFilters();

        string SelectedPosition { get; }
        string SelectedNation { get; }
        int? SelectedPlayerId { get; }

        void SetPositions(IEnumerable<string> positions);
        void SetNations(IEnumerable<string> nations);
    }
}
