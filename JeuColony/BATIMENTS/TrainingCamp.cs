namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp(int[] size, int[] coordinate,  MapGame Map) : base(size, coordinate, Map) { BatimentType = "Training Camp"; }
        public TrainingCamp(int[] size, MapGame Map) : base(size, Map)
        {
            HealthPointMax = 200;
            BatimentType = "Training Camp";
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
    }
}
