using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.List_Interact
{
    class Dormitory:MainClass.CityBatiment
    {
        public Dormitory(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
    }
}
