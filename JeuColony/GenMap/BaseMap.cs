﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;

namespace JeuColony.GenMap
{
    class BaseMap
    {
        private int _nbl, _nbc;
        private object[,] _mat;
        private List<Batiments.Batiment> _listeBatiments;
        public BaseMap()
        {
            Console.SetWindowSize(85, 33);
            _nbc = 5;
            _nbl = 5;
            this.GenerateSquare();
            this.GenerateBatiments();
        }
        public void GenerateSquare()
        {
            _mat = new object[_nbl, _nbc];
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    _mat[i, j] = new object();
                }
            }

        }
        public void GenerateBatiments()
        {
            Random r = new Random();
            int nb;
            int nbMaxBatiments = 20;
            nb = r.Next(0, nbMaxBatiments);


            for (int i = 0; i < nb; i++)
            {
                
            }





        }
        public void GenerateABatiment(Batiments.Batiment B, Random r)
        {
            int posx = r.Next(0, _nbl - 1); // Génération aléatoire de la position en x
            int posy = r.Next(0, _nbc - 1); // Génération aléatoire de la position en y
            int[] tab = { posx, posy };
            _listeBatiments.Add(B.GenerateBatiment(1, tab, true, 1));// dortoir premier batiment
        }
        public override string ToString()
        {
            String chRes = "";
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    chRes += " . ";
                }
                chRes += "\n";
            }
            return chRes;
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}