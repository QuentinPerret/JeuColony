using System;
using System.Collections.Generic;
using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    abstract class Batiment
    {
        public int[] Size { get; } = new int[] { -1, -1 }; // size in a tab, Size[0] is the height, Size[1] is the width
        public int[] Coordinate { get; protected set; } = new int[] { -1, -1 };//coordinate x and y
        protected int Level { get; set; }
        protected int CapacityMax { get; }
        protected int HealthPointMax { get; set; }
        protected int HealthPoint { get; set; }
        public List<PNJ> _listPNJ;
        private readonly GameSimulation M;
        private static readonly Random random = new Random();
        public static int GetSomeRandomNumber(int max)
        {
            return random.Next(max);
        }
        public Batiment(int[] size, GameSimulation Map)
        {
            Size = size;
            M = Map;
            Level = 1;
            _listPNJ = new List<PNJ>();
            //_state = true; //by default the batiment is functional at its creation
            GeneratePositionAlea();
        }
        public Batiment(int[] size, int[] coordinate, GameSimulation Map)
        {
            Size = size;
            M = Map;
            Level = 1;
            _listPNJ = new List<PNJ>();
            //_state = true; //by default the batiment is functional at its creation
            GeneratePosition(coordinate);
        }
        public void AddPNJ(PNJ P)
        {
            _listPNJ.Add(P);
        }
        public void RemovePNJ(PNJ P)
        {
            _listPNJ.Remove(P);
        }
        public void ReverseSize()
        {
            (Size[0], Size[1]) = (Size[1], Size[0]);
        }
        private void GeneratePositionAlea()
        {
            if (GetSomeRandomNumber(2) == 0)
            {
                ReverseSize();
            }
            while (!PositionClear(M) || Coordinate == new int[] { -1, -1 })
            {
                Coordinate[0] = GetSomeRandomNumber(M.Nbl - Size[1] - 1); // Génération aléatoire de la position en x
                Coordinate[1] = GetSomeRandomNumber(M.Nbc - Size[0] - 1); // Génération aléatoire de la position en y
            }
            ExtendBat(M);
        }
        private void GeneratePosition(int[] coordinate)
        {
            Coordinate = coordinate;
            if (PositionClear(M))
            {
                ExtendBat(M);
            }
            else { GeneratePositionAlea(); }
        }
        private bool PositionClear(GameSimulation M)
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
        private void ExtendBat(GameSimulation M)
        {
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    M.Map[Coordinate[0] + i, Coordinate[1] + j] = this;
                }
            }
        }
        protected void GenerateStat()
        {
            HealthPoint = HealthPointMax;
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
            chres += "Level : " + Level + "\n";
            chres += "HP : " + HealthPoint + " / " + HealthPointMax + "\n";
            chres += "Position : " + Coordinate[0] + " , " +Coordinate[1] + "\n";
            return chres;
        }
    }
}
