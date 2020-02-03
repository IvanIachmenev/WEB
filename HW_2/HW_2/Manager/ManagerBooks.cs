using System;
using System.Collections.Generic;
using System.Text;
using HW_2.Characters;

namespace HW_2.Manager
{
    class ManagerBooks
    {
        public List<Book> books;

        public ManagerBooks()
        {
            books = new List<Book>();
        }

        public void GetAll()
        {
            Console.WriteLine("Книги в асортименте: ");
            foreach(Book book in books)
            {
                Console.WriteLine(" Id книги: " + Convert.ToString(book.GetId()) + " Название книги: " + book.GetName() + " Цена книги: " + Convert.ToString(book.GetPrice()));
                Console.WriteLine(" Id автора: " + Convert.ToString(book.GetAuthor().GetId()) + " Имя автора: " + book.GetAuthor().GetName());
                Console.WriteLine(" Id жанра: " + Convert.ToString(book.GetGenre().GetId()) + " Жанр: " + book.GetGenre().GetName());
                Console.WriteLine(" Id издательства: " + Convert.ToString(book.GetPublisher().GetId()) + " Название издательства: " + book.GetPublisher().GetName());
            }
        }

        public int GetIdAuthor(string name)
        {
            foreach(Book book in books)
            {
                if(name == book.GetAuthor().GetName())
                {
                    return book.GetAuthor().GetId();
                }
            }
            return -1;
        }

        public int GetIdGener(string name)
        {
            foreach(Book book in books)
            {
                if(book.GetGenre().GetName() == name)
                {
                    return book.GetGenre().GetId();
                }
            }
            return -1;
        }

        public int GetIdPublishers(string name)
        {
            foreach (Book book in books)
            {
                if (book.GetPublisher().GetName() == name)
                {
                    return book.GetPublisher().GetId();
                }
            }
            return -1;
        }

        public void GetId(int id)
        {
            foreach(Book book in books)
            {
                if(book.GetId() == id)
                {
                    Console.WriteLine(" Id книги: " + Convert.ToString(book.GetId()) + " Название книги: " + book.GetName() + "Цена книги: " + Convert.ToString(book.GetPrice()));
                    Console.WriteLine(" Id автора: " + Convert.ToString(book.GetAuthor().GetId()) + " Имя автора: " + book.GetAuthor().GetName());
                    Console.WriteLine(" Id жанра: " + Convert.ToString(book.GetGenre().GetId()) + " Жанр: " + book.GetGenre().GetName());
                    Console.WriteLine(" Id издательства: " + Convert.ToString(book.GetPublisher().GetId()) + " Название издательства: " + book.GetPublisher().GetName());
                }
            }
        }
    }
}
