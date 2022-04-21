namespace JeuColony.Batiments
{
    class Dormitory : Construction
    {
        public int Capacity { get; set; }
        public int PlaceLeft { get; set; }
        public Dormitory(MapGame Map) : base(Map)
        {
            TimeLeftToConstruct = 3;
            Size = new int[] { 2, 3 };
            Capacity = 4;
            PlaceLeft = 4;
            BatimentType = "Dormitory";
            GeneratePositionAlea();
        }
        public Dormitory(int[] coordinate ,int[] size, MapGame Map) : base(coordinate, Map)
        {
            Map.Simulation.PlayerInventory.NbStone -= 5;
            Map.Simulation.PlayerInventory.NbWood -= 5;
            TimeLeftToConstruct = 4;
            Size = size;
            Capacity = 4;
            BatimentType = "Dormitory";
            GeneratePosition(coordinate);
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
