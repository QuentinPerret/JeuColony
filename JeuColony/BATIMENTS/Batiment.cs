using System;
using System.Collections.Generic;
using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    abstract class Batiment
    {
        public int[] Size { get; set; } = new int[] { -1, -1 }; // size in a tab, Size[0] is the height, Size[1] is the width
        public int[] Coordinate { get; protected set; } = new int[] { -1, -1 };//coordinate x and y
        public string BatimentType { get; set; }
        public int TimeLeftToConstruct { get; set; }
        protected readonly MapGame MapGame;
        protected static readonly Random random = new Random();
        public static int GetSomeRandomNumber(int max)
        {
            return random.Next(max);
        }
        public Batiment(int[] coordinate, MapGame Map)
        {
            MapGame = Map;
        }
        public Batiment(MapGame Map)
        {
            MapGame = Map;
        }
        public void ReverseSize()
        {
            (Size[0], Size[1]) = (Size[1], Size[0]);
        }
        protected void GeneratePositionAlea()
        {
            if (GetSomeRandomNumber(2) == 0)
            {
                ReverseSize();
            }
            while (!PositionClear(MapGame))
            {
                Coordinate[0] = GetSomeRandomNumber(MapGame.Nbl - Size[1] - 1); // Génération aléatoire de la position en x
                Coordinate[1] = GetSomeRandomNumber(MapGame.Nbc - Size[0] - 1); // Génération aléatoire de la position en y
            }
            ExtendBat(MapGame);
        }
        protected void GeneratePosition(int[] coordinate)
        {
            Coordinate = coordinate;
            ExtendBat(MapGame);
            //else { GeneratePositionAlea(); }
        }
        private bool PositionClear(MapGame M)
        {
            for (int i = 0; i < this.Size[0]; i++)
            {
                for (int j = 0; j < this.Size[1]; j++)
                {
                    try
                    {
                        if (M.Map[Coordinate[0] + i, Coordinate[1] + j] is Batiment)
                        {
                            return false;
                        }
                    }
                    catch (IndexOutOfRangeException) { return false; }
                }
            }
            return true;
        }
        private void ExtendBat(MapGame M)
        {
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    M.Map[Coordinate[0] + i, Coordinate[1] + j] = this;
                }
            }
        }

        protected virtual string AfficheStatBatiment(int n, int[] tab, bool b, int p)
        {
            string chRes = "";
            chRes += " # " /*\n####"*/;
            return chRes;
        }
        public virtual string PageBat()
        {
            string chres ="";
            chres += "Batiment Type : " + BatimentType + "\n";
            chres += "Position : " + Coordinate[0] + " , " + Coordinate[1] + "\n";
            return chres;
        }
        
    }
}
