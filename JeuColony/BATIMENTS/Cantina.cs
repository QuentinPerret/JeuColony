namespace JeuColony.Batiments
{
    class Cantina : Batiment
    {
        public Cantina(int[] size, MapGame Map) : base(size, Map)
        {
            HealthPointMax = 500;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Cantina(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        public override string ToString()
        {
            return " C ";
        }
    }
}
