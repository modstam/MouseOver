using Xamarin.Forms;

namespace MouseOverClient
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new MouseOverClient.StartPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
