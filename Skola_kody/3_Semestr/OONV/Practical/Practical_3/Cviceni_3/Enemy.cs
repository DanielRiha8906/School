using System.Diagnostics;
using System.Dynamic;
namespace Shitty_RPG
{
    class Enemy : Character
    {
        public int DV_current { set; get; }
        public int Initiative { set; get; }
        public int EXP_if_slain { set; get; }
        public Enemy(string name, int HP_max, int HP_current, int Atk, int Dv, int Exp_if_slain, int initiative, int Regen, int Dv_current) : base(name, HP_max, HP_current, Atk, Dv)
        {
            this.DV_current = Dv_current;
            this.Initiative = initiative;
        }
        public void Death()
        {
            Console.WriteLine("This Enemy has died");
        }
        public void Reset_after_turn()
        {
            this.DV_current = this.DV;
        }
        public void Get_hit(int damage)
        {
            Console.WriteLine(damage);
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
        public void Attack(Hero defender)
        {
            Console.WriteLine($"Haha, defend yourslef {defender.Name}");
            defender.Get_hit(this.ATK);
        }
        public void Defend()
        {
            this.DV_current = Math.Max(this.DV, 0) * 2;
            Console.WriteLine("The enemy is defending");
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
        public void Get_hp()
        {
            Console.WriteLine(HP_current);
        }
        public void Turn(Enemy enemy, Hero hero)
        {
            Random rand = new Random();
            int randomValue = rand.Next(0, 2);
            switch (randomValue.ToString())
            {
                case "0":
                    this.Attack(hero);
                    break;

                case "1":
                    this.Defend();
                    break;
                case "2":
                    this.Regenerate();
                    break;
                default:
                    Console.WriteLine("Je tu nějaký problém, fix this shit");
                    break;

            }
        }
    }
}