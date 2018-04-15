using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MouseOverClient.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        

        private readonly string _apiEndpoint = "/api/start/getname";

        private IDictionary<string, string> _machines;
        private string mockData;

        public event PropertyChangedEventHandler PropertyChanged;

        public StartPageViewModel()
        {         
            _machines = new Dictionary<string, string>();
            _machines.Add("Mock1", "192.168.1.1");
            _machines.Add("Mock2", "192.168.1.2");
            _machines.Add("Mock3", "192.168.1.3");

            for (int addr = 1; addr < 256; addr++)
            {
                TryGetMachineAsync($"http://192.168.1.{addr}:5000");
            }
        }
       
        public string MockData
        {
            set
            {
                if(mockData != value)
                {
                    mockData = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MockData"));
                    }
                }
            }
            get
            {
                return mockData;
            }
        }
        
        private async Task TryGetMachineAsync(string address)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address + _apiEndpoint);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "text/plain";
            request.Timeout = 2000;
            request.Proxy = null;
         
            using (var response = await request.GetResponseAsync())
            {
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        string machine = await new StreamReader(responseStream).ReadToEndAsync();
                        if (!string.IsNullOrWhiteSpace(machine))
                        {
                            _machines.Add(machine, address);

                            MockData += $"\n {machine}:{address}";
                        }
                    }

                }
                catch (Exception ex)
                {
                    //TODO: Handle logging
                }
            }
        }
    }
}
