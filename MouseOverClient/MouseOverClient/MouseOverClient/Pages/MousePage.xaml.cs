using MouseOverClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MouseOverClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MousePage : ContentPage
	{
        public MousePage (string machineName, string machineAddress)
		{
			InitializeComponent ();
            BindingContext = new MousePageViewModel(machineName, machineAddress);
		}
	}
}