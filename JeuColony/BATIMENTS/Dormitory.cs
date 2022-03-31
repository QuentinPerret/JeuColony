namespace JeuColony.Batiments
{
    class Dormitory : Batiment
    {
        public Dormitory(int[] size, bool state, GameSimulation M) : base(size, state, M)
        {
            HealthMax = 100;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Dormitory(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
        public override string ToString()
        {
            return " D ";
        }
        public override string PageBat()
        {
            return "Batiment Type : Dormitory \n" + base.PageBat();
        }
    }
}
