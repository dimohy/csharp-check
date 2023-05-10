using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using N31.BlazorServerMVVM.Base;

namespace N31.BlazorServerMVVM.ViewModels;

public partial class IndexViewModel : ViewModelBase
{
    [ObservableProperty] private int _count;
    [ObservableProperty] private int _inputCount = 200;


    [ObservableProperty] private bool _refresh;


    [RelayCommand(IncludeCancelCommand = true)]
    public async Task OnCountAsync(CancellationToken ct)
    {
        StartAsyncCommand(CountCommand);

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