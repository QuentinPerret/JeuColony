﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListInteract
{
    class Cantina:MainClass.CityBatiment
    {
        public Cantina(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            HealthMax = 500;
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        private override void GenerateStat()
        {
            Health = HealthMax * Level;
        }
    }
}