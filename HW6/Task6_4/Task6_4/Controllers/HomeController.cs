using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task6_4.Models;

namespace Task6_4.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
            if(db.Mobiles.Count() == 0 || db.Brands.Count() == 0)
            {

                Brand apple = new Brand { Name = "Apple" };
                Brand google = new Brand { Name = "Google" };
                db.Brands.AddRange(apple, google);
                db.SaveChanges();

                Mobile iphone10 = new Mobile { Name = "Iphone 10", Brand = apple };
                Mobile googlePixel3 = new Mobile { Name = "Google Pixel 3", Brand = google };
                Mobile iphone11 = new Mobile { Name = "Iphone 11", Brand = google };
                db.Mobiles.AddRange(iphone10, iphone11, googlePixel3);
                db.SaveChanges();
            }
        }
        
        //жадная
        public IActionResult EagerLoadingIndex()
        {
            var mobile = db.Mobiles
                .Include(u => u.Brand)
                .ToList();
            return View(mobile);
        }

        //явная
        public IActionResult ExplicitLoadingIndex()
        {
            Mobile mobile = db.Mobiles.FirstOrDefault();
            db.Entry(mobile).Reference(x => x.Brand).Load();
            return View(db.Mobiles.ToList());
        }

        public IActionResult LazyLoadingIndex()
        {
            var mobiles = db.Mobiles.ToList();
            return View(mobiles);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
