using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Digger : Ally
    {
        public Digger(Dormitory D, MapGame M) : base(D,M) { Profession = "Digger"; }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 2;
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
            foreach (Batiment B in Map.ListBatiments)
            {
                if (B is Mountain M)
                {
                    list.Add(M);
                }
            }
            return list;
        }
        protected override void ExecuteAction()
        {
            Mountain M = (Mountain)Map.Map[Coordinate[0], Coordinate[1]];
            M.GetHarvast(this);
        }
    }
}
