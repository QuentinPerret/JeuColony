using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class TrainingCamp : MainClass.CityBatiment
    {
        public TrainingCamp(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            HealthMax = 200;
            //GenerateBatiment(size, coordinate, state, 1);
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
