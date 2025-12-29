using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IChangeFromView
    {
        event EventHandler SaveButtonClicked;
        int PlayerId { get; set; }
        string PlayerName { get; set; }
        string PlayerNumber { get; set; }
        string PlayerNation { get; set; }
        string PlayerPosition { get; set; }
        string PlayerHeight { get; set; }
        string PlayerWeight { get; set; }
        void SetPositions(IEnumerable<string> positions);
        void CloseView();
    }
}
