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
    }
}