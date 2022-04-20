using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Forester : Ally
    {
        public Forester(Dormitory D, MapGame M) : base(D, M)
        {
            Profession = "Forester";
            M.Simulation.PlayerInventory.NbStone -= 1;
            M.Simulation.PlayerInventory.NbWood -= 2;
        }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 2 ;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25 ;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3;
        }
        protected override List<Batiment> CreateListBat()
        {
            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (B is Forest F)
                {
                    list.Add(F);
                }
            }
            return list;
        }
        protected override void ExecuteAction(object O)
        {
            Batiment B = O as Batiment;

            if (B is Forest F) { F.GetHarvast(this); }
        }
    }
}
