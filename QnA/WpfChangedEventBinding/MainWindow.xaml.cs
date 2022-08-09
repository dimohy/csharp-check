using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfChangedEventBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _text = "123";
        public string Text
        {
            get => _text;
            set
            {
                if (value == _text)
                    return;

                _text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void changeTextButton_Click(object sender, RoutedEventArgs e)
        {
            Text = "소스에서 변경함";
        }

        private void textBox_Updated(object sender, DataTransferEventArgs e)
        {
            if (e.RoutedEvent.Name is "TargetUpdated")
                message.Content = "ViewModel에서 수정함";
            if (e.RoutedEvent.Name is "SourceUpdated")
                message.Content = "View에서 수정함";
        }
    }
}
