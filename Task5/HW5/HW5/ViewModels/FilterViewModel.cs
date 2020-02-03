using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW5.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Brands { get; private set; } //list brands
        public int? SelectedBrand { get; private set; }//select brand
        public string SelectedName { get; private set; }//enter name
        
        public FilterViewModel(List<Brand> brands, int? brand, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            brands.Insert(0, new Brand { Name = "ALL", Id = 0, Country = "not" });
            Brands = new SelectList(brands, "Id", "Name", brand);
            SelectedBrand = brand;
            SelectedName = name;
        }
    }
}
