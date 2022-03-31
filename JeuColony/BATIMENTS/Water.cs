namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(int[] size, bool state, GameSimulation M) : base(size, state, M) { BatimentType = "Water"; }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W ";
            return chRes;
        }
    }
}
