using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4.Models;
using Microsoft.EntityFrameworkCore;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        CityContext db;
        public HomeController(CityContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var cities = from m in db.Cities
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(s => s.name.Contains(searchString));
            }
            return View(await cities.ToListAsync());
        }

        //для Едита
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            City city = db.Cities.Find(id);
            if (city != null)
            {
                return View(city);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Edit(City city)
        {
            db.Entry(city).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //для добавления
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(City city)
        {
            if (db.Cities.Contains(city))
            {
                return BadRequest();
            }
            db.Cities.Add(city);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //для удаления
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            City ForDelete = db.Cities.Find(id);
            if (ForDelete == null)
            {
                return NotFound();
            }
            return View(ForDelete);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City ForDelete = db.Cities.Find(id);
            if (ForDelete == null)
            {
                return NotFound();
            }
            db.Cities.Remove(ForDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
