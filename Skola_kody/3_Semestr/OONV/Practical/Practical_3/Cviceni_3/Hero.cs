using System.Security.Cryptography.X509Certificates;
namespace Shitty_RPG
{
    class Hero : Character
    {
        public int Initiative { set; get; }
        public int LEVEL { set; get; }
        public int DV_current { set; get; }
        public int EXP { set; get; }
        public Hero(string name, int HP_max, int HP_current, int ATK, int Dv,
        int Level, int EXP, int initiative, int Dv_current, int Regen) : base(name, HP_max, HP_current, ATK, Dv)
        {
            this.Regen = (HP_current * 10) / 100;
            this.Initiative = initiative;
            this.DV_current = Dv_current;
            this.LEVEL = Level;
            this.EXP = EXP;
        }
        public void Reset_after_turn()
        {
            this.DV_current = this.DV;
        }
        public void Death()
        {
            Console.WriteLine("This Hero has died, Would you like to restart?");

        }
        public void Get_hp()
        {
            Console.WriteLine(HP_current);
        }
        
        public void Get_hit(int damage)
        {
            if (this.DV_current >= damage)
            {
                Console.WriteLine("Ding, this dealt 0 damage");
            }
            else
            {
                Console.WriteLine("You got hit for " + (damage) + " damage");
                this.HP_current += (this.DV_current - damage);
            }
            if (this.HP_current <= 0)
            {
                this.Death();

            }
        }
        public void Defend()
        {
            this.DV_current = Math.Max(this.DV, 0) * 2;
            Console.WriteLine("You are defending");
        }
        public void Attack(Enemy defender)
        {
            Console.WriteLine($"Haha, defend yourslef {defender.Name}");
            defender.Get_hit(this.ATK);
        }
        public void Regenerate()
        {
            if (this.HP_max > this.HP_current + this.Regen)
            {
                this.HP_current += this.Regen;
            }
            else
            {
                HP_current = HP_max;
            }
        }

        public void Turn(Hero hero, Enemy enemy)
        {
            Console.WriteLine("What Would you like to do? Would you Like to ATTACK(0), DEFEND(1), REGENERATE(2), USE SPECIAL ABILITY(3), ");
            switch (Console.ReadLine())
            {
                case "0":
                    this.Attack(enemy);
                    break;
                case "1":
                    this.Defend();
                    break;
                case "2":
                    this.Regenerate();
                    break;
                default:
                    Console.WriteLine("By choosing an invalid option, you have forfeited your turn");
                    break;

            }
        }
    }
}

