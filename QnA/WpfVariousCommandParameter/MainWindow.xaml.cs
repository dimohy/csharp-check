using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Windows;
using System.Windows.Input;

namespace WpfVariousCommandParameter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

[INotifyPropertyChanged]
public partial class MainWindow : Window
{
    [ObservableProperty]
    private string _message = default!;

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        //CommandManager.InvalidateRequerySuggested();

        RelayCommand
    }

    [RelayCommand]
    private void OnButton(object args)
    {
        switch (args)
        {
            case string text:
                Message = $"{args.GetType().Name}: {text}";

                break;
            case int num:
                Message = $"{args.GetType().Name}: {num}";

                break;
            case ManyParams manyParams:
                Message = $"{args.GetType().Name}: {manyParams}";

                break;
        }
    }
}

public class ManyParams
{
    public string Text { get; set; } = default!;
    public int Number { get; set; }

    public bool Boolean { get; set; }

    public override string ToString()
    {
        return $"{Text}, {Number}, {Boolean}";
    }
}