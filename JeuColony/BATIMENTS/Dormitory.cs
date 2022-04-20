namespace JeuColony.Batiments
{
    class Dormitory : Batiment
    {
        public int Capacity { get; set; }
        public Dormitory(int[] size, MapGame Map) : base(size, Map)
        {
            Capacity = 4;
            HealthPointMax = 100;
            BatimentType = "Dormitory";
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Dormitory(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map)
        {
            BatimentType = "Dormitory";
            HealthPointMax = 100;
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        public override string ToString()
        {
            return " D ";
        }
    }
}
