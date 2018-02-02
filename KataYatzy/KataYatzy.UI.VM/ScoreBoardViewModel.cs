using System.Collections.Generic;
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

        public ScoreBoardViewModel()
        {
            InitializeScoreBoard();
            InitializeTossFactory();

            CreateTossCommand = new RelayCommand(CreateTossCommandExecute);
        }

        #region Properties for Binding

        public IList<IPlayer> Players => _scoreBoard.Players;

        public IList<IPlayer> Combinations => _scoreBoard.Players;

        public string CurrentToss { get; private set; }

        public RelayCommand CreateTossCommand { get; }

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

        #endregion
    }
}