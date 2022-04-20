using JeuColony.Batiments;
using System.Collections.Generic;
namespace JeuColony.PNJFolder
{
    class Pioneer : Ally
    {
        public Pioneer(Dormitory D, MapGame M) : base(D, M)
        {
            Profession = "Pioneer";
            M.Simulation.PlayerInventory.NbStone -= 1;
            M.Simulation.PlayerInventory.NbWood -= 1;
        }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 1;
        }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 1;
        }
        protected override void GenerateBuildingPower()
        {
            BuildingPower = 1;
        }
        protected override List<Batiment> CreateListBat()
        {
            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (!((B is Dormitory)||(B is Water)))
                {
                    list.Add(B);
                }
            }
            return list;
        }
        protected override void ExecuteAction(object O)
        {
            Batiment B  = O as Batiment;
            if(B is Quarry Q)
            {
                Q.GetHarvast(this); 
            }
            if(B is Forest F)
            {
                F.GetHarvast(this);
            }
        }
    }
}
