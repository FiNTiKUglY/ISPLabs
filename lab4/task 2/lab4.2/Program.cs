using System;
using System.Runtime.InteropServices;

namespace lab4._2
{
    class Program
    {
        [DllImport("Dll for lab4.dll")]
        static extern float Min(float a, float b);
        [DllImport("Dll for lab4.dll")]
        static extern float Max(float a, float b);
        [DllImport("Dll for lab4.dll")]
        static extern float Abs(float a);
        [DllImport("Dll for lab4.dll")]
        static extern float Pow(float a, int b);
        [DllImport("Dll for lab4.dll")]
        static extern int Fact(int a);
        [DllImport("Dll for lab4.dll")]
        static extern int Fibonacci(int a);

        static int InputChecker()
        {
            string n;
            for (; ; )
            {
                n = Console.ReadLine();
                bool check = Int32.TryParse(n, out int ni);
                if (check) return ni;
                Console.WriteLine("\nНекорректный ввод, попробуйте снова");
            }
        }
        static void Main(string[] args)
        {
            int first, second, n;
            while (true)
            {
                Console.WriteLine("1. Min.\n2. Max.\n3. Модуль.\n4. Возведение в степень.\n5. Факториал.\n6. Фибоначчи.\n7. Выход.");
                n = InputChecker();
                switch (n)
                {
                    case 1:
                        Console.WriteLine("\nВведите первое число");
                        first = InputChecker();
                        Console.WriteLine("\nВведите второе число");
                        second = InputChecker();
                        Console.WriteLine($"\n{Min(first, second)}");
                        break;
                    case 2:
                        Console.WriteLine("\nВведите первое число");
                        first = InputChecker();
                        Console.WriteLine("\nВведите второе число");
                        second = InputChecker();
                        Console.WriteLine($"\n{Max(first, second)}");
                        break;
                    case 3:
                        Console.WriteLine("\nВведите число");
                        first = InputChecker();
                        Console.WriteLine($"\n{Abs(first)}");
                        break;
                    case 4:
                        Console.WriteLine("\nВведите число");
                        first = InputChecker();
                        Console.WriteLine("\nВведите степень");
                        second = InputChecker();
                        Console.WriteLine($"\n{Pow(first, second)}");
                        break;
                    case 5:
                        Console.WriteLine("\nВведите число");
                        first = InputChecker();
                        Console.WriteLine($"\n{Fact(first)}");
                        break;
                    case 6:
                        Console.WriteLine("\nВведите позицию в последовательности");
                        first = InputChecker();
                        Console.WriteLine($"\n{Fibonacci(first)}");
                        break;
                    case 7:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
