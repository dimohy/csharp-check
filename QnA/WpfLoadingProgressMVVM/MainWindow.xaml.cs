using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfLoadingProgressMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel? _vm;

        public MainWindow()
        {
            InitializeComponent();


            _vm = new MainViewModel();
            DataContext = _vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ = _vm!.LoadAsync();
        }
    }
}
