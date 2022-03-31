using System.Windows;
using System.Windows.Input;

namespace WpfKeyDownEventMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewmodel;

        public MainWindow()
        {
            InitializeComponent();

            _viewmodel = new MainWindowViewModel();
            DataContext = _viewmodel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key.ToString();

            _viewmodel.DownKey = key;
        }
    }
}
