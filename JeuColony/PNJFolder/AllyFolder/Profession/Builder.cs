using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Builder : Ally
    {
        public Builder(Dormitory D, MapGame M) : base(D, M)
        {
            Profession = "Builder";
            M.Simulation.PlayerInventory.NbStone -= 1;
            M.Simulation.PlayerInventory.NbWood -= 1;
        }
        protected override void GenerateBuildingPower()
        {
            BuildingPower = 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3;
        }
        protected override List<Batiment> CreateListEnemy()
        {
            List<Batiment> list = new List<Batiment>();
            foreach(Batiment B in MapGame.ListBatiments)
            {
                if (B is Dormitory D)
                {
                    list.Add(D);
                }
            }
            return list;
        }
        protected override void ExecuteAction(object O)
        {
            
        }
    }
}
