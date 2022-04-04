namespace JeuColony.Batiments
{
    class Dormitory : Batiment
    {
        public Dormitory(int[] size, GameSimulation M) : base(size, M)
        {
            HealthPointMax = 100;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Dormitory(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
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
