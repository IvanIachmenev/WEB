using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class SelectViewModel
    {
        public SelectList Manufacturer { get; private set; }
        public int? SelectedManufacturer { get; private set; }

        public SelectViewModel(List<Manufacturer> manufacturers, int? manufacturer)
        {
            manufacturers.Insert(0, new Manufacturer { Name = "Not seelected", Id = 0 });
            Manufacturer = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
        }
    }
}
