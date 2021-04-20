using System;

namespace lab6
{
    public class Tenniser : Athlete
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
}
