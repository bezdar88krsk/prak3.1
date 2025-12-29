using DataAccessLayer;
using ModelLogic1;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ProjectLogic
{
    public class Logic : ILogic
    {
        public IRepository<Player> Repository { get; set; }
        private readonly IPlayerOperations Operations;
        private IPositionOperations PositionOperations { get; set; }
        public Logic(IRepository<Player> repository, IPlayerOperations operations, IPositionOperations positionOperations)
        {
            Repository = repository;
            Operations = operations;
            PositionOperations = positionOperations;
        }
        //public Logic(IRepository<Player> repository)
        //{
        //    Repository = repository;
        //}
        /// <summary>
        /// Метод, добавляющий игрока в коллекцию игроков
        /// </summary>
        /// <param name="number">Номер игрока</param>
        /// <param name="name">Фамилия/Имя/Псевдоним игрока</param>
        /// <param name="position">Позиция игрока на площадке</param>
        /// <param name="height">Рост игркоа</param>
        /// <param name="weight">Вес игрока</param>
        public void AddEntity(int number, string name, string nation, Position position, int height, int weight)
        {
            Repository.Add(new Player(number, name, nation, position, height, weight));

        }
        /// <summary>
        /// Метод, удаляющий игрока из коллекции
        /// </summary>
        /// <param name="playerID">ID игрока, которого необходимо удалить из коллекции</param>
        public void RemoveEntityByID(int entityID)
        {
            Repository.Delete(entityID);
        }
        /// <summary>
        /// Удаляет игрока по соответствующему индексу
        /// </summary>
        /// <param name="index">индекс игрока, которого надо удаллить</param>
        public void RemoveEntityByIndex(int index)
        {
            Repository.Delete(index);
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
        public void ChangeEntityByID(int ID, int number, string name, string nation, Position position, int height, int weight)
        {
            Operations.ChangePlayerByID(ID, number, name, nation, position,height, weight);
        }
        

        /// <summary>
        /// Метод, возвращающий список сгруппированных по позиции
        /// </summary>
        /// <param name="position">Позиция, по которой происходит группировка</param>
        /// <returns>возвращает список отсортированный по позиции</returns>
        public List<Player> GroupByPosition(Position position)
        {
            return Operations.GetByPosition(position).ToList();

        }
        /// <summary>
        /// Возвращает игрока по его ID
        /// </summary>
        /// <param name="ID">айди нудного игрока</param>
        /// <returns>возвращает объект иргока</returns>
        public Player GetEntity(int ID)
        {
            return Repository.ReadById(ID);

        }
        /// <summary>
        /// Группировка по национальности
        /// </summary>
        /// <param name="nation">национальность, по котрой группируем</param>
        /// <param name="currentPlayers">список, который отображается в данный момент</param>
        /// <returns>возвращает список сгруппированный по нациоанльности</returns>
        public List<Player> GroupByNation(string nation)
        {
            return Operations.GetByNation(nation).ToList();
        }
        /// <summary>
        /// Возвращает List<string> со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>врзвращает списко строк национальностей</returns>
        public List<string> GetNations()
        {
            return Operations.GetAllNations();
        }
        /// <summary>
        /// Возвращает string[] со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>возвращает массив строк национальностей</returns>
        public string[] GetNationsArray()
        {
            return Operations.GetNationsArray();  
        }
        /// <summary>
        /// Конвертирует текст в позицию
        /// </summary>
        /// <param name="text"></param>
        /// <returns>возвращщает позицию</returns>
        public Position ConvertPosition(string text)
        {
            return PositionOperations.ConvertPosition(text);
        }
        /// <summary>
        /// Возвращает список всех игроков из бд
        /// </summary>
        /// <returns></returns>
        public List<Player> LoadAllEntities()
        {
            return Repository.ReadAll().ToList();
        }
        /// <summary>
        /// Конвертирует номер в позицию
        /// </summary>
        /// <param name="index"></param>
        /// <returns>возвращает обхект позиции</returns>
        public Position ConvertPosition(int index)
        {
           return PositionOperations.ConvertPosition(index);
        }
        /// <summary>
        /// Возвращает массив всех позиций
        /// </summary>
        /// <returns>возвращает массив строк позиций</returns>
        public string[] GetPositions()
        {
            return PositionOperations.GetPositions();
        }
        /// <summary>
        /// Возвращает массив строк всех игроков
        /// </summary>
        /// <returns>возвращает массив строк игрокав</returns>
        public string[] EntitiesToStrings()
        {

            return Repository.ReadAll().Select(p => $"{p.Name}, {p.Number}, {p.Nation}, {p.Position}, {p.Height}, {p.Weight}")
                          .ToArray();
        }
     
       
        /// <summary>
        /// группирует по позиции и возвращает словарь позиция-игрок
        /// </summary>
        /// <returns>словарь позиция-игрок</returns>
        public Dictionary<Position, List<Player>> GroupPlayersByPosition()
        {
            return Operations.GroupPlayersByPosition();
        }
        /// <summary>
        /// Загружает всех игроков в формате DTO для отображения в UI
        /// </summary>
        /// <returns>Список PlayerDto для View</returns>
        public IEnumerable<PlayerDto> LoadAllEntitiesDto()
        {
            return Repository.ReadAll().Select(MapToDto);
        }

        /// <summary>
        /// Добавляет нового игрока из DTO данных
        /// </summary>
        public void AddEntityDto(int number, string name, string nation, string position, int height, int weight)
        {
            Position pos = (Position)Enum.Parse(typeof(Position), position);
            Repository.Add(new Player(number, name, nation, pos, height, weight));
        }

        /// <summary>
        /// Изменяет существующего игрока по ID из DTO данных
        /// </summary>
        public void ChangeEntityByIdDto(int id, int number, string name, string nation, string position, int height, int weight)
        {
            Position pos = (Position)Enum.Parse(typeof(Position), position);
            Operations.ChangePlayerByID(id, number, name, nation, pos, height, weight);
        }

        /// <summary>
        /// Удаляет игрока по ID
        /// </summary>
        public void RemoveEntityByIdDto(int id)
        {
            Repository.Delete(id);
        }

        /// <summary>
        /// Возвращает список позиций как строк для UI
        /// </summary>
        public string[] GetPositionsDto()
        {
            return PositionOperations.GetPositions();
        }

        /// <summary>
        /// Возвращает список национальностей как строк для UI
        /// </summary>
        public string[] GetNationsDto()
        {
            return Operations.GetNationsArray();
        }

        /// <summary>
        /// Группирует игроков по позиции (DTO)
        /// </summary>
        public IEnumerable<PlayerDto> GroupByPositionDto(string positionStr)
        {
            Position pos = (Position)Enum.Parse(typeof(Position), positionStr);
            return Operations.GetByPosition(pos).Select(MapToDto);
        }

        /// <summary>
        /// Группирует игроков по национальности (DTO)
        /// </summary>
        public IEnumerable<PlayerDto> GroupByNationDto(string nation)
        {
            return Operations.GetByNation(nation).Select(MapToDto);
        }

        /// <summary>
        /// Вспомогательный метод преобразования Entity в DTO
        /// </summary>
        private PlayerDto MapToDto(Player player)
        {
            PlayerDto dto = new PlayerDto();
            dto.Id = player.ID;
            dto.Number = player.Number;
            dto.Name = player.Name;
            dto.Nation = player.Nation;
            dto.Position = player.Position.ToString();
            dto.Height = player.Height;
            dto.Weight = player.Weight;
            return dto;
        }

    }
}
