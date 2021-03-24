using System;

namespace lab3
{
    class Human
    {
        static private int id = 0;
        private string name;
        private string surname;
        private int age;
        private string sex;
        private string nationality;
        private int weight;
        private int height;
        private int iq;

        public Human(string name, string surname, int age, string sex, string nationality, int weight, int height, int iq)
        {
            id += 1;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.sex = sex;
            this.nationality = nationality;
            this.weight = weight;
            this.height = height;
            this.iq = iq;
        }

        public string Name 
        {
            set { name = value; }
            get { return name; }
        }
        public string Surname
        {
            set { surname = value; }
            get { return surname; }
        }
        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        public string Nationality
        {
            set { nationality = value; }
            get { return nationality; }
        }
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        public int Weight
        {
            set { weight = value; }
            get { return weight; }
        }
        public int Height
        {
            set { height = value; }
            get { return height; }
        }
        public int IQ
        {
            set { iq = value; }
            get { return iq; }
        }
        public void ChangeName(string surname)
        {
            Surname = surname;
        }
        public void ChangeName(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }
        public int this[int parameters]
        {
            set
            {
                switch (parameters)
                {
                    case 1:
                        weight = value;
                        break;
                    case 2:
                        height = value;
                        break;
                    case 3:
                        iq = value;
                        break;
                }
            }
        }
        public void GetInfo()
        {
            Console.WriteLine($"{Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Height}, Вес: {Weight}, IQ: {IQ}");
        }
        public void IQCheck()
        {
            if (IQ < 80) Console.WriteLine("Этот человек довольно глупый");
            else if (IQ >= 80 && IQ <= 115) Console.WriteLine("Человек не глупый, но и не умный");
            else if (IQ > 115) Console.WriteLine("Человек довольно умный");
        }
        public void WeightCheck()
        {
            double IMT = Weight / Math.Pow(Height, 2) * 10000;
            IMT = Math.Round(IMT, 2);
            Console.WriteLine($"Ваш ИМТ составляет {IMT}");
            if (IMT < 19) Console.WriteLine("Вам следут потолстеть");
            else if (IMT >= 19 && IMT <= 25) Console.WriteLine("Ваш вес в норме");
            else if (IMT > 25) Console.WriteLine("Вам следут похудеть");
        }
        public void MinusWeight(int tries)
        {
            Random rnd = new Random();
            int cweight = rnd.Next(0, tries / 10);
            Console.WriteLine($"Вы смогли похудеть на {cweight} кг");
            Weight = Weight - cweight;
        }
        public void PlusWeight(int food)
        {
            Random rnd = new Random();
            int cweight = rnd.Next(0, food / 2);
            Console.WriteLine($"Вы смогли потолстеть на {cweight} кг");
            Weight = Weight + cweight;
        }
        public void ReadBook(int page)
        {
            Random rnd = new Random();
            int ciq = rnd.Next(0, page / 100 + 1);
            Console.WriteLine($"Ваш IQ увеличился на {ciq}");
            IQ = IQ + ciq;
        }
    }

    class Program
    {
        static int InputChecker()
        {
            string n;
            for (; ; )
            {
                n = Console.ReadLine();
                bool check = Int32.TryParse(n, out int ni);
                if (check && (ni > 0)) return ni;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
            
        }
        static void Main(string[] args)
        {
            string name;
            string surname;
            int age;
            string sex;
            string nationality;
            int weight;
            int height;
            int iq;     
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите фамилию");
            surname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите возраст");
            age = InputChecker();
            Console.Clear();
            Console.WriteLine("Введите пол");
            sex = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите национальность");
            nationality = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите вес");
            weight = InputChecker();
            Console.Clear();
            Console.WriteLine("Введите рост");
            height = InputChecker();
            Console.Clear();
            Console.WriteLine("Введите IQ");
            iq = InputChecker();
            Console.Clear();
            Human chel = new Human(name, surname, age, sex, nationality, weight, height, iq);
            for(; ; )
            {
                Console.WriteLine("Введите число чтобы:");
                Console.WriteLine("1. Вывести информацию о человеке");
                Console.WriteLine("2. Отправиться в ЗАГС и изменить фамилию (и имя если желаете)");
                Console.WriteLine("3. Изменить параметры (рост, вес, iq)");
                Console.WriteLine("4. Похудеть");
                Console.WriteLine("5. Потолстеть");
                Console.WriteLine("6. Почитать книгу");
                Console.WriteLine("7. Узнать уровень интеллекта");
                Console.WriteLine("8. Отправиться на консультацию по поводу веса");
                Console.WriteLine("Любое другое значение завершит программу");
                int x;
                x = InputChecker();
                switch (x)
                {
                    case 1:
                        Console.Clear();
                        chel.GetInfo();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите 1 (изменить фамилию), 2 (изменить и имя), любое другое число чтобы покинуть ЗАГС");
                        int decision = InputChecker();
                        if (decision == 1)
                        {
                            string NewSurname = Console.ReadLine();
                            chel.ChangeName(NewSurname);
                        }
                        else if (decision == 2)
                        {
                            string NewSurname = Console.ReadLine();
                            string NewName = Console.ReadLine();
                            chel.ChangeName(NewSurname, NewName);
                        }
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("1. Изменить вес");
                        Console.WriteLine("2. Изменить рост");
                        Console.WriteLine("3. Изменить IQ");
                        int parameter = InputChecker();
                        chel[parameter] = InputChecker();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите количество подходов:");
                        int tries;
                        tries = InputChecker();
                        chel.MinusWeight(tries);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введите количество пайков с едой:");
                        int food;
                        food = InputChecker();
                        chel.PlusWeight(food);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введите количество страниц:");
                        int page;
                        page = InputChecker();
                        chel.ReadBook(page);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        chel.IQCheck();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        chel.WeightCheck();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
