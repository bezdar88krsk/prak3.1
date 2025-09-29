using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLogic1
{
    public class Logic
    {
        public BindingList<Player> Players = new BindingList<Player>() { new Player(1, 38, "lebron james", "usa", Position.PowerForward, 200, 100) };
        /// <summary>
        /// Метод, добавляющий игрока в коллекцию игроков
        /// </summary>
        /// <param name="number">Номер игрока</param>
        /// <param name="name">Фамилия/Имя/Псевдоним игрока</param>
        /// <param name="position">Позиция игрока на площадке</param>
        /// <param name="height">Рост игркоа</param>
        /// <param name="weight">Вес игрока</param>
        public void AddPlayer(int number, string name, string nation, Position position, int height, int weight)
        {
            int LastId = Players.Last().Id;
            Players.Add(new Player(LastId + 1, number, name, nation, position, height, weight)); 
        }
        /// <summary>
        /// Метод, удаляющий игрока из коллекции
        /// </summary>
        /// <param name="playerId">id игрока, которого необходимо удалить из коллекции</param>
        public void RemovePlayer(int playerId)
        {
            foreach (Player p in Players)
            {
                if (p.GetId() == playerId)
                {
                    Players.Remove(p);
                    break;
                }
            }
        }
        /// <summary>
        /// Метод, изменяющий свойства игрока
        /// </summary>
        /// <param name="id">айди игрока</param>
        /// <param name="number">новый номер</param>
        /// <param name="name">новое имя</param>
        /// <param name="position">новая позиция</param>
        /// <param name="height">новый рост</param>
        /// <param name="weight">новый вес</param>
        public void ChangePlayer(int id, int number, string name, string nation, Position position, int height, int weight)
        {
            foreach (Player p in Players)
            {
                if (p.GetId() == id)
                {
                    p.Number = number;
                    p.Name = name;
                    p.Nation = nation;
                    p.Position = position;
                    p.Weight = weight;
                    p.Height = height;
                }
            }
            
        }
        /// <summary>
        /// Метод, возвращающий список сгруппированных по позиции
        /// </summary>
        /// <param name="position">Позиция, по которой происходит группировка</param>
        /// <returns></returns>
        public BindingList<Player> GroupByPosition(Position position)
        {
            BindingList<Player> groupedPlayers =new BindingList<Player>(Players.Where(p => p.Position == position).ToList());
            return groupedPlayers;
        }

        public Player GetPlayer(int id)
        {
            foreach (Player p in Players)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }
        //public List<Player> GetPlayers()
        //{
        //    return Players;
        //}
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


