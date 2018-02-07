using KataYatzy.UI.VM;
using System.Windows;
using System.Windows.Controls;

namespace KataYatzy.UI.WPF
{
    public partial class MainWindow : Window
    {
        private readonly ScoreBoardViewModel _scoreBoardViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _scoreBoardViewModel = new ScoreBoardViewModel();
            DataContext = _scoreBoardViewModel;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRowIndex = scoreBoardTable.SelectedIndex;
            _scoreBoardViewModel.ChooseCombination(selectedRowIndex);
        }
        
    }
}
