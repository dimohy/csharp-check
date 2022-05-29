using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfComboBoxBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> Items { get; }
        public string ItemKind { get; }
        public Item SelecredItem { get; set; }

        public MainWindow()
        {
            ItemKind = "Group A";
            Items = new()
            {
                new("A"),
                new("B"),
                new("C"),
                new("D"),
            };

            DataContext = this;

            InitializeComponent();
        }
    }

    public class Item
    {
        public string Text { get; }

        public Item(string text) => Text = text;
    }
}
