namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        public NaturalElement(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { }
        public NaturalElement(int[] size, MapGame Map) : base(size, Map) { }

    }
}
