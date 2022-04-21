namespace JeuColony.Batiments
{
    class Hospital : Batiment
    {
        public Hospital(int[]coordinate, int[]size ,MapGame Map) : base(coordinate,Map)
        {
            Map.Simulation.PlayerInventory.NbStone -= 20;
            Map.Simulation.PlayerInventory.NbWood -= 20;
            TimeLeftToConstruct = 5;
            Size = size;
            BatimentType = "Hostital";
            GeneratePosition(coordinate);
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        public override string ToString()
        {
            return " H ";
        }
    }
}
