using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class TrainingCamp : Batiment
    {
        public TrainingCamp(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size, coordinate, state, Map) { }
        public TrainingCamp(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            HealthMax = 200;
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5*Level;
        }
    }
    
    
}
