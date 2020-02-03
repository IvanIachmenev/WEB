using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            
=======
<<<<<<< HEAD
            
=======
<<<<<<< HEAD
            
=======
            string mode = null;
            while(mode != "0")
            {
                Console.WriteLine("Для поиска товара - нажмите 1 \n" 
                    + "Для входа в режим администратора - нажмите 9 \n" 
                    + "Для выхода - нажмите 0");
                mode = Console.ReadLine();
                Console.WriteLine();
                if(mode == "1")
                {
                    Console.WriteLine(
                        "Чтобы увидеть все бренды - нажмите 1 \nДля просмотра бренда по его идентификатору - нажмите 2 \n"
                        + "Чтобы увидеть все категории - нажмите 3 \nДля просмотра категории по ее идентификатору - нажмите 4 \n"
                        + "Чтобы увидеть все коллекции - нажмите 5 \nДля просмотра коллекции по ее идентификатору - нажмите 6 \n"
                        + "Чтобы увидеть все книги - нажмите 7 \nЧтобы увидеть книгу по его идентификатору - нажмите 8 \n"
                        + "Для выхода нажмите 0");
                    string click = null;
                    click = Console.ReadLine();
                    Console.WriteLine();

                    if(click == "1")
                    {
                        BrandActions.GetAll();
                    }
                    else if(click == "2")
                    {
                        Console.WriteLine("Напишите идентификатор бренда, который хотите увидеть: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            BrandActions.GetById(id);
                        }
                        catch
                        {
                            Console.WriteLine("Операция не может быть завершена \n");
                        }
                    }
                    else if(click == "3")
                    {
                        CategoryActions.GetAll();
                    }
                    else if(click == "4")
                    {
                        Console.WriteLine("Напишите идентификатор категории, которую хотите увидеть: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            CategoryActions.GetById(id);
                        }
                        catch
                        {
                            Console.WriteLine("Операция не может быть завершена \n");
                        }
                    }
                    else if(click == "5")
                    {
                        CollectionActions.GetAll();
                    }
                    else if(click == "6")
                    {
                        Console.WriteLine("Напишите идентификационный номер коллекции, которую хотите увидеть: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            CollectionActions.GetById(id);
                        }
                        catch
                        {
                            Console.WriteLine("Операция не может быть завершена \n");
                        }
                    }
                    else if(click == "7")
                    {
                        BookActions.GetAll();
                    }
                    else if(click == "8")
                    {
                        Console.WriteLine("Напишите идентификатор продукта, который вы хотите увидеть: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            BookActions.GetById(id);
                        }
                        catch
                        {
                            Console.WriteLine("Операция не может быть завершена \n");
                        }
                    }
                    else if(click == "9") {}
                    else
                    {
                        Console.WriteLine("Вы не попали по нужной клавише =)");
                    }
                }
                else if (mode == "9")
                {
                    string click = null;
                    while(click != "0")
                    {
                        Console.WriteLine("Чтобы выполнить действия с брендом - нажмите 1 \nДля выполнения действий с категорией - нажмите 2 \n"
                            + "Чтобы выполнить действия с коллекцией, нажмите 3 \nДля выполнения действий с продуктом нажмите 4 \n"
                            + "Для выхода нажмите 0");
                        click = Console.ReadLine();
                        Console.WriteLine();

                        if(click == "1")
                        {
                            string action = null;
                            while(action != "0")
                            {
                                Console.WriteLine("Чтобы добавить бренд - нажмите 1 \nДля изменения идентификатора бренда - нажмите 2 \nДля удаления бренда - нажмите 3 \n"
                                    + "Для выхода нажмите 0");
                                action = Console.ReadLine();
                                if(action == "1")
                                {
                                    Console.WriteLine("Напишите id бренда");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите название бренда");
                                    string name = Console.ReadLine();

                                    try
                                    {
                                        BrandActions.Add(id, name);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Не удалось выполнить операцию\n");
                                    }
                                }
                                if(action == "2")
                                {
                                    Console.WriteLine("Напишите индефекатор существующего бренда\n");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый индефекатор для изменения\n");
                                    int newId = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BrandActions.ChangeId(id, newId);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if(action == "3")
                                {
                                    Console.WriteLine("Напишите индефекатор бренда, которго хотите удалить\n");
                                    int id = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BrandActions.Delete(id);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операцию не может быть выполнена\n");
                                    }
                                }
                                if(action == "0") { }
                                else
                                {
                                    Console.WriteLine("Неверные входные данные \n");
                                }
                            }
                        }
                        else if(click == "2")
                        {
                            string action = null;
                            while(action != "0")
                            {
                                Console.WriteLine("Чтобы добавить категорию - нажмите 1 \nДля изменения идентификатора категории - нажмите 2 \n"
                                    + "Чтобы удалить категорию - нажмите 3 \nДля выхода - нажмите 0");
                                action = Console.ReadLine();
                                if(action == "1")
                                {
                                    Console.WriteLine("Напишите индефекатор категории");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите название категории");
                                    string name = Console.ReadLine();

                                    try
                                    {
                                        CategoryActions.Add(id, name);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if(action == "2")
                                {
                                    Console.WriteLine("Напишите индефекатор существующего категории\n");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый индефекатор для изменения\n");
                                    int newId = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        CategoryActions.ChangeId(id, newId);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "3")
                                {
                                    Console.WriteLine("Напишите индефекатор категории, которого хотите удалить\n");
                                    int id = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        CategoryActions.Delete(id);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операцию не может быть выполнена\n");
                                    }
                                }
                                if (action == "0") { }
                                else
                                {
                                    Console.WriteLine("Неверные входные данные \n");
                                }
                            }
                        }
                        if(click == "3")
                        {
                            string action = null;
                            while (action != "0")
                            {
                                Console.WriteLine("Чтобы добавить колекцию - нажмите 1 \nДля изменения идентификатора колекции - нажмите 2 \n"
                                    + "Чтобы удалить колекцию - нажмите 3 \nДля выхода - нажмите 0");
                                action = Console.ReadLine();
                                if (action == "1")
                                {
                                    Console.WriteLine("Напишите индефекатор колекции");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите название колекции");
                                    string name = Console.ReadLine();

                                    try
                                    {
                                        CollectionActions.Add(id, name);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "2")
                                {
                                    Console.WriteLine("Напишите индефекатор существующего колекции\n");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый индефекатор для изменения\n");
                                    int newId = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        CategoryActions.ChangeId(id, newId);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "3")
                                {
                                    Console.WriteLine("Напишите индефекатор колекции, которого хотите удалить\n");
                                    int id = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        CollectionActions.Delete(id);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операцию не может быть выполнена\n");
                                    }
                                }
                                if (action == "0") { }
                                else
                                {
                                    Console.WriteLine("Неверные входные данные \n");
                                }
                            }
                        }
                        if(click == "4")
                        {
                            string action = null;
                            while(action != "0")
                            {
                                Console.WriteLine("Чтобы добавить продукт - нажмите 1 \nДля изменения идентификатора продукта - нажмите 2 \n"
                                    + "Для изменения категории продукта - нажмите 3 \n Для изменения бренда продукта - нажмите 4 \n"
                                    + "Чтобы изменить цвет товара - нажмите 5 \nДля изменения количества товара - нажмите 6 \n"
                                    + "Чтобы удалить товар - нажмите 7 \nДля выхода - нажмите 0");
                                action = Console.ReadLine();
                                if(action == "1")
                                {
                                    Console.WriteLine("Напишите индефекатор книги");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите индефекатор категории");
                                    int catid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите индефекатор бренда");
                                    int brid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите цвет книги");
                                    string color = Console.ReadLine();
                                    Console.WriteLine("Напишите количество книг");
                                    int amount = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.Add(id, catid, brid, color, amount);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операцию не может быть выполнена\n");
                                    }
                                }
                                if (action == "2")
                                {
                                    Console.WriteLine("Напишите существующий индефекатор книги");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый индефекатор для изменения");
                                    int newID = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.ChangeId(id, newID);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "3")
                                {
                                    Console.WriteLine("Напишите идентификатор книги, который вы хотите изменить.");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый идентификатор категории");
                                    int newID = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.ChangeCategory(id, newID);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "4")
                                {
                                    Console.WriteLine("Напишите идентификатор книги, который вы хотите изменить");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый индефекатор категории");
                                    int newID = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.ChangeBrand(id, newID);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "5")
                                {
                                    Console.WriteLine("Напишите идентификатор продукта, какой цвет вы хотите изменить");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новый цвет\n");
                                    string newColor = Console.ReadLine();

                                    try
                                    {
                                        BookActions.ChangeColor(id, newColor);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                    }
                                }
                                if (action == "6")
                                {
                                    Console.WriteLine("Напишите идентификатор книги, который вы хотите изменить");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Напишите новое количество");
                                    int newID = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.ChangeAmount(id, newID);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операци не может быть выполнена\n");
                                        Console.WriteLine();
                                    }
                                }
                                if (action == "7")
                                {
                                    Console.WriteLine("Напишите идентификатор продукта, который вы хотите удалить");
                                    int id = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        BookActions.Delete(id);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Операция не может быть выполнена\n");
                                        Console.WriteLine();
                                    }
                                }
                                else if (action == "0") { }
                                else
                                {
                                    Console.WriteLine("Неверные входные данные\n");
                                }
                            }
                        }
                        else if (click == "0") { }
                        else
                        {
                            Console.WriteLine("Вы ошиблись\n");
                        }
                        Console.WriteLine();
                    }
                }
                else if (mode == "0")
                {
                    Console.WriteLine("На этом и покончим\n");
                }

                else
                {
                    Console.WriteLine("Вы ошиблись\n");
                    Console.WriteLine();
                }
            }
>>>>>>> HW2 end
>>>>>>> HW2 end
>>>>>>> HW2 end
        }
    }
}
