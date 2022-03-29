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
        BaseMap M;
        public Batiment(int[] size, bool state, int level, BaseMap M)
        {
            GeneratePosition(M);
            State = state;
            Level = level;
            Size = size;
            //_state = true; //by default the batiment is functional at its creation
            Level = 1;
        }
        private void GeneratePosition(BaseMap M)
        {
            Random R = new Random();
            while(PositionClear(M))
            {
                Coordinate[0] = R.Next(0, M.Nbl - Size[1] - 1); // Génération aléatoire de la position en x
                Coordinate[1] = R.Next(0, M.Nbc - Size[0] - 1); // Génération aléatoire de la position en y
            }
            ExtendBat(M);
        }
        
        private bool PositionClear(BaseMap M)
        {
            for (int i = 0; i < this.Size[0]; i++)
            {
                for (int j = 0; j < this.Size[1]; j++)
                {
                    if(M.Mat[i,j] != null && M.Mat[i,j] is Batiment)
                    {
                        return true;
                    }
                }
            }
            return false;
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

        protected virtual String AfficheStatBatiment(int n, int[] tab, bool b, int p)
        {
            string chRes = "";
            chRes += " # " /*\n####"*/;
            return chRes;
        }
    }
}
