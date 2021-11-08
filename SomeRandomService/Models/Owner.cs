using System;
using System.Collections.Generic;
using System.Text;

namespace SomeRandomService.Models
{
    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }
    }

    public class ReportOwners
    {
        public string OwnerName { get; set; }
        public string PetName { get; set; }
    }

}
