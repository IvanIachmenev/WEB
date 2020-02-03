using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class BrandActions
    {
        public static List<Brand> brands = new List<Brand>();

        public static void Add(int id, string name)
        {
            if(brands.FindIndex(x => x.brandId == id) == -1)
            {
                brands.Add(new Brand(id, name));
                Console.WriteLine("Операция выполнена\n");
                return;
            }
            Console.WriteLine("Бренд уже добавлен\n");
        }

        public static void ChangeId(int currentId, int newId)
        {
            if(brands.FindIndex(x => x.brandId == newId) != -1)
            {
                Console.WriteLine("Нет такого бренда\n");
            }

            var index = brands.FindIndex(x => x.brandId == currentId);

            try
            {
                brands[index].brandId = newId;
                Console.WriteLine("Операция выполнена!\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти бренд с таким id\n");
            }
        }

        public static void Delete(int id)
        {
            var index = brands.FindIndex(x => x.brandId == id);

            try
            {
                brands.RemoveAt(index);
                Console.WriteLine("Операция выполненан\n");
            }
            catch
            {
                Console.WriteLine("Не найден брен с таким id\n");
            }
        }

        public static void GetAll()
        {
            for(var i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{brands[i].brandId} {brands[i].brandName}");
            }
            Console.WriteLine();
        }

        public static void GetById(int id)
        {
            try
            {
                var index = brands.FindIndex(x => x.brandId == id);
                Console.WriteLine($"{brands[index].brandId} {brands[index].brandName}\n");
            }
            catch
            {
                Console.WriteLine("Нет такого id\n");
            }
        }
    }
}
