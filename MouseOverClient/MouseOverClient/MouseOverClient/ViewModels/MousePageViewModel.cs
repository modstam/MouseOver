using MouseOverClient.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MouseOverClient.ViewModels
{
    public class MousePageViewModel : ViewModelBase
    {

        private readonly string _mousePosEndpoint = "api/mouse/";
        private readonly string _mouseClickEndpoint = "api/mouse/click/";
        private readonly int _port;

        private readonly int _screenWidth;
        private readonly int _screenHeight;


        private Machine _machine;

        public MousePageViewModel(Machine machine, int port)
        {
            _machine = machine;
            _port = port;
            _screenWidth = (int)Application.Current.MainPage.Width;
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

        public async Task SendMousePosition(int x, int y)
        {
            try
            {


                using (var client = new HttpClient())
                {

                    string apiAddress = string.Empty;

                    if (_screenWidth > _screenHeight)
                    {
                        apiAddress = $"http://{Machine.Address}:{_port}/{_mousePosEndpoint}/{x}/{y}/{_screenWidth}/{_screenHeight}";
                    }
                    else
                    {
                        apiAddress = $"http://{Machine.Address}:{_port}/{_mousePosEndpoint}/{x}/{y}/{_screenHeight}/{_screenWidth}";
                    }
 

                    using (var response = client.GetAsync(apiAddress))
                    {
                        if (response.Result.IsSuccessStatusCode)
                        {
                           //No need to handle results
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //TODO: Handle logging
                string error = e.InnerException.Message;
                Console.WriteLine(e);

            }
        }

        public async Task ClickMousePosition(int x, int y)
        {

        }
    }
}
