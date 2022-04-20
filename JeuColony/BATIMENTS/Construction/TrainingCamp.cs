namespace JeuColony.Batiments
{
    class TrainingCamp : Construction
    {
        public TrainingCamp( MapGame Map) : base(Map)
        {
            TimeLeftToConstruct = 5;
            Size = new int[] { 3, 3 };
            BatimentType = "Training Camp";
            GeneratePositionAlea();
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        public override string ToString()
        {
            return " T ";
        }
    }
}
