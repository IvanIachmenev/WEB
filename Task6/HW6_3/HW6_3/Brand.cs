using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6_3
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Water> waters{ get; set; }
    }
}
