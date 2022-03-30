namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        public TrainingCamp(int[] size, bool state, GameSimulation M) : base(size, state, M)
        {
            HealthMax = 200;
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
    }


}
