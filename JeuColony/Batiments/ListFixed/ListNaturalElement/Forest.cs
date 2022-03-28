﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListNaturalElement
{
    class Forest:NaturalElement
    {
        public Forest(int size, int[] coordinate, bool state) : base(size, coordinate, state)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }

        protected override void Remove()
        {
           
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Forest F = new Forest(n, tab, b);
            return F;
        }
        public override String AfficheBatiment()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " Ce batiment est une forêt, "+base.ToString() ;
            return chRes;
        }
    }
}
