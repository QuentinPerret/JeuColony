namespace JeuColony.Batiments
{
    class Cantina : Batiment
    {
        public Cantina(int[] size, bool state, GameSimulation M) : base(size, state, M)
        {
            HealthMax = 500;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Cantina(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 9 * Level;
        }
        public override string ToString()
        {
            return " C ";
        }
        public override string PageBat()
        {
            return "Batiment Type : Cantina \n" + base.PageBat();
        }
    }
}
