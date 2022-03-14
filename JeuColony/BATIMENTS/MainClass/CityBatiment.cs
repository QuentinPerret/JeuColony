﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.MainClass
{
    abstract class CityBatiment:InteractiveBatiment
    {
        protected int CapacityMax { get; }
        protected int HealthMax { get; set;}
        protected int Health { get; set;}
        public CityBatiment(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
        }
        protected abstract int GenerateCapaMax(int level);
    }
}