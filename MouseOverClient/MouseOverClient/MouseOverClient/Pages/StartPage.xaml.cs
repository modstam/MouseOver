using MouseOverClient.Models;
using MouseOverClient.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MouseOverClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        CancellationTokenSource cts;
        int apiPort = 5000;

        public StartPage()
        {
            InitializeComponent();
            BindingContext = new StartPageViewModel(apiPort);
        }

        public async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var item = e.SelectedItem as Machine;

            if (item != null)
            {
                if(cts != null)
                {
                    cts.Cancel();
                }
                await this.Navigation.PushAsync(new MousePage(item, apiPort));
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as StartPageViewModel;
            cts = new CancellationTokenSource();
            Task.Factory.StartNew(() => viewModel.ScanNetwork(cts.Token));
        }
    }
}