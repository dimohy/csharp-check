using CommunityToolkit.Mvvm.ComponentModel;

using System.ComponentModel;

namespace N31.BlazorServerMVVM.Base;

public abstract class ViewModelBase : ObservableObject, IStateHasChanged
{
    Action IStateHasChanged.StateHasChanged { get; set; } = () => { };

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        (this as IStateHasChanged).StateHasChanged();
    }
}
