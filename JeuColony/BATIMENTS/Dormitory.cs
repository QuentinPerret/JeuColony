using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class Dormitory:Batiment
    {
        public Dormitory(int[] size, bool state,BaseMap M) : base(size,  state, M)
        {
            HealthMax = 100;
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public Dormitory(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size,coordinate, state, Map) { }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5*Level;
        }
        public override string ToString()
        {
            return " D ";
        }
    }
}
