using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLogic1;
namespace ProjectLogic
{
    public class PlayerWorkOperations : IPlayerOperations
    {
        private readonly DBContext _context;

        public PlayerWorkOperations(DBContext context)
        {
            _context = context;
        }
        public IEnumerable<Player> GetByPosition(Position position)
        {
            return _context.Set<Player>().Where(p => p.Position == position).ToList();
        }

        public IEnumerable<Player> GetByNation(string nation)
        {
            return _context.Set<Player>().Where(p => p.Nation == nation).ToList();
        }

        public Dictionary<Position, List<Player>> GroupPlayersByPosition()
        {
            return _context.Set<Player>()
                           .GroupBy(p => p.Position)
                           .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<string> GetAllNations()
        {
            return _context.Set<Player>().Select(p => p.Nation).Distinct().ToList();
        }
        public void ChangePlayerByID(int ID, int number, string name, string nation, Position position, int height, int weight)
        {
            var player = _context.Entities.Find(ID); 
            if (player != null)
            {
                player.Number = number;
                player.Name = name;
                player.Nation = nation;
                player.Position = position;
                player.Height = height;
                player.Weight = weight;
                _context.SaveChanges();   
            }

        }
        public string[] GetNationsArray()
        {
            return _context.Entities
                     .Select(p => p.Nation)
                     .Distinct()
                     .ToArray();
        }
    }
}
