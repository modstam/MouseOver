using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MouseOverClient.Items;

namespace MouseOverClient.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {       
        private readonly string _apiEndpoint = "/api/start/getname";
        
        public StartPageViewModel()
        {
            Machines = new ObservableCollection<MachineItem>
            {
                new MachineItem("mockdata1", "mockaddr"),
                new MachineItem("mockdata2", "mockaddr")
            };

            //for (int addr = 1; addr < 256; addr++)
            //{
            //    TryGetMachineAsync($"http://192.168.1.{addr}:5000");
            //}
        }
       
        public ObservableCollection<MachineItem> Machines { get; set; }


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
                            Machines.Add(new MachineItem(machine, address));
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
