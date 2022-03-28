using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class Batiment
    {
        public int[] Size { get; } // size in a tab, Size[0] is the height, Size[1] is the width
        public int[] Coordinate { get; } //coordinate x and y
        private bool State { get; set; } //bat is impossible to use because of a degradation
        protected int Level { get; set; }
        protected int CapacityMax { get; }
        protected int HealthMax { get; set; }
        protected int Health { get; set; }
        public Batiment(int[] size, int[] coordinate, bool state, int level)
        {
            Coordinate = coordinate;
            State = state;
            Level = level;
            Size = size;
            //_state = true; //by default the batiment is functional at its creation
            Level = 1;
        }
        private void ExtendBat(BaseMap M)
        {
            for (int i = 0; i < this.Size[0]; i++) 
            {
                for (int j = 0; j < this.Size[1]; j++)
                {
                    M.Mat[this.Coordinate[0] + i, this.Coordinate[1] + j] = this;
                }
            }
        }
        protected abstract void GenerateStat();

        protected abstract Batiment GenerateBatiment(int n, int[] tab, bool b, int p);

        protected virtual String AfficheStatBatiment(int n, int[] tab, bool b, int p)
        {
            string chRes = "";
            chRes += " # " /*\n####"*/;
            return chRes;
        }
    }
}
