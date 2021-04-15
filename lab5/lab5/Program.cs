using System;
using System.Collections.Generic;

namespace lab3
{
    enum Gender
    {
        Male = 1,
        Female = 2,
    }
    struct Physical
    {
        public int weight;
        public int height;
        public int stamina;
        public int speed;
    }
    abstract class Athlete
    {
        static public int amount = 0;
        protected Physical Physics;
        private int sex;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Sex 
        { 
            get
            {
                if (sex == (int)Gender.Male) return "мужчина";
                else if (sex == (int)Gender.Female) return "женщина";
                else return "неизвестно";
            }
            set
            {
                sex = Convert.ToInt32(value);
            }
        }    
        public string Nationality { get; set; }

        public Athlete(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina, int speed)
        {
            amount += 1;
            ID = amount;
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
            Nationality = nationality;
            Physics.weight = weight;
            Physics.height = height;
            Physics.stamina = stamina;
            Physics.speed = speed;
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
                        Physics.weight = value;
                        break;
                    case 2:
                        Physics.height = value;
                        break;
                    case 3:
                        Physics.stamina = value;
                        break;
                    case 4:
                        Physics.speed = value;
                        break;
                }
            }
        }
        public abstract void SmallInfo();
        public void GetInfo()
        {
            Console.WriteLine($"{Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Physics.height}, Вес: {Physics.weight}");
        }
        public abstract string GetSpeciality();
       
        public void WeightCheck()
        {
            double IMT = Physics.weight / Math.Pow(Physics.height, 2) * 10000;
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
            Physics.weight = Physics.weight - cweight;
        }
        public void PlusWeight(int food)
        {
            Random rnd = new Random();
            int cweight = rnd.Next(0, food / 2);
            Console.WriteLine($"Вы смогли потолстеть на {cweight} кг");
            Physics.weight = Physics.weight + cweight;
        }
        public void PhysicalTraining(int rounds)
        {
            Random rnd = new Random();
            int cspeed = rnd.Next(0, rounds / 10 + 1);
            int cweight = rnd.Next(0, rounds / 5 + 1);
            int cstamina = rnd.Next(0, rounds / 10 + 1);
            Physics.stamina = Physics.stamina + cstamina;
            Physics.speed = Physics.speed + cspeed;
            Physics.weight = Physics.weight - cweight;
            Console.WriteLine($"Изменение характеристик: вес -{cweight}, скорость +{cspeed}, выносливость +{cstamina}");
        }
    }

    class Footballer : Athlete
    {
        public int Shooting { get; set; }
        public int Passing { get; set; }
        public int Defending { get; set; }
        public int Dribbling { get; set; }
        public Footballer(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina, int speed, 
                int shooting, int passing, int dribbling, int defending) : base(name, surname, age, sex, nationality, weight, height, stamina, speed)
        {
            Shooting = shooting;
            Dribbling = dribbling;
            Passing = passing;
            Defending = defending;
        }

        public override void SmallInfo()
        {
            Console.WriteLine($"{ID}. Футболист {Surname} {Name}");
        }
        public void GetInfo()
        {
            Console.WriteLine($"Футболист {Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Physics.height}, Вес: {Physics.weight}");
            Console.WriteLine($"Характеристики: удар {Shooting}, пасы {Passing}, владение мячом {Dribbling}, защита {Defending}, выносливость {Physics.stamina}, скорость {Physics.speed}");
        }
        public void ShootTraining()
        {
            Random rnd = new Random();
            int cshoot = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: удар +{cshoot}");
            Shooting = Shooting + cshoot;
        }
        public void AttackTraining()
        {
            Random rnd = new Random();
            int cdrib = rnd.Next(0, 2);
            int cpas = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: пасы +{cpas}, владения мячом +{cdrib}");
            Passing = Passing + cpas;
            Dribbling = Dribbling + cdrib;
        }
        public void DefenceTraining()
        {
            Random rnd = new Random();
            int cdef = rnd.Next(0, 2);
            int cpas = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: пасы +{cpas}, владения мячом +{cdef}");
            Passing = Passing + cpas;
            Defending = Defending + cdef;
        }
        public void RoleAnalysis()
        {
            int attack = (Passing + Shooting + Dribbling + Physics.speed) / 4;
            int defence = (Defending + Passing) / 2;
            int compare = attack - defence;
            if (compare >= 20) Console.WriteLine("атакующий");
            else if (compare <= -20) Console.WriteLine("защитник");
            else Console.WriteLine("полу-защитник");
        }
        public override string GetSpeciality()
        {
            return "футболист";
        }
    }

    class Tenniser : Athlete
    {
        public int Reaction { get; set; }
        public int RacketControl { get; set; }
        public int Power { get; set; }
        public Tenniser(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina,
                int speed, int reaction, int racketControl, int power) : base(name, surname, age, sex, nationality, weight, height, stamina, speed)
        {
            Reaction = reaction;
            RacketControl = racketControl;
            Power = power;
        }

        public override void SmallInfo()
        {
            Console.WriteLine($"{ID}. Теннисист {Surname} {Name}");
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Теннисист {Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Physics.height}, Вес: {Physics.weight}");
            Console.WriteLine($"Характеристики: реакция {Reaction}, владение ракеткой {RacketControl}, сила удара {Power}, выносливость {Physics.stamina}, скорость {Physics.speed}");
        }
        public void HitTraining()
        {
            Random rnd = new Random();
            int creac = rnd.Next(0, 2);
            int ccont = rnd.Next(0, 2);
            int cpow = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: удар +{cpow}, реакция +{creac}, владение ракеткой +{ccont}");
            Reaction = Reaction + creac;
            RacketControl = RacketControl + ccont;
            Power = Power + cpow;
        }
        public void PlayGame(Tenniser opponent)
        {
            int player1Statistic = Reaction + Power + RacketControl + Physics.stamina + Physics.speed;
            int player2Statistic = opponent.Reaction + opponent.Power + opponent.RacketControl + opponent.Physics.stamina + opponent.Physics.speed;
            int compare = player1Statistic - player2Statistic;
            if (compare > 40) Console.WriteLine($"{Surname} {Name} выиграл");
            else if (compare < -40) Console.WriteLine($"{opponent.Surname} {opponent.Name} выиграл");
            else
            {
                Random rnd = new Random();
                int result = rnd.Next(0, 2);
                if (result == 0) Console.WriteLine($"{Surname} {Name} выиграл в равной игре");
                else Console.WriteLine($"{opponent.Surname} {opponent.Name} выиграл в равной игре");
            }
        }
        public override string GetSpeciality()
        {
            return "теннисист";
        }
    }

    class Biathlete : Athlete
    {
        public int Accuracy { get; set; }
        public int MoveBalance { get; set; }
        public Biathlete(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina,
                 int speed, int accuracy, int moveBalance) : base(name, surname, age, sex, nationality, weight, height, stamina, speed)
        {
            Accuracy = accuracy;
            MoveBalance = moveBalance;
        }

        public override void SmallInfo()
        {
            Console.WriteLine($"{ID}. Биатлонист {Surname} {Name}");
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Биатлонист {Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Physics.height}, Вес: {Physics.weight}");
            Console.WriteLine($"Характеристики: точность {Accuracy}, равновесие на лыжах {MoveBalance}, выносливость {Physics.stamina}, скорость {Physics.speed}");
        }
        public void AccuracyTraining()
        {
            Random rnd = new Random();
            int cacc = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: точность стрельбы +{cacc}");
            Accuracy = Accuracy + cacc;
        }
        public void HaveARound()
        {
            Random rnd = new Random();
            int cspeed = rnd.Next(0, 2);
            int cbalance = rnd.Next(0, 2);
            Console.WriteLine($"Характеристики: равновесие на лыжах +{cbalance}, скорость +{cspeed}");
            MoveBalance = MoveBalance + cbalance;
            Physics.speed = Physics.speed + cspeed;
        }
        public override string GetSpeciality()
        {
            return "биатлонист";
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
        static int InputChecker(int max)
        {
            string n;
            for (; ; )
            {
                n = Console.ReadLine();
                bool check = Int32.TryParse(n, out int ni);
                if (check && (ni > 0) && (ni <= max)) return ni;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }

        }
        static void Main(string[] args)
        {
            string name, surname;
            int age;
            string sex;
            string nationality;
            int weight, height;
            int stamina, speed;
            int choose;
            int n, m, x = 1;
            List<Athlete> chel = new List<Athlete>();
            while (true)
            {
                n = Athlete.amount;
                if (x == 1)
                {
                    Console.WriteLine("Введите имя");
                    name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Введите фамилию");
                    surname = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Введите возраст");
                    age = InputChecker();
                    Console.Clear();
                    Console.WriteLine("Введите пол 1/2 (муж/жен)");
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
                    Console.WriteLine("Выберите вид спорта:\n1. Футболист\n2. Теннисист\n3. Биатлонист");
                    choose = InputChecker(3);
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Введите выносливость (от 1 до 100)");
                            stamina = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите скорость (от 1 до 100)");
                            speed = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите умение удара (от 1 до 100)");
                            int shoot = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите умение в пасс (от 1 до 100)");
                            int pass = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите владение мячом (от 1 до 100)");
                            int dribling = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите умение в защите (от 1 до 100)");
                            int defence = InputChecker(100);
                            Console.Clear();
                            chel.Add(new Footballer(name, surname, age, sex, nationality, weight, height, stamina, speed, shoot, pass, dribling, defence));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Введите выносливость (от 1 до 100)");
                            stamina = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите скорость (от 1 до 100)");
                            speed = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите силу удара (от 1 до 100)");
                            int power = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите владение ракеткой (от 1 до 100)");
                            int racket = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите скорость реакции (от 1 до 100)");
                            int reaction = InputChecker(100);
                            Console.Clear();
                            chel.Add(new Tenniser(name, surname, age, sex, nationality, weight, height, stamina, speed, reaction, racket, power));
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Введите выносливость (от 1 до 100)");
                            stamina = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите скорость (от 1 до 100)");
                            speed = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите точность стрельбы (от 1 до 100)");
                            int accuracy = InputChecker(100);
                            Console.Clear();
                            Console.WriteLine("Введите умение стоять на лыжах (от 1 до 100)");
                            int balance = InputChecker(100);
                            Console.Clear();
                            chel.Add(new Biathlete(name, surname, age, sex, nationality, weight, height, stamina, speed, accuracy, balance));
                            break;
                    }
                    Console.Clear();
                }
                else if (x == 2)
                {
                    foreach (var i in chel)
                    {
                        i.SmallInfo();
                    }
                    n = InputChecker(chel.Count) - 1;
                    Console.Clear();
                }
                do
                {
                    Console.WriteLine("Введите число чтобы:");
                    Console.WriteLine("1. Создать нового спортсмена");
                    Console.WriteLine("2. Выбрать существующего спортсмена");
                    Console.WriteLine("3. Вывести информацию о человеке");
                    Console.WriteLine("4. Отправиться в ЗАГС и изменить фамилию (и имя если желаете)");
                    Console.WriteLine("5. Изменить параметры (рост, вес, выносливость, скорость)");
                    Console.WriteLine("6. Похудеть");
                    Console.WriteLine("7. Потолстеть");
                    Console.WriteLine("8. Пробежать на стадионе");
                    Console.WriteLine("9. Отправиться на консультацию по поводу веса");
                    if (chel[n].GetSpeciality() == "футболист")
                    {
                        Console.WriteLine("10. Тренировать удар");
                        Console.WriteLine("11. Тренировать атаку");
                        Console.WriteLine("12. Тренировать защиту");
                        Console.WriteLine("13. Узнать роль");
                    } 
                    else if (chel[n].GetSpeciality() == "теннисист")
                    {
                        Console.WriteLine("10. Тренировать удар");
                        Console.WriteLine("11. Сыграть игру");
                    }
                    else if (chel[n].GetSpeciality() == "биатлонист")
                    {
                        Console.WriteLine("10. Тренировать стрельбу");
                        Console.WriteLine("11. Пройти круг на лыжах");
                    }    
                    Console.WriteLine("Любое другое значение завершит программу");
                    x = InputChecker();
                    switch (x)
                    {
                        case 1:
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            chel[n].GetInfo();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Введите 1 (изменить фамилию), 2 (изменить и имя), любое другое число чтобы покинуть ЗАГС");
                            int decision = InputChecker();
                            if (decision == 1)
                            {
                                string NewSurname = Console.ReadLine();
                                chel[n].ChangeName(NewSurname);
                            }
                            else if (decision == 2)
                            {
                                string NewSurname = Console.ReadLine();
                                string NewName = Console.ReadLine();
                                chel[n].ChangeName(NewSurname, NewName);
                            }
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("1. Изменить вес");
                            Console.WriteLine("2. Изменить рост");
                            Console.WriteLine("3. Изменить выносливость");
                            Console.WriteLine("4. Изменить скорость");
                            int parameter = InputChecker(4);
                            chel[n][parameter] = InputChecker();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Введите количество подходов:");
                            int tries;
                            tries = InputChecker();
                            chel[n].MinusWeight(tries);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Введите количество пайков с едой:");
                            int food;
                            food = InputChecker();
                            chel[n].PlusWeight(food);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Введите количество кругов:");
                            int rounds;
                            rounds = InputChecker();
                            chel[n].PhysicalTraining(rounds);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 9:
                            Console.Clear();
                            chel[n].WeightCheck();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 10:
                            Console.Clear();
                            if (chel[n].GetSpeciality() == "футболист")
                            {
                                Footballer temp = (Footballer)chel[n];
                                temp.ShootTraining();
                                chel[n] = temp;
                            }
                            else if (chel[n].GetSpeciality() == "теннисист")
                            {
                                Tenniser temp = (Tenniser)chel[n];
                                temp.HitTraining();
                                chel[n] = temp;
                            }
                            else if (chel[n].GetSpeciality() == "биатлонист")
                            {
                                Biathlete temp = (Biathlete)chel[n];
                                temp.AccuracyTraining();
                                chel[n] = temp;
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 11:
                            Console.Clear();
                            if (chel[n].GetSpeciality() == "футболист")
                            {
                                Footballer temp = (Footballer)chel[n];
                                temp.AttackTraining();
                                chel[n] = temp;
                            }
                            else if (chel[n].GetSpeciality() == "теннисист")
                            {
                                Console.WriteLine("Выберите соперника");
                                while (true)
                                {
                                    foreach (var i in chel)
                                    {
                                        i.SmallInfo();
                                    }
                                    m = InputChecker(chel.Count) - 1;
                                    if (n == m) Console.WriteLine("Игра с самим собой невозможна");
                                    else if (chel[m].GetSpeciality() == "теннисист") break;
                                    else Console.WriteLine("Спортсмен не является теннисистом");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                Console.Clear();
                                Tenniser temp = (Tenniser)chel[n];
                                Tenniser opponent = (Tenniser)chel[m];
                                temp.PlayGame(opponent);
                            }
                            else if (chel[n].GetSpeciality() == "биатлонист")
                            {
                                Biathlete temp = (Biathlete)chel[n];
                                temp.HaveARound();
                                chel[n] = temp;
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 12:
                            Console.Clear();
                            if (chel[n].GetSpeciality() == "футболист")
                            {
                                Footballer temp = (Footballer)chel[n];
                                temp.DefenceTraining();
                                chel[n] = temp;
                            }
                            else return;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 13:
                            Console.Clear();
                            if (chel[n].GetSpeciality() == "футболист")
                            {
                                Footballer temp = (Footballer)chel[n];
                                temp.RoleAnalysis();
                            }
                            else return;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            return;
                    }
                } while (x != 1 && x != 2);
            }
        }
    }
}
