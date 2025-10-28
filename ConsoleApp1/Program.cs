using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ModelLogic1;
using ProjectLogic;
namespace ConsoleApp1
{
    internal class Program
    {
        static Logic logic = new Logic();
        /// <summary>
        /// Запускает меню добавления игрока
        /// </summary>
        static void AddPlayerOption()
        {
            Console.Clear();
            Console.WriteLine("--Добавление игрока--");
            Console.Clear();
            Console.WriteLine("Введите имя и фамилию игрока");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите номер игрока");
            int number = IntInput();
            Console.Clear();
            Console.WriteLine("Введите национальность игрока");
            string nation = Console.ReadLine();
            Console.Clear();
            Position pos = logic.ConvertPosition(ChooseOption(logic.GetPositions(),"Выберите позицию"));
            Console.Clear();
            Console.WriteLine("Введите рост игрока");
            int height = IntInput();
            Console.Clear();
            Console.WriteLine("Введите вес игрока");
            int weight = IntInput();
            Console.Clear();
            logic.AddPlayer(number, name, nation, pos, height, weight);
            Console.WriteLine("Игрок добавлен");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }
        /// <summary>
        /// Запускает опцию изменения игрока
        /// </summary>
        static void ChangePlayerOption()
        {
            Console.Clear();

            // Получаем всех игроков
            var players = logic.LoadAllPlayers();

            // Массив строк с описанием игроков для меню выбора
            string[] playerDescriptions = players.Select(p => $"{p.Name} (ID: {p.ID})").ToArray();

            // Выбор игрока по индексу в списке
            int selectedIndex = ChooseOption(playerDescriptions, "Выберите игрока");

            // Получаем выбранного игрока по индексу
            Player selectedPlayer = players[selectedIndex];

            string name = selectedPlayer.Name;
            int number = selectedPlayer.Number;
            string nation = selectedPlayer.Nation;
            int weight = selectedPlayer.Weight;
            int height = selectedPlayer.Height;
            Position position = selectedPlayer.Position;

            string[] props = new string[] { "Имя", "Номер", "Нация", "Позиция", "Рост", "Вес" };
            int choose = ChooseOption(props, "ВЫБЕРИТЕ СВОЙСТВО, КОТОРОЕ ХОТИТЕ ПОМЕНЯТЬ");
            Console.Clear();

            switch (choose)
            {
                case 0:
                    Console.WriteLine($"Старое имя:\t{name}");
                    name = Console.ReadLine();
                    Console.Clear();
                    break;
                case 1:
                    Console.WriteLine($"Старый номер \t{number}");
                    number = IntInput();
                    break;
                case 2:
                    Console.WriteLine($"Старая национальность \t{nation}");
                    nation = Console.ReadLine();
                    break;
                case 3:
                    position = logic.ConvertPosition(ChooseOption(logic.GetPositions(), $"Выберите позицию, старая позиция \t{position.ToString()}"));
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine($"Старый рост \t{height}");
                    height = IntInput();
                    break;
                case 5:
                    Console.WriteLine($"Старый вес \t{weight}");
                    weight = IntInput();
                    break;
            }

            
            logic.ChangePlayerByID(selectedPlayer.ID, number, name, nation, position, height, weight);

            Console.WriteLine("Игрок изменен");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }
        /// <summary>
        /// Запускает опцию удаления игрока
        /// </summary>
        static void RemovePlayerOption()
        {
            var players = logic.LoadAllPlayers();

            // Создать массив строк для выбора игрока, например, "Имя (ID)"
            string[] playerDescriptions = players.Select(p => $"{p.Number} {p.Name} (ID: {p.Position} {p.Nation}").ToArray();

            // Запросить у пользователя выбор индекса из этого списка
            int selectedIndex = ChooseOption(playerDescriptions, "Выберите игрока");

            // Получить ID выбранного игрока по его индексу в списке
            int selectedPlayerId = players[selectedIndex].ID;

            // Вызвать удаление по ID в логике
            logic.RemovePlayerByID(selectedPlayerId);
        }
        /// <summary>
        /// Ввод целого числа
        /// </summary>
        /// <returns></returns>
        static int IntInput()
        {
            int result = 0;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Введите число!!!!!!");
                }

            }
        }
        /// <summary>
        /// Запускает отображения игроков сгруппированных по позиции
        /// </summary>
        static void ShowGrouppedByPosition()
        {
            Console.Clear();
            Position pos = logic.ConvertPosition(ChooseOption(logic.GetPositions(), "Выберите позицию"));
            foreach (var player in logic.GroupByPosition(pos))
            {
                Console.WriteLine("{0,-3}|{1,-4}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}", player.ID, player.Number, player.Name, player.Nation, player.Position, player.Height, player.Weight);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// оторажает игроков сгруппированных по национальности
        /// </summary>
        static void ShowGrouppedByNation()
        {
            Console.Clear();
            string nation = logic.GetNationsArray()[ChooseOption(logic.GetNationsArray(), "Выберите национальность")];
            foreach (var player in logic.GroupByNation(nation))
            {
                Console.WriteLine("{0,-3}|{1,-4}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}", player.ID, player.Number, player.Name, player.Nation, player.Position, player.Height, player.Weight);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Метод, запускающий интерактивный выбор опций
        /// </summary>
        /// <param name="menuItems">списко вариантов</param>
        /// <param name="text">текст, который необходимо выводить при отображении опций</param>
        /// <returns>возвращает индекс выбранного варианта</returns>
        static int ChooseOption(string[] menuItems, string text)
        {
            
            
            int selectedIndex = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine(text);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        // Подсветка выбранного пункта
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }

            } while (key != ConsoleKey.Enter);
            return selectedIndex;
        }
        static void Main(string[] args)
        {
            string[] menuItems = {"Просмотреть список игроков", "Добавить игрока", "Удалить игрока", "Изменить игрока", "Сгруппировать по позиции","Сгруппировать по национальности","Настоящая группировка", "Выход" };
            Console.CursorVisible = false;
            
            int choise = 0;
            do
            {
                Console.Clear();
                
                choise = ChooseOption(menuItems, "Главное меню");
                switch (choise)
                {
                    case 0:
                        Console.Clear();
                        foreach (var player in logic.LoadAllPlayers())
                        {
                            Console.WriteLine("{0,-3}|{1,-4}|{2,-20}|{3,-12}|{4,-9}|{5,4}|{6,4}", player.ID, player.Number, player.Name, player.Nation, player.Position, player.Height, player.Weight);
                        }
                        Console.ReadKey();
                        break;
                    case 1:
                        AddPlayerOption();

                        break;
                        case 2:
                        RemovePlayerOption();
                        break;
                    case 3:
                        ChangePlayerOption();
                        break;
                    case 4:
                        ShowGrouppedByPosition();
                        break;
                    case 5:
                        ShowGrouppedByNation();
                        break;
                    case 6:
                        Console.Clear();
                        var grouped = logic.GroupPlayersByPosition();
                        foreach (var group in grouped)
                        {
                            Console.WriteLine($"Position: {group.Key}");
                            foreach (var player in group.Value)
                            {
                                Console.WriteLine($"  {player.Name}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    
                }
            } while (choise != 7);
            Console.Clear ();
            Console.WriteLine("До свидания");
            

            

        }
    }
}
