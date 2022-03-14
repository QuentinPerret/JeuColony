using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS
{
    abstract class Batiment
    {
        private double[] Size{ get; } // size in a tab, much easier to compare with other tabs of x and y
        private int[] Coordinate { get; } //coordinate x and y
        private bool State { get; set; } //bat is impossible to use because of a degradation
        protected int Level { get; set; }
        public Batiment(double[] size, int[] coordinate, bool state, int level)
        {
            Coordinate = coordinate;
            State = state;
            Level = level;
            Size = size;
            //_state = true; //by default the batiment is functional at its creation
            Level = 1;
        }

        protected abstract void GenerateStat();
       
    }
}
