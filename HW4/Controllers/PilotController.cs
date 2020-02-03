using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HW4.Models;
using Microsoft.EntityFrameworkCore;

namespace HW4.Controllers
{
    public class PilotController : Controller
    {
        CityContext db;

        public PilotController(CityContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index_pilot(string searchString)
        {
            var pilots = from m in db.Pilots
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                pilots = pilots.Where(s => s.name.Contains(searchString) || s.company.Contains(searchString)); //|| pilots.Where(s => s.company.Contains(searchString)));
            }
            return View(await pilots.ToListAsync());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index_pilot");
            }
            Pilot pilot = db.Pilots.Find(id);
            if (pilot == null)
            {
                return RedirectToAction("Index_pilot");
            }
            return View(pilot);
        }

        [HttpGet]
        public IActionResult Edit_pilot(int? id)
        {
            if (id == null) return NotFound();
            Pilot pilot = db.Pilots.Find(id);
            if (pilot != null)
            {
                return View(pilot);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Edit_pilot(Pilot pilot)
        {
            db.Entry(pilot).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index_pilot");
        }

        [HttpGet]
        public ActionResult Delete_pilot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Pilot ForDelete = db.Pilots.Find(id);
            if (ForDelete == null)
            {
                return NotFound();
            }
            return View(ForDelete);
        }
        [HttpPost, ActionName("Delete_pilot")]
        public ActionResult DeleteConfirmed_pilot(int id)
        {
            Pilot ForDelete = db.Pilots.Find(id);
            if (ForDelete == null)
            {
                return RedirectToAction("Index_pilot");
            }
            db.Pilots.Remove(ForDelete);
            db.SaveChanges();
            return RedirectToAction("Index_pilot");
        }

        //для добавления
        [HttpGet]
        public ActionResult Create_pilot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_pilot(Pilot pilot)
        {
            if (db.Pilots.Contains(pilot))
            {
                return BadRequest();
            }
            db.Pilots.Add(pilot);
            db.SaveChanges();

            return RedirectToAction("Index_pilot");
        }
    }
}