using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2.Characters
{
    class Book : ICharacter
    {
        int id, price;
        string name;
        Author author;
        Genres genre;
        Publishers publisher;

        public Book(Author a, Genres g, Publishers p, int id, string name)
        {
            Random rand = new Random();
            this.id = id;
            this.name = name;
            author = a;
            genre = g;
            publisher = p;
            price = rand.Next(100, 500);
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public Genres GetGenre()
        {
            return genre;
        }

        public Publishers GetPublisher()
        {
            return publisher;
        }

        public int GetPrice()
        {
            return price;
        }

        public void SetId(int id) { }

        public void SetName(string name) { }

    }
}
