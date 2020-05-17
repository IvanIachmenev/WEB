using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task6_4.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Mobile> Mobiles { get; set; }
    }
}
