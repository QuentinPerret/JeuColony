﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class TrainingCamp : MainClass.CityBatiment
    {
        public TrainingCamp(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            HealthMax = 200;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5*Level;
        }
        public override String AfficheBatiment()
        {
            string chRes = "";
            chRes += " T " /*\n####"*/;
            return chRes;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            TrainingCamp T = new TrainingCamp(n, tab, b, p);
            return T;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " Ce batiment est une dortoir, " + base.ToString();
            return chRes;
        }
    }
    
    
}
