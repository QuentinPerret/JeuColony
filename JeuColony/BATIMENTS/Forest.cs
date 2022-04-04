namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        public Forest(int[] size, GameSimulation M) : base(size, M) { }
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
