using System;
using System.Collections.Generic;

namespace lab8
{
    public enum Gender : int
    {
        Male = 1,
        Female,
    }

    public enum Nation : int
    {
        BY = 1,
        RU,
        US,
        UA,
        DE,
        GB,
        PL,
        ES,
        TR,
    }
    
    public struct Physical
    {
        public int weight;
        public int height;
        public int stamina;
        public int speed;
    }

    public abstract class Athlete : IHuman, ISport
    {
        public delegate void OutputHandler(string message);
        public event OutputHandler Print;
        public delegate void NameHandler();
        static public event NameHandler ChangeSurnameEvent;
        static public event NameHandler ChangeFullNameEvent;
        static public int amount = 0;
        protected Physical Physics;
        private int sex;
        private int nationality;
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

        public string Nationality
        {
            get
            {
                if (sex != 2)
                {
                    switch (nationality)
                    {
                        case (int)Nation.BY: return "белорус";
                        case (int)Nation.DE: return "немец";
                        case (int)Nation.ES: return "испанец";
                        case (int)Nation.RU: return "русский";
                        case (int)Nation.TR: return "турок";
                        case (int)Nation.PL: return "поляк";
                        case (int)Nation.UA: return "украинец";
                        case (int)Nation.US: return "амереканец";
                        case (int)Nation.GB: return "британец";
                        default: return "неизвестно";
                    }
                }
                else
                {
                    switch (nationality)
                    {
                        case (int)Nation.BY: return "белоруска";
                        case (int)Nation.DE: return "немка";
                        case (int)Nation.ES: return "испанка";
                        case (int)Nation.RU: return "русская";
                        case (int)Nation.TR: return "турчанка";
                        case (int)Nation.PL: return "полячка";
                        case (int)Nation.UA: return "украинка";
                        case (int)Nation.US: return "амереканка";
                        case (int)Nation.GB: return "британка";
                        default: return "неизвестно";
                    }
                }
            }
            set
            {
                nationality = Convert.ToInt32(value);
            }
        }

        public Athlete(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina, int speed)
        {
            amount += 1;
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
            ChangeSurnameEvent?.Invoke();
        }

        public void ChangeName(string surname, string name)
        {
            Surname = surname;
            Name = name;
            ChangeFullNameEvent?.Invoke();
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

        public abstract void GetInfo();

        public abstract string GetSpeciality();

        public void WeightCheck()
        {
            double IMT = Physics.weight / Math.Pow(Physics.height, 2) * 10000;
            IMT = Math.Round(IMT, 2);
            Print?.Invoke($"Ваш ИМТ составляет {IMT}");
            if (IMT < 19) Print?.Invoke("Вам следут потолстеть");
            else if (IMT >= 19 && IMT <= 25) Print?.Invoke("Ваш вес в норме");
            else if (IMT > 25) Print?.Invoke("Вам следут похудеть");
        }

        public void MinusWeight(int tries)
        {
            Random rnd = new Random();
            int cweight = rnd.Next(0, tries / 10);
            Print?.Invoke($"Вы смогли похудеть на {cweight} кг");
            if (cweight > Physics.weight) throw new Exception("Вес не может быть отрицательным");
            Physics.weight = Physics.weight - cweight;
        }

        public void PlusWeight(int food)
        {
            Random rnd = new Random();
            int cweight = rnd.Next(0, food / 2);
            Print?.Invoke($"Вы смогли потолстеть на {cweight} кг");
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
            Print?.Invoke($"Изменение характеристик: вес -{cweight}, скорость +{cspeed}, выносливость +{cstamina}");
        }
    }
}
