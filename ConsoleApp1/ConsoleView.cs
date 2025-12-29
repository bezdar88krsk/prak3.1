using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace ConsoleApp1
{
    public class ConsoleView : IConsoleView
    {
        /// <summary>
        /// Отображает список игроков в консольном формате
        /// </summary>
        public void ShowPlayers(IEnumerable<PlayerDto> players)
        {
            Console.Clear();
            Console.WriteLine("ID | Номер | Имя              | Нация      | Позиция | Рост | Вес");
            Console.WriteLine(new string('-', 60));

            foreach (var p in players)
            {
                Console.WriteLine("{0,-3}|{1,-6}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}",
                    p.Id, p.Number, p.Name ?? "", p.Nation ?? "", p.Position ?? "",
                    p.Height, p.Weight);
            }
        }

        /// <summary>
        /// Отображает группу игроков с заголовком
        /// </summary>
        public void ShowGroupedPlayers(string groupName, IEnumerable<PlayerDto> players)
        {
            Console.Clear();
            Console.WriteLine($"=== {groupName} ===");
            Console.WriteLine("ID | Номер | Имя              | Нация      | Позиция | Рост | Вес");
            Console.WriteLine(new string('-', 60));

            foreach (var p in players)
            {
                Console.WriteLine("{0,-3}|{1,-6}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}",
                    p.Id, p.Number, p.Name ?? "", p.Nation ?? "", p.Position ?? "",
                    p.Height, p.Weight);
            }
        }

        /// <summary>
        /// Выбор игрока из списка описаний
        /// </summary>
        public int ChoosePlayer(string[] playerDescriptions)
        {
            return ChooseOption("Выберите игрока", playerDescriptions);
        }

        public int ShowMenu(string title, string[] items)
        {
            return ChooseOption(title, items);
        }

        public void Clear() => Console.Clear();
        public void WriteLine(string text) => Console.WriteLine(text);
        public void Write(string text) => Console.Write(text);
        public void WaitKey() => Console.ReadKey(true);
        public string ReadLine() => Console.ReadLine();

        public int ReadInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;
                Console.WriteLine("Введите целое число!");
            }
        }

        public int ChooseOption(string title, string[] items)
        {
            int selectedIndex = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine(title);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex == 0) ? items.Length - 1 : selectedIndex - 1;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex == items.Length - 1) ? 0 : selectedIndex + 1;

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }

        public void ShowPlayers(IEnumerable<Player> players)
        {
            Console.Clear();
            foreach (var player in players)
            {
                Console.WriteLine(
                    "{0,-3}|{1,-4}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}",
                    player.ID, player.Number, player.Name,
                    player.Nation, player.Position, player.Height, player.Weight);
            }
        }

    }
}
