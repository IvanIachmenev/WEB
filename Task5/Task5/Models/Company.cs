using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Mobile> Mobiles { get; set; }

        public Company()
        {
            Mobiles = new List<Mobile>();
        }
    }
}
