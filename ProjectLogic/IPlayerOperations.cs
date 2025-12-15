using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLogic
{
    public interface IPlayerOperations
    {
        /// <summary>
        /// возвращает список игроков введенной позиции
        /// </summary>
        /// <param name="position"></param>
        /// <returns>список игроков</returns>
        IEnumerable<Player> GetByPosition(Position position);
        /// <summary>
        /// Возвращает список игроков, введеннной национальности
        /// </summary>
        /// <param name="nation"></param>
        /// <returns>список игроков</returns>
        IEnumerable<Player> GetByNation(string nation);

        /// <summary>
        /// группирует по позиции и возвращает словарь позиция-игрок
        /// </summary>
        /// <returns>словарь позиция-игрок</returns>
        Dictionary<Position, List<Player>> GroupPlayersByPosition();
        /// <summary>
        /// возвращает список всех наций игроков
        /// </summary>
        /// <returns>возвращает список всех наций игроков</returns>
        List<string> GetAllNations();
        /// <summary>
        /// изменяет игрока по его id
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="nation"></param>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        void ChangePlayerByID(int ID, int number, string name, string nation, Position position, int height, int weight);
        /// <summary>
        /// Возвращает string[] со всеми нациями сущесвтующих игроков
        /// </summary>
        /// <returns>возвращает массив строк национальностей</returns>
         string[] GetNationsArray();
    }
}
