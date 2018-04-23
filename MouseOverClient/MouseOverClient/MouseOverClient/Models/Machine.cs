using System;
using System.Collections.Generic;
using System.Text;

namespace MouseOverClient.Models
{
    public class Machine
    {
        public Machine(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
