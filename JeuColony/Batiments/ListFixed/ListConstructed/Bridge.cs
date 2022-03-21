using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListConstructed
{
    class Bridge:ConstructedBatiment
    {
        public Bridge(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state)
        {

        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 2* Level;
        }
        protected override void Construct()
        {

        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Bridge B = new Bridge(n, tab, b, p);
            return B;
        }
    }
}
