using JeuColony.Batiments;
using System.Collections.Generic;
namespace JeuColony.PNJFolder
{
    class Soldier : Ally
    {
        public Soldier(Dormitory D, MapGame M) : base(D, M) { Profession = "Soldier"; }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 30 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3 * Level;
        }
        protected override List<Batiment> CreateListBatiment()
        {
            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
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
            Enemy E = O as Enemy;
        }
    }
}
