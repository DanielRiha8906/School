namespace Shitty_RPG
{
    class Battle
    {
        public Hero Hero { set; get; }
        public Enemy Enemy { set; get; }
        public Battle(Hero hero, Enemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
        }
        public void Squad_battle(Hero Hero, Enemy Enemy)
        {
            Console.WriteLine("No clue what to do here, TBD");
        }
        public void Single_battle(Hero hero, Enemy enemy)
        {
            if (hero.Initiative > enemy.Initiative)
            {
                while (hero.HP_current > 0 && enemy.HP_current > 0)
                {
                    Console.WriteLine("Another round starts");
                    hero.Turn(hero, enemy);
                    if (hero.HP_current <= 0 || enemy.HP_current <= 0)
                    {
                        Console.WriteLine("Problem je v ifu numero uno");
                        break;
                    }
                    enemy.Turn(enemy, hero);
                    if (hero.HP_current <= 0 || enemy.HP_current <= 0)
                    {
                        break;
                    }
                    hero.Reset_after_turn();
                    enemy.Reset_after_turn();
                    Console.WriteLine("Another round ends");
                }
            }
            if (enemy.Initiative > hero.Initiative)
            {
                while (hero.HP_current > 0 && enemy.HP_current > 0)
                {
                    enemy.Turn(enemy, hero);
                    if (hero.HP_current <= 0 || enemy.HP_current <= 0)
                    {
                        break;
                    }
                    hero.Turn(hero, enemy);
                    hero.Reset_after_turn();
                    enemy.Reset_after_turn();
                    Console.WriteLine("Another round ends");
                }
            }
        }
    }
}