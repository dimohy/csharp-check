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

namespace WpfSelectedTwoFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FilterInfo RootFilter { get; } = new FilterInfo("ROOT", new List<FilterInfo> {
            new FilterInfo("depth1_1", new List<FilterInfo>
            {
                new FilterInfo("depth2_11", Enumerable.Empty<FilterInfo>()),
                new FilterInfo("depth2_12", Enumerable.Empty<FilterInfo>()),
                new FilterInfo("depth2_13", Enumerable.Empty<FilterInfo>())
            }),
            new FilterInfo("depth1_2", Enumerable.Empty<FilterInfo>()),
            new FilterInfo("depth1_3", Enumerable.Empty<FilterInfo>()),
        });

        public SelectedFilter SelectedFilter { get; } = new SelectedFilter();

        public MainWindow()
        {
            DataContext = this;
            
            InitializeComponent();
        }
    }

    public class SelectedFilter : INotifyPropertyChanged
    {
        private FilterInfo? _depth1;
        private FilterInfo? _depth2;

        public event PropertyChangedEventHandler? PropertyChanged;

        public FilterInfo? Depth1
        {
            get => _depth1;
            set
            {
                if (_depth1 != value)
                {
                    _depth1 = value;
                    OnPropertyChanged(nameof(Depth1));
                }
            }
        }
        public FilterInfo? Depth2
        {
            get => _depth2;
            set
            {
                if (_depth2 != value)
                {
                    _depth2 = value;
                    OnPropertyChanged(nameof(Depth2));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FilterInfo
    {
        public string Text { get; }
        public IEnumerable<FilterInfo> Children { get; }
        
        public FilterInfo(string text, IEnumerable<FilterInfo> children)
        {
            this.Text = text;
            this.Children = children;
        }
    }
}
