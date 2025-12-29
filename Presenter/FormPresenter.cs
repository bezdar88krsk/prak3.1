using Lab3._1;
using ModelLogic1;
using ProjectLogic;
using Shared;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace Presenter
{
    public class FormPresenter
    {
        private ILogic _logic;
        private readonly IFormView _view;

        /// <summary>
        /// Создает экземпляр презентера, подписывает его на события представления
        /// и выполняет начальную инициализацию данных.
        /// </summary>
        /// <param name="logic">
        /// Экземпляр объекта бизнес-логики, реализующий интерфейс ILogic.
        /// </param>
        /// <param name="view">
        /// Экземпляр представления, реализующий интерфейс IFormView, с которым
        /// будет взаимодействовать презентер.
        /// </param>
        public FormPresenter(ILogic logic, IFormView view)
        {
            _logic = logic;
            _view = view;

            _view.ButtonAddClicked += OnButtonAddClicked;
            _view.ButtonDeleteClicked += OnButtonDeleteClicked;
            _view.ButtonEditClicked += OnButtonEditClicked;
            _view.ButtonGroupPositionClicked += OnButtonGroupPositionClicked;
            _view.ButtonGroupNationClicked += OnButtonGroupNationClicked;
            _view.ButtonGroupFormClicked += OnButtonGroupFormClicked;
            _view.CheckBoxPositionChanged += OnCheckBoxPositionChanged;
            _view.CheckBoxNationChanged += OnCheckBoxNationChanged;

            Initialize();
        }

        /// <summary>
        /// Выполняет начальную настройку представления: подгружает список позиций,
        /// список наций и отображает всех игроков в таблице.
        /// </summary>
        private void Initialize()
        {
            _view.SetPositions(_logic.GetPositions());
            _view.SetNations(_logic.GetNations());
            LoadAllPlayers();
        }

        /// <summary>
        /// Загружает из слоя бизнес-логики всех игроков, преобразует их
        /// в DTO PlayerDto и передает коллекцию в представление для отображения.
        /// </summary>
        private void LoadAllPlayers()
        {
            var players = _logic.LoadAllEntities();
            var dto = players.Select(p => new PlayerDto
            {
                Id = p.ID,
                Number = p.Number,
                Name = p.Name,
                Nation = p.Nation,
                Position = p.Position.ToString(),
                Height = p.Height,
                Weight = p.Weight
            }).ToList();
            _view.ShowPlayers(dto);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления игрока в главной форме:
        /// открывает форму добавления, создает для нее презентер,
        /// а после закрытия формы обновляет список игроков и сбрасывает фильтры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonAddClicked(object sender, EventArgs e)
        {
            var addForm = new Lab3._1.AddForm();
            var addPresenter = new AddFormPresenter(_logic, addForm);
            addForm.ShowDialog();
            LoadAllPlayers();
            _view.ResetFilters();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления игрока:
        /// получает ID выбранного игрока из представления, вызывает удаление
        /// через бизнес-логику и обновляет список игроков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonDeleteClicked(object sender, EventArgs e)
        {
            if (_view.SelectedPlayerId.HasValue)
            {
                _logic.RemoveEntityByID(_view.SelectedPlayerId.Value);
                LoadAllPlayers();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки редактирования игрока:
        /// загружает выбранного игрока по ID, открывает форму редактирования,
        /// инициализирует ее данными и после сохранения обновляет список игроков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonEditClicked(object sender, EventArgs e)
        {
            if (!_view.SelectedPlayerId.HasValue)
                return;

            int id = _view.SelectedPlayerId.Value;
            var player = _logic.GetEntity(id);
            if (player == null)
                return;

            
            var changeForm = new Lab3._1.ChangeForm();
            var changePresenter = new ChangeFormPresenter(_logic, changeForm);

            changeForm.PlayerId = player.ID;
            changeForm.PlayerName = player.Name;
            changeForm.PlayerNumber = player.Number.ToString();
            changeForm.PlayerNation = player.Nation;
            changeForm.PlayerPosition = player.Position.ToString();
            changeForm.PlayerHeight = player.Height.ToString();
            changeForm.PlayerWeight = player.Weight.ToString();

            changeForm.ShowDialog();
            LoadAllPlayers();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки группировки по позиции:
        /// получает выбранную позицию из представления, запрашивает у бизнес-логики
        /// список игроков данной позиции и передает результат в представление.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonGroupPositionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SelectedPosition))
                return;

            var pos = _logic.ConvertPosition(_view.SelectedPosition);
            var players = _logic.GroupByPosition(pos);
            var dto = players.Select(p => new PlayerDto
            {
                Id = p.ID,
                Number = p.Number,
                Name = p.Name,
                Nation = p.Nation,
                Position = p.Position.ToString(),
                Height = p.Height,
                Weight = p.Weight
            }).ToList();

            _view.ShowPlayers(dto);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки группировки по нации:
        /// получает выбранную нацию из представления, запрашивает у бизнес-логики
        /// список игроков этой нации и отображает их через представление.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonGroupNationClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SelectedNation))
                return;

            var players = _logic.GroupByNation(_view.SelectedNation);
            var dto = players.Select(p => new PlayerDto
            {
                Id = p.ID,
                Number = p.Number,
                Name = p.Name,
                Nation = p.Nation,
                Position = p.Position.ToString(),
                Height = p.Height,
                Weight = p.Weight
            }).ToList();

            _view.ShowPlayers(dto);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки открытия формы группировки:
        /// создает и показывает окно с группировкой игроков по позициям.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnButtonGroupFormClicked(object sender, EventArgs e)
        {
            var groupForm = new Lab3._1.GroupForm(_logic);
            groupForm.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает изменение состояния чекбокса фильтра по позиции:
        /// при снятии фильтра (нет выбранной позиции) заново загружает всех игроков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnCheckBoxPositionChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SelectedPosition))
                LoadAllPlayers();
        }

        /// <summary>
        /// Обрабатывает изменение состояния чекбокса фильтра по нации:
        /// при снятии фильтра (нет выбранной нации) заново загружает всех игроков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnCheckBoxNationChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(_view.SelectedNation))
                LoadAllPlayers();
        }
    }
}
