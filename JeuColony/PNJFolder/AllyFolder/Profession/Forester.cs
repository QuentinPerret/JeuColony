using JeuColony.Batiments;
using System.Collections.Generic;

namespace JeuColony.PNJFolder
{
    class Forester : Ally
    {
        public Forester (Dormitory D, MapGame M) : base(D,M) { Profession = "Forester"; }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 2 * Level;
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
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (B is Forest F)
                {
                    list.Add(F);
                }
            }
            return list;
        }
        protected override void ExecuteAction()
        {
            Forest F = (Forest)MapGame.Map[Coordinate[0], Coordinate[1]];
            F.GetHarvast(this);
        }
    }
}
