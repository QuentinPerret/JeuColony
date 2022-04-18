namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { BatimentType = "Water"; }
        public Water(int[] size, MapGame Map) : base(size, Map) { BatimentType = "Water"; }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W ";
            return chRes;
        } 
    }
}
