namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        public Forest(int[] size, bool state, GameSimulation M) : base(size, state, M) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
    }
}
