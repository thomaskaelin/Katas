using System.Collections.Generic;
using System.Data;
using System.Linq;
using GalaSoft.MvvmLight;
using KataYatzy.Shared;

namespace KataYatzy.UI.VM
{
    public class ScoreBoardViewModel : ViewModelBase
    {
        private readonly GameEngine _gameEngine;
        private DataView _table;

        public ScoreBoardViewModel()
        {
            _gameEngine = new GameEngine();
            _gameEngine.NewTurnStarted += DoOnNewTurnStarted;
            _gameEngine.Start();

            CreateTable();
        }

        #region Properties for Binding

        public string CurrentToss { get; private set; }

        public string CurrentPlayer { get; private set; }

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

        private void DoOnNewTurnStarted(object sender, NewTurnEventArgs e)
        {
            CurrentToss = string.Join(",", e.Toss.Dices.Select(d => d.Value.ToString()));
            CurrentPlayer = e.Player.Name;
        }
        
        private void CreateTable()
        {
            var dataTable =  new DataTable();
            dataTable.Columns.Add("Combination");
            foreach (var player in _gameEngine.ScoreBoard.Players)
            {
                dataTable.Columns.Add(player.Name);
            }

            foreach (var combination in _gameEngine.ScoreBoard.Combinations)
            {
                var columnsForCombination = new List<object> {combination.Type.ToString()};

                foreach (var player in _gameEngine.ScoreBoard.Players)
                {
                    if (_gameEngine.ScoreBoard.HasPointsForCombination(player, combination.Type))
                    {
                        columnsForCombination.Add(_gameEngine.ScoreBoard.GetPointsForCombination(player, combination.Type).Value);
                    }
                    else
                    {
                        columnsForCombination.Add(string.Empty);
                    }
                }

                dataTable.Rows.Add(columnsForCombination.ToArray());
            }
            var columnsForTotal = new List<object>{"Total"};
            foreach (var player in _gameEngine.ScoreBoard.Players)
            {
                columnsForTotal.Add(_gameEngine.ScoreBoard.GetTotalPoints(player).Value);
            }
            dataTable.Rows.Add(columnsForTotal.ToArray());

            Table = dataTable.DefaultView;
        }

        #endregion
    }
}