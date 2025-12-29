using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IGroupFormView
    {
        void ShowGroupedPlayers(Dictionary<string, List<PlayerDto>> groups);
    }
}
