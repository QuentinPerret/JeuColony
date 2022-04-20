namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp( MapGame Map) : base(Map)
        {
            Size = new int[] { 3, 3 };
            BatimentType = "Training Camp";
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
    }
}
