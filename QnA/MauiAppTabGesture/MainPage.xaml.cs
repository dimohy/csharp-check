using CommunityToolkit.Mvvm.Input;

namespace MauiAppTabGesture
{
    public partial class MainPage : ContentPage
    {
        private CancellationTokenSource? cts;

        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        [RelayCommand]
        private async void OnGesture()
        {
            if (cts is null)
                cts = new CancellationTokenSource();
            else
                cts.Cancel();

            await Task.Delay(1000, cts.Token);

            OnCounterClicked(this, EventArgs.Empty);

            cts.Dispose();
            cts = null;
        }


        //[RelayCommand(AllowConcurrentExecutions = false)]
        //[RelayCommand]
        //private async Task OnGestureAsync()
        //{
        //    if (cts is null)
        //        cts = new CancellationTokenSource();
        //    else
        //        cts.Cancel();

        //    await Task.Delay(1000, cts.Token);

        //    OnCounterClicked(this, EventArgs.Empty);

        //    cts.Dispose();
        //    cts = null;
        //}
    }
}