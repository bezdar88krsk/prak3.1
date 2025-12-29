using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace ProjectLogic
{
    public interface ILogic
    {
        /// <summary>
        /// Добавляет сущность
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="nation"></param>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        void AddEntity(int number, string name, string nation, Position position, int height, int weight);
        /// <summary>
        /// Удаляет сущность по айди
        /// </summary>
        /// <param name="entityID"></param>
        void RemoveEntityByID(int entityID);
        /// <summary>
        /// Удаляет сущность по индексу
        /// </summary>
        /// <param name="index"></param>
        void RemoveEntityByIndex(int index);
        /// <summary>
        /// Изменяет сущнсоть с введенным индексом
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="nation"></param>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        void ChangeEntityByID(int ID, int number, string name, string nation, Position position, int height, int weight);
        /// <summary>
        /// Возвращает сущность
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Player GetEntity(int ID);
        /// <summary>
        /// Возвращает все сущности
        /// </summary>
        /// <returns></returns>
        List<Player> LoadAllEntities();
        /// <summary>
        /// преобразует сущности в массив строк
        /// </summary>
        /// <returns></returns>
        string[] EntitiesToStrings();
        /// <summary>
        /// Возвращает список игроков, сгруппированных по позиции
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        List<Player> GroupByPosition(Position position);
        /// <summary>
        /// Возвращает список игроков, сгруппированных по нации
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        List<Player> GroupByNation(string nation);
        /// <summary>
        /// Возвращает список наций игроков из бд
        /// </summary>
        /// <returns></returns>
        List<string> GetNations();
        /// <summary>
        /// Возвращает позицию по тексту
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Position ConvertPosition(string text);
        /// <summary>
        /// Возвращает массив наций игроков из бд
        /// </summary>
        /// <returns></returns>
        string[] GetNationsArray();
        /// <summary>
        /// Возвращает позицию по её индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Position ConvertPosition(int index);
        /// <summary>
        /// Возвращает массив строк всех позиций
        /// </summary>
        /// <returns></returns>
        string[] GetPositions();
        /// <summary>
        /// возвращает словарь Позиция - Список игроков данной позиции
        /// </summary>
        /// <returns></returns>
        Dictionary<Position, List<Player>> GroupPlayersByPosition();
        /// <summary>
        /// Загружает всех игроков в формате DTO для отображения в UI
        /// </summary>
        /// <returns>Список PlayerDto для View</returns>
        IEnumerable<PlayerDto> LoadAllEntitiesDto();

        /// <summary>
        /// Добавляет нового игрока из DTO данных
        /// </summary>
        /// <param name="number">Номер игрока</param>
        /// <param name="name">Имя и фамилия</param>
        /// <param name="nation">Национальность</param>
        /// <param name="position">Позиция как строка</param>
        /// <param name="height">Рост</param>
        /// <param name="weight">Вес</param>
        void AddEntityDto(int number, string name, string nation, string position, int height, int weight);

        /// <summary>
        /// Изменяет существующего игрока по ID из DTO данных
        /// </summary>
        /// <param name="id">ID игрока</param>
        /// <param name="number">Новый номер</param>
        /// <param name="name">Новое имя</param>
        /// <param name="nation">Новая национальность</param>
        /// <param name="position">Новая позиция (строка)</param>
        /// <param name="height">Новый рост</param>
        /// <param name="weight">Новый вес</param>
        void ChangeEntityByIdDto(int id, int number, string name, string nation, string position, int height, int weight);

        /// <summary>
        /// Удаляет игрока по ID
        /// </summary>
        /// <param name="id">ID игрока для удаления</param>
        void RemoveEntityByIdDto(int id);

        /// <summary>
        /// Возвращает список позиций как строк для UI
        /// </summary>
        string[] GetPositionsDto();

        /// <summary>
        /// Возвращает список национальностей как строк для UI
        /// </summary>
        string[] GetNationsDto();

        /// <summary>
        /// Группирует игроков по позиции (DTO)
        /// </summary>
        IEnumerable<PlayerDto> GroupByPositionDto(string position);

        /// <summary>
        /// Группирует игроков по национальности (DTO)
        /// </summary>
        IEnumerable<PlayerDto> GroupByNationDto(string nation);
    }
}
