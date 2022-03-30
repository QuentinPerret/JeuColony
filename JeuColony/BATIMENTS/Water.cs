namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        public Water(int[] size, bool state, GameSimulation M) : base(size, state, M) { }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W ";
            return chRes;
        }
    }
}
