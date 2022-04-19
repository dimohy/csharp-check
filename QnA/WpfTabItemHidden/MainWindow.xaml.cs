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

namespace WpfTabItemHidden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            for (var i = 3; i > 0; i--)
            {
                lodingLabel.Text = $"{i}초 남았습니다.";

                await Task.Delay(1000);
            }
            lodingLabel.Text = $"0초 남았습니다.";
            lodingTabHeader.Visibility = Visibility.Collapsed;

            foreach (TabItem tabItem in tab.Items)
                tabItem.IsEnabled = true;
            tab.SelectedItem = tab1;
        }
    }
}
