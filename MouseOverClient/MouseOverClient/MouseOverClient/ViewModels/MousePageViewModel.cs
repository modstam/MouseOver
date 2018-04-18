using System;
using System.Collections.Generic;
using System.Text;

namespace MouseOverClient.ViewModels
{
    public class MousePageViewModel : ViewModelBase
    {
        private string _machineName;
        private string _machineAddr;

        public MousePageViewModel(string machineName, string machineAddress)
        {
            MachineName = machineName;
            MachineAddress = machineAddress;
        }


        public string MachineName
        {
            get
            {
                return _machineName;
            }
            set
            {
                _machineName = value;
                OnPropertyChanged(nameof(MachineName));
            }
        }

        public string MachineAddress
        {
            get
            {
                return _machineAddr;
            }
            set
            {
                _machineAddr = value;
                OnPropertyChanged(nameof(MachineAddress));
            }
        }
    }
}
