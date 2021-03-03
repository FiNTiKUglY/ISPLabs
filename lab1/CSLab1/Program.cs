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
        static void changeColor(int i, int j, int[,] mas)
        {
            if (mas[i, j] == 0) mas[i, j] = 1;
            else mas[i, j] = 0;
        }

        static void winChecker(int[,] mas1, int[,] mas2, int size)
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

        static bool inputChecker(string size)
        {
            bool check = Int32.TryParse(size, out int sizeI);
            if (check && (sizeI > 1)) return true;
            else return false;
        }

        static void Main()
        {
            string sizeS;
            for (; ; )
            {
                Console.WriteLine("Введите размер поля (квадрат N*N): ");
                sizeS = Console.ReadLine();
                if (inputChecker(sizeS)) break;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
            int size = Convert.ToInt32(sizeS);
            Console.WriteLine();
            Console.CursorVisible = false;
            int[,] field1 = new int[size, size];   
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
                    if (field1[i, j] == 1) Console.Write("■ ");
                    else Console.Write("□ ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(size * size * 200);
            Console.Clear();
            int[,] field2 = new int[size, size];
            char[,] field3 = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field2[i, j] = 0;
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
                        if (field2[i, j] == 0) field3[i, j] = '□';
                        else field3[i, j] = '■';
                        field3[i1, j1] = 'x';
                        Console.Write("{0} ", field3[i, j]);
                    }
                    Console.WriteLine();
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.Enter) changeColor(i1, j1, field2);
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
            winChecker(field1, field2, size);
            Console.WriteLine();
            Console.WriteLine("Ваш вариант: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field2[i, j] == 0) field3[i, j] = '□';
                    else field3[i, j] = '■';
                    Console.Write("{0} ", field3[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Правильный вариант: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field1[i, j] == 1) Console.Write("■ ");
                    else Console.Write("□ ");
                }
                Console.WriteLine();
            }
        }
    }
}
