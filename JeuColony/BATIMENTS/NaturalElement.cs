namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        public NaturalElement(int[] size, int[] coordinate, GameSimulation Map) : base(size, coordinate, Map) { }
        public NaturalElement(int[] size, GameSimulation M) : base(size, M) { }

    }
}
