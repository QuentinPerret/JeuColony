using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.List_Interact
{
    class Cantina:MainClass.CityBatiment
    {
        public Cantina(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
    }
}
