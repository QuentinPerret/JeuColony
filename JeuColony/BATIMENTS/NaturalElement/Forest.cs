using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    class Forest : NaturalElement
    {
        public Forest(MapGame Map) : base(Map)
        {
            BatimentType = "Forest";
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
        public void GetHarvast(Ally P)
         {
            NbRessouces -= P.LoggingPower;
            MapGame.Simulation.PlayerInventory.NbWood += P.LoggingPower;
            TestExistence();
        }
    }
}
