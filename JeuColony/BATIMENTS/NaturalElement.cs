namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        public NaturalElement(int[] size, int[] coordinate, bool state, GameSimulation Map) : base(size, coordinate, state, Map) { }
        public NaturalElement(int[] size, bool state, GameSimulation M) : base(size, state, M) { }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }

    }
}
