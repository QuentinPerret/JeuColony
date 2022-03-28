using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class Batiment
    {
        public int Size{ get; } // size in a tab, much easier to compare with other tabs of x and y
        public int[] Coordinate { get; } //coordinate x and y
        private bool State { get; set; } //bat is impossible to use because of a degradation
        protected int Level { get; set; }
        protected int CapacityMax { get; }
        protected int Occupation { get; }
        protected int HealthMax { get; set; }
        protected int Health { get; set; }
        public Batiment(int size, int[] coordinate, bool state, int level)
        {
            Coordinate = coordinate;
            State = state;
            Level = level;
            Size = size;
            Occupation = 0;
            //_state = true; //by default the batiment is functional at its creation
            Level = 1;
        }

        protected abstract void GenerateStat();

        protected abstract Batiment GenerateBatiment(int n, int[] tab, bool b, int p);

        public abstract String AfficheBatiment();
        
        public override string ToString()
        {
            string chRes = "";
            chRes += "Type :" + this.GetType() + "\t Niveau :" + Level + "\t PV : " + Health + "/" + HealthMax + "\t Occupants :" + Occupation +"/" +CapacityMax;
            return chRes;
        }


    }
}
