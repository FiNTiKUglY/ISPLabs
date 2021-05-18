using System;

namespace lab8
{
    public class Biathlete : Athlete
    {
        public new event OutputHandler Print;
        public int Accuracy { get; set; }

        public int MoveBalance { get; set; }

        public Biathlete(string name, string surname, int age, string sex, string nationality, int weight, int height, int stamina,
                 int speed, int accuracy, int moveBalance) : base(name, surname, age, sex, nationality, weight, height, stamina, speed)
        {
            Accuracy = accuracy;
            MoveBalance = moveBalance;
        }

        public override void SmallInfo() => Console.WriteLine($"{ID}. Биатлонист {Surname} {Name}");

        public override void GetInfo()
        {
            Console.WriteLine($"Биатлонист {Surname} {Name}, {Age} лет, {Sex}, {Nationality}, Рост: {Physics.height}, Вес: {Physics.weight}");
            Console.WriteLine($"Характеристики: точность {Accuracy}, равновесие на лыжах {MoveBalance}, выносливость {Physics.stamina}, скорость {Physics.speed}");
        }

        public void AccuracyTraining()
        {
            Random rnd = new Random();
            int cacc = rnd.Next(0, 2);
            Print?.Invoke($"Характеристики: точность стрельбы +{cacc}");
            Accuracy = Accuracy + cacc;
        }

        public void HaveARound()
        {
            Random rnd = new Random();
            int cspeed = rnd.Next(0, 2);
            int cbalance = rnd.Next(0, 2);
            Print?.Invoke($"Характеристики: равновесие на лыжах +{cbalance}, скорость +{cspeed}");
            MoveBalance = MoveBalance + cbalance;
            Physics.speed = Physics.speed + cspeed;
        }

        public override string GetSpeciality() => "биатлонист";
    }
}
