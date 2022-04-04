namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp(int[] size, int[] coordinate,  MapGame Map) : base(size, coordinate, Map) { }
        public TrainingCamp(int[] size, MapGame Map) : base(size, Map)
        {
            HealthPointMax = 200;
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        public override string PageBat()
        {
            return "Batiment Type : Training Camp \n" + base.PageBat();
        }
    }
}
