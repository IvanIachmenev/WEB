using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HW6_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Brand Chanel = new Brand { Name = "Chanel", Country = "France" };
                Brand Armani = new Brand { Name = "Armani", Country = "Italy" };
                Brand Versace = new Brand { Name = "Versace", Country = "Italy" };
                Brand Givenchy = new Brand { Name = "Givenchy", Country = "France" };
                Brand Burberry = new Brand { Name = "Burberry", Country = "UK" };
                Brand Kenzo = new Brand { Name = "Kenzo", Country = "France" };
                Brand Lanvin = new Brand { Name = "Lanvin", Country = "France" };

                List<Brand> Store = new List<Brand>() { Chanel, Armani, Versace, Givenchy, Burberry, Kenzo, Lanvin };


                // добавляем их в бд
                foreach (var v in Store)
                {
                    if (!db.Brands.Contains(v))
                    {
                        db.Brands.Add(v);
                    }
                }

                db.SaveChanges();
                Console.WriteLine("Бренды успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var brands = db.Brands.ToList();
                Console.WriteLine("Список брендов:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
            }
            Console.Read();
        }
    }
}
