using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.ViewModels
{
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        PriceAsc, // по price по возрастанию
        PriceDesc,    // по price по убыванию
        BrandAsc, // по компании по возрастанию
        BrandDesc // по компании по убыванию
    }
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState PriceSort { get; private set; }    // значение для сортировки по возрасту
        public SortState BrandSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            BrandSort = sortOrder == SortState.BrandAsc ? SortState.BrandDesc : SortState.BrandAsc;
            Current = sortOrder;
        }
    }
}
