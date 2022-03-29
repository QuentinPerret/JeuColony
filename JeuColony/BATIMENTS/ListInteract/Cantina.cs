using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract
{
    class Cantina:MainClass.CityBatiment
    {
        public Cantina(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            HealthMax = 500;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax *9* Level;
        }
    }
}
