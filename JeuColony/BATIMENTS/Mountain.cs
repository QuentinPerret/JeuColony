using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    class Mountain : NaturalElement
    {
        public Mountain(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { BatimentType = "Mountain"; }
        public Mountain(int[] size, MapGame Map) : base(size, Map) { BatimentType = "Mountain"; }
        public override string ToString()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
        public void GetHarvast(Ally P)
        {
            HealthPoint -= P.DiggingPower;
        }
    }
}
