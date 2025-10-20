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
            int LastID = Players.Last().ID;
            Players.Add(new Player(LastID + 1, number, name, nation, position, height, weight));
        }
        /// <summary>
        /// Метод, удаляющий игрока из коллекции
        /// </summary>
        /// <param name="playerID">ID игрока, которого необходимо удалить из коллекции</param>
        public void RemovePlayerByID(int playerID)
        {
            foreach (Player p in Players)
            {
                if (p.GetID() == playerID)
                {
                    Players.Remove(p);
                    break;
                }
            }
        }
        /// <summary>
        /// Удаляет игрока по соответствующему индексу
        /// </summary>
        /// <param name="index">индекс игрока, которого надо удаллить</param>
        public void RemovePlayerByIndex(int index)
        {
            Players.RemoveAt(index);
        }
        /// <summary>
        /// Метод, изменяющий свойства игрока
        /// </summary>
        /// <param name="ID">айди игрока</param>
        /// <param name="number">новый номер</param>
        /// <param name="name">новое имя</param>
        /// <param name="position">новая позиция</param>
        /// <param name="height">новый рост</param>
        /// <param name="weight">новый вес</param>
        public void ChangePlayerByID(int ID, int number, string name, string nation, Position position, int height, int weight)
        {
            foreach (Player p in Players)
            {
                if (p.GetID() == ID)
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
        /// <param name="index">индекс нужного игрока</param>
        /// <param name="number">номер игрока</param>
        /// <param name="name">имя игрока</param>
        /// <param name="nation">национальность игрока</param>
        /// <param name="position">позиция игрока</param>
        /// <param name="height">рост игрока</param>
        /// <param name="weight">вес игрока</param>
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
        /// <returns>возвращает список отсортированный по позиции</returns>
        public BindingList<Player> GroupByPosition(Position position, BindingList<Player> currentPlayers)
        {
            BindingList<Player> groupedPlayers = new BindingList<Player>(currentPlayers.Where(p => p.Position == position).ToList());
            return groupedPlayers;
        }
        /// <summary>
        /// Возвращает игрока по его ID
        /// </summary>
        /// <param name="ID">айди нудного игрока</param>
        /// <returns>возвращает объект иргока</returns>
        public Player GetPlayer(int ID)
        {
            foreach (Player p in Players)
            {
                if (p.ID == ID)
                    return p;
            }
            return null;
        }
        /// <summary>
        /// Группировка по национальности
        /// </summary>
        /// <param name="nation">национальность, по котрой группируем</param>
        /// <param name="currentPlayers">список, который отображается в данный момент</param>
        /// <returns>возвращает список сгруппированный по нациоанльности</returns>
        public BindingList<Player> GroupByNation(string nation, BindingList<Player> currentPlayers)
        {
            BindingList<Player> groupedPlayers = new BindingList<Player>(currentPlayers.Where(p => p.Nation == nation).ToList());
            return groupedPlayers;
        }
        /// <summary>
        /// Возвращает List<string> со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>врзвращает списко строк национальностей</returns>
        public List<string> GetNations()
        {
            return Players.Select(p => p.Nation).ToList();
        }
        /// <summary>
        /// Возвращает string[] со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>возвращает массив строк национальностей</returns>
        public string[] GetNationsArray()
        {
            return Players.Select(p => p.Nation).ToArray();
        }
       /// <summary>
       /// Конвертирует текст в позицию
       /// </summary>
       /// <param name="text"></param>
       /// <returns>возвращщает позицию</returns>
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
        /// <returns>возвращает обхект позиции</returns>
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
        /// <returns>возвращает массив строк позиций</returns>
        public string[] GetPositions()
        {
            return new string[] { "PointGuard", "SmallForward", "PowerForward", "Center" };
        }
        /// <summary>
        /// Возвращает массив строк всех игроков
        /// </summary>
        /// <returns>возвращает массив строк игрокав</returns>
        public string[] PlayersToStrings()
        {
           
            return Players.Select(p => $"{p.Name}, {p.Number}, {p.Nation}, {p.Position}, {p.Height}, {p.Weight}")
                          .ToArray();
        }
        /// <summary>
        /// возвращает игрока по индексу в листе
        /// </summary>
        /// <param name="index"></param>
        /// <returns>возвращает обхект игрока по индексу в листе</returns>
        public Player GetPlayerByIndex(int index)
        {
            return Players[index];
        }
        /// <summary>
        /// группирует по позиции и возвращает словарь позиция-игрок
        /// </summary>
        /// <returns>словарь позиция-игрок</returns>
        public Dictionary<Position, List<Player>> GroupPlayersByPosition()
        {
            return Players.GroupBy(p => p.Position)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

    }
    }



