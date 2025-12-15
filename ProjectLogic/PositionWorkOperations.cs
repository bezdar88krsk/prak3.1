using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLogic
{
    public class PositionWorkOperations : IPositionOperations
    {
        public Position ConvertPosition(int index)
        {
            switch (index)
            {
                case 0:
                    return Position.PointGuard;
                case 1:
                    return Position.SmallForward;
                case 2:
                    return Position.PowerForward;
                case 3:
                    return Position.Center;
            }
            return Position.Center;
        }
        public string[] GetPositions()
        {
            return new string[] { "PointGuard", "SmallForward", "PowerForward", "Center" };
        }
         public Position ConvertPosition(string text)
        {
            switch (text)
            {
                case "Center":
                    return Position.Center;
                case "PointGuard":
                    return Position.PointGuard;
                case "SmallForward":
                    return Position.SmallForward;
                case "PowerForward":
                    return Position.PowerForward;


            }
            return Position.Center;
        }
    }
}
