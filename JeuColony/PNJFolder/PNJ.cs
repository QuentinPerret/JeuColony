namespace JeuColony.PNJFolder
{
    abstract class PNJ
    {
        public string Name { get; }
        protected int HealthPointMax { get; set; }
        protected int HealthPoint { get; set; }
        protected int AttackPower { get; set; }
        protected int Speed { get; set; }
        protected int Level { get; set; }
        public int[] Coordinate { get; set; }
        public PNJ(string name) : this(name, 1) { }
        public PNJ(string name, int level)
        {
            Name = name;
            Level = level;
        }
        protected abstract void GenerateAllStat();
        protected abstract void GenerateSpeed();
        public override string ToString()
        {
            string chRes = "";
            chRes += " O " /*\n####"*/;
            return chRes;
        }
        public void DealDamage(PNJ Dealer, PNJ Target)
        {
            Target.HealthPoint -= Dealer.AttackPower;
        }
        public virtual string PagePNJ()
        {
            string chres = "";
            chres += "Name : " + Name + "\n";
            chres += "Level : " + Level + "\n";
            chres += "HP : " + HealthPoint + " / " + HealthPointMax + "\n";
            chres += "Position : " + Coordinate[0] + " , " +Coordinate[1] + "\n";
            return chres;
        }
        public void MoveTo(int[] coordinate)
        {
            int moveLeft = Speed;
            for(int i = 0; i < moveLeft; i++)
            {
                if(Coordinate[0] < coordinate[0])
                {
                    Coordinate[0]++;
                }
                else if(Coordinate[0] > coordinate[0])
                {
                    coordinate[0]--;
                }
                if(Coordinate[1] < coordinate[1])
                {
                    Coordinate[1]++;
                }
                else if(coordinate[1] > coordinate[1])
                {
                    Coordinate[1]--;
                }
            }
        }
    }
}
