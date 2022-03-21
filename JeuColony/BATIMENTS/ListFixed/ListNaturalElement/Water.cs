using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListFixed.ListNaturalElement
{
    class Water:NaturalElement
    {
        public Water(double[] size, int[] coordinate, bool state) : base(size, coordinate, state)
        {

        }
        public Water generateRiver()
        {
            Water river = new Water(new[]{ 5.0,5.0},new[] { 0, 0 },true);
            return river;
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
