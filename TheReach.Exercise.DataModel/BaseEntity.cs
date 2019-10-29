using System;

namespace TheReach.Exercise.DataModel
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
