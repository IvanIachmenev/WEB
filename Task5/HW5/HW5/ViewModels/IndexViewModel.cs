using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW5.Models;

namespace HW5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Water> Waters { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
