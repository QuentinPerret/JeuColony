using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS
{
    class TrainingCamp : MainClass.CityBatiment
    {
        public TrainingCamp(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
    }
    
    
}
