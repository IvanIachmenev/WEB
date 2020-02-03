using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class CategoryActions
    {
        public static List<Category> categories = new List<Category>();

        public static void Add(int id, string name)
        {
            if(categories.FindIndex(x => x.categoryId == id) == -1)
            {
                categories.Add(new Category(id, name));
                Console.WriteLine("Операция выполнена\n");
                return;
            }
            Console.WriteLine("Категория уже добавлена\n");
        }

        public static void ChangeId(int currentId, int newId)
        {
            if(categories.FindIndex(x => x.categoryId == newId) != -1)
            {
                Console.WriteLine("Нет категории с таким id\n");
                return;
            }

            var index = categories.FindIndex(x => x.categoryId == currentId);

            try
            {
                categories[index].categoryId = newId;
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти категорию с таким id\n");
            }
        }

        public static void Delete(int id)
        {
            var index = categories.FindIndex(x => x.categoryId == id);

            try
            {
                categories.RemoveAt(index);
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Нет категории с таким id\n");
            }
        }

        public static void GetAll()
        {
            for(var i = 0; i <categories.Count; i++)
            {
                Console.WriteLine($"{categories[i].categoryId} {categories[i].categoryName}");
            }
            Console.WriteLine();
        }

        public static void GetById(int id)
        {
            try
            {
                int index = categories.FindIndex(x => x.categoryId == id);
                Console.WriteLine($"{categories[index].categoryId} {categories[index].categoryName}\n");
            }
            catch
            {
                Console.WriteLine("Нет категории с таким id\n");
            } 
        }
    }
}
