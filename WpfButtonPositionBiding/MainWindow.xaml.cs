using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfButtonPositionBiding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _buttonX = 100;
        private int _buttonY = 100;

        public int ButtonX
        {
            get => _buttonX;
            set
            {
                if (_buttonX == value)
                    return;

                _buttonX = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonX)));
            }
        }
        public int ButtonY
        {
            get => _buttonY;
            set
            {
                if (_buttonY == value)
                    return;

                _buttonY = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonY)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() =>
                    {
                        ButtonX = Random.Shared.Next((int)ActualWidth);
                        ButtonY = Random.Shared.Next((int)ActualHeight);
                    });

                    //Thread.Sleep(100);
                }
            });
        }
    }
}
