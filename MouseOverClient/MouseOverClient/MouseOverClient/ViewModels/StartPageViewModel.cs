using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using MouseOverClient.Models;
using System.Threading;
using System.Net;

namespace MouseOverClient.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly string _apiEndpoint = "api/start/getname";
        private readonly int _apiPort = 5000;
        private readonly int _timeout = 1000;
        private readonly int _maximumConnections = 3;

        public StartPageViewModel()
        {

            Machines = new ObservableCollection<Machine>
            {
                new Machine("mockdata1", "mockaddr"),
                new Machine("mockdata2", "mockaddr")
            };

            ServicePointManager.DefaultConnectionLimit = _maximumConnections;
        }

        public ObservableCollection<Machine> Machines { get; set; }

        private void FindMachines(object sender, System.Timers.ElapsedEventArgs e)
        {
            //do something here
        }

        public async Task ScanNetwork()
        {
            Machines.Clear();

            Task[] tasks = new Task[_maximumConnections];
            int addr = 1;
            while(addr < 255)
            {
                for(int i = 0; i < _maximumConnections; i++)
                {
                    string address = "192.168.1." + addr;
                    tasks[i] = Task.Run(() => SendPingAsync(address));
                    addr++;
                }
                Task.WaitAny(tasks);
            }
        }

        private async Task SendPingAsync(string ipAddress)
        {

            try
            {
                using(var client = new HttpClient())
                {

                    string apiAddress = $"http://{ipAddress}:{_apiPort}/{_apiEndpoint}";

                    CancellationTokenSource cts = new CancellationTokenSource();
                    cts.CancelAfter(_timeout);

                    using (HttpResponseMessage response = client.GetAsync(apiAddress, cts.Token).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string hostname = response.Content.ReadAsStringAsync().Result;

                            if (!Machines.Any(x => x.Name == hostname))
                            {
                                Machine machine = new Machine(hostname, ipAddress);
                                Machines.Add(machine);
                            }
                        }
                    }
                }              
            }
            catch (Exception e)
            {
                //TODO: Handle logging
                string error = e.InnerException.Message;
                Console.WriteLine($"{ipAddress}: {error}");

            }
        }

    }
}
