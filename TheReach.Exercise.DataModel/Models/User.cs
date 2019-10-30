using System;
using System.Collections.Generic;
using System.Text;

namespace TheReach.Exercise.DataModel.Models
{
    public class User: BaseEntity
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Postcode { get; set; }

        public string State { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }
    }
}
