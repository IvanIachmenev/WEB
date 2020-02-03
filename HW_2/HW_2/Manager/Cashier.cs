using System;
using System.Collections.Generic;
using System.Text;
using HW_2.Characters;

namespace HW_2.Manager
{
    class Cashier
    {
        ManagerBooks manager = new ManagerBooks();

        public void RemoveBook(Book book)
        {
            manager.books.Remove(book);
        }

        public Book GetId(int id)
        {
            foreach (Book book in manager.books)
            {
                if (book.GetId() == id)
                {
                    Book b = book;
                    manager.books.Remove(book);
                    return b;
                }
            }
            return null;
        }
    }
}
