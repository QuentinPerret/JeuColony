﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract
{
    class Cantina:MainClass.CityBatiment
    {
        public Cantina(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            HealthMax = 500;
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax *9* Level;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Cantina C = new Cantina(n, tab, b, p);
            return C;
        }
    }
}