using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Models
{
    public class Water
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double Volume { get; set; }
        public int Count { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime
        {
            get
            {
                return DateTime.Now.Subtract(CreationDate);
            }
        }
    }
}
