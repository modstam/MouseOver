using MouseOverClient.Items;
using MouseOverClient.ViewModels;
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
            var item = e.SelectedItem as MachineItem;

            if(item != null)
            {
                await this.Navigation.PushAsync(new MousePage(item.Name, item.Address));
            }                   
        }
    }
}