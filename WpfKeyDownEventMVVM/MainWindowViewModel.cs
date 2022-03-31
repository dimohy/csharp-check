using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfKeyDownEventMVVM
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        [ObservableProperty]
        private string _downKey = string.Empty;
    }
}
