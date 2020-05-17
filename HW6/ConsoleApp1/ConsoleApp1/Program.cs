using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(AppDbContext db = new AppDbContext())
            {
                Mobile mobile1 = new Mobile { Name = "Apple", Price = 70000 };
                Mobile mobile2 = new Mobile { Name = "Samsung", Price = 10000 };

                db.Mobiles.Add(mobile1);
                db.Mobiles.Add(mobile2);
                db.SaveChanges();
                Console.WriteLine("Add objects");

                var _mobiles = db.Mobiles.ToList();
                Console.WriteLine("List opjects");
                foreach(var item in _mobiles)
                {
                    Console.WriteLine($"{item.Id}.{item.Name} - {item.Price}");
                }
            }
        }
    }
}
