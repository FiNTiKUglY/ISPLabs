using System;
using System.Text;
using System.Numerics;

namespace lab2
{
    class Program
    {
        static int DegreeCounter(int first, int second)
        {
            int res1 = 0;
            int res2 = 0;
            int res;
            while (first != 0)
            {
                first  /= 2;
                res1 += first;
            }
            while (second != 0)
            {
                second /= 2;
                res2 += second;
            }
            res = Math.Abs(res2 - res1);
            return res;
        }

        static bool LetterChecker(string Line, int pos)    // Для 1-го задания
        {
            if (Line[pos] == 'a' || Line[pos] == 'e' || Line[pos] == 'i' || Line[pos] == 'o' || Line[pos] == 'u') return true;
            else return false;
        }

        static bool StringChecker(string Line)              // Для 1-го задания
        {
            bool check = true;
            for (int i = 0; i < Line.Length; i++)
            {
                if (!(Line[i] >= 97 && Line[i] <= 122)) check = false;
            }
            return check;
        }

        static void StringChanger(string Line)            // Для 1-го задания
        {
            StringBuilder NewLine = new StringBuilder();
            NewLine.Append(Line[0]);
            for (int i = 0; i < Line.Length - 1; i++)
            {
                if (LetterChecker(Line, i))
                {
                    if (Line[i + 1] == 122)
                    {
                        NewLine.Append("a");
                    }
                    else
                    {
                        int temp = Line[i + 1] + 1;
                        NewLine.Append((char)temp);
                    }
                }
                else
                {
                    NewLine.Append(Line[i + 1]);
                }
            }
            Console.Write("{0}", NewLine);
        }

        static bool IntCheckerer(string min, string max)                // Для 2-го задания
        {
            bool check1 = Int32.TryParse(min, out int minI);
            bool check2 = Int32.TryParse(max, out int maxI);
            if (check1 && check2 && (minI <= maxI)) return true;
            else return false;
        }

        static void NumbersCount(DateTime date1)                       // Для 3-го задания
        {
            string dateLong = Convert.ToString(date1);
            string dateShort1 = Convert.ToString(date1.ToLongDateString());
            string dateShort2 = Convert.ToString(date1.ToShortTimeString());
            for (int i = 0; i < 10; i++)
            {
                int count = 0;
                for (int j = 0; j < dateLong.Length; j++)
                {
                    if (dateLong[j] == ((char)i + 48)) count++;
                }
                for (int j = 0; j < dateShort1.Length; j++)
                {
                    if (dateShort1[j] == ((char)i + 48)) count++;
                }
                for (int j = 0; j < dateShort2.Length; j++)
                {
                    if (dateShort2[j] == ((char)i + 48)) count++;
                }
                Console.WriteLine("Количество {0}: {1}", i, count);
            }
        }

        static void NextTask()                                             // Для перехода на следующее задание
        {
            Console.WriteLine("\n\n\nНажмите любую клавишу для перехода на следующее задание");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строчные английские буквы");      // Дана строка, состоящая из строчных английских букв.
            string EngLine;                                              // Заменить в ней все буквы, стоящие после гласных,  
            for (; ; )                                                   // на следующие по алфавиту (z заменяется на a).
            { 
                EngLine = Console.ReadLine();
                if (StringChecker(EngLine)) break;
                Console.Clear();
                Console.WriteLine("Введите СТРОЧНЫЕ АНГЛИЙСКИЕ БУКВЫ:");
            }
            StringChanger(EngLine);

            NextTask();

            string minS, maxS;
            for (; ; )
            {
                Console.WriteLine("Введите числа начальную и конечную границы диапазона: ");       // Рассчитать максимальную степень двойки,  
                minS = Console.ReadLine();                                                         // на которую делится произведение подряд идущих
                maxS = Console.ReadLine();                                                         // чисел от a до b (числа целые 64-битные без знака).
                if (IntCheckerer(minS, maxS)) break;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
            int min = Convert.ToInt32(minS);
            int max = Convert.ToInt32(maxS);
            bool zero = false;
            for (int i = min; i <= max; i++)
            {
                if (i == 0)
                {
                    zero = true;
                    break;
                }
            }
            int counter = DegreeCounter(min - 1, max);  
            if (zero) Console.WriteLine("Степень бесконечна, так как произведение чисел в диапазоне равно 0");
            else Console.WriteLine("Максимальная степень двойки: {0}", counter); 

            NextTask();

            DateTime date1 = DateTime.Now;                             // Получить  текущее время и дату в двух разных форматах
            Console.WriteLine(date1);                                  // и вывести на экран количество нулей, единиц, ... , девяток в их записи
            Console.Write(date1.ToLongDateString());
            Console.WriteLine($" {date1.ToShortTimeString()}");
            NumbersCount(date1);
        }
    }
}
