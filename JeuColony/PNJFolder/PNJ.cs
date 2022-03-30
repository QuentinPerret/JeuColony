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
        public string AffichePNJ()
        {
            string chRes = "";
            chRes += " * " /*\n####"*/;
            return chRes;
        }
        protected void DealDamage(PNJ Dealer, PNJ Target)
        {

        }
    }
}
