namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(MapGame Map) : base(Map) { BatimentType = "Water"; }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W ";
            return chRes;
        }
    }
}
