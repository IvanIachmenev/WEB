using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
            if (db.Mobiles.Count() == 0)
            {
                Manufacturer Apple = new Manufacturer { Name = "Apple", Country = "USA" };
                Manufacturer Samsung = new Manufacturer { Name = "Samsung", Country = "Karea"};
                Manufacturer Google = new Manufacturer { Name = "Google", Country =  "USA"};
                Manufacturer Xaomi = new Manufacturer { Name = "Xaomi", Country = "China" };
                db.Manufacturers.AddRange(Apple, Samsung, Google, Xaomi);
                db.Mobiles.AddRange(
                    new Mobile { Name = "Iphone 10", Diagonal = 12.5, Manufacturer = Apple, Yaer = 2018 },
                    new Mobile { Name = "Samsung Galaxy note 10", Diagonal = 14.7, Manufacturer = Samsung, Yaer = 2017 },
                    new Mobile { Name = "Google Pixel 3", Diagonal = 9.9, Manufacturer = Google, Yaer = 2016 },
                    new Mobile { Name = "Samsung Galaxy Note 7", Diagonal = 11.5, Manufacturer = Samsung, Yaer = 2016 },
                    new Mobile { Name = "Iphone 5", Diagonal = 8.4, Manufacturer = Apple, Yaer = 2011 },
                    new Mobile { Name = "Iphone 7", Diagonal = 10.3, Manufacturer = Apple, Yaer = 2017 }
                );

                db.SaveChanges();
            }
        }

        [Authorize(Roles = "admin, moderator, consultant")]
        public async Task<IActionResult> Index(string name, int? manufacturer, SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            int pageSize = 4;

            IQueryable<Mobile> songs = db.Mobiles.Include(x => x.Manufacturer);
            if (manufacturer != null && manufacturer != 0)//brand filter
            {
                songs = songs.Where(p => p.ManufacturerId == manufacturer);
            }
            if (!String.IsNullOrEmpty(name))//song name filter
            {
                songs = songs.Where(p => p.Name.Contains(name));
            }

            songs = sortOrder switch
            {
                SortState.NameDes => songs.OrderByDescending(s => s.Name),
                SortState.YearAsc => songs.OrderBy(s => s.Yaer),
                SortState.ManufacturerAsc => songs.OrderBy(s => s.Manufacturer.Name),
                SortState.ManufacturerDes => songs.OrderByDescending(s => s.Manufacturer.Name),
                SortState.DiagonalAsc => songs.OrderBy(s => s.Diagonal),
                SortState.DiagonalDes => songs.OrderByDescending(s => s.Diagonal),
                _ => songs.OrderBy(s => s.Name),
            };

            var count = await songs.CountAsync();
            var items = await songs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Manufacturers.ToList(), manufacturer, name),
                Mobile = items
            };
            SetClearance();
            return View(viewModel);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.Select = new SelectList(db.Manufacturers.ToList(), "Id", "Name");
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                if (mobile.ManufacturerId == 0)
                {
                    return BadRequest("Incorrect brand id(==0).");
                }
                mobile.Manufacturer = db.Manufacturers.FirstOrDefault(x => x.Id == mobile.ManufacturerId);
                if (mobile.Manufacturer == null)
                {
                    return BadRequest("Incorrect producer id.");
                }
                db.Mobiles.Add(mobile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Select = new SelectList(db.Manufacturers.ToList(), "Id", "Name");
            return View(mobile);
        }
        [Authorize(Roles = "admin, moderator, consultant")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                DetailsViewModel detailsView = new DetailsViewModel
                {
                    Mobile = await db.Mobiles.FirstOrDefaultAsync(p => p.Id == id)
                };
                if (detailsView.Mobile != null)
                {
                    detailsView.Select = new SelectViewModel(db.Manufacturers.ToList(), detailsView.Mobile.ManufacturerId);
                    SetClearance();
                    return View(detailsView);
                }
            }
            return NotFound();
        }
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Mobile mobile = await db.Mobiles.FirstOrDefaultAsync(p => p.Id == id);
                if (mobile != null)
                {
                    ViewBag.Select = new SelectList(db.Manufacturers.ToList(), "Id", "Name", mobile.ManufacturerId);
                    return View(mobile);
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }
        [Authorize(Roles = "admin, moderator")]
        [HttpPost]
        public async Task<IActionResult> Edit(Mobile mobile, int? id)
        {
            if (ModelState.IsValid)
            {
                Mobile original = db.Mobiles.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (original == null)
                {
                    return BadRequest();
                }
                if (mobile.ManufacturerId == 0)
                {
                    return BadRequest("Incorrect brand id(==0).");
                }
                mobile.Manufacturer = db.Manufacturers.FirstOrDefault(x => x.Id == mobile.ManufacturerId);
                if (mobile.Manufacturer == null)
                {
                    return BadRequest("Incorrect brand id.");
                }
                db.Mobiles.Update(mobile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Select = new SelectList(db.Manufacturers.ToList(), "Id", "Name", mobile.ManufacturerId);
            return View(mobile);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Mobile mobile = await db.Mobiles.FirstOrDefaultAsync(p => p.Id == id);
                if (mobile != null)
                    return View(mobile);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Mobile mobile = new Mobile { Id = id.Value };
                db.Entry(mobile).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [Authorize(Roles = "admin, moderator, consultant")]

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetClearance()
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.CL = 3;
            }
            else if (User.IsInRole("moderator"))
            {
                ViewBag.CL = 2;
            }
            else if (User.IsInRole("consultant"))
            {
                ViewBag.CL = 1;
            }
        }
    }
}
