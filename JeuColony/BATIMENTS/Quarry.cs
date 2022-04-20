using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    class Quarry : NaturalElement
    {
        public Quarry(int[] size, int[] coordinate, MapGame Map) : base(size, coordinate, Map)
        {
            BatimentType = "Mountain";
            HealthPointMax = 50;
            HealthPoint = 50;
        }
        public Quarry(int[] size, MapGame Map) : base(size, Map)
        {
            BatimentType = "Mountain";
            HealthPointMax = 50;
            HealthPoint = 50;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " Q " /*\n####"*/;
            return chRes;
        }
        public void GetHarvast(Ally P)
        {
            HealthPoint -= P.DiggingPower;
            MapGame.Simulation.PlayerInventory.NbStone += P.DiggingPower * 20;
            TestExistence();
        }
    }
}
