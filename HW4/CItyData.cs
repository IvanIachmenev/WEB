using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW4.Models;

namespace HW4
{
    public class CityData
    {
        public static void Initialize(CityContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City
                    {
                        name = "Paris"
                    },
                    new City
                    {
                        name = "Tokyo"
                    },
                    new City
                    {
                        name = "Soul"
                    }
                );
                context.SaveChanges();

                context.Pilots.AddRange(
                   new Pilot
                   {
                       name = "John",
                       company = "USA Airlines",
                       exp = 3
                   },
                   new Pilot
                   {
                       name = "Leon",
                       company = "Aeroflot",
                       exp = 2
                   },
                   new Pilot
                   {
                       name = "Hiro",
                       company = "Korean Air",
                       exp = 8
                   }
               );
                context.SaveChanges();
            }

        }
    }
}
