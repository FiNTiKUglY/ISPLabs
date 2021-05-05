using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RNumber num1 = new RNumber(3, 5);
            RNumber num2 = new RNumber(true, 10, 11);
            RNumber num3 = new RNumber(1, 3);
            RNumber num3Another = RNumber.ToRNumber("2/6");
            RNumber num3Minus = RNumber.ToRNumber("-(1/3)");
            RNumber num4 = RNumber.ToRNumber("-(15/4)");
            Console.WriteLine(num1);
            Console.WriteLine(num1.ToString(true));
            Console.WriteLine(num2);
            Console.WriteLine(num2.ToString(true));
            Console.WriteLine();
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} + {num3} = {num1 + num3}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            Console.WriteLine($"{num1} - {num3} = {num1 - num3}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            Console.WriteLine($"{num1} * {num3} = {num1 * num3}");
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
            Console.WriteLine($"{num1} / {num3} = {num1 / num3}");
            Console.WriteLine();
            if (num3 == num3Another) Console.WriteLine($"{num3} = {num3Another}");
            if (num3 != num3Minus) Console.WriteLine($"{num3} != {num3Minus}");
            if (num1 > num3) Console.WriteLine($"{num1} > {num3}");
            if (num2 < num3Minus) Console.WriteLine($"{num2} < {num3Minus}");
            Console.WriteLine();
            Console.WriteLine($"{num1} в double = {(double)num1}");
            Console.WriteLine($"{num2} в float = {(float)num2}");
            Console.WriteLine($"{num4} в int = {(int)num4}");
            Console.WriteLine($"{num3Another} в short = {(short)num3Another}");
            Console.WriteLine($"{num3Minus} в long = {(int)num3Minus}");
            Console.WriteLine();
            Console.Write($"{num3Another} = ");
            num3Another.Reduce();
            Console.WriteLine($"{num3Another}");
        }
    }
}
