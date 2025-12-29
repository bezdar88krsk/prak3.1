using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        int ShowMenu(string title, string[] items);
        void Clear();
        void WriteLine(string text);
        void Write(string text);
        void WaitKey();
        string ReadLine();
        int ReadInt(string prompt);
        int ChooseOption(string title, string[] items);
        /// <summary>
        /// Отображает список игроков в консольном формате
        /// </summary>
        /// <param name="players">Список PlayerDto для отображения</param>
        void ShowPlayers(IEnumerable<PlayerDto> players);

        /// <summary>
        /// Позволяет пользователю выбрать игрока из списка описаний
        /// </summary>
        /// <param name="playerDescriptions">Массив строк с описаниями игроков</param>
        /// <returns>Индекс выбранного игрока</returns>
        int ChoosePlayer(string[] playerDescriptions);
        void ShowGroupedPlayers(string groupName, IEnumerable<PlayerDto> players);
    }
}
