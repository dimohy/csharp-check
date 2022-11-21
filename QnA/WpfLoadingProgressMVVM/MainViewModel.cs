using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLoadingProgressMVVM
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string _message = default!;

        public async Task LoadAsync()
        {
            IsLoading = true;
            Message = "읽는중...";

            await Task.Delay(5000);
            IsLoading = false;
            Message = "읽기 완료";
        }
    }
}
