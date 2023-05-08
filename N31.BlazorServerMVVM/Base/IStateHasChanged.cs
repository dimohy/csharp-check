namespace N31.BlazorServerMVVM.Base;

public interface IStateHasChanged
{
    Action StateHasChanged { get; set; }
}
