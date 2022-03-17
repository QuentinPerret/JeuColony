using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListInteract
{
    class Dormitory:MainClass.CityBatiment
    {
        public Dormitory(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            HealthMax = 100;
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5*Level;
        }
    }
}
