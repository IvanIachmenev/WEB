using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class FilterViewModel : SelectViewModel
    {

        public string SelectedName { get; private set; }
        public FilterViewModel(List<Manufacturer> manufacturers, int? manufacturer, string name) 
            : base(manufacturers, manufacturer)
        {
            SelectedName = name;
        }
    }
}
