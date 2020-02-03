using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HW6_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StoreContext db = new StoreContext())
            {
                // �������� ������� �� �� � ������� �� �������
                var brands = db.Brands.ToList();
                Console.WriteLine("������ �������:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
            }
            Console.ReadKey();
        }
    }
}
