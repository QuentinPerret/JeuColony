using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.MainClass
{
    abstract class DefenseBatiment:InteractiveBatiment
    {
        public DefenseBatiment(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            HealthMax=1000;
        }
        protected abstract int GenerateProtection(int level);
        protected override void GenerateStat()
        {
            Health = HealthMax * Level;
        }

    }
}
