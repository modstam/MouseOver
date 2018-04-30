using MouseOverClient.Models;
using Xamarin.Forms;

namespace MouseOverClient.ViewModels
{
    public class MousePageViewModel : ViewModelBase
    {

        private readonly string _mousePosEndpoint = "api/mouse/";
        private readonly string _mouseClickEndpoint = "api/mouse/click/";

        private readonly int _screenWidth;
        private readonly int _screenHeight;


        private Machine _machine;

        public MousePageViewModel(Machine machine)
        {
            _machine = machine;

            _screenWidth = (int) Application.Current.MainPage.Width;
            _screenHeight = (int)Application.Current.MainPage.Height;
        }


        public Machine Machine
        {
            get
            {
                return _machine;
            }
            set
            {
                _machine = value;
                OnPropertyChanged(nameof(Machine));
            }
        }

        public void SendMousePosition(int x, int y)
        {

        }

        public void ClickMousePosition(int x, int y)
        {

        }
    }
}
