using System;

namespace lab6
{
    public class Footballer : Athlete
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
        public override void GetInfo()
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
}
