using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Builder : Ally
    {
        public Builder(Dormitory D , MapGame M) : base(D,M) { Profession = "Builder"; }
        protected override void GenerateBuildingPower()
        {
            BuildingPower = 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 2 * Level + 1;
        }
        protected override List<Batiment> CreateListBatiment()
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
