using Microsoft.AspNetCore.Components;

namespace N31.BlazorServerMVVM.Base;

public abstract class ViewModelComponent<TViewModel> : OwningComponentBase
    where TViewModel : IStateHasChanged
{
    public TViewModel ViewModel { get; private set; } = default!;


    protected override void OnInitialized()
    {
        base.OnInitialized();

        ViewModel = ScopedServices.GetRequiredService<TViewModel>();

        ViewModel.StateHasChanged = () => InvokeAsync(StateHasChanged);
    }
}
