using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class CollectionActions
    {
        public static List<Collection> collections = new List<Collection>();

        public static void Add(int id, string name)
        {
            if(collections.FindIndex(x => x.collectionId == id) == -1)
            {
                collections.Add(new Collection(id, name));
                Console.WriteLine("Операция выполнена\n");
                return;
            }
            Console.WriteLine("Не удалось добавить в колекцию\n");
        }

        public static void ChangeId(int currentId, int newId)
        {
            if(collections.FindIndex(x => x.collectionId == newId) != -1)
            {
                Console.WriteLine("Не в колекциии такого id\n");
                return;
            }

            var index = collections.FindIndex(x => x.collectionId == currentId);

            try
            {
                collections[index].collectionId = newId;
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти в колекции такого id\n");
            }
        }

        public static void Delete(int id)
        {
            var index = collections.FindIndex(x => x.collectionId == id);

            try
            {
                collections.RemoveAt(index);
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти в колекции такого id\n");
            }
        }

        public static void GetAll()
        {
            for(var i = 0; i < collections.Count; i++)
            {
                Console.WriteLine($"{collections[i].collectionId} {collections[i].collectionName}");
            }
            
            Console.WriteLine();
        }

        public static void GetById(int id)
        {
            try
            {
                var index = collections.FindIndex(x => x.collectionId == id);
                Console.WriteLine($"{collections[index].collectionId} {collections[index].collectionName}\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти в колекции такой id\n");
            }
        }
    }
}
