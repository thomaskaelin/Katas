using System;
using KataYatzy.UI.VM;
using System.Windows;
using System.Windows.Controls;
using KataYatzy.Contracts;
using MessageBox = System.Windows.MessageBox;

namespace KataYatzy.UI.WPF
{
    public partial class MainWindow : Window
    {
        private readonly ScoreBoardViewModel _scoreBoardViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _scoreBoardViewModel = new ScoreBoardViewModel();
            _scoreBoardViewModel.ShowGameFinishedMessage += DoOnShowGameFinishedMessage;
            DataContext = _scoreBoardViewModel;
        }

        private void DoOnShowGameFinishedMessage(object sender, GameFinishedEventArgs e)
        {
            var message = MessageBox.Show("Gewinner: "+ e.Winner.Name + Environment.NewLine + "Erneut spielen?" , "Spiel beendet", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                _scoreBoardViewModel.RestartGame();
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRowIndex = scoreBoardTable.SelectedIndex;
            _scoreBoardViewModel.ChooseCombination(selectedRowIndex);
        }
        
    }
}
