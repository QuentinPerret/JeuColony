namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        public Forest(int[] size, MapGame Map) : base(size, Map) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
        public override string PageBat()
        {
            return "Batiment Type : Forest \n" + base.PageBat();
        }
    }
}
