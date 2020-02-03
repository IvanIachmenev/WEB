using System;
using System.Collections.Generic;
using System.Text;
using HW_2.Manager;
using HW_2.Characters;

namespace HW_2
{
    enum State
    {
        Manager,
        Cashier,
        Warehouse
    }
    class Modes
    {
        State state = State.Manager;
        ManagerBooks manager = new ManagerBooks();

        public void Manager()
        { 
            string f;
            Console.WriteLine("Посмотреть весь асортимент? +");
            f = Console.ReadLine();
            if(f == "+")
            {
                manager.GetAll();
                f = "-";
            }

            Console.WriteLine("Желайте найти книгу по id? +");
            f = Console.ReadLine();
            if(f == "+")
            {
                Console.WriteLine("Введите id");
                int id = Convert.ToInt32(Console.ReadLine());
                manager.GetId(id);
                f = "-";
            }

            Console.WriteLine("Желайте перейти на склад? +");
            f = Console.ReadLine();
            if(f == "+")
            {
                Warehouse();
            }
            Console.WriteLine("Желайте перейти на кассу? +");
            f = Console.ReadLine();
            if (f == "+")
            {
                Cashier();
            }
            Console.WriteLine("Желайте закончить с покупками? +");
            f = Console.ReadLine();
            if (f == "+")
            {
                return;
            }
            else
            {
                Manager();
                return;
            }
        }

        public void Cashier()
        {
            string f;
            Cashier cashier = new Cashier();
            Console.WriteLine("Желайте приобрести книгу по id? +");
            f = Console.ReadLine();
            if(f == "+")
            {
                Console.WriteLine("Введите id");
                int id = Convert.ToInt32(Console.ReadLine());
                manager.GetId(id);
                Book book = cashier.GetId(id);
                if(book == null)
                {
                    Console.WriteLine("К сожалению нет такой книги =(");
                }
                else
                {
                    Console.WriteLine("Спасибо за покупку!");
                }
            }
            Console.WriteLine("Хотите продолжить? \n (+) = да (-) = нет");
            f = Console.ReadLine();
            if (f == "-") return;
            else if(f == "+")
            {
                f = "-";
                Console.WriteLine("Желайте перейти в магазин? +");
                f = Console.ReadLine();
                if (f == "+")
                {
                    Manager();
                    return;
                }
                Console.WriteLine("Желайте перейти на склад? +");
                f = Console.ReadLine();
                if (f == "+")
                {
                    Warehouse();
                }
            }
        }

        public void Warehouse()
        {
            string f;
            Console.WriteLine("Желайте оформить заказ? +");
            f = Console.ReadLine();
            if (f == "+")
            {
                Console.WriteLine("Введите название книги");
                string n = Console.ReadLine();
                Random rand = new Random();
                Console.WriteLine("Введите автора");
                string author = Console.ReadLine();
                int idAuthor = manager.GetIdAuthor(author);
                if (idAuthor == -1)
                {
                    idAuthor = rand.Next(100, 1000);
                }
                Console.WriteLine("Введите жанр книги");
                string g = Console.ReadLine();
                int idGener = manager.GetIdAuthor(g);
                if (idGener == -1)
                {
                    idGener = rand.Next(100, 1000);
                }
                Console.WriteLine("Введите издательство");
                string p = Console.ReadLine();
                int idPublisher = manager.GetIdPublishers(p);
                if (idPublisher == -1)
                {
                    idPublisher = rand.Next(100, 1000);
                }
                Author a = new Author(idAuthor, author, 0, 0, 0);
                Genres genre = new Genres(idGener, g);
                Publishers publisher = new Publishers(idPublisher, p);
                int id = rand.Next(100, 1000);
                Book book = new Book(a, genre, publisher, id, n);
                manager.books.Add(book);
                Console.WriteLine($"Ваш заказ готов c id: {id}");
                Cashier();
            }
        }
    }
}