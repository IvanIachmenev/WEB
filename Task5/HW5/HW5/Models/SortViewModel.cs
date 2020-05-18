using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Models
{
    public class SortViewModel
    {
        public SortState CategorySort { get; private set; } // значение для сортировки по имени
        public SortState AmountSort { get; private set; }    // значение для сортировки по возрасту
        public SortState BrandSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            AmountSort = sortOrder == SortState.AmountAsc ? SortState.AmountDesc : SortState.AmountAsc;
            BrandSort = sortOrder == SortState.BrandAsc ? SortState.BrandDesc : SortState.BrandAsc;
            Current = sortOrder;
        }
    }
}
