namespace JeuColony.Batiments
{
    class Water : NaturalElement
    {
        public Water(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        public Water(int[] size, GameSimulation M) : base(size, M) { }
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
        
        public override string PageBat()
        {
            return "Batiment Type : Water \n" + base.PageBat();
        }
    }
}
