using System;

namespace HW_1_4_5
{
    class Program
    {
        static void Bouble(int size, int[] mas)
        {
            int a = 0;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size-1; j++)
                {
                    if(mas[j] > mas[j+1])
                    {
                        a = mas[j];
                        mas[j] = mas[j+1];
                        mas[j+1] = a;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите длинну массива");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] mas = new int[a];
            Random rand = new Random();

            Console.WriteLine("Введите ваше любимое число =)");
            int g = Convert.ToInt32(Console.ReadLine());
            int max = -1000000000;
            int min = 1000000000;
            for(int i = 0; i < a; i++)
            {
                mas[i] = rand.Next(g);
                if(max < mas[i])
                {
                    max = mas[i];
                }else if(min > mas[i])
                {
                    min = mas[i];
                }
                if(i == a-1)
                {                    
                    Console.WriteLine(mas[i]);
                }
                else
                {
                    Console.Write(mas[i] + " ");
                }
            }
            Console.WriteLine($" Max = {max}\n Min = {min}");

            Console.WriteLine("Рандомно сгенерированный массив.");
            Console.WriteLine("Хотите его отсортировать?\n 1.Да\n 2.Нет\n Введите цифру варианта.");
            int f = Convert.ToInt32(Console.ReadLine());
            
            if(f == 2)
            {
                Console.WriteLine("Всего доброго!");
                return;
            }

            Console.WriteLine(" 1.Bouble\n 2.Встроенная сортировка");
            int h  = Convert.ToInt32(Console.ReadLine());
            switch(h)
            {
                case 1:
                    Bouble(a, mas);
                break;
                case 2:
                    Array.Sort(mas);
                break;
                default:
                    Console.WriteLine("Нет такой соритровки!!!");
                return;
            }

            for(int i = 0; i < a; i++)
            {
                if(i == a-1)
                {                    
                    Console.WriteLine(mas[i]);
                }
                else
                {
                    Console.Write(mas[i] + " ");
                }
            }
        }
    }
}