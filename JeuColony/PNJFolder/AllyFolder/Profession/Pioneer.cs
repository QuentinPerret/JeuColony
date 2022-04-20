using JeuColony.Batiments;
using System.Collections.Generic;
namespace JeuColony.PNJFolder
{
    class Pioneer : Ally
    {
        public Pioneer(Dormitory D, MapGame M) : base(D, M) { Profession = "Pioneer"; }
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
        protected override List<Batiment> CreateListBatiment()
        {
            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (!(B is Dormitory))
                {
                    list.Add(B);
                }
            }
            return list;
        }
        protected override void ExecuteAction()
        {
            Batiment B = (Batiment)MapGame.Map[Coordinate[0], Coordinate[1]];
            if(B is Mountain M)
            {
                M.GetHarvast(this); 
            }
            if(B is Forest F)
            {
                F.GetHarvast(this);
            }
        }
    }
}
