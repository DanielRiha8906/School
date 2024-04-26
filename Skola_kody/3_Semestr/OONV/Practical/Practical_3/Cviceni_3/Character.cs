namespace Shitty_RPG
{
    class Character
    {
        public int Regen { set; get; }
        public int HP_current { set; get; }
        public int HP_max { set; get; }
        public int ATK { set; get; }
        public int DV { set; get; }
        public string Name = "Bob";
        public Character(string name, int Hp_max, int Hp_current, int Atk, int Dv)
        {
            this.Name = name;
            this.HP_max = Hp_max;
            this.HP_current = Hp_current;
            this.ATK = Atk;
            this.DV = Dv;

        }
        protected void Attack(Character defender)
        {
            defender.Gethit(this.ATK);
        }
        public void Gethit(int damage)
        {
            this.HP_current = this.HP_current - (damage - this.DV);
        }
    }
}