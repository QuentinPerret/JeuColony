namespace JeuColony.Batiments
{
    class Mountain : NaturalElement
    {
        public Mountain(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        public Mountain(int[] size, GameSimulation M) : base(size, M) { }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
    }
}
