using System;
using System.Collections.Generic;
using System.Text;
using HW_2.Characters;

namespace HW_2.Manager
{
    class WarehouseManager
    {
        ManagerBooks manager = new ManagerBooks();
        public void AddBook(Book book)
        {
            manager.books.Add(book);
        }
    }
}
