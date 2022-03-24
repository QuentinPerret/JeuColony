using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListNaturalElement
{
    class Water:NaturalElement
    {
        public Water(int size, int[] coordinate, bool state) : base(size, coordinate, state)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Water generateRiver()
        {
            Water river = new Water(25,new[] { 0, 0 },true);
            return river;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }

        protected override void Remove()
        {
           
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Water W = new Water(n, tab, b);
            return W;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W " /*\n####"*/;
            return chRes;
        }
    }
}
