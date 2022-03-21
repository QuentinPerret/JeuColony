using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.MainClass
{
    abstract class ProductionBatiment:InteractiveBatiment
    {
        protected int Production { get; set; }
        public ProductionBatiment(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            HealthMax=300; 
        }
        protected abstract int GenerateProduction(int level);
        protected override void GenerateStat()
        {
            Health = HealthMax * Level;
        }

    }
}
