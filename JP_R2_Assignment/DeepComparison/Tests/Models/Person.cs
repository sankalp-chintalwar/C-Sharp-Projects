using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_R2_Assignment.DeepComparison.Tests.Models
{
    internal class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Address? Residence { get; set; }
        public List<PhoneNumber>? PhoneNumbers { get; set; }
    }
}
