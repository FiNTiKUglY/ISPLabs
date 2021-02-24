/* "Память" 
Суть игры: вы вводите размер квадратной игровой зоны. Случайно генерируется поле с закрашенными и незакрашенными ячейками, 
которое вы должны запомнить за некоторое время.После очистки консоли вы, используя стрелочки для перемещения курсора, 
закрашиваете ячейки (клавишей Enter) так, чтобы ваше поле было идентично генерируемому до этого. Если вы считаете, 
что ваш вариант готов, нажимаете клавишу Escape, после чего вам выбивает сообщение о вашей победе (или поражении) */

using System;
using System.Threading;

namespace CSLab1
{
    class Program
    {
        static void ChangeColor(int i, int j, int[,] mas)
        {
            if (mas[i, j] == 0) mas[i, j] = 1;
            else mas[i, j] = 0;
        }
        static void WinChecker(int[,] mas1, int[,] mas2, int size)
        {
            bool check = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mas1[i, j] != mas2[i, j]) check = false;
                }
            }
            if (check) Console.WriteLine("вВы выиграли!");
            else Console.WriteLine("вВы проиграли (");
        }
        static bool InputChecker(string size)
        {
            bool check;
            int sizeI;
            check = Int32.TryParse(size, out sizeI);
            if (check) return true;
            else return false;
        }
        static void Main()
        {
            string sizeS;
            for (; ; )
            {
                Console.WriteLine("Введите размер поля (квадрат N*N): ");
                sizeS = Console.ReadLine();
                if (InputChecker(sizeS)) break;
                Console.Clear();
            }
            int size = Convert.ToInt32(sizeS);
            Console.WriteLine();
            int[,] field1 = new int[size, size];   
            char[,] field2 = new char[size, size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field1[i, j] = rnd.Next(0, 2);
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field1[i, j] == 1) field2[i, j] = '■';
                    else field2[i, j] = '□';
                    Console.Write("{0} ", field2[i, j]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(size * size * 200);
            Console.Clear();
            int[,] field3 = new int[size, size];
            char[,] field4 = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field3[i, j] = 0;
                }
            }
            int i1 = 0, j1 = 0;
            for (; ; )
            {
                ConsoleKeyInfo key;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (field3[i, j] == 0) field4[i, j] = '□';
                        else field4[i, j] = '■';
                        field4[i1, j1] = 'x';
                        Console.Write("{0} ", field4[i, j]);
                    }
                    Console.WriteLine();
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.Enter) ChangeColor(i1, j1, field3);
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    j1++;
                    if (j1 >= size) j1 = size - 1; 
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    j1--;
                    if (j1 < 0) j1 = 0;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    i1++;
                    if (i1 >= size) i1 = size - 1;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    i1--;
                    if (i1 < 0) i1 = 0;
                }
                Console.Clear();
            }
            Console.Clear();
            WinChecker(field1, field3, size);
            Console.WriteLine();
            Console.WriteLine("Ваш вариант: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field3[i, j] == 0) field4[i, j] = '□';
                    else field4[i, j] = '■';
                    Console.Write("{0} ", field4[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Правильный вариант: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", field2[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
