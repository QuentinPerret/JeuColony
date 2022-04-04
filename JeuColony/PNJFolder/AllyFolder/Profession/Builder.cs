﻿using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Builder : Ally
    {
        public Builder(string name, Dormitory D) : base(name, D) { Profession = "Builder"; }
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
    }
}