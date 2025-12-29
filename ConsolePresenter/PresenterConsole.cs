using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLogic1;
using ProjectLogic;
using Shared;

namespace ConsolePresenter
{
    public class PresenterConsole
    {
        private readonly ILogic _logic;
        private readonly IConsoleView _view;

        private readonly string[] _menuItems =
        {
            "Просмотреть список игроков",
            "Добавить игрока",
            "Удалить игрока",
            "Изменить игрока",
            "Найти по позиции",
            "Найти по национальности",
            "Настоящая группировка",
            "Выход"
        };

        public PresenterConsole(ILogic logic, IConsoleView view)
        {
            _logic = logic;
            _view = view;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            int choice;
            do
            {
                choice = _view.ShowMenu("Главное меню", _menuItems);
                HandleMenuChoice(choice);
            } while (choice != 7);

            _view.Clear();
            _view.WriteLine("До свидания");
        }

        private void HandleMenuChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    ShowAllPlayers();
                    break;
                case 1:
                    AddPlayer();
                    break;
                case 2:
                    RemovePlayer();
                    break;
                case 3:
                    ChangePlayer();
                    break;
                case 4:
                    ShowGroupedByPosition();
                    break;
                case 5:
                    ShowGroupedByNation();
                    break;
                case 6:
                    ShowRealGrouping();
                    break;
            }
        }

        private void ShowAllPlayers()
        {
            _view.ShowPlayers(_logic.LoadAllEntitiesDto());
            _view.WaitKey();
        }

        private void AddPlayer()
        {
            _view.Clear();
            _view.WriteLine("--Добавление игрока--");

            _view.WriteLine("Введите имя и фамилию игрока");
            string name = _view.ReadLine();

            int number = _view.ReadInt("Введите номер игрока");
            _view.Clear();

            _view.WriteLine("Введите национальность игрока");
            string nation = _view.ReadLine();

            Position pos = _logic.ConvertPosition(
                _view.ChooseOption("Выберите позицию", _logic.GetPositions())
            );

            int height = _view.ReadInt("Введите рост игрока");
            int weight = _view.ReadInt("Введите вес игрока");

            _logic.AddEntity(number, name, nation, pos, height, weight);

            _view.Clear();
            _view.WriteLine("Игрок добавлен");
            _view.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            _view.WaitKey();
        }

        private void ChangePlayer()
        {
            _view.Clear();
            var players = _logic.LoadAllEntities().ToList();

            if (!players.Any())
            {
                _view.WriteLine("Нет игроков для изменения");
                _view.WaitKey();
                return;
            }

            string[] descriptions = players
                .Select(p => $"{p.Name} (ID: {p.ID})")
                .ToArray();

            int index = _view.ChooseOption("Выберите игрока", descriptions);
            var selected = players[index];

            string name = selected.Name;
            int number = selected.Number;
            string nation = selected.Nation;
            int height = selected.Height;
            int weight = selected.Weight;
            Position position = selected.Position;

            string[] props = { "Имя", "Номер", "Нация", "Позиция", "Рост", "Вес" };
            int propIndex = _view.ChooseOption("Выберите свойство для изменения", props);
            _view.Clear();

            switch (propIndex)
            {
                case 0:
                    _view.WriteLine($"Старое имя: {name}");
                    name = _view.ReadLine();
                    break;
                case 1:
                    _view.WriteLine($"Старый номер: {number}");
                    number = _view.ReadInt("Введите новый номер");
                    break;
                case 2:
                    _view.WriteLine($"Старая нация: {nation}");
                    nation = _view.ReadLine();
                    break;
                case 3:
                    position = _logic.ConvertPosition(
                        _view.ChooseOption(
                            $"Выберите позицию (старая: {position})",
                            _logic.GetPositions())
                    );
                    break;
                case 4:
                    _view.WriteLine($"Старый рост: {height}");
                    height = _view.ReadInt("Введите новый рост");
                    break;
                case 5:
                    _view.WriteLine($"Старый вес: {weight}");
                    weight = _view.ReadInt("Введите новый вес");
                    break;
            }

            _logic.ChangeEntityByID(selected.ID, number, name, nation, position, height, weight);

            _view.WriteLine("Игрок изменен");
            _view.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            _view.WaitKey();
        }

        private void RemovePlayer()
        {
            _view.Clear();
            var players = _logic.LoadAllEntities().ToList();

            if (!players.Any())
            {
                _view.WriteLine("Нет игроков для удаления");
                _view.WaitKey();
                return;
            }

            string[] descriptions = players
                .Select(p => $"{p.Number} {p.Name} {p.Position} {p.Nation}")
                .ToArray();

            int index = _view.ChooseOption("Выберите игрока", descriptions);
            int id = players[index].ID;

            _logic.RemoveEntityByID(id);

            _view.WriteLine("Игрок удалён");
            _view.WaitKey();
        }

        private void ShowGroupedByPosition()
        {
            _view.Clear();
            Position pos = _logic.ConvertPosition(
                _view.ChooseOption("Выберите позицию", _logic.GetPositions())
            );

            var players = _logic.GroupByPositionDto(pos.ToString());
            _view.ShowPlayers(players);
            _view.WaitKey();
        }

        private void ShowGroupedByNation()
        {
            _view.Clear();
            var nations = _logic.GetNationsArray();
            if (nations.Length == 0)
            {
                _view.WriteLine("Нет наций");
                _view.WaitKey();
                return;
            }

            string nation = nations[_view.ChooseOption("Выберите нацию", nations)];
            var players = _logic.GroupByNationDto(nation);
            _view.ShowPlayers(players);
            _view.WaitKey();
        }

        private void ShowRealGrouping()
        {
            _view.Clear();
            var grouped = _logic.GroupPlayersByPosition();
            foreach (var group in grouped)
            {
                _view.WriteLine($"Position: {group.Key}");
                foreach (var player in group.Value)
                {
                    _view.WriteLine($"  {player.Name}");
                }
            }
            _view.WaitKey();
        }
    }
}
