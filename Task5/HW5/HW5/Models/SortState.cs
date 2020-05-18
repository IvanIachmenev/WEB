using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Models
{
    public enum SortState
    {
        CategoryAsc,    // по имени по возрастанию
        CategoryDesc,   // по имени по убыванию
        AmountAsc, // по возрасту по возрастанию
        AmountDesc,    // по возрасту по убыванию
        BrandAsc, // по компании по возрастанию
        BrandDesc // по компании по убыванию
    }
}
