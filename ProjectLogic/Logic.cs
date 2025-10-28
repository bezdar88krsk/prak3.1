using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelLogic1;
namespace ProjectLogic
{
    public class Logic
    {
        public IRepository<Player> repository;
        public DBContext dbContext =new DBContext();
        public Logic()
        {
            repository = new EntityRepository<Player>(dbContext);
        }
        
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
            repository.Add(new Player(number,name,nation,position,height,weight));
           
        }
        /// <summary>
        /// Метод, удаляющий игрока из коллекции
        /// </summary>
        /// <param name="playerID">ID игрока, которого необходимо удалить из коллекции</param>
        public void RemovePlayerByID(int playerID)
        {
            foreach (Player p in repository.ReadAll())
            {
                repository.Delete(playerID);
            }
        }
        /// <summary>
        /// Удаляет игрока по соответствующему индексу
        /// </summary>
        /// <param name="index">индекс игрока, которого надо удаллить</param>
        public void RemovePlayerByIndex(int index)
        {
            repository.Delete(index);
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
            Player p = repository.ReadById(ID);
            if (p != null)
            {
                p.Number = number;
                p.Name = name;
                p.Nation = nation;
                p.Position = position;
                p.Weight = weight;
                p.Height = height;
                repository.Update(p);
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
        
        /// <summary>
        /// Метод, возвращающий список сгруппированных по позиции
        /// </summary>
        /// <param name="position">Позиция, по которой происходит группировка</param>
        /// <returns>возвращает список отсортированный по позиции</returns>
        public List<Player> GroupByPosition(Position position)
        {
            return  repository.ReadAll().Where(p => p.Position == position).ToList();
            
        }
        /// <summary>
        /// Возвращает игрока по его ID
        /// </summary>
        /// <param name="ID">айди нудного игрока</param>
        /// <returns>возвращает объект иргока</returns>
        public Player GetPlayer(int ID)
        {
            return repository.ReadById(ID);
            return null;
        }
        /// <summary>
        /// Группировка по национальности
        /// </summary>
        /// <param name="nation">национальность, по котрой группируем</param>
        /// <param name="currentPlayers">список, который отображается в данный момент</param>
        /// <returns>возвращает список сгруппированный по нациоанльности</returns>
        public List<Player> GroupByNation(string nation)
        {
            return repository.ReadAll().Where(p => p.Nation == nation).ToList();
        }
        /// <summary>
        /// Возвращает List<string> со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>врзвращает списко строк национальностей</returns>
        public List<string> GetNations()
        {
            return repository.ReadAll().Select(p => p.Nation).Distinct().ToList();
        }
        /// <summary>
        /// Возвращает string[] со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>возвращает массив строк национальностей</returns>
        public string[] GetNationsArray()
        {
            return repository.ReadAll().Select(p => p.Nation).Distinct().ToArray();
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
        public List<Player> LoadAllPlayers()
        {
            return repository.ReadAll().ToList();
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

            return repository.ReadAll().Select(p => $"{p.Name}, {p.Number}, {p.Nation}, {p.Position}, {p.Height}, {p.Weight}")
                          .ToArray();
        }
        /// <summary>
        /// возвращает игрока по индексу в листе
        /// </summary>
        /// <param name="index"></param>
        /// <returns>возвращает обхект игрока по индексу в листе</returns>
        //public Player GetPlayerByIndex(int index)
        //{
        //    List<Player> players = repository.ReadAll().ToList();   // Получить всех игроков
        //    int selectionIndex = ChooseOption(players.Select(p => p.Name).ToArray(), "Выберите игрока");
        //    Player selectedPlayer = players[selectionIndex];
        //}
        /// <summary>
        /// группирует по позиции и возвращает словарь позиция-игрок
        /// </summary>
        /// <returns>словарь позиция-игрок</returns>
        public Dictionary<Position, List<Player>> GroupPlayersByPosition()
        {
            return repository.ReadAll()
            .GroupBy(p => p.Position)
            .ToDictionary(g => g.Key, g => g.ToList());
        }

    }
}
