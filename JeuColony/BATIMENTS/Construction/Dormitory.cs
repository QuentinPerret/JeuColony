namespace JeuColony.Batiments
{
    class Dormitory : Construction
    {
        public int Capacity { get; set; }
        public Dormitory(MapGame Map) : base(Map)
        {
            TimeLeftToConstruct = 4;
            Size = new int[] { 2, 3 };
            Capacity = 4;
            BatimentType = "Dormitory";
            GeneratePositionAlea();
        }
        public Dormitory(int[] coord , MapGame Map) : base(coord, Map)
        {
            TimeLeftToConstruct = 4;
            Size = new int[] { 2, 3 };
            Capacity = 4;
            BatimentType = "Dormitory";
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
