using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAddFormView
    {
        event EventHandler AddButtonClicked;

        string PlayerName { get; }
        string PlayerNumber { get; }
        string PlayerNation { get; }
        string PlayerPosition { get; }
        string PlayerHeight { get; }
        string PlayerWeight { get; }

        void SetPositions(IEnumerable<string> positions);
        void CloseView();
    }
}
