// c:/Users/danie/Desktop/Škola - kódy/OONV/Practical/Practical_3/Cviceni_3/Program.cs
namespace Shitty_RPG
{
    class Program
    {
        static void Main()
        {   inicializuj();
            Hero Aragorn = new Hero("Aragorn", 100, 100, 20, 15, 5, 0, 10, 15, 2);//HP_max, HP_current, Atk, Dv, Level, EXP, initiative, Dv_current, Regen
            Enemy Orc_Grunt = new Enemy("Orc Grunt", 50, 50, 10, 5, 25, 8, 5, 5);
            Battle battle = new Battle(Aragorn, Orc_Grunt);
            battle.Single_battle(Aragorn, Orc_Grunt);
        }
    }

}