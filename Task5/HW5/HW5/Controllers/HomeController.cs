using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW5.Models;
using Microsoft.EntityFrameworkCore;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            this.db = context;
            // добавляем начальные данные
            if (db.Brands.Count() == 0)
            {
                Brand armani = new Brand { Name = "Apple" };
                Brand lv = new Brand { Name = "Samsung" };
                Brand gucci = new Brand { Name = "Xaomi" };
                Brand hilfiger = new Brand { Name = "LG" };

                Mobile user1 = new Mobile { Category = "Флагман", Brand = gucci, Amount = 26, CreationDate = DateTime.Now };
                Mobile user2 = new Mobile { Category = "Бюджетный", Brand = hilfiger, Amount = 24, CreationDate = DateTime.Now };
                Mobile user3 = new Mobile { Category = "Средней ценовой категории", Brand = hilfiger, Amount = 25, CreationDate = DateTime.Now };
                
                db.Brands.AddRange(armani, lv, gucci, hilfiger);
                db.Mobiles.AddRange(user1, user2, user3);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(int? company, string name, int page = 1,
            SortState sortOrder = SortState.CategoryAsc)
        {
            int pageSize = 5;

            //фильтрация
            IQueryable<Mobile> users = db.Mobiles.Include(x => x.Brand);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.Brand.Id == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Category.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.CategoryDesc:
                    users = users.OrderByDescending(s => s.Category);
                    break;
                case SortState.AmountAsc:
                    users = users.OrderBy(s => s.Amount);
                    break;
                case SortState.AmountDesc:
                    users = users.OrderByDescending(s => s.Amount);
                    break;
                case SortState.BrandAsc:
                    users = users.OrderBy(s => s.Brand.Name);
                    break;
                case SortState.BrandDesc:
                    users = users.OrderByDescending(s => s.Brand.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Category);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Brands.ToList(), company, name),
                Users = items
            };
            return View(viewModel);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string Add, string Back, MobileTemp pr)
        {
            var btn = Add ?? Back;
            if (btn == Back)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Mobile temp = new Mobile
                { Category = pr.Category, Amount = pr.Amount, CreationDate = DateTime.Now, Brand = pr.Brand };
                if (db.Mobiles.Contains(temp))
                {
                    return BadRequest();
                }

                if (!db.Brands.Contains(pr.Brand))
                {
                    db.Brands.Add(pr.Brand);
                }

                db.Mobiles.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
