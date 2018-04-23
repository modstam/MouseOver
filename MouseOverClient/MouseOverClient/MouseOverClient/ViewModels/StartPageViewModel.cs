using System.Collections.ObjectModel;
using MouseOverClient.Models;

namespace MouseOverClient.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly string _apiEndpoint = "api/start/getname";
        private readonly System.Timers.Timer _timer;

        public StartPageViewModel()
        {

            Machines = new ObservableCollection<Machine>
            {
                new Machine("mockdata1", "mockaddr"),
                new Machine("mockdata2", "mockaddr")
            };

            System.Net.ServicePointManager.DefaultConnectionLimit = 10;

            _timer = new System.Timers.Timer();
            _timer.Interval = 10000;
            _timer.Elapsed += FindMachines;
            _timer.Enabled = true;

        }

        public ObservableCollection<Machine> Machines { get; set; }

        private void FindMachines(object sender, System.Timers.ElapsedEventArgs e)
        {
            //do something here
        }
    }
}
