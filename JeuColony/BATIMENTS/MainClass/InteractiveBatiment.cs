using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class InteractiveBatiment:Batiment
    {
        private bool _activity;
        
        public InteractiveBatiment(int size, int[] coordinate, bool state, int level) : base(size, coordinate,state,level)
        {
            _activity = false;
        }

        public static void Isused()
        {
            /*if (_activity)
                _activity=false;
            else
                _activity = true;*/
        }
    }
}
