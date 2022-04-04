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
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 9 * Level;
        }
        public override string ToString()
        {
            return " C ";
        }
    }
}
