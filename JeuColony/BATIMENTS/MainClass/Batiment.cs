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
        private bool _state { get; set; } //bat is impossible to use beacause of a degradation
        protected int _level { get; set; }
        public Batiment(double[] size, int[] coordinate, bool state, int level)
        {
            Coordinate = coordinate;
            _state = state;
            _level = level;
            Size = size;
            _state = true; //by default the batiment is functional at its creation
            _level = 1;
        }
    }
}
