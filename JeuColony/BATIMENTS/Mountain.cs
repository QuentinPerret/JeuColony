namespace JeuColony.Batiments
{
    class Mountain : NaturalElement
    {
        public Mountain(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        public Mountain(int[] size, GameSimulation M) : base(size, M) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
    }
}
