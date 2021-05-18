using System;
using System.Collections.Generic;

namespace lab8
{
    class Program
    {
        static int InputChecker()
        {
            string input;
            for (; ; )
            {
                input = Console.ReadLine();
                bool check = Int32.TryParse(input, out int inputInt);
                if (check && (inputInt > 0)) return inputInt;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
        }

        static int InputChecker(int max)
        {
            string input;
            for (; ; )
            {
                input = Console.ReadLine();
                bool check = Int32.TryParse(input, out int inputInt);
                if (check && (inputInt > 0) && (inputInt <= max)) return inputInt;
                Console.Clear();
                Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
        }

        static void ConsoleOutput(string message)
        {
            Console.WriteLine(message);
        }

        static void PositiveConsoleOutput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
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
            int n, m, switcher = 1;
            List<Athlete> chel = new List<Athlete>();
            AthleteComparer comparer = new AthleteComparer();
            Athlete.ChangeFullNameEvent += delegate ()
            {
                Console.WriteLine("\nИмя изменено");
                Console.WriteLine("Фамилия изменена");
                Console.WriteLine("Как будто другой человек...");
            };
            Athlete.ChangeSurnameEvent += () => Console.WriteLine("\nФамилия изменена");
            while (true)
            {
                n = Athlete.amount;
                if (switcher == 1)
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
                    sex = Convert.ToString(InputChecker());
                    Console.Clear();
                    Console.WriteLine("Введите национальность");
                    Console.WriteLine("1. BY\n2. RU\n3. US\n4. UA\n5. DE\n6. GB\n7. PL\n8. ES\n9. TR\n10. Прочие");
                    nationality = Convert.ToString(InputChecker());
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
                            Console.WriteLine("Введите умение в пас (от 1 до 100)");
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
                    chel.Sort(comparer);
                    for (int i = 0; i < chel.Count; i++)
                    {
                        chel[i].ID = i + 1;
                    }
                    Console.Clear();
                }
                else if (switcher == 2)
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
                    chel[n].Print += PositiveConsoleOutput;
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
                    switcher = InputChecker();
                    switch (switcher)
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
                            Console.ReadKey();
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
                            chel[n].Print -= PositiveConsoleOutput;
                            chel[n].Print += ConsoleOutput;
                            chel[n].WeightCheck();
                            chel[n].Print -= ConsoleOutput;
                            chel[n].Print += PositiveConsoleOutput;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 10:
                            Console.Clear();
                            if (chel[n].GetSpeciality() == "футболист")
                            {
                                Footballer temp = (Footballer)chel[n];
                                temp.Print += PositiveConsoleOutput;
                                temp.ShootTraining();
                                temp.Print -= PositiveConsoleOutput;
                                chel[n] = temp;
                            }
                            else if (chel[n].GetSpeciality() == "теннисист")
                            {
                                Tenniser temp = (Tenniser)chel[n];
                                temp.Print += PositiveConsoleOutput;
                                temp.HitTraining();
                                temp.Print -= PositiveConsoleOutput;
                                chel[n] = temp;
                            }
                            else if (chel[n].GetSpeciality() == "биатлонист")
                            {
                                Biathlete temp = (Biathlete)chel[n];
                                temp.Print += PositiveConsoleOutput;
                                temp.AccuracyTraining();
                                temp.Print -= PositiveConsoleOutput;
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
                                temp.Print += PositiveConsoleOutput;
                                temp.AttackTraining();
                                temp.Print -= PositiveConsoleOutput;
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
                                    if (n == m) throw new Exception("Игра с самим собой невозможна");
                                    else if (chel[m].GetSpeciality() == "теннисист") break;
                                    else Console.WriteLine("Человек не является теннисистом");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                Console.Clear();
                                Tenniser temp = (Tenniser)chel[n];
                                Tenniser opponent = (Tenniser)chel[m];
                                temp.Print += ConsoleOutput;
                                temp.PlayGame(opponent);
                                temp.Print -= ConsoleOutput;
                            }
                            else if (chel[n].GetSpeciality() == "биатлонист")
                            {
                                Biathlete temp = (Biathlete)chel[n];
                                temp.Print += PositiveConsoleOutput;
                                temp.HaveARound();
                                temp.Print -= PositiveConsoleOutput;
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
                                temp.Print += PositiveConsoleOutput;
                                temp.DefenceTraining();
                                temp.Print -= PositiveConsoleOutput;
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
                                temp.Print += ConsoleOutput;
                                temp.RoleAnalysis();
                                temp.Print -= ConsoleOutput;
                            }
                            else return;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            return;
                    }
                    chel[n].Print -= PositiveConsoleOutput;
                } while (switcher != 1 && switcher != 2);
            }
        }
    }
}
