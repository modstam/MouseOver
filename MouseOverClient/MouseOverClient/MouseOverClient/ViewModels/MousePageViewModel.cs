using MouseOverClient.Models;

namespace MouseOverClient.ViewModels
{
    public class MousePageViewModel : ViewModelBase
    {
        private Machine _machine;

        public MousePageViewModel(Machine machine)
        {
            _machine = machine;
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
    }
}
