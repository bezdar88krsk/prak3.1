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
        public void RemovePlayerById(int playerId)
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
        /// Удаляет игрока по соответствующему индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemovePlayerByIndex(int index)
        {
            Players.RemoveAt(index);
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
        public void ChangePlayerById(int id, int number, string name, string nation, Position position, int height, int weight)
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
        /// Изменяет игрока по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="nation"></param>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        public void ChangePlayerByIndex(int index, int number, string name, string nation, Position position, int height, int weight)
        {
            Players[index].Name = name;
            Players[index].Nation = nation; 
            Players[index].Position = position;
            Players[index].Weight = weight;
            Players[index].Height = height;
            Players[index].Number = number;
        }
        /// <summary>
        /// Метод, возвращающий список сгруппированных по позиции
        /// </summary>
        /// <param name="position">Позиция, по которой происходит группировка</param>
        /// <returns></returns>
        public BindingList<Player> GroupByPosition(Position position, BindingList<Player> currentPlayers)
        {
            BindingList<Player> groupedPlayers = new BindingList<Player>(currentPlayers.Where(p => p.Position == position).ToList());
            return groupedPlayers;
        }
        /// <summary>
        /// Возвращает игрока по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetPlayer(int id)
        {
            foreach (Player p in Players)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }
        /// <summary>
        /// Группировка по национальности
        /// </summary>
        /// <param name="nation"></param>
        /// <param name="currentPlayers"></param>
        /// <returns></returns>
        public BindingList<Player> GroupByNation(string nation, BindingList<Player> currentPlayers)
        {
            BindingList<Player> groupedPlayers = new BindingList<Player>(currentPlayers.Where(p => p.Nation == nation).ToList());
            return groupedPlayers;
        }
        /// <summary>
        /// Возвращает List<string> со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns></returns>
        public List<string> GetNations()
        {
            return Players.Select(p => p.Nation).ToList();
        }
        /// <summary>
        /// Возвращает string[] со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns></returns>
        public string[] GetNationsArray()
        {
            return Players.Select(p => p.Nation).ToArray();
        }
       /// <summary>
       /// Конвертирует текст в позицию
       /// </summary>
       /// <param name="text"></param>
       /// <returns></returns>
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
        /// <summary>
        /// Конвертирует номер в позицию
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Возвращает массив всех позиций
        /// </summary>
        /// <returns></returns>
        public string[] GetPositions()
        {
            return new string[] { "PointGuard", "SmallForward", "PowerForward", "Center" };
        }
        /// <summary>
        /// Возвращает массив строк всех игроков
        /// </summary>
        /// <returns></returns>
        public string[] PlayersToStrings()
        {
           
            return Players.Select(p => $"{p.Name}, {p.Number}, {p.Nation}, {p.Position}, {p.Height}, {p.Weight}")
                          .ToArray();
        }
        /// <summary>
        /// возвращает игрока по индексу в листе
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Player GetPlayerByIndex(int index)
        {
            return Players[index];
        }
        public Dictionary<Position, List<Player>> GroupPlayersByPosition()
        {
            return Players.GroupBy(p => p.Position)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

    }
    }



