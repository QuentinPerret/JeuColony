namespace JeuColony.Batiments
{
    class Cantina : Batiment
    {
        public Cantina(int[] size, GameSimulation M) : base(size, M)
        {
            HealthPointMax = 500;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Cantina(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
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
