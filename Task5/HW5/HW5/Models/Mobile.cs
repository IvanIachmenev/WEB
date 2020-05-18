using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan LifeTime => DateTime.Now - CreationDate;
        public Brand Brand { get; set; }
    }
}
