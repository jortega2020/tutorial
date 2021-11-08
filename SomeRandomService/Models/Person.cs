using System;
using System.Collections.Generic;
using System.Text;

namespace SomeRandomService.Models
{
    public class Person
    {
        public Guid Curp { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
