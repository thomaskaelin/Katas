using System.Collections.Generic;
using System.Data;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KataYatzy.Contracts;
using KataYatzy.Shared;
using KataYatzy.Shared.Combinations;

namespace KataYatzy.UI.VM
{
    public class ScoreBoardViewModel : ViewModelBase
    {
        private IScoreBoard _scoreBoard;
        private ITossFactory _tossFactory;
        private DataView _table;

        public ScoreBoardViewModel()
        {
            InitializeScoreBoard();
            InitializeTossFactory();

            CreateTossCommand = new RelayCommand(CreateTossCommandExecute);
        }

        #region Properties for Binding

        public IList<IPlayer> Players => _scoreBoard.Players;

        public IList<ICombination> Combinations => _scoreBoard.Combinations;

        public string CurrentToss { get; private set; }

        public RelayCommand CreateTossCommand { get; }

        public DataView Table
        {
            get { return _table; }
            set
            {
                _table = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Private Methods

        private void InitializeScoreBoard()
        {
            _scoreBoard = new ScoreBoard();

            AddPlayer("Loana");
            AddPlayer("Thomas");

            AddCombination(new OnesCombination());
            AddCombination(new ThreeOfAKindCombination());
            AddCombination(new FullHouseCombination());
            AddCombination(new SmallStraightCombination());
            AddCombination(new ChanceCombination());

            CreateTable();
        }

        private void InitializeTossFactory()
        {
            _tossFactory = new TossFactory(5, 1, 6);
        }

        private void AddPlayer(string playerName)
        {
            _scoreBoard.AddPlayer(new Player(playerName));
            RaisePropertyChanged(() => Players);
        }

        private void AddCombination(ICombination combination)
        {
            _scoreBoard.AddCombination(combination);
            RaisePropertyChanged(() => Combinations);
        }

        private void CreateTossCommandExecute()
        {
            var newToss = _tossFactory.CreateToss();
            CurrentToss = string.Join(",", newToss.Dices.Select(d => d.Value.ToString()));
            RaisePropertyChanged(() => CurrentToss);
        }

        private void CreateTable()
        {
            var dataTable =  new DataTable();
            dataTable.Columns.Add("Combination");
            foreach (var player in Players)
            {
                dataTable.Columns.Add(player.Name);
            }

            foreach (var combination in Combinations)
            {
                var columnsForCombination = new List<object> {combination.Type.ToString()};

                foreach (var player in Players)
                {
                    if (_scoreBoard.HasPointsForCombination(player, combination.Type))
                    {
                        columnsForCombination.Add(_scoreBoard.GetPointsForCombination(player, combination.Type).Value);
                    }
                    else
                    {
                        columnsForCombination.Add(string.Empty);
                    }
                }

                dataTable.Rows.Add(columnsForCombination.ToArray());
            }
            var columnsForTotal = new List<object>{"Total"};
            foreach (var player in Players)
            {
                columnsForTotal.Add(_scoreBoard.GetTotalPoints(player).Value);
            }
            dataTable.Rows.Add(columnsForTotal.ToArray());

            Table = dataTable.DefaultView;
        }

        #endregion
    }
}