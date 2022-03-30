﻿using System;

namespace JeuColony.Batiments
{
    abstract class Batiment
    {
        public int[] Size { get; } = new int[] { -1, -1 }; // size in a tab, Size[0] is the height, Size[1] is the width
        public int[] Coordinate { get; protected set; } = new int[] { -1, -1 };//coordinate x and y
        private bool State { get; set; } //bat is impossible to use because of a degradation
        protected int Level { get; set; }
        protected int CapacityMax { get; }
        protected int HealthMax { get; set; }
        protected int Health { get; set; }
        private readonly GameSimulation M;
        private static readonly Random random = new Random();
        public void ReverseSize()
        {
            (Size[0], Size[1]) = (Size[1], Size[0]);
        }
        public static int GetSomeRandomNumber(int max)
        {
            return random.Next(max);
        }
        public Batiment(int[] size, bool state, GameSimulation Map)
        {
            Size = size;
            M = Map;
            State = state;
            Level = 1;
            //_state = true; //by default the batiment is functional at its creation
            GeneratePositionAlea();
        }
        public Batiment(int[] size, int[] coordinate, bool state, GameSimulation Map)
        {
            Size = size;
            M = Map;
            State = state;
            Level = 1;
            //_state = true; //by default the batiment is functional at its creation
            GeneratePosition(coordinate);
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
                        if (M.Mat[Coordinate[0] + i, Coordinate[1] + j] is Batiment)
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
                    M.Mat[Coordinate[0] + i, Coordinate[1] + j] = this;
                }
            }
        }
        protected abstract void GenerateStat();

        protected virtual string AfficheStatBatiment(int n, int[] tab, bool b, int p)
        {
            string chRes = "";
            chRes += " # " /*\n####"*/;
            return chRes;
        }
    }
}
