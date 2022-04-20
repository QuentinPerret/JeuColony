namespace JeuColony.Batiments
{
    class Hospital : Batiment
    {
        public Hospital(MapGame Map) : base(Map)
        {
            TimeLeftToConstruct = 5;
            Size = new int[] { 4, 2 };
            BatimentType = "Hostital";
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
