using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Digger : Ally
    {
        public Digger(Dormitory D, MapGame M) : base(D, M)
        {
            Profession = "Digger";
            M.Simulation.PlayerInventory.NbStone -= 2;
            M.Simulation.PlayerInventory.NbWood -= 1;
        }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25;
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
                if (B is Quarry M)
                {
                    list.Add(M);
                }
            }
            return list;
        }
        protected override void ExecuteAction(object O)
        {
            Batiment B = O as Batiment;
            if (B is Quarry Q) { Q.GetHarvast(this); }
        }
    }
}
