using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Yaer")]
        public int Yaer { get; set; }
        [Required(ErrorMessage = "Enter Diagonal")]
        public double Diagonal { get; set; }
        [Required(ErrorMessage = "Select Brand")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
