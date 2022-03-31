namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        public NaturalElement(int[] size, bool state, GameSimulation M) : base(size, M) { }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
        }

    }
}
