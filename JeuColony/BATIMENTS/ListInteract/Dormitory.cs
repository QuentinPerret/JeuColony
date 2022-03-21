using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract
{
    class Dormitory:MainClass.CityBatiment
    {
        public Dormitory(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
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
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Dormitory D = new Dormitory(n, tab, b, p);
            return D;
        }
    }
}
