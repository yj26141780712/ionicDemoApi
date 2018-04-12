using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string State { get; set; }
        public string Motion { get; set; }
    }
}
