using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class BookActions
    {
        public static List<Book> books = new List<Book>();
        public static void Add(int bookId, int catId, int brId, string bookColor, int bookAmount)
        {
            if(books.FindIndex(x => x.bookId == bookId) == -1)
            {
                books.Add(new Book(bookId, catId, brId, bookColor, bookAmount));
                Console.WriteLine("Операция выполнена\n");
                return;
            }
        }

        public static void ChangeId(int currentId, int newId)
        {
            if(books.FindIndex(x => x.bookId == newId) != -1)
            {
                Console.WriteLine("Нет книги с таким id\n");
                return;
            }

            var index = books.FindIndex(x => x.bookId == currentId);

            try
            {
                books[index].bookId = newId;
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Нет книги с таким id\n");
            }
        }

        public static void ChangeCategory(int currntId, int newId)
        {
            if(books.FindIndex(x => x.bookId == currntId) != -1)
            {
                Console.WriteLine("Нет книги с таким id\n");
                return;
            }

            var index = books.FindIndex(x => x.bookId == currntId);

            try
            {
                books[index].CategoryId = newId;
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Не удалось выполнить операцию\n");
            }
        }

        public static void ChangeBrand(int currentId, int newId)
        {
            if(books.FindIndex(x => x.bookId == currentId) != -1)
            {
                Console.WriteLine("Нет книги с таким id\n");
                return;
            }

            var index = books.FindIndex(x => x.bookId == currentId);

            try
            {
                books[index].BrandId = newId;
                Console.WriteLine("Операция выполнена");
            }
            catch
            {
                Console.WriteLine("Не удалось выполнить операцию\n");
            }
        }

        public static void ChangeColor(int currentId, string newId)
        {
            if(books.FindIndex(x => x.bookId == currentId) != -1)
            {
                Console.WriteLine("Нет книги с таким id\n");
                return;
            }

            var index = books.FindIndex(x => x.bookId == currentId);

            try
            {
                books[index].bookColor = newId;
                Console.WriteLine("Операция выполнена");
            }
            catch
            {
                Console.WriteLine("Не удалось выполнить операцию\n");
            }
        }

        public static void ChangeAmount(int currentId, int newId)
        {
            if (books.FindIndex(x => x.bookId == currentId) != -1)
            {
                Console.WriteLine("Нет книги с таким id\n");
                return;
            }

            var index = books.FindIndex(x => x.bookId == currentId);

            try
            {
                books[index].bookAmount = newId;
                Console.WriteLine("Операция выполнена");
            }
            catch
            {
                Console.WriteLine("Не удалось выполнить операцию\n");
            }
        }

        public static void Delete(int id)
        {
            var index = books.FindIndex(x => x.bookId == id);
            try
            {
                books.RemoveAt(index);
                Console.WriteLine("Операция выполнена\n");
            }
            catch
            {
                Console.WriteLine("Не удалось выполнить операцию\n");
            }
        }

        public static void GetAll()
        {
            for (var i = 0; i < books.Count; i++)
            {
                Console.Write($"{books[i].CategoryId} {books[i].CategoryId} {books[i].BrandId} {books[i].bookColor} {books[i].bookAmount}");
            }
            Console.WriteLine();
        }

        public static void GetById(int id)
        {
            try
            {
                int index = books.FindIndex(x => x.CategoryId == id);
                Console.Write($"{books[index].CategoryId} {books[index].CategoryId} {books[index].BrandId} {books[index].bookColor} {books[index].bookAmount}\n");
            }
            catch
            {
                Console.WriteLine("Не удалось найти книгу с таким id\n");
            }
        }
    }
}
