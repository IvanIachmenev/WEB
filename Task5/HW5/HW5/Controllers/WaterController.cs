using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using HW5.Models;
using HW5.ViewModels;

namespace HW5.Controllers
{
    public class WaterController : Controller
    {
        WaterContext db;
        public WaterController(WaterContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult AddNewWater()
        {
            List<Brand> brandModels = db.Brands.ToList();

            //добовляем на первое место
            List<Water> waters = db.Waters.ToList();
            IndexViewModel ivm = new IndexViewModel { Brands = brandModels, Waters = waters };

            return View(ivm);
        }
        [HttpPost]
        public IActionResult AddNewWater(string sumbit, string cancel, Water water)
        {
            var button = sumbit ?? cancel;
            if(button == "Cancel")
            {
                return RedirectToAction("AddNewWater");
            }

            if (db.Waters.Any(x => x.Name == water.Name))
            {
                return BadRequest();
            }

            db.Waters.Add(water);
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> Index(int? brand, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //filter
            IQueryable<Water> waters = db.Waters.Include(x => x.Brand);

            if(brand != null && brand != 0)
            {
                waters = waters.Where(p => p.Name.Contains(name));
            }
            if (!String.IsNullOrEmpty(name))
            {
                waters = waters.Where(p => p.Name.Contains(name));
            }

            //sort
            switch(sortOrder)
            {
                case SortState.NameDesc:
                    waters = waters.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    waters = waters.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    waters = waters.OrderByDescending(s => s.Price);
                    break;
                case SortState.BrandAsc:
                    waters = waters.OrderBy(s => s.Brand.Name);
                    break;
                case SortState.BrandDesc:
                    waters = waters.OrderByDescending(s => s.Brand.Name);
                    break;
                default:
                    waters = waters.OrderBy(s => s.Name);
                    break;
            }

            //пагинация
            var count = await waters.CountAsync();
            var items = await waters.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //формируем модель поведения
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Brands.ToList(), brand, name),
                Waters = items
            };

            return View(viewModel);
        }
    }
}