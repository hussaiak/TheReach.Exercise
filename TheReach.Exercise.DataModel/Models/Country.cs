using System;
using System.Collections.Generic;
using System.Text;

namespace TheReach.Exercise.DataModel.Models
{
    public class Country: BaseEntity
    { 
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
