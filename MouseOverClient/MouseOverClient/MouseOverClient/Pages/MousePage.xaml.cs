using MouseOverClient.Models;
using MouseOverClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MouseOverClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MousePage : ContentPage
	{
        public MousePage (Machine machine, int port)
		{
			InitializeComponent ();
            BindingContext = new MousePageViewModel(machine, port);         
        }

	}
}