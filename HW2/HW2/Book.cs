using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class Book
    {
        public int bookId;
        public int CategoryId;
        public int BrandId;
        public string bookColor;
        public int bookAmount;

        public Book(int bId, int catId, int brId, string bColor, int bAmount)
        {
            bookId = bId;
            CategoryId = catId;
            BrandId = brId;
            bookColor = bColor;
            bookAmount = bAmount;
        }
    }
}
