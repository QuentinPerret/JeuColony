using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JeuColony.Batiments;

namespace JeuColony.PNJFolder
{
    class Soldier : Ally
    {
        public Soldier(Dormitory D, MapGame M) : base(D, M)
        {
            Profession = "Soldier";
            M.Simulation.PlayerInventory.NbStone -= 2;
            M.Simulation.PlayerInventory.NbWood -= 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 30;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 4;
        }
        protected Enemy MostNearEnemy(List<Enemy> list)
        {
            try
            {
                int iRes = 0;
                double distMin = int.MaxValue;
                for (int i = 0; i < list.Count; i++)
                {
                    Enemy E = list[i];
                    if (HowFarFrom(E.Coordinate) < distMin)
                    {
                        distMin = HowFarFrom(E.Coordinate);
                        iRes = i;
                    }

                }
                return list[iRes];
            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        protected override List<Batiment> CreateListBat()
        {
            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (!((B is Dormitory) || (B is Water)))
                {
                    list.Add(B);
                }
            }
            return list;
        }
        protected override void ExecuteAction(object O) { }
        public override void PlayOneTurn()
        {
            Enemy E = MostNearEnemy(MapGame.ListPNJEnemy);
            if (!Immobilized && E !=null)
            {
                if ((Coordinate[0], Coordinate[1]) == (E.Coordinate[0], E.Coordinate[1]))
                {
                    ExecuteAction(E);
                }
                else
                {
                    MoveTo(E.Coordinate);
                }
            }
            TestDeath();
        }
    }
}
