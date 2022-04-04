namespace JeuColony.Batiments
{
    class Mountain : NaturalElement
    {
        public Mountain(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        public Mountain(int[] size, MapGame Map) : base(size, Map) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
        public override string PageBat()
        {
            return "Batiment Type : Mountain \n" + base.PageBat();
        }
    }
}
