using System;
using System.Collections.Generic;
using System.Text;

namespace MouseOverClient.Items
{
    public class MachineItem
    {
        public MachineItem(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
