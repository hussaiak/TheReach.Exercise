using System;
using System.Collections.Generic;
using System.Text;

namespace TheReach.Exercise.DataModel.Models
{
    public class Postcode : BaseEntity
    { 
        public string Pcode { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }        
        public string Comments { get; set; }
        public string DeliveryOffice { get; set; }
        public string PreSortIndicator { get; set; }
        public string ParcelZone { get; set; }
        public string BSPnumber { get; set; }
        public string BSPname { get; set; }
        public string Category { get; set; }
    }
}
