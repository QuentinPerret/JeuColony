using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map) { BatimentType = "Forest"; }
        public Forest(int[] size, MapGame Map) : base(size, Map) { BatimentType = "Forest"; }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
        public void GetHarvast(Ally P)
        {
            HealthPoint -= P.LoggingPower;
        }
    }
}
