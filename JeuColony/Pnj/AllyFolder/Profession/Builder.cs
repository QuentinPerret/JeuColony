﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Builder : Ally
    {
        public Builder(string name,int level) : base(name, level) { }
        protected virtual void GenerateBuildingPower()
        {
            BuildingPower = 2;
        }
        protected virtual void GenerateHealthPointMax()
        {
            HealthPointMax = 25 * Level;
        }
        protected virtual void GenerateAttackPower()
        {
            AttackPower = 2 * Level + 1;
        }
    }
}