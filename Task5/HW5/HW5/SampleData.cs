using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW5.Models;

namespace HW5
{
    public class SampleData
    {
        public static void Initialize(WaterContext context)
        {
            Brand Slavda = new Brand { Name = "Slavda", Country = "Russia" };
            Brand Swallow = new Brand { Name = "Swallow", Country = "Russia" };
            Brand Monastry = new Brand { Name = "Monastry", Country = "Russia" };

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(Slavda, Swallow, Monastry);
                context.SaveChanges();
            }

            if (!context.Waters.Any())
            {
                context.Waters.AddRange(
                    new Water
                    {
                        Name = "Bottle 0.5L",
                        Count = 10,
                        Price = 65,
                        Brand = Swallow,
                        Volume = 0.5,
                    },
                    new Water
                    {
                        Name = "Bottle 1L",
                        Count = 20,
                        Price = 75,
                        Brand = Monastry,
                        Volume = 1,
                    },
                    new Water
                    {
                        Name = "Bottle 19L",
                        Count = 5,
                        Price = 110,
                        Brand = Slavda,
                        Volume = 19,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
