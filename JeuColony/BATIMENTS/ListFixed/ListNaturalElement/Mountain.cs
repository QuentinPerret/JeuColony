using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListFixed.ListNaturalElement
{
    class Mountain:NaturalElement
    {
        public Mountain(int size, int[] coordinate, bool state) : base(size, coordinate, state)
        {

        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }

        protected override void Remove()
        {
            
        }
    }
}
