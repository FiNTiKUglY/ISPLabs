using System;
using System.Text;

namespace lab7
{
    public class RNumber : IComparable<RNumber>
    {
        public bool Minus{ get; set; }
        public ulong Numerator { get; set; }
        public ulong Denominator { get; set; }

        public RNumber(ulong numerator, ulong denominator)
        {
            Minus = false;
            Numerator = numerator;
            Denominator = denominator;
        }

        public RNumber(bool minus, ulong numerator, ulong denominator)
        {
            Minus = minus;
            Numerator = numerator;
            Denominator = denominator;
        }

        private static ulong GCD(ulong a, ulong b)
        {
            while (a != b)
                if (a > b) a -= b;
                else b -= a;
            return a;
        }

        private static ulong LCM(ulong a, ulong b)
        {
            return a * b / GCD(a, b);
        }

        public void Reduce()
        {
            ulong gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public int CompareTo(RNumber other)
        {
            if (this > other) return 1;
            else if (this == other) return 0;
            else return -1;
        }

        public static explicit operator double(RNumber r)
        {
            double number;
            if (r.Minus == false) number = 1;
            else number = -1;
            return number * (double)r.Numerator / r.Denominator;
        }

        public static explicit operator float(RNumber r)
        {
            float number;
            if (r.Minus == false) number = 1;
            else number = -1;
            return number * (float)r.Numerator / r.Denominator;
        }

        public static explicit operator short(RNumber r)
        {
            short number;
            if (r.Minus == false) number = 1;
            else number = -1;
            ulong fullpart = r.Numerator / r.Denominator;
            return (short)(number * (short)fullpart);
        }

        public static explicit operator int(RNumber r)
        {
            int number;
            if (r.Minus == false) number = 1;
            else number = -1;
            ulong fullpart = r.Numerator / r.Denominator;
            return (int)(number * (int)fullpart);
        }

        public static explicit operator long(RNumber r)
        {
            long number;
            if (r.Minus == false) number = 1;
            else number = -1;
            ulong fullpart = r.Numerator / r.Denominator;
            return (long)(number * (long)fullpart);
        }

        public static RNumber operator +(RNumber r1, RNumber r2)
        {
            long resultNum;
            bool resultMinus = false;
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            resultNum = r1Num + r2Num;
            if (resultNum < 0) 
            {
                resultMinus = true;
                resultNum *= -1;
            }
            return new RNumber(resultMinus, (ulong)resultNum, lcm);

        }
        public static RNumber operator -(RNumber r1, RNumber r2)
        {
            long resultNum;
            bool resultMinus = false;
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            resultNum = r1Num - r2Num;
            if (resultNum < 0)
            {
                resultMinus = true;
                resultNum *= -1;
            }
            return new RNumber(resultMinus, (ulong)resultNum, lcm);
        }

        public static RNumber operator *(RNumber r1, RNumber r2)
        {
            ulong resultNum, resultDen;
            bool resultMinus;
            if (r1.Minus == r2.Minus) resultMinus = false;
            else resultMinus = true;
            resultNum = r1.Numerator * r2.Numerator;
            resultDen = r1.Denominator * r2.Denominator;
            return new RNumber(resultMinus, resultNum, resultDen);
        }

        public static RNumber operator /(RNumber r1, RNumber r2)
        {
            if (r2.Numerator == 0)
            {
                Console.Write("Делить на 0 нельзя: ");
                return new RNumber(0, 0);
            }
            ulong resultNum, resultDen;
            bool resultMinus;
            if (r1.Minus == r2.Minus) resultMinus = false;
            else resultMinus = true;
            resultNum = r1.Numerator * r2.Denominator;
            resultDen = r1.Denominator * r2.Numerator;
            return new RNumber(resultMinus, resultNum, resultDen);
        }

        public static bool operator >(RNumber r1, RNumber r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            return r1Num > r2Num;
        }

        public static bool operator <(RNumber r1, RNumber r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            return r1Num < r2Num;
        }

        public static bool operator ==(RNumber r1, RNumber r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            return r1Num == r2Num;
        }

        public static bool operator !=(RNumber r1, RNumber r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);
            if (r1.Minus == true) r1Num *= -1;
            if (r2.Minus == true) r2Num *= -1;
            return r1Num != r2Num;
        }

        public override string ToString()
        {
            if (Minus == false) return $"{Numerator}/{Denominator}";
            else return $"-({Numerator}/{Denominator})";
        }

        public string ToString(bool condition)
        {
            if (condition == false) return ToString();
            else
            {
                if (Minus == false) return $"Число положительное, числитель равен {Numerator}, знаменатель равен {Denominator}";
                else return $"Число отрицательное, числитель равен {Numerator}, знаменатель равен {Denominator}";
            }
        }
        public static RNumber ToRNumber(string str)
        {
            int i, j;
            StringBuilder strNum = new StringBuilder();
            StringBuilder strDen = new StringBuilder();
            bool rMinus = false;
            ulong rNum, rDen;
            if (str[0] == '-') rMinus = true;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == '-' || str[i] == '(') continue;
                else if (str[i] > '0' && str[i] < '9') strNum.Append(str[i]);
                else if (str[i] == '/') break;
                else throw new Exception("Неизвестный формат");
            }
            for (j = i + 1; j < str.Length; j++)
            {
                if (str[j] == ')') continue;
                else if (str[j] > '0' && str[j] < '9') strDen.Append(str[j]);
                else throw new Exception("Неизвестный формат");
            }
            rNum = Convert.ToUInt64(Convert.ToString(strNum));
            rDen = Convert.ToUInt64(Convert.ToString(strDen));
            return new RNumber(rMinus, rNum, rDen);
        }
    }
}