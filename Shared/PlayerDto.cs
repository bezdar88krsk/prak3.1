using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PlayerDto
    {
        public int Id { get; set; }         
        public int Number { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public string Position { get; set; } 
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
