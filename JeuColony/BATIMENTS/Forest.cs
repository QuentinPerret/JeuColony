namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(int[] size, bool state, GameSimulation M) : base(size, state, M) { BatimentType = "Forest"; }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
    }
}
