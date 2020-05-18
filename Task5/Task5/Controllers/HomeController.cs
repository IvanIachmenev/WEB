using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task5.Models;

namespace Task5.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            this.db = context;
            // добавляем начальные данные
            if (db.Companies.Count() == 0)
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                

                db.Companies.AddRange(oracle, microsoft, google, apple);
                db.Mobiles.AddRange();
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(int? company, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Mobile> mobile = db.Mobiles.Include(x => x.Company);

            if (company != null && company != 0)
            {
                mobile = mobile.Where(p => p.Company.Id == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                mobile = mobile.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    mobile = mobile.OrderByDescending(s => s.Name);
                    break;
                case SortState.CompanyAsc:
                    mobile = mobile.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    mobile = mobile.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    mobile = mobile.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await mobile.CountAsync();
            var items = await mobile.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Companies.ToList(), company, name),
                Users = items
            };
            return View(viewModel);
        }
    }
}
