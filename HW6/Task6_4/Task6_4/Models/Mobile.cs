using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task6_4.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
