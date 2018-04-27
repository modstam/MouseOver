using MouseOverClient.Models;
using MouseOverClient.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MouseOverClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            BindingContext = new StartPageViewModel();
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
                await this.Navigation.PushAsync(new MousePage(item));
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as StartPageViewModel;
            Task.Factory.StartNew(() => viewModel.ScanNetwork());
        }
    }
}