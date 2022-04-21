namespace JeuColony.Batiments
{
    class TrainingCamp : Construction
    {
        public TrainingCamp( int[] coordinate,MapGame Map) : base(Map)
        {
            Map.Simulation.PlayerInventory.NbStone -= 10;
            Map.Simulation.PlayerInventory.NbWood -= 10;
            TimeLeftToConstruct = 5;
            Size = new int[] { 3, 3 };
            BatimentType = "Training Camp";
            GeneratePosition(coordinate);
        }
        public override string ToString()
        {
            return " T ";
        }
    }
}
