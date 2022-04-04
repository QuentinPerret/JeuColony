namespace JeuColony.Batiments
{
    class Dormitory : Batiment
    {
        public Dormitory(int[] size, MapGame Map) : base(size, Map)
        {
            HealthPointMax = 100;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Dormitory(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
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
