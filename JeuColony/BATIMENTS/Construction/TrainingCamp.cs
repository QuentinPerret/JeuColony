namespace JeuColony.Batiments
{
    class TrainingCamp : Construction
    {
        public TrainingCamp( int[] coordinate,MapGame Map) : base(coordinate,Map)
        {
            Map.Simulation.PlayerInventory.NbStone -= 10;
            Map.Simulation.PlayerInventory.NbWood -= 10;
            TimeLeftToConstruct = 5;
            Size = new int[] { 3, 3 };
            BatimentType = "Training Camp";
            GeneratePosition(coordinate);
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
