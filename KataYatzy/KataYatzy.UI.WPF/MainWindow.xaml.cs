using System.Windows;
using KataYatzy.UI.VM;

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
    }
}
