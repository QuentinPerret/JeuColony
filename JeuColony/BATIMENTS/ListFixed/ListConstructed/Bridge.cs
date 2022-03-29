using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListConstructed
{
    class Bridge:ConstructedBatiment
    {
        public Bridge(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 2* Level;
        }
        protected override void Construct()
        {

        }
    }
}
