using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState DiagonalSort { get; set; }
        public SortState YearSort { get; set; }
        public SortState ManufacturerSort { get; set; }
        public SortState Current { get; set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDes : SortState.NameAsc;
            YearSort = sortOrder == SortState.YearAsc ? SortState.YearDes : SortState.YearAsc;
            DiagonalSort = sortOrder == SortState.DiagonalAsc ? SortState.DiagonalDes : SortState.DiagonalAsc;
            ManufacturerSort = sortOrder == SortState.ManufacturerAsc ? SortState.ManufacturerDes : SortState.ManufacturerAsc;
            Current = sortOrder;
        }
    }
}
