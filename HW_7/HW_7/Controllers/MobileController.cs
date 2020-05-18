using HW_7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace HW_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        MobileContext db;

        public MobileController(MobileContext context)
        {
            db = context;
            
            if (db.Mobiles.Count() == 0)
            {
                Mobile mobile1 = new Mobile { Name = "Iphone 10", Brand = "Apple", Amount = 24 };
                Mobile mobile2 = new Mobile { Name = "Samsung Note 10", Brand = "Samsung", Amount = 16 };
                Mobile mobile3 = new Mobile { Name = "Google Pixel 3", Brand = "Google", Amount = 19 };
                Mobile mobile4 = new Mobile { Name = "Iphone 11", Brand = "Apple", Amount = 10 };

                db.Mobiles.AddRange(mobile1, mobile2, mobile3, mobile4);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Mobile>> GetAll()
        {
            return db.Mobiles.ToList();
        }

        [HttpGet("{id}", Name = "GetMobile")]
        public ActionResult<Mobile> GetById(int id)
        {
            var mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return mobile;
        }

        //POST api/mobiles
        [HttpPost]
        public async Task<ActionResult<Mobile>> Post(Mobile mobile)
        {
            if(mobile == null)
            {
                return BadRequest();
            }

            db.Mobiles.Add(mobile);
            await db.SaveChangesAsync();
            return Ok(mobile);
        }

        //PUT api/mobiles/
        [HttpPut]
        public async Task<ActionResult<Mobile>> Put(Mobile mobile)
        {
            if(mobile == null)
            {
                return BadRequest();
            }
            if(!db.Mobiles.Any(x => x.Id == mobile.Id))
            {
                return NotFound();
            }

            db.Update(mobile);
            await db.SaveChangesAsync();
            return Ok(mobile);
        }

        //DELETE api/mobiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mobile>> Delete(int id)
        {
            var mobile = db.Mobiles.FirstOrDefault(x => x.Id == id);
            if(mobile == null)
            {
                return NotFound();
            }

            db.Mobiles.Remove(mobile);
            await db.SaveChangesAsync();
            return Ok(mobile);
        }
    }
}
