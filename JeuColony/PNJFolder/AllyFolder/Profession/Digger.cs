﻿using JeuColony.Batiments;
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
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (B is Quarry M)
                {
                    list.Add(M);
                }
            }
            return list;
        }
        protected override void ExecuteAction()
        {
            if (MapGame.Map[Coordinate[0], Coordinate[1]] is Quarry Q) { Q.GetHarvast(this); }
        }
    }
}
