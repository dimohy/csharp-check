using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using N31.BlazorServerMVVM.Base;

using System.ComponentModel;

namespace N31.BlazorServerMVVM.ViewModels;

public partial class IndexViewModel : ViewModelBase
{
    [ObservableProperty] private int _count;
    [ObservableProperty] private int _inputCount = 200;

    [RelayCommand]
    public async Task OnCountAsync(CancellationToken ct)
    {
        try
        {
            for (var i = 0; i < InputCount; i++)
            {
                Count++;

                await Task.Delay(10, ct);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }
}