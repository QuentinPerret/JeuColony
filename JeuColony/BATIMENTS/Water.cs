namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        public Water(int[] size, MapGame Map) : base(size, Map) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W ";
            return chRes;
        }
        public override string PageBat()
        {
            return "Batiment Type : Water \n" + base.PageBat();
        }
    }
}
