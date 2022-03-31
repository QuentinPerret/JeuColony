﻿using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Builder : Ally
    {
        public Builder(string name, Dormitory D) : base(name, D) { }
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
        public override string PagePNJ()
        {
            return base.PagePNJ() + "Profession : Builder";
        }

    }
}
