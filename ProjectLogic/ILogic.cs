using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
