using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.ComponentModel;

namespace N31.BlazorServerMVVM.Base;

public abstract class ViewModelBase : ObservableObject, IStateHasChanged
{
    Action IStateHasChanged.StateHasChanged { get; set; } = () => { };

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        StateHasChanged();
    }

    protected void StateHasChanged() => (this as IStateHasChanged).StateHasChanged();

    protected void StartAsyncCommand(IAsyncRelayCommand asyncRelayCommand)
    {
        asyncRelayCommand.PropertyChanged += AsyncRelayCommand_PropertyChanged;

        void AsyncRelayCommand_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is nameof(IAsyncRelayCommand.IsRunning) && asyncRelayCommand.IsRunning is false)
            {
                StateHasChanged();

                asyncRelayCommand.PropertyChanged -= AsyncRelayCommand_PropertyChanged;
            }
        }
    }
}
