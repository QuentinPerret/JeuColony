namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp(int[] size, bool state, GameSimulation M) : base(size, M)
        {
            HealthPointMax = 200;
            BatimentType = "Training Camp";
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
        }
    }
}
